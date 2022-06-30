namespace Core.Services.Category;

public interface ICategoryService
{
    Task FillGroceryCategories();
    Task<List<int>> GetGroceryCategories();
}