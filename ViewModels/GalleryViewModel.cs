using Photo = PhotoOrganizer.Models.Photo;

namespace PhotoOrganizer.ViewModels;

public partial class GalleryViewModel(
    ISupabaseDataService dataService,
    IShare share,
    ICreateExcel notesExcel,
    FilterPopupView views) : ObservableObject {

    public ObservableCollection<Photo> Photos { get; } = [];

    public ObservableCollection<PhotoGroup> PhotoGroups { get; } = [];


    [RelayCommand]
    private async Task InitializeAsync() {
        var photoDtos = await dataService.GetPhotosAsync();

        var photos = new List<Photo>();

        foreach(var dto in photoDtos) {
            photos.Add(new Photo {
                Id = (int)dto.Id,
                TagId = dto.TagId,
                Title = dto.Title ?? string.Empty,
                Description = dto.Description ?? string.Empty,
                LocationDescription = dto.LocationDescription ?? string.Empty,
                FilePath = dto.FilePath,
                CreatedAt = dto.CreatedAt
            });
        }

        // Sort newest first
        photos.Sort((a, b) => Nullable.Compare(b.CreatedAt, a.CreatedAt));

        PhotoGroups.Clear();

        DateTime? currentMonth = null;
        PhotoGroup? currentGroup = null;

        foreach(var photo in photos) {
            DateTime? photoDate = photo.CreatedAt?.ToLocalTime();

            DateTime? monthKey = photoDate.HasValue
                ? new DateTime(photoDate.Value.Year, photoDate.Value.Month, 1)
                : null;

            if(currentGroup == null || currentMonth != monthKey) {
                string title = photoDate?.ToString("MMMM yyyy") ?? "Unknown date";

                currentGroup = new PhotoGroup(title);
                PhotoGroups.Add(currentGroup);

                currentMonth = monthKey;
            }

            currentGroup.Add(photo);
        }
    }


    [RelayCommand]
    private void FilterPopupOpen() {
        views.IsOpen = true;
    }

    [RelayCommand]
    private async Task OpenPhotoDetailAsync(string photoPath) => new PhotoBrowsers.PhotoBrowser {
        Photos =
        [
            new() {
                URL = photoPath
            }
        ]
    }.Show();
}