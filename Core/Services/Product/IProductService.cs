namespace Core.Services.Product;

using Dtos;

public interface IProductService
{
    Task<ProductEntity> GetProductBySku(string sku);
}