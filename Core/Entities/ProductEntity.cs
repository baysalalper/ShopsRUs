namespace Core.Dtos;

using MongoDB.Bson.Serialization.Attributes;

[BsonCollection("Product")]
public class ProductEntity : BaseEntity
{
    public string Name { get; set; }
    public string Sku { get; set; }
    public int CategoryId { get; set; }
    public decimal UnitPrice { get; set; }
}