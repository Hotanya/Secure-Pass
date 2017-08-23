using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace SecurePass
{
    class CustomersDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<User> Applications { get; set; }

        public CustomersDataAccess()
        {
            database =
              DependencyService.Get<IDatabaseConnection>().
              DbConnection();
            database.CreateTable<User>();
            this.Applications =
            new ObservableCollection<User>(database.Table<User>());
            // If the table is empty, initialize the collection
            if (!database.Table<User>().Any())
            {
                AddNewApplication();
            }
        }

        public void AddNewApplication()
        {
            this.Applications.
              Add(new User
              {
                  Id = 0,
                  AccountName = "Company name...",
                  Password = "Address...",
              });
        }

        // Use LINQ to query and filter data
        //public IEnumerable<User> GetFilteredCustomers(string countryName)
        //{
        //    // Use locks to avoid database collitions
        //    lock (collisionLock)
        //    {
        //        var query = from cust in database.Table<User>()
        //                    where cust.Country == countryName
        //                    select cust;
        //        return query.AsEnumerable();
        //    }
        //}
        // Use SQL queries against data
        //public IEnumerable<User> GetFilteredCustomers()
        //{
        //    lock (collisionLock)
        //    {
        //        return database.
        //          Query<User>
        //          ("SELECT * FROM Item WHERE Country = 'Italy'").AsEnumerable();
        //    }
        //}
        public User GetApplication(int id)
        {
            lock (collisionLock)
            {
                return database.Table<User>().
                  FirstOrDefault(customer => customer.Id == id);
            }
        }
        public int SaveApplication(User applicationInstance)
        {
            lock (collisionLock)
            {
                if (applicationInstance.Id != 0)
                {
                    database.Update(applicationInstance);
                    return applicationInstance.Id;
                }
                else
                {
                    database.Insert(applicationInstance);
                    return applicationInstance.Id;
                }
            }
        }
        public void SaveAllApplications()
        {
            lock (collisionLock)
            {
                foreach (var applicationInstance in this.Applications)
                {
                    if (applicationInstance.Id != 0)
                    {
                        database.Update(applicationInstance);
                    }
                    else
                    {
                        database.Insert(applicationInstance);
                    }
                }
            }
        }
        public int DeleteApplication(User applicationInstance)
        {
            var id = applicationInstance.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<User>(id);
                }
            }
            this.Applications.Remove(applicationInstance);
            return id;
        }
        public void DeleteAllApplications()
        {
            lock (collisionLock)
            {
                database.DropTable<User>();
                database.CreateTable<User>();
            }
            this.Applications = null;
            this.Applications = new ObservableCollection<User>
              (database.Table<User>());
        }
    }
}