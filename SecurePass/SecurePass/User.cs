using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;

namespace SecurePass
{

    [Table("Applications")]
   public class User : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _accountName;
        [NotNull]
        public string AccountName
        {
            get
            {
                return _accountName;
            }
            set
            {
                this._accountName = value;
                OnPropertyChanged(nameof(AccountName));
            }
        }
        private string _password;
        [MaxLength(50)]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                this._password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
