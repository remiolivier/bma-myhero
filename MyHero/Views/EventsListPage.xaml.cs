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
using System.Collections.ObjectModel;
using Microsoft.Phone.Shell;
using MyHero.Models;

namespace MyHero.Views
{
    public partial class EventsListPage : PhoneApplicationPage
    {
        private ProgressIndicator _progressIndicator;
        protected EventsListViewModel model { get; set; }

        public EventsListPage()
        {
            InitializeComponent();
            this.DataContext = model = new EventsListViewModel();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _progressIndicator = new ProgressIndicator();
            _progressIndicator.IsVisible = true;
            SystemTray.ProgressIndicator = _progressIndicator;

            model.Load();

            _progressIndicator.IsVisible = false;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedevent = e.AddedItems[0] as Event;

            ListBox listbox = sender as ListBox;
            listbox.SelectionChanged -= ListBox_SelectionChanged;
            listbox.SelectedItem = null;
            listbox.SelectionChanged += ListBox_SelectionChanged;

            NavigationService.Navigate(new Uri("/Views/EventDetailsPage.xaml?eventid=65455757", UriKind.Relative));
        }

        private void appbar_MapButton_Click(object sender, EventArgs e)
        {
            if (PhoneApplicationService.Current.State.ContainsKey("ListEvents"))
                PhoneApplicationService.Current.State.Remove("ListEvents");

            PhoneApplicationService.Current.State.Add("ListEvents", model);
            NavigationService.Navigate(new Uri("/Views/MapEventsListPage.xaml", UriKind.Relative));
        }

        private void appbar_RefreshButton_Click(object sender, EventArgs e)
        {
            _progressIndicator.IsVisible = true;
            
            model.Clear();
            model.Load();

            _progressIndicator.IsVisible = false;
        }
    }
}