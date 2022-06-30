namespace Core.Services.UserGroup;

using Dtos;

public interface IUserGroupService
{
    Task FillUserGroups();
    Task<Dictionary<string, int>> GetUserGroups();
}