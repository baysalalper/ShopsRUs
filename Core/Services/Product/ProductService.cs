namespace Core.Services.Product;

using Dtos;
using Exceptions;
using Models.Consts;
using Repositories;

public class ProductService : IProductService
{
    private readonly IRepository<ProductEntity> _repository;

    public ProductService(IRepository<ProductEntity> repository)
    {
        _repository = repository;
    }

    public async Task<ProductEntity> GetProductBySku(string sku)
    {
        var product = await _repository.GetItem(RepoFilterKeys.ProductKey, sku);

        return product is not null 
            ? product 
            : throw new ProductDoesntExistException();
    }
}