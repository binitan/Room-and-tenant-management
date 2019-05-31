using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_RoomManagement
{
    class RoomAvailability : ObservableCollection<string>
    {
        public RoomAvailability()
        {
            Add("Free");
            Add("Occupied");
        }
    }
}
