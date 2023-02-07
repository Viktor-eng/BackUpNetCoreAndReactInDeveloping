using DataBase.Model;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataBase.Repositories
{
    internal class BackUpHistoryRepository : BaseGenericCrudRepository<BackUpHistory>
    {
        public BackUpHistoryRepository(DbContext context)
        : base(context) { }

        protected override IQueryable<BackUpHistory> Get()
        {
            return entities
                .Include(e => e.BackUpHistoryLogs);
        }
    }
}
