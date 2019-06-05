using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_RoomManagement.Classes
{
    public class Room
    {
        public int roomnr { get; set; }
        public int price { get; set; }
        public string disability { get; set; }
        public string specialities { get; set; }
        public string smoke { get; set; }
        public string furniture { get; set; }
        public string housekeeping { get; set; }
        //public string imagePath
        //{
        //    get
        //    {
        //        if (specialities.Equals("Balcony"))
        //            imagePath = "Images\room1.jpg";
        //        return this.imagePath;
        //    }
        //    set
        //    {
                
        //    }
        //}
    }
}
