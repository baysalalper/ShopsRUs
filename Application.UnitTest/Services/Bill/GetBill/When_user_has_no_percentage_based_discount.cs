namespace Application.UnitTest.Services.Bill.GetBill;

using AutoFixture;
using Core.Dtos;
using Dtos.Request;
using FluentAssertions;
using Moq;

public class When_user_has_no_percentage_based_discount : Given, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        Product = Fixture.Build<ProductEntity>().With(x => x.UnitPrice, ProductPrice).Create();
        UserGroupResponse = Fixture.Build<Dictionary<string, int>>().Create();

        var registirationDate = DateTime.Today.AddYears(-1);
        User = Fixture.Build<UserEntity>().With(x => x.RegistrationDate, registirationDate).Create();

        CategoryResponse = Fixture.Build<List<int>>().Create();

        ProductService.Setup(x => x.GetProductBySku(It.IsAny<string>())).ReturnsAsync(Product);
        UserGroupService.Setup(x => x.GetUserGroups()).ReturnsAsync(UserGroupResponse);
        UserService.Setup(x => x.GetUser(It.IsAny<string>())).ReturnsAsync(User);
        CategoryService.Setup(x => x.GetGroceryCategories()).ReturnsAsync(CategoryResponse);

        RequestDto = Fixture.Build<GetBillRequestDto>().Create();

        ResponseDto = await BillService.GetBill(RequestDto);
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;    
    }

    [Fact]
    public void user_address_should_be_mapped()
    {
        ResponseDto.CustomerInfo.Address.Should().Be(User.Address);
    }
    
    [Fact]
    public void user_names_should_be_mapped()
    {
        ResponseDto.CustomerInfo.CustomerName.Should().Be(User.FullName);
    }
    
    [Fact]
    public void product_name_should_be_mapped()
    {
        ResponseDto.Product.Name.Should().Be(Product.Name);
    }
    
    [Fact]
    public void product_price_should_be_mapped()
    {
        ResponseDto.Product.Price.Should().Be(Product.UnitPrice);
    }
    
    [Fact]
    public void product_discounted_price_should_be_mapped()
    {
        ResponseDto.Product.DiscountedPrice.Should().Be(190);
    }
}