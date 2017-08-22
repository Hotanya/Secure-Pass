using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace SecurePass
{
    public class UserDatabase
    {
        private SQLiteConnection _connection;

        public UserDatabase()
        {
            _connection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            _connection.CreateTable<User>();
        }

        public IEnumerable<User> GetAccounst()
        {
            return (from t in _connection.Table<User>()
                    select t).ToList();
        }

        public User GetAccount(int id)
        {
            return _connection.Table<User>().FirstOrDefault(t => t.ID == id);
        }

        public void DeleteAccount(int id)
        {
            _connection.Delete<User>(id);
        }

        public void AddAccount(string account)
        {
            var user = new User
            {
                Account = account,
                CreatedOn = DateTime.Now
            };
            _connection.Insert(user);
        }
    }
}
