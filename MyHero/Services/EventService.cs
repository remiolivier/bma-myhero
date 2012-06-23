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
            JsonHelper<EventContainer>.QueryCompleted += new QueryCompletedDelegate<EventContainer>((x) =>
            {
                action.Invoke(x);
            });

            JsonHelper<EventContainer>.GetFromUri("http://bactisme.frandroid.com/bemyapp/?action=get_event_list");
        }
    }
}
