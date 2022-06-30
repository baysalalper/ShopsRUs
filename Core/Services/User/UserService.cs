namespace Core.Services.User;

using Dtos;
using Exceptions;
using Models.Consts;
using Repositories;

public class UserService : IUserService
{
    private readonly IRepository<UserEntity> _repository;

    public UserService(IRepository<UserEntity> repository)
    {
        _repository = repository;
    }

    public async Task<UserEntity> GetUser(string id)
    {
        var user = await _repository.GetItem(RepoFilterKeys.UserFilterKey, id);

        return user is not null 
            ? user 
            : throw new UserDoesntExistException();
    }
}