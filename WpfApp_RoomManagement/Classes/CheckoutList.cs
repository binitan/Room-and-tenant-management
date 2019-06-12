using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_RoomManagement.Classes
{
    public class CheckoutList
    {
        public DateTime checkoutDate { get; set; }
        public int roomNumber { get; set; }
        public string identityNr { get; set; }
        public string name { get; set; }
    }
}
