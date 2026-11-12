namespace PhotoOrganizer.Models.Dtos;

[Table("tags")]
public class TagDto : BaseModel {

    [PrimaryKey("tag_id", false)]
    public int Id { get; set; }

    [Column("tag_name")]
    public string TagName { get; set; }

    [Column("color")]
    public string Color { get; set; } = "#4285F4";

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}