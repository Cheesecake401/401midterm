using Crypts_And_Coders.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

//namespace CryptsAndTesters
//{
//    public class DatabaseTest : IDisposable
//    {
//        private readonly SqliteConnection _connection;
//        private readonly CryptsDbContext _db;

//        public DatabaseTestBase()
//        {
//            _connection = new SqliteConnection("Filename=:memory:");
//            _connection.Open();

//            _db = new CryptsDbContext(
//                new DbContextOptionsBuilder<CryptsDbContext>()
//                .UseSqlite(_connection)
//                .Options);
//            _db.Database.EnsureCreated();
//        }
//        public void Dispose()
//        {
//            _db?.Dispose();
//            _connection?.Dispose();
//        }
//    }
//}
