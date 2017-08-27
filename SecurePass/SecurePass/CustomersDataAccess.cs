using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace SecurePass
{
    public class CustomersDataAccess
    {
        private SQLiteAsyncConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<User> Applications { get; set; }

        public CustomersDataAccess(string dbPath)
        {
			database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetApplicationsAsync()
        {
            return database.Table<User>().ToListAsync();
        }
        

        public Task<List<User>> GetApplicationsNotDoneAsync()
        {
            return database.QueryAsync<User>("SELECT * FROM [User] WHERE [Done] = 0");
        }

        public Task<User> GetApplicationAsync(int id)
        {
            return database.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveApplicationAsync(User application)
        {
            if (application.Id != 0)
            {
                return database.UpdateAsync(application);
            }            
            else
            {
                return database.InsertAsync(application);
            }
        }

        public Task<int> DeleteItemAsync(User application)
        {
            return database.DeleteAsync(application);
        }
        
    }
}