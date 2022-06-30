namespace Core.Dtos;

[BsonCollection("UserGroup")]
public class UserGroupEntity : BaseEntity
{
    public string GroupName { get; set; }
    public int DiscountRate { get; set; }
}