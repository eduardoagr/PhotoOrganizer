using CommunityToolkit.Mvvm.Messaging.Messages;

using Tag = PhotoOrganizer.Models.Tag;

namespace PhotoOrganizer.ViewModels;

public partial class CreatePhotoViewModel(
    IMediaService media, IGeolocation geolocation, IGeocoding geocoding, IShellService shellService,
    IAuthService authService, IBucketsService bucketsService, IMessenger messenger,
    ITagService tagService, ITagStore tagStore, ISupabaseDataService supabaseDataService, NewTagDialogView views) : ObservableObject {
    private bool isInitialized;

    [ObservableProperty]
    public partial Profile? CurrentProfile { get; set; }

    [ObservableProperty]
    public partial Photo Photo { get; set; } = new();

    [ObservableProperty]
    public partial bool IsPhotoEmpty { get; set; } = true;

    [ObservableProperty]
    public partial bool IsPhotoTaken { get; set; } = false;

    [ObservableProperty]
    public partial Tag? SelectedTag { get; set; }

    [ObservableProperty]
    public partial bool IsCreatingNewTag { get; set; }

    [ObservableProperty]
    public partial bool IsDropDownOpen { get; set; }

    public ObservableCollection<Tag> Tags => tagStore.Tags;

    [RelayCommand]
    private async Task Initialize() {

        if(isInitialized)
            return;

        await authService.InitializeAsync();

        RegisterMessages();

        isInitialized = true;

        if(authService.IsAuthenticated) {
            CurrentProfile = await authService.GetCurrentProfileAsync();
            await LoadTagsAsync();
            return;
        }

        UpdateTags([]);
        messenger.Send(MessengerKeys.LoginRequested);
    }

    [RelayCommand]
    public void ShowAccountDialog() {
        messenger.Send(MessengerKeys.ShowAccountDialog);
    }



    [RelayCommand]
    private async Task TakePhotoAsync() {
        try {
            var photo = await media.TakePhotoAsync(new PhotoCaptureOptions {
                Instructions = "Remember to smile!",
                ShowConfirmation = false
            });

            if(photo is null)
                return;

            var locationText = await GetPhotoLocationAsync();

            var path = Path.Combine(
                FileSystem.CacheDirectory,
                $"{Guid.NewGuid()}.jpg");

            await photo.SaveAsync(path);

            Photo.PhotoPath = path;
            Photo.LocationDescription = locationText;

            IsPhotoEmpty = false;
            IsPhotoTaken = true;

        } catch(Exception ex) {
            await shellService.DisplayAlertAsync(
                "Error",
                $"Failed to take photo: {ex.Message}",
                "OK");
        }
    }

    [RelayCommand]
    public void CreateNewTag() {
        IsDropDownOpen = false;
        views.IsOpen = true;
    }

    [RelayCommand]
    private async Task SavePictureAsync() {
        if(string.IsNullOrWhiteSpace(Photo.PhotoPath) || SelectedTag == null) {
            await shellService.DisplayAlertAsync(
                "Error",
                "Please take a photo and select a tag before saving.",
                "OK");

            return;
        }

        var fileName = Guid.NewGuid().ToString();

        Photo.FilePath = await bucketsService.UploadFileAsync(
            Photo.PhotoPath,
            fileName);

        var photoDto = new PhotoDto {
            UserId = CurrentProfile!.Id,
            TagId = SelectedTag.Id,
            Title = Photo.Title,
            Description = Photo.Description,
            LocationDescription = Photo.LocationDescription,
            FilePath = Photo.FilePath,
            CreatedAt = DateTime.UtcNow
        };

        await supabaseDataService.InsertPhotoAsync(photoDto);

        await shellService.DisplayAlertAsync(
            "Success",
            "Photo saved successfully!",
            "OK");

        ResetFields();

    }



    private async Task<string> GetPhotoLocationAsync() {

        try {
            var location = await geolocation.GetLocationAsync();

            if(location is null)
                return string.Empty;

            var places = await geocoding.GetPlacemarksAsync(location);

            var place = places?.FirstOrDefault();

            if(place is null)
                return string.Empty;

            return $"{place.Thoroughfare} {place.SubThoroughfare}, " +
                   $"{place.PostalCode}, {place.Locality}, {place.CountryName}";
        } catch {
            return string.Empty;
        }
    }




    private void UpdateTags(IEnumerable<Tag> userTags) {

        var tags = TagsSeed.InitialTags
            .Concat(userTags)
            .OrderBy(tag => tag.Name)
            .ToList();

        Tags.Clear();

        foreach(var tag in tags)
            Tags.Add(tag);
    }

    private void ResetFields() {
        Photo = new Photo();
        IsPhotoTaken = false;
        SelectedTag = null;
    }


    private void RegisterMessages() {

        if(!messenger.IsRegistered<ValueChangedMessage<Tag>>(this)) {
            messenger.Register<CreatePhotoViewModel, ValueChangedMessage<Tag>>(
                this,
                async (recipient, message) => {

                    await recipient.LoadTagsAsync();

                    recipient.SelectedTag = recipient.Tags.FirstOrDefault(
                        tag => tag.Id == message.Value.Id);
                });
        }

        if(!messenger.IsRegistered<ValueChangedMessage<Profile>>(this)) {
            messenger.Register<CreatePhotoViewModel, ValueChangedMessage<Profile>>(
                this,
                async (recipient, message) => {

                    recipient.CurrentProfile = message.Value;

                    await recipient.LoadTagsAsync();
                });
        }
    }

    private async Task LoadTagsAsync() {
        var userTags = await tagService.GetTagsAsync();
        UpdateTags(userTags);
    }
}