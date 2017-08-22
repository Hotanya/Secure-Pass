using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;

namespace SecurePass
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }

        public User()
        {

        }
    }
}
