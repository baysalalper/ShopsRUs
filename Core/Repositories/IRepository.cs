namespace Core.Repositories;

public interface IRepository<T>
{
    Task<List<T>> GetItems();
    Task<T> GetItem(string key, string value);
    Task<T> GetItem(string key, int value);
    Task SaveItem(T item);
    Task UpdateItem(T item);
}