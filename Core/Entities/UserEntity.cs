namespace Core.Dtos;

[BsonCollection("User")]
public class UserEntity : BaseEntity
{
    public string FullName { get; set; }
    public string UserId { get; set; }
    public string Address { get; set; }
    public List<string> UserGroups { get; set; }
    public DateTime RegistrationDate { get; set; }
}