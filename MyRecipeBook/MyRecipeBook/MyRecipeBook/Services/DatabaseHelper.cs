using MyRecipeBook.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Services
{
    public class DatabaseHelper
    {
        private readonly SQLiteAsyncConnection _db;

        public DatabaseHelper(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<User>().Wait();
        }

        public Task<int> RegisterUser(User user)
        {
            return _db.InsertAsync(user);
        }

        public async Task<bool> LoginUser(string username, string password)
        {
            var user = await _db.Table<User>().Where(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
            return user != null;
        }
    }

}
