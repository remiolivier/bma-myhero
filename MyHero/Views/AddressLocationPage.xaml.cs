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
using System.Device.Location;
using MyHero.Models;
using MyHero.Services;
using System.IO.IsolatedStorage;
using MyHero.Helpers;
using Microsoft.Phone.Shell;

namespace MyHero.Views
{
    public partial class AddressLocationPage : PhoneApplicationPage
    {
        private ProgressIndicator _progressIndicator;
        GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
        GeoPosition<GeoCoordinate> position;

        public AddressLocationPage()
        {
            InitializeComponent();

            Loaded += new RoutedEventHandler(AddressLocationPage_Loaded);
            watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            watcher.Start();

            _progressIndicator = new ProgressIndicator();
            _progressIndicator.IsVisible = false;
            SystemTray.ProgressIndicator = _progressIndicator;

        }

        void AddressLocationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (watcher.Status == GeoPositionStatus.Ready)
            {
                this.btnLocalize.Opacity = 1;
            }
            else
            {
                this.btnLocalize.Opacity = 0.2;
                this.btnLocalize.Tap -= Image_Tap;
            }
        }

        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            if (watcher.Status == GeoPositionStatus.Ready)
            {
                this.btnLocalize.Opacity = 1;
                this.btnLocalize.Tap += Image_Tap;
            }
            else
            {
                this.btnLocalize.Opacity = 0.2;
                this.btnLocalize.Tap -= Image_Tap;
            }
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var image = sender as Image;
            if (image.Tag.ToString() == "localize")
            {

                _progressIndicator.IsVisible = true;
                position = watcher.Position;

                EventService.GetAddressByGeoLocAction(new List<double>() { position.Location.Latitude, position.Location.Longitude }, x =>
                    {
                        var loc = x.FirstOrDefault();

                        var userAddress = new UserAddress()
                        {
                            Address = loc.Label,
                            Latitude = position.Location.Latitude,
                            Longitude = position.Location.Longitude
                        };

                        if (App.Addresses.Where(a => a.Address ==  userAddress.Address).FirstOrDefault() == null)
                        {
                            App.Addresses.Add(userAddress);
                            Deployment.Current.Dispatcher.BeginInvoke(() =>
                                {
                                    IsolatedStorage.SaveObject<List<UserAddress>>("Addresses", App.Addresses);
                                });
                        }

                        watcher.Stop();

                        Deployment.Current.Dispatcher.BeginInvoke(() =>
                            {
                                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

                                _progressIndicator.IsVisible = false;
                            });
                    });

            }
            else
            {
                this.spAddress.Visibility = System.Windows.Visibility.Visible;
                this.btnAddress.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            try
            {
                NavigationService.RemoveBackEntry();
            }
            catch { }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            _progressIndicator.IsVisible = true;
            this.btnAddress.Visibility = System.Windows.Visibility.Collapsed;

            var address = this.txtAddress.Text;

            if (string.IsNullOrEmpty(address))
                return;

            EventService.GetAddressByAddress(address, x =>
            {
                var loc = x.FirstOrDefault();

                var userAddress = new UserAddress()
                {
                    Address = loc.Label,
                    Latitude = loc.Coordinate.Latitude,
                    Longitude = loc.Coordinate.Longitude
                };

                if (App.Addresses.Where(a => a.Address == userAddress.Address).FirstOrDefault() == null)
                {
                    App.Addresses.Add(userAddress);
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        IsolatedStorage.SaveObject<List<UserAddress>>("Addresses", App.Addresses);
                    });
                }

                watcher.Stop();
                _progressIndicator.IsVisible = false;

                Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                    });
            });
        }
    }
}