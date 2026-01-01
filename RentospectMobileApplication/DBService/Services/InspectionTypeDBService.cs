using RentospectMobileApp.DBService.Contracts;
using RentospectMobileApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace RentospectMobileApp.DBService.Services
{
    public class InspectionTypeDBService : BaseDBService, IInspectionTypeDBService
    {
        public InspectionTypeDBService(SQLiteAsyncConnection db) { }

        public async Task<List<InspectionType>> GetInspectionTypesAsync()
        {
            return await Db.Table<InspectionType>().Where(x => x.IsActive).ToListAsync();
        }
    }
}
