using DataBase.Model;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataBase.Repositories
{
    internal class ServerRepository : BaseGenericCrudRepository<Server>
    {
        public ServerRepository(DbContext context)
        : base(context) { }

        protected override IQueryable<Server> Get()
        {
            return entities
                .Include(e => e.DatabaseDefinitions)
                .ThenInclude(e => e.BackUpTargets);
        }
    }
}
