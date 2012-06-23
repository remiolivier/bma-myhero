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
using Nokia.Maps;
using Microsoft.Phone.Shell;
using System.Device.Location;
using MyHero.ViewModels;
using System.Collections.ObjectModel;
using MyHero.Models;

namespace MyHero.Views
{
    public partial class MapEventsListPage : PhoneApplicationPage
    {
        public EventsListViewModel model;
        private MapLayer _customLayer;
        private ProgressIndicator _progressIndicator;

        public MapEventsListPage()
        {
            Nokia.Maps.Services.Configuration.ApplicationId = "OjRjfYRupyS4HZymCAkj";
            Nokia.Maps.Services.Configuration.AuthenticationToken = "d_0KBiFCC4GJa7-ZJWeB-w";

            InitializeComponent();

            Loaded += new RoutedEventHandler(MapEventsListPage_Loaded);
        }

        void MapEventsListPage_Loaded(object sender, RoutedEventArgs e)
        {
            _progressIndicator = new ProgressIndicator();
            _progressIndicator.IsVisible = true;
            SystemTray.ProgressIndicator = _progressIndicator;

            StartCurrentPosition();
        }

        private void StartCurrentPosition()
        {
            _progressIndicator.IsIndeterminate = true;

            _customLayer = new MapLayer();
            MapControl.Layers.Add(_customLayer);
            MapControl.Center = new GeoCoordinate(48.8607, 2.3504);
            MapControl.ZoomLevel = 10;

            Random rand = new Random();
            
            foreach (var evt in model.ItemsByDate)
            {
                MapIcon posIcon = new MapIcon()
                {
                    Width = 40,
                    Height = 40,
                    AnchorPoint = MapIconAnchorPoint.Center,
                    Coordinate = new GeoCoordinate(evt.loc[0], evt.loc[0]),
                    Source = new Uri("/PanoramaApp1;component/Images/MapObjects.png", UriKind.RelativeOrAbsolute),
                    Content =  GetPushPinTemplate( evt.text + " - " + evt.nb_plus, evt)
                };
                _customLayer.Children.Add(posIcon);
            }

            _progressIndicator.IsIndeterminate = false;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (!PhoneApplicationService.Current.State.ContainsKey("ListEvents"))
            {
                MessageBox.Show("Il n'y pas de données présentes");
                NavigationService.GoBack();
                return;
            }

            model = PhoneApplicationService.Current.State["ListEvents"] as EventsListViewModel;
        }

        public UIElement GetPushPinTemplate(string text, Event context)
        {
            StackPanel sp = new StackPanel();
            sp.Background = new SolidColorBrush(Colors.Black);
            sp.Opacity = 0.7;
            sp.DataContext = context;

            TextBlock txt = new TextBlock();
            txt.Foreground = new SolidColorBrush(Colors.White);
            txt.Text = text;

            sp.Children.Add(txt);

            sp.Tap += new EventHandler<System.Windows.Input.GestureEventArgs>(sp_Tap);

            return sp;
        }

        void sp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var sp = e.OriginalSource as TextBlock;
            var evt = sp.DataContext as Event;

            NavigationService.Navigate(new Uri("/Views/EventDetailsPage.xaml?eventid=231648647", UriKind.Relative));
        }
    }
}