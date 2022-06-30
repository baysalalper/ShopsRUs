namespace Core.UnitTest.Services.Category.GetGroceryCategories;

using AutoFixture;
using Core.Services.Category;
using Dtos;
using Microsoft.Extensions.Logging;
using Moq;
using Repositories;

public class Given
{
    protected Fixture Fixture;
    protected List<CategoryEntity> RepositoryResponse;
    protected List<int> ServiceResponse;
    protected Mock<IRepository<CategoryEntity>> Repository;
    protected Mock<ILogger<CategoryService>> Logger;
    protected CategoryService Service;

    public Given()
    {
        Fixture = new Fixture();
        Repository = new Mock<IRepository<CategoryEntity>>();
        Logger = new Mock<ILogger<CategoryService>>();
        Service = new CategoryService(Repository.Object, Logger.Object);
    }
}