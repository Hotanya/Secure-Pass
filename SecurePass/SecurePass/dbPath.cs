using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePass
{
    class dbPath
    {
        private string databasePath
        {
            get
            {
                var dbName = "SecurePass.db3";
#if __IOS__
            string folder = Environment.GetFolderPath
              (Environment.SpecialFolder.Personal);
            folder = Path.Combine (folder, "..", "Library");
            var databasePath = Path.Combine(folder, dbName);
#else
#if __ANDROID__
                string folder = Environment.GetFolderPath
                  (Environment.SpecialFolder.Personal);
                var databasePath = Path.Combine(folder, dbName);
#endif
#endif
                return databasePath;
            }
        }
    }
}

