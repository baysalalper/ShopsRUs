namespace Core.UnitTest.Services.User.GetUser;

using AutoFixture;
using Core.Services.User;
using Dtos;
using Moq;
using Repositories;

public class Given
{
    protected Fixture Fixture;
    protected string UserId;
    protected UserEntity RepositoryResponse;
    protected UserEntity ServiceResponse;
    protected Mock<IRepository<UserEntity>> Repository;
    protected UserService Service;

    public Given()
    {
        Fixture = new Fixture();
        Repository = new Mock<IRepository<UserEntity>>();
        Service = new UserService(Repository.Object);
    }
}