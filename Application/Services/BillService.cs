namespace Application.Services;

using Builders;
using Core.Services.Category;
using Core.Services.Product;
using Core.Services.User;
using Core.Services.UserGroup;
using Dtos.Request;
using Dtos.Response;

public class BillService : IBillService
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly IUserService _userService;
    private readonly IUserGroupService _userGroupService;

    public BillService(ICategoryService categoryService, IProductService productService, IUserService userService, IUserGroupService userGroupService)
    {
        _categoryService = categoryService;
        _productService = productService;
        _userService = userService;
        _userGroupService = userGroupService;
    }

    public async Task<GetBillResponseDto> GetBill(GetBillRequestDto request)
    {
        var user = await _userService.GetUser(request.UserId);
        var product = await _productService.GetProductBySku(request.ProductSku);

        var builder = new BillResponseBuilder();
        var userGroups = await _userGroupService.GetUserGroups();
        var groceryCategories = await _categoryService.GetGroceryCategories();

        var response = builder.Begin()
            .SetDefaultCustomerInfo(user)
            .SetDefaultProductInfo(product)
            .SetPriceWithDiscount(user, product, userGroups, groceryCategories)
            .Build();

        return response;
    }
}