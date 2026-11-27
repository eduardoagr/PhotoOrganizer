namespace PhotoOrganizer.Models.Dtos;

[Table("photos")]
public class PhotoDto : BaseModel {

    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("tag_id")]
    public long? TagId { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("location_description")]
    public string? LocationDescription { get; set; }

    [Column("file_path")]
    public string FilePath { get; set; } = string.Empty;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}