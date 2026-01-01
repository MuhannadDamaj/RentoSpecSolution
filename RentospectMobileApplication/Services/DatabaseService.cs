using RentospectMobileApp.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;
        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
        }
        public async Task InitAsync()
        {
            await _db.CreateTableAsync<Branch>();
            await _db.CreateTableAsync<Car>();
            await _db.CreateTableAsync<CarCategory>();
            await _db.CreateTableAsync<CarClass>();
            await _db.CreateTableAsync<CarClassDamage>();
            await _db.CreateTableAsync<Company>();
            await _db.CreateTableAsync<Damage>();
            await _db.CreateTableAsync<Inspection>();
            await _db.CreateTableAsync<InspectionDamage>();
            await _db.CreateTableAsync<InspectionImage>();
            await _db.CreateTableAsync<InspectionSignature>();
            await _db.CreateTableAsync<InspectionType>();
            await _db.CreateTableAsync<User>();
        }

        public SQLiteAsyncConnection Connection => _db;
    }
}
