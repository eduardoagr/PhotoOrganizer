using Photo = PhotoOrganizer.Models.Photo;

namespace PhotoOrganizer.ViewModels;

public partial class GalleryViewModel(
    ISupabaseDataService dataService,
    IShare share,
    ICreateExcel notesExcel) : ObservableObject {

    public ObservableCollection<Tag> Tags { get; } = [];

    public ObservableCollection<Photo> Photos { get; } = [];

    public bool IsLoaded { get; private set; }

    //    [RelayCommand]
    //    private async Task LoadTagsAsync() {

    //        var user = await userService.GetCurrentUserAsync();

    //        var tags = await dataService.GetAllTagsAsync(user.Id);

    //        var orderedTags = tags
    //            .Where(t => t.TagName != "New tag")
    //            .OrderBy(t => t.TagName == "All" ? 0 : 1)
    //            .ThenBy(t => t.TagName);

    //        foreach(var dto in orderedTags) {
    //            if(Tags.Any(t => t.Id == dto.Id))
    //                continue;

    //            Tags.Add(dto.ToModel());
    //        }

    //        SortTags();
    //    }

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




