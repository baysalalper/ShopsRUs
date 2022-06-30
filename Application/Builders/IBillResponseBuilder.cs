namespace Application.Builders;

using Core.Dtos;
using Core.Services.Category;
using Core.Services.UserGroup;
using Dtos.Request;
using Dtos.Response;

public interface IBillResponseBuilder
{
    IBillResponseBuilder Begin();
    IBillResponseBuilder SetDefaultCustomerInfo(UserEntity user);
    IBillResponseBuilder SetDefaultProductInfo(ProductEntity product);

    IBillResponseBuilder SetPriceWithDiscount(UserEntity user, ProductEntity product, Dictionary<string, int> userGroups,
        List<int> groceryCategories);

    GetBillResponseDto Build();

}