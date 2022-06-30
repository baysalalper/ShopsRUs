namespace Core.Services.UserGroup;

using Dtos;
using Extensions;
using Microsoft.Extensions.Logging;
using Models.Consts;
using Repositories;

public class UserGroupService : IUserGroupService
{
    private Dictionary<string, int> _userGroups;
    private readonly IRepository<UserGroupEntity> _repository;
    private readonly ILogger<UserGroupService> _logger;

    public UserGroupService(IRepository<UserGroupEntity> repository, ILogger<UserGroupService> logger)
    {
        _userGroups = new Dictionary<string, int>();
        _repository = repository;
        _logger = logger;
    }

    public async Task FillUserGroups()
    {
        try
        {
            var userGroups = await _repository.GetItems();

            if (userGroups is null || !userGroups.IsAny())
            {
                return;
            }

            _userGroups = userGroups.ToDictionary(x => x.GroupName, x => x.DiscountRate);
        }
        catch(Exception ex)
        {
            _logger.LogError($"{LogMessages.UserGroupJobFailed} + StackTrace: {ex.StackTrace} ");
        }
    }
    
    public async Task<Dictionary<string, int>> GetUserGroups()
    {
        return _userGroups;
    }
}