namespace PhotoOrganizer.Models.Dtos;

[Table("profiles")]
public class Profile : BaseModel {

    [PrimaryKey("id", true)]
    public Guid Id { get; set; }

    [Column("display_name")]
    public string? DisplayName { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("created_at", ignoreOnInsert: true, ignoreOnUpdate: true)]
    public DateTime CreatedAt { get; set; }
}