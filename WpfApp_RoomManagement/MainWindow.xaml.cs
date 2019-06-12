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
        public static ObservableCollection<CheckoutList> checkoutLists = new ObservableCollection<CheckoutList>();
        private bool changed;
        string filter = "";
        string choice2;
        string choice4;
        string choice5;
        string choice6;
        int frm, to;

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
                MyStorage.WriteXml<ObservableCollection<Room>>(rooms, "RoomData.xml");
                MyStorage.WriteXml<ObservableCollection<CheckoutList>>(checkoutLists, "CheckoutData.xml");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rooms = MyStorage.ReadXml<ObservableCollection<Room>>("RoomData.xml");
            Lbx_rooms.ItemsSource = rooms;

            tt= MyStorage.ReadXml<ObservableCollection<Tenant>>("TenantData.xml");
            Lbx_tenants.ItemsSource = tt;

            bookings=MyStorage.ReadXml<ObservableCollection<Bookings>>("BookingData.xml");
            Grd_book.ItemsSource = bookings;

            checkoutLists = MyStorage.ReadXml<ObservableCollection<CheckoutList>>("CheckoutData.xml");
            Grd_history.ItemsSource = checkoutLists;

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
            if (selected1.SelectedIndex != -1)
            {
                choice2 = selected1.SelectedItem.ToString() as string;
                exeQuery();
            }
            
        }

        private void ComboBox_df(object sender, RoutedEventArgs e)
        {
            List<string> disf = new List<string>();
           
            disf.Add("Yes");
            disf.Add("No");
            var combo = sender as ComboBox;
            combo.ItemsSource = disf;
       
        }
        private void ComboBox_SelectionChanged4(object sender, SelectionChangedEventArgs e)
        {
            var selected = sender as ComboBox;
            choice4 = selected.SelectedItem as string;
            exeQuery();
        }

        private void ComboBox_sp(object sender, RoutedEventArgs e)
        {
            List<string> spec = new List<string>();
            spec.Add("None");
            spec.Add("Balcony");
            spec.Add("River-Side");
            var combo = sender as ComboBox;
            combo.ItemsSource = spec;
            
        }
        private void ComboBox_SelectionChanged5(object sender, SelectionChangedEventArgs e)
        {
            var selected = sender as ComboBox;
            choice5 = selected.SelectedItem as string;
            exeQuery();
        }

        private void ComboBox_sf(object sender, RoutedEventArgs e)
        {
            List<string> smf = new List<string>();
            smf.Add("Yes");
            smf.Add("No");
            var combo = sender as ComboBox;
            combo.ItemsSource = smf;
           
        }
        private void ComboBox_SelectionChanged6(object sender, SelectionChangedEventArgs e)
        {
            var selected = sender as ComboBox;
            choice6 = selected.SelectedItem as string;
            exeQuery();
        }

        private void exeQuery () {
            if (choice2 != null && choice4 == null && choice5 == null && choice6 == null)
            {
                var priceFiltered = from r in rooms where r.price.ToString().Equals(choice2) select r;
                Lbx_rooms.ItemsSource = priceFiltered;
            }
            else if (choice2 != null && choice4 != null && choice5 == null && choice6 == null)
            {
                var filter = from r in rooms where (r.price.ToString().Equals(choice2) && r.disability.Equals(choice4)) select r;
                Lbx_rooms.ItemsSource = filter;
            }
            else if (choice2 != null && choice4 == null && choice5 != null && choice6 == null)
            {
                var filter = from r in rooms where (r.price.ToString().Equals(choice2) && r.specialities.Equals(choice5)) select r;
                Lbx_rooms.ItemsSource = filter;
            }
            else if (choice2 != null && choice4 == null && choice5 == null && choice6 != null)
            {
                var filter = from r in rooms where (r.price.ToString().Equals(choice2) && r.smoke.Equals(choice6)) select r;
                Lbx_rooms.ItemsSource = filter;
            }
            else if (choice2 == null && choice4 != null && choice5 == null && choice6 == null)
            {
                var filter = from r in rooms where (r.disability.Equals(choice4)) select r;
                Lbx_rooms.ItemsSource = filter;
            }
            else if (choice2 == null && choice4 != null && choice5 != null && choice6 == null)
            {
                var filter = from r in rooms where (r.disability.Equals(choice4) && r.specialities.Equals(choice5)) select r;
                Lbx_rooms.ItemsSource = filter;
            }
            else if (choice2 == null && choice4 != null && choice5 == null && choice6 != null)
            {
                var filter = from r in rooms where (r.disability.Equals(choice4) && r.smoke.Equals(choice6)) select r;
                Lbx_rooms.ItemsSource = filter;
            }
            else if (choice2 == null && choice4 == null && choice5 != null && choice6 == null)
            {
                var filter = from r in rooms where (r.specialities.Equals(choice5)) select r;
                Lbx_rooms.ItemsSource = filter;
            }
            else if (choice2 == null && choice4 == null && choice5 != null && choice6 != null)
            {
                var filter = from r in rooms where (r.specialities.Equals(choice5) && r.smoke.Equals(choice6)) select r;
                Lbx_rooms.ItemsSource = filter;
            }
            else if (choice2 == null && choice4 == null && choice5 == null && choice6 != null)
            {
                var filter = from r in rooms where (r.smoke.Equals(choice6)) select r;
                Lbx_rooms.ItemsSource = filter;
            }
            else if (choice2 != null && choice4 != null && choice5 != null && choice6 != null)
            {
                var results = from s in rooms
                              where (s.price.ToString().Equals(choice2) && s.disability.Equals(choice4) && s.specialities.Equals(choice5) && s.smoke.Equals(choice6))
                              select s;
                Lbx_rooms.ItemsSource = results;
                //if (results==null)
                //{
                //    MessageBox.Show("No rooms for such combination!!", "Try something else", MessageBoxButton.OK, MessageBoxImage.Information);

                //}
            }
            else if (choice2 != null && choice4 != null && choice5 != null && choice6 == null)
            {
                var results = from s in rooms
                              where (s.price.ToString().Equals(choice2) && s.disability.Equals(choice4) && s.specialities.Equals(choice5))
                              select s;
                Lbx_rooms.ItemsSource = results;
            }
            else if (choice2 != null && choice4 != null && choice5 == null && choice6 != null)
            {
                var results = from s in rooms
                              where (s.price.ToString().Equals(choice2) && s.disability.Equals(choice4) && s.smoke.Equals(choice6))
                              select s;
                Lbx_rooms.ItemsSource = results;
            }
            else if (choice2 != null && choice4 == null && choice5 != null && choice6 != null)
            {
                var results = from s in rooms
                              where (s.price.ToString().Equals(choice2) && s.specialities.Equals(choice5) && s.smoke.Equals(choice6))
                              select s;
                Lbx_rooms.ItemsSource = results;
            }
            else if (choice2 == null && choice4 != null && choice5 != null && choice6 != null)
            {
                var results = from s in rooms
                              where (s.disability.Equals(choice4) && s.specialities.Equals(choice5) && s.smoke.Equals(choice6))
                              select s;
                Lbx_rooms.ItemsSource = results;
            }
        }

        private void Button_Click_Go(object sender, RoutedEventArgs e)
        {
            
        }

        private void Tenant_Updated(object sender, TextChangedEventArgs e)
        {
            changed = true;
        }

        private void Tbx_filter_tenants_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter = Tbx_filter_tenant.Text.ToLower();
            if (filter == "")
            {
                Lbx_tenants.ItemsSource = tt;
            }
            else
            {
                var results = from s in tt where s.lastname.ToString().ToLower().Contains(filter) select s;
                Lbx_tenants.ItemsSource = results;

            }
        }

        private void Tbx_filter_bookings_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter = Tbx_filter_booking.Text.ToLower();
            if (filter == "")
            {
                Grd_book.ItemsSource = bookings;
            }
            else
            {
                var results = from s in bookings where s.identitynr.ToString().ToLower().Contains(filter) select s;
                Grd_book.ItemsSource = results;
            }
        }

        private void Tbx_filter_roomnr_TextChanged(object sender, TextChangedEventArgs e)
        {
            filter = Tbx_filter_booking1.Text.ToLower();
            if (filter == "")
            {
                Grd_book.ItemsSource = bookings;
            }
            else
            {
                var results = from s in bookings where s.booked_roomnr.ToString().ToLower().Contains(filter) select s;
                Grd_book.ItemsSource = results;
            }
        }


        private void Button_Click_Go1(object sender, RoutedEventArgs e)
        {
            if (this.frm >= this.to)
            {
                MessageBox.Show("Please select a valid date");
            }
            else
            {
                var roomsBooked = from b in bookings
                                  where (this.frm <= Int32.Parse(b.to.ToString("yyyyMMdd"))
                       && (this.frm >= Int32.Parse(b.@from.ToString("yyyyMMdd"))) ||
                       Int32.Parse((b.@from).ToString("yyyyMMdd")) <= this.to && Int32.Parse((b.@from).ToString("yyyyMMdd")) >= this.frm)
                                  select b;

                if (roomsBooked != null)
                {
                    var availableRooms = rooms.Where(r => !roomsBooked.Any(b => b.booked_roomnr == r.roomnr));
                    Lbx_rooms.ItemsSource = availableRooms;

                }
                else
                {
                    Lbx_rooms.ItemsSource = rooms;
                }
            }
        }
        private void FromDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            this.frm = Int32.Parse(((DateTime)fromDatePicker.SelectedDate).ToString("yyyyMMdd"));
        }
        private void ToDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            this.to = Int32.Parse(((DateTime)toDatePicker.SelectedDate).ToString("yyyyMMdd"));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (Lbx_rooms.SelectedItem as Room).housekeeping = !(Lbx_rooms.SelectedItem as Room).housekeeping;
            changed = true;
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Tenant Details Updated", "Thank You", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            Cbx_df.SelectedIndex = -1;
            Cbx_price.SelectedIndex = -1;
            Cbx_sf.SelectedIndex = -1;
            Cbx_sp.SelectedIndex = -1;
            rooms = MyStorage.ReadXml<ObservableCollection<Room>>("RoomData.xml");
            Lbx_rooms.ItemsSource = rooms;
        }

        private void Btn_CheckOut_Click(object sender, RoutedEventArgs e)
        {
            Bookings book = (Bookings)Grd_book.SelectedItem;
            bookings.Remove(book);
            
            CheckoutList checkout = new CheckoutList { roomNumber = book.booked_roomnr, name = book.name, identityNr = book.identitynr, checkoutDate = DateTime.Today.ToLocalTime()};
            checkoutLists.Add(checkout);
            MessageBox.Show("CheckOut Completed", "Thank You", MessageBoxButton.OK, MessageBoxImage.Information);
        }


    }
}
