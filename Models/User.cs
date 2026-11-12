namespace PhotoOrganizer.Models;

[Table("users")]
public class User : BaseModel {

    [PrimaryKey("id", false)]
    public Guid Id { get; set; }

    [Column("device_id")]
    public string DeviceId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}