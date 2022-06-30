namespace Core.UnitTest.Services.User.GetUser;

using Exceptions;
using Helpers;
using Models.Consts;
using Moq;

public class When_user_doesnt_exist : Given, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        UserId = TestHelper.RandomString();
        RepositoryResponse = null;
        
        Repository.Setup(s => s.GetItem(RepoFilterKeys.UserFilterKey, UserId)).ReturnsAsync(RepositoryResponse);
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;    
    }
    
    [Fact]
    public void should_throw_exception()
    {
        Assert.ThrowsAsync<UserDoesntExistException>(async () => await Service.GetUser(UserId));
    }
}