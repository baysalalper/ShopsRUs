namespace Core.UnitTest.Services.User.GetUser;

using AutoFixture;
using Dtos;
using FluentAssertions;
using Helpers;
using Models.Consts;
using Moq;

public class When_everything_is_ok : Given, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        UserId = TestHelper.RandomString();
        RepositoryResponse = Fixture.Build<UserEntity>().Create();
        
        Repository.Setup(s => s.GetItem(RepoFilterKeys.UserFilterKey, UserId)).ReturnsAsync(RepositoryResponse);

        ServiceResponse = await Service.GetUser(UserId);
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;    
    }

    [Fact]
    public void repository_get_method_should_call_once()
    {
        Repository.Verify(x => x.GetItem(RepoFilterKeys.UserFilterKey, UserId), Times.Once);
    }
    
    [Fact]
    public void response_address_should_be_mapped_correctly()
    {
        ServiceResponse.Address.Should().Be(RepositoryResponse.Address);
    }
    
    [Fact]
    public void response_fullname_should_be_mapped_correctly()
    {
        ServiceResponse.FullName.Should().Be(RepositoryResponse.FullName);
    }
    
    [Fact]
    public void response_registrationdate_should_be_mapped_correctly()
    {
        ServiceResponse.RegistrationDate.Should().Be(RepositoryResponse.RegistrationDate);
    }
    
    [Fact]
    public void response_usergroups_should_be_mapped_correctly()
    {
        ServiceResponse.UserGroups.Select(x => RepositoryResponse.UserGroups.Select(y => x.Should().Be(y)));
    }
}