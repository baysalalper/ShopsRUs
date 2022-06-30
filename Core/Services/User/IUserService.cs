namespace Core.Services.User;

using Dtos;

public interface IUserService
{
    Task<UserEntity> GetUser(string id);
}