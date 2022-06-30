namespace Core.Dtos;

using MongoDB.Bson.Serialization.Attributes;

public class BaseEntity
{
    public BaseEntity()
    {
    }
    public BaseEntity(Guid id)
    {
        Id = id;
    }

    [BsonId]
    [BsonIgnoreIfDefault]
    public Guid Id { get; set; }
        
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute : Attribute
    {
        private string _collectionName;
        public BsonCollectionAttribute(string collectionName)
        {
            _collectionName = collectionName;
        }
        public string CollectionName => _collectionName;
    }
}