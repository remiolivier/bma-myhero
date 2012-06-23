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
        public static void GetEventsByDate(Action<EventContainer> action)
        {
            FromUri("http://bactisme.frandroid.com/bemyapp/?action=get_event_list", action);
        }

        public static void GetEventsByPopularity(Action<EventContainer> action)
        {
            FromUri("http://bactisme.frandroid.com/bemyapp/?action=get_event_list", action);
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
