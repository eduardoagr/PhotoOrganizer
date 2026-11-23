namespace PhotoOrganizer.ViewModels;

public partial class CreatePhotoViewModel(
    IMediaService media, IGeolocation geolocation, IGeocoding geocoding, IShellService shellService,
    IAuthService authService, IBucketsService bucketsService, IMessenger messenger,
    ITagService tagService, NewTagDialogView views) : ObservableObject {
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
    public partial Tag SelectedTag { get; set; }

    [ObservableProperty]
    public partial bool IsCreatingNewTag { get; set; }

    public ObservableCollection<Tag> Tags { get; set; } = [];

    [RelayCommand]
    private async Task Initialize() {

        if(isInitialized)
            return;

        await authService.InitializeAsync();

        isInitialized = true;

        if(authService.IsAuthenticated) {
            CurrentProfile = await authService.GetCurrentProfileAsync();

            var userTags = await tagService.GetTagsAsync();

            UpdateTags(userTags);
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


    //[RelayCommand]
    //private async Task SavePictureAsync() {
    //    if(string.IsNullOrWhiteSpace(Photo.PhotoPath) || SelectedTag == null) {
    //        await shellService.DisplayAlertAsync(
    //            "Error",
    //            "Please take a photo and select a tag before saving.",
    //            "OK");

    //        return;
    //    }

    //    var user = await userService.GetCurrentUserAsync();
    //    var deviceId = user.DeviceId;

    //    var storagePath = await bucketsService.UploadFileAsync(
    //        Photo.PhotoPath,
    //        deviceId,
    //        Photo.Title);

    //    Photo.DeviceId = deviceId;
    //    Photo.FilePath = storagePath;
    //    Photo.TagId = SelectedTag.Id;

    //    var dto = Photo.ToDto();
    //    dto.CreatedAt = DateTime.UtcNow;

    //    await supabaseDataService.InsertPhotoAsync(dto);

    //    await shellService.DisplayAlertAsync(
    //        "Success",
    //        "Photo note saved successfully.",
    //        "OK");

    //    ResetFields();
    //}

    private void UpdateTags(IEnumerable<Tag> userTags) {

        var tags = TagsSeed.InitialTags
            .Concat(userTags)
            .OrderBy(tag => tag.Name)
            .ToList();

        tags.Add(new Tag { Name = "New tag", Color = "#3600FF", Id = 10 });

        Tags.Clear();

        foreach(var tag in tags)
            Tags.Add(tag);
    }

    private void ResetFields() {
        Photo = new Photo();
        IsPhotoTaken = false;
        SelectedTag = null;
    }

    public void CreateNewTag() {
        views.IsOpen = true;
    }
}