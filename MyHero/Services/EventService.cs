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

namespace MyHero.Services
{
    public class EventService
    {
        public static void GetEventsByDate(UserAddress position, Action<EventContainer> action)
        {
            FromUri(string.Format("{0}?action=get_event_list&lat={1}&lng={2}", App.BASE_URL, position.Latitude, position.Longitude), action);
        }

        public static void GetEventsByPopularity(UserAddress position, Action<EventContainer> action)
        {
            FromUri(string.Format("{0}?action=get_event_list&lat={1}&lng={2}&sort=nb_plus&order=-1", App.BASE_URL, position.Latitude, position.Longitude), action);
        }

        private static void FromUri<T>(string uri, Action<T> action)
        {
            JsonHelper<T>.QueryCompleted += new QueryCompletedDelegate<T>((x) =>
            {
                action.Invoke(x);
            });

            JsonHelper<EventContainer>.GetFromUri(uri);
        }
    }
}
