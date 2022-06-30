namespace Core;

using Microsoft.Extensions.DependencyInjection;
using Services.Category;
using Services.Product;
using Services.User;
using Services.UserGroup;

public static class ConfigureServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IUserService), typeof(UserService));
        services.AddSingleton(typeof(IProductService), typeof(ProductService));
        services.AddSingleton(typeof(IUserGroupService), typeof(UserGroupService));
        services.AddSingleton(typeof(ICategoryService), typeof(CategoryService));
        return services;
    }
}