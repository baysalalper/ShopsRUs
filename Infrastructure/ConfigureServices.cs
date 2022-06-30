namespace Infrastructure;

using Core.Repositories;
using Jobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Repositories;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
        ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);

        var appsettings = configuration.GetSection("MongoSettings");
        var mongoClient = new MongoClient(appsettings["Uri"]);
        var mongoDatabase = mongoClient.GetDatabase(appsettings["DbName"]);

        services.AddSingleton(mongoDatabase);
        services.AddSingleton(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddUserGroupsJob();
        services.AddCategoriesJob();
        return services;
    }
}