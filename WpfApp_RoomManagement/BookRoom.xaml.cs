using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using WpfApp_RoomManagement.Classes;

namespace WpfApp_RoomManagement
{
  
    /// Interaction logic for BookRoom.xaml
   
    public partial class BookRoom : Window
    {
        ObservableCollection<Tenant> tenants = new ObservableCollection<Tenant>();
        ObservableCollection<Bookings> storebooking = new ObservableCollection<Bookings>();
        private bool storeData;
        private Room selectedItem;
        DateTime from, to;
        public BookRoom()
        {
            InitializeComponent();
        }
        int price;
        int roomNo;
        public BookRoom(Room selectedItem, DateTime toDate, DateTime fromDate)
        {
            InitializeComponent();
            this.from = fromDate;
            this.to = toDate;
            Tbx_toDate.Text = (toDate.ToString()).Substring(0, 10);
            Tbx_fromDate.Text = (fromDate.ToString()).Substring(0, 10);
            this.selectedItem = selectedItem;
            this.roomNo = selectedItem.roomnr;
            Tbx_rnum.Text = selectedItem.roomnr.ToString();
            this.price = selectedItem.price;
            double totalPrice = this.price * (MainWindow.totalDays);
            Tbx_tp.Text = totalPrice.ToString();
        }
        private void Button_Click_Submit(object sender, RoutedEventArgs e)
        {
            var fname = Tbx_fname.Text;
            var lname = Tbx_lname.Text;
            var inr = Tbx_inr.Text;
            var dob = Tbx_dob.Text;
           
            var email = Tbx_email.Text;
            var rnr = Tbx_rnum.Text;
            if (storeData)
            {
                Tbx_tp.Text = price.ToString();
                Tenant newTene = new Tenant { firstname = fname, lastname = lname, dob = dob, email = email, identitynr = inr };
                tenants.Add(newTene);
                MainWindow.tt.Add(newTene);
                MainWindow.bookings.Add(new Bookings { booked_roomnr = this.roomNo, identitynr=inr, name = fname+" "+lname, from = this.from, to = this.to });
            }
            MessageBox.Show("Booking Successful !!", "Thank You", MessageBoxButton.OK, MessageBoxImage.Information);
            Btn_book.IsEnabled = false;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
            MyStorage.WriteXml<ObservableCollection<Tenant>>(tenants, "TenantData.xml");
            MyStorage.WriteXml<ObservableCollection<Bookings>>(storebooking,"BookingData.xml");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tenants = MyStorage.ReadXml<ObservableCollection<Tenant>>("TenantData.xml");
            storebooking = MyStorage.ReadXml<ObservableCollection<Bookings>>("BookingData.xml");
        }
      
        private void Tenant_TextChanged(object sender, TextChangedEventArgs e)
        {
            storeData = true;
        }
        private void Tbx_BookingTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
