namespace Application.UnitTest.Services.Bill.GetBill;

using Application.Services;
using AutoFixture;
using Core.Dtos;
using Core.Services.Category;
using Core.Services.Product;
using Core.Services.User;
using Core.Services.UserGroup;
using Core.UnitTest.Helpers;
using Dtos.Request;
using Dtos.Response;
using Moq;

public class Given
{
    protected Fixture Fixture;
    protected Mock<ICategoryService> CategoryService;
    protected Mock<IProductService> ProductService;
    protected Mock<IUserService> UserService;
    protected Mock<IUserGroupService> UserGroupService;

    protected UserEntity User;
    protected ProductEntity Product;
    protected Dictionary<string, int> UserGroupResponse;
    protected List<int> CategoryResponse;

    protected string EmployeeKey = TestHelper.RandomString();
    protected int EmployeeDiscount = 30;

    protected string AffiliateKey = TestHelper.RandomString();
    protected int AffilateDiscount = 20;

    protected decimal ProductPrice = 200;

    protected GetBillResponseDto ResponseDto;
    protected GetBillRequestDto RequestDto;
    protected BillService BillService;

    public Given()
    {
        Fixture = new Fixture();
        CategoryService = new Mock<ICategoryService>();
        ProductService = new Mock<IProductService>();
        UserService = new Mock<IUserService>();
        UserGroupService = new Mock<IUserGroupService>();

        BillService = new BillService(CategoryService.Object, ProductService.Object, UserService.Object, UserGroupService.Object);
    }
}