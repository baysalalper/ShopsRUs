namespace Core.UnitTest.Services.Category.GetGroceryCategories;

using AutoFixture;
using Dtos;
using FluentAssertions;
using Models.Consts;
using Moq;

public class When_everything_is_ok : Given, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        RepositoryResponse = Fixture.Build<CategoryEntity>().CreateMany(3).ToList();
        
        Repository.Setup(s => s.GetItems()).ReturnsAsync(RepositoryResponse);

        await Service.FillGroceryCategories();
        
        ServiceResponse = await Service.GetGroceryCategories();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;    
    }

    [Fact]
    public void repository_get_method_should_call_once()
    {
        Repository.Verify(x => x.GetItems(), Times.Once);
    }
    
    [Fact]
    public void categoryIds_should_be_mapped_correctly()
    {
        ServiceResponse.Select(x => RepositoryResponse.Select(y => y.CategoryId.Should().Be(x)));
    }
}