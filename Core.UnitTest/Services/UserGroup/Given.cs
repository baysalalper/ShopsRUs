namespace Core.UnitTest.Services.UserGroup;

using AutoFixture;
using Core.Services.UserGroup;
using Dtos;
using Microsoft.Extensions.Logging;
using Moq;
using Repositories;

public class Given
{
    protected Fixture Fixture;
    protected List<UserGroupEntity> RepositoryResponse;
    protected Dictionary<string, int> ServiceResponse;
    protected Mock<IRepository<UserGroupEntity>> Repository;
    protected Mock<ILogger<UserGroupService>> Logger;

    protected UserGroupService Service;

    public Given()
    {
        Fixture = new Fixture();
        Repository = new Mock<IRepository<UserGroupEntity>>();
        Logger = new Mock<ILogger<UserGroupService>>();
        Service = new UserGroupService(Repository.Object, Logger.Object);
    }
}