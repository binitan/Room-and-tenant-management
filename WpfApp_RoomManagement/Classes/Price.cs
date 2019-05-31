using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_RoomManagement.Classes
{
    class Price : ObservableCollection<string>
    {
        public Price()
        {
            Add(">=50 & <70");
            Add(">=70 & <100");
            Add(">=100 & <120");
        }
    }
}
