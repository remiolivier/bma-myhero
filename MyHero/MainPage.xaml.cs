using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using MyHero.ViewModels;
using Microsoft.Phone.Shell;
using MyHero.Models;
using System.IO.IsolatedStorage;
using MyHero.Helpers;

namespace MyHero
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainViewModel model { get; set; }

        // Constructor
        public MainPage()
        {
            InitializeComponent();


            model = new MainViewModel();
            model.Load();
            this.DataContext = model;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (App.CurrentAddress == null)
            {
                try
                {
                    if (IsolatedStorage.GetObject<List<UserAddress>>("Addresses") != null)
                    {
                        App.Addresses = IsolatedStorage.GetObject<List<UserAddress>>("Addresses");
                        App.CurrentAddress = App.Addresses.First();
                    }
                    else
                        NavigationService.Navigate(new Uri("/Views/AddressLocationPage.xaml", UriKind.Relative));
                }
                catch
                {
                    NavigationService.Navigate(new Uri("/Views/AddressLocationPage.xaml", UriKind.Relative));
                }
            }

        }

        private void HubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image hub = sender as Image;
            if (hub.Tag.ToString() == "incident")
                NavigationService.Navigate(new Uri("/Views/EventsListPage.xaml?category=incidents", UriKind.Relative));
            else if (hub.Tag.ToString() == "photo")
                NavigationService.Navigate(new Uri("/Views/ImageEventsListPage.xaml?category=photos", UriKind.Relative));
            else if (hub.Tag.ToString() == "social")
                NavigationService.Navigate(new Uri("/Views/EventsListPage.xaml?category=social", UriKind.Relative));
            else if (hub.Tag.ToString() == "animaux")
                NavigationService.Navigate(new Uri("/Views/ImageEventsListPage.xaml?category=animaux", UriKind.Relative));
        }

        private void FeatListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = sender as ListBox;
            var selecteditem = listbox.SelectedItem as Mailman;

            listbox.SelectionChanged -= FeatListBox_SelectionChanged;
            listbox.SelectedItem = null;
            listbox.SelectionChanged += FeatListBox_SelectionChanged;

            if (PhoneApplicationService.Current.State.ContainsKey("Mailman"))
                PhoneApplicationService.Current.State.Remove("Mailman");

            PhoneApplicationService.Current.State.Add("Mailman", selecteditem);

            NavigationService.Navigate(new Uri(string.Format("/Views/MailmanDetailPage.xaml?mailmanid={0}", selecteditem._id), UriKind.Relative));
        }
    }
}