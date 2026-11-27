namespace PhotoOrganizer.Models;

public partial class PhotoGroup(string title) : ObservableCollection<Photo> {
    
    public string Title { get; set; } = title;
}