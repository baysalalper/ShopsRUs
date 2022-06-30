namespace Core.UnitTest.Services.Product.GetProductBySku;

using AutoFixture;
using Dtos;
using FluentAssertions;
using Helpers;
using Models.Consts;
using Moq;

public class When_everything_is_ok : Given, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        Sku = TestHelper.RandomString();
        RepositoryResponse = Fixture.Build<ProductEntity>().Create();
        
        Repository.Setup(s => s.GetItem(RepoFilterKeys.ProductKey, Sku)).ReturnsAsync(RepositoryResponse);

        ServiceResponse = await Service.GetProductBySku(Sku);
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;    
    }

    [Fact]
    public void repository_get_method_should_call_once()
    {
        Repository.Verify(x => x.GetItem(RepoFilterKeys.ProductKey, Sku), Times.Once);
    }
    
    [Fact]
    public void response_name_should_be_mapped_correctly()
    {
        ServiceResponse.Name.Should().Be(RepositoryResponse.Name);
    }
    
    [Fact]
    public void response_categoryId_should_be_mapped_correctly()
    {
        ServiceResponse.CategoryId.Should().Be(RepositoryResponse.CategoryId);
    }
    
    [Fact]
    public void response_unitprice_should_be_mapped_correctly()
    {
        ServiceResponse.UnitPrice.Should().Be(RepositoryResponse.UnitPrice);
    }
    
    [Fact]
    public void response_sku_should_be_mapped_correctly()
    {
        ServiceResponse.Sku.Should().Be(RepositoryResponse.Sku);
    }
}