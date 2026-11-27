using Photo = PhotoOrganizer.Models.Photo;

namespace PhotoOrganizer.ViewModels;

public partial class GalleryViewModel(
    ISupabaseDataService dataService,
    IShare share,
    ICreateExcel notesExcel,
    FilterPopupView views) : ObservableObject {

    public ObservableCollection<Photo> Photos { get; } = [];

    [RelayCommand]
    void FilterPopupOpen() {
        views.IsOpen = true;
    }

    //    [RelayCommand]
    //    private async Task FilterByTagAsync(Tag tag) {

    //        foreach(var t in Tags)
    //            t.isSelected = false;

    //        tag.isSelected = true;

    //        var photos = tag.Name == "All"
    //            ? await dataService.GetAllPhotosAsync()
    //            : await dataService.GetPhotosByTagAsync(tag.Id);

    //        Photos.Clear();

    //        foreach(var photo in photos)
    //            Photos.Add(photo.ToModel());
    //    }

    //    private void SortTags() {

    //        var sortedTags = Tags
    //            .OrderBy(t => t.Name == "All" ? 0 : 1)
    //            .ThenBy(t => t.Name)
    //            .ToList();

    //        Tags.Clear();

    //        foreach(var tag in sortedTags)
    //            Tags.Add(tag);
    //    }

    //    [RelayCommand]
    //    private async Task OpenPhotoDetailAsync(string photoPath) => new PhotoBrowsers.PhotoBrowser {
    //        Photos =
    //            [
    //        new() {
    //            URL = photoPath
    //        }
    //    ]
    //    }.Show();
    //}
}




