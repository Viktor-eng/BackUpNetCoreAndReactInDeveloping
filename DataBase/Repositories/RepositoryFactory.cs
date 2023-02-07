using DataBase.Model;
using GenericRepository;
using Microsoft.EntityFrameworkCore;


namespace DataBase.Repositories
{
    public class RepositoryFactory : UserDefinedRepositoryFactory
    {
        public RepositoryFactory(DbContext context) 
            : base(context) { }

        protected override object GetUserDefinedRepository<TEntity>(TEntity entity)
        {
            return entity switch
            {
                Server => Bind<ServerRepository>(),
                DatabaseDefinition => Bind<DatabaseDefenitionRepository>(),
                BackUpHistory => Bind<BackUpHistoryRepository>(),
                _ => default
            };
        }
    }
}
