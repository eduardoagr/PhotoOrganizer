namespace PhotoOrganizer.Models.Dtos;

[Table("photos")]
public class PhotoDto : BaseModel {

    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("title")]
    public string Title { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("location_description")]
    public string LocationDescription { get; set; }

    [Column("tag_id")]
    public int TagId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("device_id")]
    public string DeviceId { get; set; }

    [Column("file_path")]
    public string filePath { get; set; }
}