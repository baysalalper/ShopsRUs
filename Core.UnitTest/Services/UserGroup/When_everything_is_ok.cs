namespace Core.UnitTest.Services.UserGroup;

using AutoFixture;
using Dtos;
using FluentAssertions;
using Moq;

public class When_everything_is_ok : Given, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        RepositoryResponse = Fixture.Build<UserGroupEntity>().CreateMany(3).ToList();
        
        Repository.Setup(s => s.GetItems()).ReturnsAsync(RepositoryResponse);

        await Service.FillUserGroups();
        
        ServiceResponse = await Service.GetUserGroups();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;    
    }

    [Fact]
    public void repository_get_method_should_call_once()
    {
        Repository.Verify(x => x.GetItems(), Times.Once);
    }
    
    [Fact]
    public void discountRates_should_be_mapped_correctly()
    {
        ServiceResponse.Values.Select(x => RepositoryResponse.Select(y => x.Should().Be(y.DiscountRate)));
    }
    
    [Fact]
    public void usergroupNames_should_be_mapped_correctly()
    {
        ServiceResponse.Keys.Select(x => RepositoryResponse.Select(y => x.Should().Be(y.GroupName)));
    }
}