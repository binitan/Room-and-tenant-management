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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp_RoomManagement.Classes;

namespace WpfApp_RoomManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Room> rooms;
        public static ObservableCollection<Tenant> tt = new ObservableCollection<Tenant>();
        public static ObservableCollection<Bookings> bookings = new ObservableCollection<Bookings>();
        private bool changed;
        string filter = "";
        string choice1;
        string choice2;
        string choice3;
        string choice4;
        string choice5;
        string choice6;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter = Tbx_filter.Text.ToLower();
            if (filter == "")
            {
                Lbx_rooms.ItemsSource = rooms;
            }
            else
            {
                var results = from s in rooms where s.roomnr.ToString().Contains(filter) select s;
                Lbx_rooms.ItemsSource = results;
                
            }
        }

        private void Button_Click_Book(object sender, RoutedEventArgs e)
        {

            var win = new BookRoom((Room)Lbx_rooms.SelectedItem);
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Hidden;

           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (changed)
                MyStorage.WriteXml<ObservableCollection<Tenant>>(tt, "TenantData.xml");
            MyStorage.WriteXml<ObservableCollection<Bookings>>(bookings, "BookingData.xml");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rooms = MyStorage.ReadXml<ObservableCollection<Room>>("RoomData.xml");
            Lbx_rooms.ItemsSource = rooms;

            tt= MyStorage.ReadXml<ObservableCollection<Tenant>>("TenantData.xml");
            Lbx_tenants.ItemsSource = tt;

            bookings=MyStorage.ReadXml<ObservableCollection<Bookings>>("BookingData.xml");
            Grd_book.ItemsSource = bookings;

        }
        private void ComboBox_roomavailability(object sender, RoutedEventArgs e)
        {
            List < string > roomav= new List<string>();
            roomav.Add("All");
            roomav.Add("Free");
            roomav.Add("Occupied");
            var combo = sender as ComboBox;
            combo.ItemsSource = roomav;
            combo.SelectedIndex = 0;
        }
        private void ComboBox_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            var selected = sender as ComboBox;
            choice1 = selected.SelectedItem as string;
        }

        private void ComboBox_price(object sender, RoutedEventArgs e)
        {
            List<int> price = new List<int>();
            price.Add(50);
            price.Add(70);
            price.Add(80);
            price.Add(100);
            var combo1 = sender as ComboBox;
            combo1.ItemsSource = price;
           
        }

        private void ComboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            var selected1 = sender as ComboBox;
            choice2 = selected1.SelectedItem.ToString() as string;
        }
        private void ComboBox_housekp(object sender, RoutedEventArgs e)
        {
            List<string> hk = new List<string>();
            hk.Add("Clean");
            hk.Add("Unclean");
            hk.Add("In-Progress");
            var combo = sender as ComboBox;
            combo.ItemsSource = hk;
            combo.SelectedIndex = 0;
        }
        private void ComboBox_SelectionChanged3(object sender, SelectionChangedEventArgs e)
        {
            var selected = sender as ComboBox;
            choice3 = selected.SelectedItem as string;
        }
        private void ComboBox_df(object sender, RoutedEventArgs e)
        {
            List<string> disf = new List<string>();
            disf.Add("Yes");
            disf.Add("No");
            var combo = sender as ComboBox;
            combo.ItemsSource = disf;
            combo.SelectedIndex = 1;
        }
        private void ComboBox_SelectionChanged4(object sender, SelectionChangedEventArgs e)
        {
            var selected = sender as ComboBox;
            choice4 = selected.SelectedItem as string;
        }
        private void ComboBox_sp(object sender, RoutedEventArgs e)
        {
            List<string> spec = new List<string>();
            spec.Add("None");
            spec.Add("Balcony");
            spec.Add("River-Side");
            var combo = sender as ComboBox;
            combo.ItemsSource = spec;
            combo.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged5(object sender, SelectionChangedEventArgs e)
        {
            var selected = sender as ComboBox;
            choice5 = selected.SelectedItem as string;
        }
        private void ComboBox_sf(object sender, RoutedEventArgs e)
        {
            List<string> smf = new List<string>();
            smf.Add("Yes");
            smf.Add("No");
            var combo = sender as ComboBox;
            combo.ItemsSource = smf;
            combo.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged6(object sender, SelectionChangedEventArgs e)
        {
            var selected = sender as ComboBox;
            choice6 = selected.SelectedItem as string;
        }
        private void Button_Click_Go(object sender, RoutedEventArgs e)
        {
          //  var results = from s in rooms
          //                where (s.availability.Equals(choice1) && s.price.ToString().Equals(choice2)
          //&& s.housekeeping.Equals(choice3) && s.disability.Equals(choice4)
          //&& s.specialities.Equals(choice5) && s.smoke.Equals(choice6))
          //                select s;
            //Lbx_rooms.ItemsSource = results;
        }

        

        private void Tenant_Updated(object sender, TextChangedEventArgs e)
        {
            changed = true;
        }

        private void Bookingcalender_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            //Lbx_booking.ItemsSource = bookingcalender.SelectedDates;
        }
    }
}
