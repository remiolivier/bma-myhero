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
    public class MailmanService
    {
        public static void GetTopMailman(Action<MailmanContainer> action)
        {
            FromUri(string.Format("{0}?action=get_mailman_list&sort=total_plus&order=-1&limit=6", App.BASE_URL), action);
        }

        private static void FromUri<T>(string uri, Action<T> action)
        {
            JsonHelper<T>.QueryCompleted += new QueryCompletedDelegate<T>((x) =>
            {
                action.Invoke(x);
            });

            JsonHelper<MailmanContainer>.GetFromUri(uri);
        }
    }
}
