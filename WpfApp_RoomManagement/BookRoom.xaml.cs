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
    /// <summary>
    /// Interaction logic for BookRoom.xaml
    /// </summary>
    public partial class BookRoom : Window
    {
        ObservableCollection<Tenant> tenants = new ObservableCollection<Tenant>();
        ObservableCollection<Bookings> storebooking = new ObservableCollection<Bookings>();
        private bool storeData;
        private Room selectedItem;

        public BookRoom()
        {
            InitializeComponent();
        }
        int price;
        int roomNo;
        public BookRoom(Room selectedItem)
        {
            this.selectedItem = selectedItem;
            InitializeComponent();
            this.roomNo = selectedItem.roomnr;
            Tbx_rnum.Text = selectedItem.roomnr.ToString();
            this.price = selectedItem.price;
        }

        private void Button_Click_Submit(object sender, RoutedEventArgs e)
        {
            var fname = Tbx_fname.Text;
            var lname = Tbx_lname.Text;
            var inr = Tbx_inr.Text;
            var dob = Tbx_dob.Text;
            var from = (DateTime)Tbx_from.SelectedDate;
            var to = (DateTime)Tbx_to.SelectedDate;
            var email = Tbx_email.Text;
            var rnr = Tbx_rnum.Text;
            //var price = (((to - from).TotalDays) * (this.price));
            //Tbx_tp.Text= price.ToString();
            if (storeData)
            {
                Tbx_tp.Text = price.ToString();
                Tenant newTene = new Tenant { firstname = fname, lastname = lname, dob = dob, email = email, identitynr = inr };
                tenants.Add(newTene);
                MainWindow.tt.Add(newTene);
                MainWindow.bookings.Add(new Bookings { booked_roomnr = this.roomNo, identitynr=inr, name = fname+" "+lname, from = from, to = to });
            }

            MessageBox.Show("Booking Succesful !!", "Thank You", MessageBoxButton.OK, MessageBoxImage.Information);

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

        private void Tenant_IdentityTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tbx_BookingTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            double totalDays = (Tbx_to.SelectedDate - Tbx_from.SelectedDate).Value.TotalDays;
            double totalPrice = this.price * totalDays;
            string tp = totalPrice.ToString();
            tp = Tbx_tp.Text;
        }
    }
}
