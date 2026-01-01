using RentospectMobileApp.DBService.Contracts;
using RentospectMobileApp.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.DBService.Services
{
    public class InspectionDBService : BaseDBService,IInspectionDBService
    {
        public InspectionDBService(SQLiteAsyncConnection db) { }
        public async Task<List<Inspection>> GetInspectionsAsync()
        {
            var userIdString = await SecureStorage.GetAsync("user_id");
            return await Db.Table<Inspection>()
                           .Where(x => x.IsActive && x.UserID.Equals(userIdString))
                           .OrderByDescending(x => x.InspectionDate)
                           .ToListAsync();
        }
    }
}
