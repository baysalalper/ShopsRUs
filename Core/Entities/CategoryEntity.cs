namespace Core.Dtos;

[BsonCollection("Category")]
public class CategoryEntity : BaseEntity
{
    public int CategoryId { get; set; }
}