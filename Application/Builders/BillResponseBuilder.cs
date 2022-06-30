namespace Application.Builders;

using Core.Dtos;
using Core.Extensions;
using Dtos.Response;
using CustomerInfoObj = Dtos.Response.CustomerInfoObj;

public class BillResponseBuilder : IBillResponseBuilder
{
    private GetBillResponseDto _responseDto;
    
    public IBillResponseBuilder Begin()
    {
        _responseDto = new GetBillResponseDto();
        return this;
    }

    public IBillResponseBuilder SetDefaultCustomerInfo(UserEntity user)
    {
        _responseDto.CustomerInfo = new CustomerInfoObj()
        {
            Address = user.Address,
            CustomerName = user.FullName
        };

        return this;
    }

    public IBillResponseBuilder SetDefaultProductInfo(ProductEntity product)
    {
        _responseDto.Product = new ProductObj
        {
            Name = product.Name,
            Price = product.UnitPrice
        };

        return this;
    }

    public IBillResponseBuilder SetPriceWithDiscount(UserEntity user, ProductEntity product, Dictionary<string, int> userGroups,
        List<int> groceryCategories)
    {
        var discountedPrice = product.UnitPrice;
        if(!groceryCategories.Contains(product.CategoryId))
        {
            var discount = decimal.Zero;
            var eligableDiscounts = userGroups.Where(x => user.UserGroups.Contains(x.Key))
                .Select(y => y.Value).ToList();

            if (eligableDiscounts.IsAny())
            {
                discount = discountedPrice * eligableDiscounts.Max() / 100;
            }
            else if(DateTime.Now.Year - user.RegistrationDate.Year >= 2)
            {
                discount = discountedPrice * 5 / 100;
            }
            discountedPrice -= discount;
        }
        var extraDiscount = ((int) discountedPrice / 100) * 5;

        discountedPrice -= extraDiscount;

        _responseDto.Product.DiscountedPrice = discountedPrice;

        return this;
    }

    public GetBillResponseDto Build()
    {
        return _responseDto;
    }
}