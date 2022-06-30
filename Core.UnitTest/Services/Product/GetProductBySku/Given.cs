namespace Core.UnitTest.Services.Product.GetProductBySku;

using AutoFixture;
using Core.Services.Product;
using Dtos;
using Moq;
using Repositories;

public class Given
{
    protected Fixture Fixture;
    protected string Sku;
    protected ProductEntity RepositoryResponse;
    protected ProductEntity ServiceResponse;
    protected Mock<IRepository<ProductEntity>> Repository;
    protected ProductService Service;

    public Given()
    {
        Fixture = new Fixture();
        Repository = new Mock<IRepository<ProductEntity>>();
        Service = new ProductService(Repository.Object);
    }
}