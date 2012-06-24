using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MyHero.Helpers;
using MyHero.Models;
using System.Device.Location;
using Nokia.Maps.Services;
using System.Collections.Generic;

namespace MyHero.Services
{
    public class EventService
    {
        public static void GetEventsByDate(UserAddress position, string category, Action<EventContainer> action)
        {
            FromUri(string.Format("{0}?action=get_event_list&category={1}&lat={2}&lng={3}", App.BASE_URL, category, position.Latitude, position.Longitude), action);
        }

        public static void GetEventsByPopularity(UserAddress position, string category, Action<EventContainer> action)
        {
            FromUri(string.Format("{0}?action=get_event_list&category={1}&lat={2}&lng={3}&sort=nb_plus&order=-1", App.BASE_URL, category, position.Latitude, position.Longitude), action);
        }

        private static void FromUri<T>(string uri, Action<T> action)
        {
            JsonHelper<T>.QueryCompleted += new QueryCompletedDelegate<T>((x) =>
            {
                action.Invoke(x);
            });

            JsonHelper<EventContainer>.GetFromUri(uri);
        }

        public static void GetAddressByGeoLocAction(List<Double> Geoloc, Action<IEnumerable<Location>> action)
        {
            GeoCoordinate coord = new GeoCoordinate(Geoloc[0], Geoloc[1]);
            ReverseGeocodeQuery q = new ReverseGeocodeQuery()
            {
                Coordinate = coord
            };

            q.QueryCompleted += (se, ea) =>
            {
                if (!ea.Cancelled && ea.UserState != null)
                {
                    action.Invoke(ea.UserState);
                }
            };

            q.StartAsync();
        }

        public static void GetAddressByAddress(string address, Action<IEnumerable<Location>> action)
        {
            GeocodeQuery q = new GeocodeQuery()
            {
                QueryString = address
            };

            q.QueryCompleted += (se, ea) =>
            {
                if (!ea.Cancelled && ea.UserState != null)
                {
                    action.Invoke(ea.UserState);
                }
            };

            q.StartAsync();
        }
    }
}
