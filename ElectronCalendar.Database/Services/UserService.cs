using ElectronCalendar.Database.Data;
using ElectronCalendar.Database.Entities;
using ElectronCalendar.Database.Services.Interface;

namespace ElectronCalendar.Database.Services
{
    public class UserService : BaseService
    {
        public UserService(DatabaseContext dbContext) : base(dbContext)
        {
        }


    }
}