using DataBase;
using DataBase.Configurations;
using DynamicApiController;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DataBaseApi
{
    public static class Dependency
    {
        public static IServiceCollection AddEntityRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("Database")))
                .AddScoped(typeof(DbContext), typeof(DatabaseContext))
                .AddDatabaseRepositories()
                .AddCrudInfrastructure(assemblyNameThatContainsDbContextModels: "DataBase");

            return services;
        }
    }
}
