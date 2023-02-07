using DataBase.Repositories;
using GenericRepository;
using Microsoft.Extensions.DependencyInjection;

namespace DataBase
{
    public static class Dependency
    {
        public static IServiceCollection AddDatabaseRepositories(this IServiceCollection services)
        {
            return services.AddTransient<IUserDefinedRepositoryFactory, RepositoryFactory>();
        }
    }
}
