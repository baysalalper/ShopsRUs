namespace Infrastructure.Jobs;

using Core.Services.Category;
using Core.Services.UserGroup;
using Microsoft.Extensions.DependencyInjection;

public static class JobExtension
{
    public static IServiceCollection AddUserGroupsJob(this IServiceCollection services)
        {
            return services.AddSingleton<IUserGroupService, UserGroupService>().AddHostedService<UserGroupsJob>();
        }

    public static IServiceCollection AddCategoriesJob(this IServiceCollection services)
    {
        return services.AddSingleton<ICategoryService, CategoryService>().AddHostedService<CategoriesJob>();
    }
}