using DataBase.Model;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataBase.Repositories
{
    internal class DatabaseDefenitionRepository : BaseGenericCrudRepository<DatabaseDefinition>
    {  
        public DatabaseDefenitionRepository(DbContext context)
        : base(context) { }

        protected override IQueryable<DatabaseDefinition> Get()
        {
            return entities
                .Include(e => e.BackUpTargets)
                .Include(e => e.ScheduleBackups);
        }
    }
}
