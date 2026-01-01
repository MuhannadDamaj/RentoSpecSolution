using SQLite;
using System.IO;

namespace RentospectMobileApp.DBService.Services
{
    public abstract class BaseDBService
    {
        protected static readonly SQLiteAsyncConnection Db;

        static BaseDBService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "rentospect.db3");
            Db = new SQLiteAsyncConnection(dbPath);
        }
    }
}