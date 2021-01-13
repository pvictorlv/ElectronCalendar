using System.Threading.Tasks;
using ElectronCalendar.Database.Data;

namespace ElectronCalendar.Database.Services.Interface
{
    public class BaseService
    {
        protected DatabaseContext DbContext;

        public BaseService(DatabaseContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task Update<T>(T entity, bool commit = false)
        {
            DbContext.Update(entity);
            if (commit)
                await Commit();
        }

        public async Task Add<T>(T entity, bool commit = false)
        {
            await DbContext.AddAsync(entity);
            if (commit)
                await Commit();
        }

        public async Task Commit()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}