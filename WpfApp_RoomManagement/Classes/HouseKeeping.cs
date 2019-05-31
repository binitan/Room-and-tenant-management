using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_RoomManagement.Classes
{
    class HouseKeeping : ObservableCollection<string>
    {
        public HouseKeeping()
        {
            Add("Clean");
            Add("Unclean");
            Add("In-Progress");
        }
    }
}
