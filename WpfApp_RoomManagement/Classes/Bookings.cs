using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_RoomManagement.Classes
{
    public class Bookings
    {
        public int booked_roomnr { get; set; }
        public string email { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
       
    }
}
