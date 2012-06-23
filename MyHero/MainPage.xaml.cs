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

namespace MyHero
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainViewModel model { get; set; }

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            model = new MainViewModel();
            model.Load();
            this.DataContext = model;
        }

        private void HubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            HubTile hub = sender as HubTile;
            if (hub.Title == "events")
                NavigationService.Navigate(new Uri("/Views/EventsListPage.xaml", UriKind.Relative));
            else if (hub.Title == "photo")
                NavigationService.Navigate(new Uri("/Views/ImageEventsListPage.xaml", UriKind.Relative));
        }
    }
}