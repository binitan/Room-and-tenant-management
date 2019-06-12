using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_RoomManagement.Classes
{
    public class Room : INotifyPropertyChanged
    {
        public int roomnr { get; set; }
        public int price { get; set; }
        public string disability { get; set; }
        public string specialities { get; set; }
        public string smoke { get; set; }
        public string furniture { get; set; }
        public bool housekeeping_;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool housekeeping
        {
            get
            {
                return housekeeping_;
            }
            set
            {
                housekeeping_ = value;
                OnPropertyChanged("housekeeping");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
