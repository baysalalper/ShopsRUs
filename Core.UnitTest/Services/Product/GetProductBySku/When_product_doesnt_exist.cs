namespace Core.UnitTest.Services.Product.GetProductBySku;

using Exceptions;
using Helpers;
using Models.Consts;
using Moq;

public class When_product_doesnt_exist : Given, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        Sku = TestHelper.RandomString();
        RepositoryResponse = null;
        
        Repository.Setup(s => s.GetItem(RepoFilterKeys.ProductKey, Sku)).ReturnsAsync(RepositoryResponse);
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;    
    }
    
    [Fact]
    public void should_throw_exception()
    {
        Assert.ThrowsAsync<ProductDoesntExistException>(async () => await Service.GetProductBySku(Sku));
    }
}