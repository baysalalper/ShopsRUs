namespace Infrastructure.Jobs;

using Core.Services.Category;
using Microsoft.Extensions.Hosting;

public class CategoriesJob : BackgroundService
{
    private readonly ICategoryService _categoryService;

    public CategoriesJob(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _categoryService.FillGroceryCategories();
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}