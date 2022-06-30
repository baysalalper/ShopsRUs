namespace Infrastructure.Repositories;

using Core.Dtos;
using Core.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

public class BaseRepository<T> : IRepository<T> 
    where T : BaseEntity
    {
        private readonly IMongoCollection<T> _mongoCollection;
        public BaseRepository(IMongoDatabase mongo)
        {
            var collectionName = GetCollectionName();
            _mongoCollection =
                mongo.GetCollection<T>(collectionName);
        }
        public async Task<List<T>> GetItems()
        {
            var query=  await _mongoCollection.FindAsync(Builders<T>.Filter.Empty);
            return query.ToList();
        }

        public async Task<T> GetItem(string key, string value )
        {
            var filter = new BsonDocument { { key, new BsonRegularExpression(value, "i") } };

            return await _mongoCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetItem(string key, int value)
        {
            var filterDefinition = Builders<T>.Filter.Empty;
            
            filterDefinition &= new BsonDocument("$expr",
                new BsonDocument("$regexMatch",
                    new BsonDocument
                    {
                        { "input", new BsonDocument("$toString", $"${key}") },
                        { "regex", value.ToString() },
                        { "options", "i" }
                    }
                )
            );
            
            return await _mongoCollection.Find(filterDefinition).FirstOrDefaultAsync();
        }
        
        public async Task SaveItem(T item)
        {
            await _mongoCollection.InsertOneAsync(item);
        }

        public async Task UpdateItem(T item)
        {
            var filterBuilder = Builders<T>.Filter;
            var filter = filterBuilder.Eq(s => s.Id, item.Id);
            await _mongoCollection.ReplaceOneAsync(
                filter,
                item,
                new UpdateOptions { IsUpsert = true });
        }
        
        private static string GetCollectionName()
        {
            return (typeof(T).GetCustomAttributes(typeof(BaseEntity.BsonCollectionAttribute), true).FirstOrDefault()
                as BaseEntity.BsonCollectionAttribute).CollectionName;
        }
}