namespace PhotoOrganizer.ViewModels;

public partial class CreatePhotoViewModel(
    IMediaService media,
    IGeolocation geolocation,
    IGeocoding geocoding,
    IShellService shellService,
    ISupabaseDataService supabaseDataService,
    IUserService userService,
    IBucketsService bucketsService,
    NewTagDialogView views) : ObservableObject {

    [ObservableProperty]
    public Photo photo = new();

    [ObservableProperty]
    public partial bool IsPhotoEmpty { get; set; } = true;

    [ObservableProperty]
    public partial bool IsPhotoTaken { get; set; } = false;

    [ObservableProperty]
    public partial Tag SelectedTag { get; set; }

    [ObservableProperty]
    public partial bool IsCreatingNewTag { get; set; }

    public ObservableCollection<Tag> Tags { get; } = [];

    [RelayCommand]
    private async Task Initializa() {

        var tagsDto = await supabaseDataService.UploadInitialTagsAsync(userService);

        var ordered = tagsDto
            .Where(t => t.TagName != "All")
            .OrderBy(t => t.TagName == "New tag" ? 1 : 0)
            .ThenBy(t => t.TagName);

        Tags.Clear();

        foreach(var dto in ordered) {
            Tags.Add(dto.ToModel());
        }
    }

    [RelayCommand]
    public async Task PhotoCaptured(Stream stream) {
        try {
            var photo = await media.TakePhotoAsync(new PhotoCaptureOptions {
                Instructions = "Remeber to smile",
                ShowConfirmation = false
            });

            if(photo is not null) {

                var path = Path.Combine(FileSystem.CacheDirectory, $"{Guid.NewGuid()}.jpg");
                await photo.SaveAsync(path);
                Photo.PhotoPath = path;


                string locationText = string.Empty;

                var location = await geolocation.GetLocationAsync();
                if(location != null) {
                    var places = await geocoding.GetPlacemarksAsync(location);
                    var place = places?.FirstOrDefault();
                    if(place != null) {
                        locationText =
                            $"{place.Thoroughfare} {place.SubThoroughfare}, " +
                            $"{place.PostalCode}, {place.Locality}, {place.CountryName}";
                    }
                }

                IsPhotoEmpty = false;
                IsPhotoTaken = true;
                Photo.LocationDescription = locationText;
            }
        } catch(Exception ex) {
            await shellService.DisplayAlertAsync(
                "Error", $"Failed to take photo: {ex.Message}", "OK");
        }
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

        var user = await userService.GetCurrentUserAsync();
        var deviceId = user.DeviceId;

        var storagePath = await bucketsService.UploadFileAsync(
            Photo.PhotoPath,
            deviceId,
            Photo.Title
        );

        Photo.DeviceId = deviceId;
        Photo.FilePath = storagePath;
        Photo.TagId = SelectedTag.Id;

        var dto = Photo.ToDto();
        dto.CreatedAt = DateTime.UtcNow;

        await supabaseDataService.InsertPhotoAsync(dto);

        await shellService.DisplayAlertAsync(
            "Success",
            "Photo note saved successfully.",
            "OK");

        ResetFields();
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