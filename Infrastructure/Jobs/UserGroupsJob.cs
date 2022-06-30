namespace Infrastructure.Jobs;

using Core.Services.UserGroup;
using Microsoft.Extensions.Hosting;

public class UserGroupsJob : BackgroundService
{
    private readonly IUserGroupService _userGroupService;

    public UserGroupsJob(IUserGroupService userGroupService)
    {
        _userGroupService = userGroupService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _userGroupService.FillUserGroups();
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}