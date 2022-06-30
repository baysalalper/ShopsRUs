namespace Core.Services.Category;

using Dtos;
using Extensions;
using Microsoft.Extensions.Logging;
using Models.Consts;
using Repositories;

public class CategoryService : ICategoryService
{
    private readonly IRepository<CategoryEntity> _repository;
    private List<int> _categories;
    private readonly ILogger<CategoryService> _logger;

    public CategoryService(IRepository<CategoryEntity> repository, ILogger<CategoryService> logger)
    {
        _categories = new List<int>();
        _repository = repository;
        _logger = logger;
    }
    
    public async Task FillGroceryCategories()
    {
        try
        {
            var categories = await _repository.GetItems();

            if (categories is null || !categories.IsAny())
            {
                return;
            }

            _categories = categories.Select(x => x.CategoryId).ToList();
        }
        catch(Exception ex)
        {
            _logger.LogError($"{LogMessages.CategoryJobFailed} + StackTrace: {ex.StackTrace} ");
        }
    }
    
    public async Task<List<int>> GetGroceryCategories()
    {
        return _categories;
    }
}