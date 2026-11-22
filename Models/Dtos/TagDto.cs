namespace PhotoOrganizer.Models.Dtos;

[Table("tags")]
public class TagDto : BaseModel {

    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("color")]
    public string Color { get; set; } = "#515FD0";

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}