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
using MyHero.Models;
using MyHero.Helpers;

namespace MyHero.Services
{
    public class CommentService
    {

        public static void GetCommentaryByEvent(Event evenement, Action<CommentContainer> action)
        {
            FromUri(String.Format("{0}?action=get_comments_list&id={1}",App.BASE_URL,evenement._id),action);
            
        }

        private static void FromUri<T>(string uri, Action<T> action)
        {
            JsonHelper<T>.QueryCompleted += new QueryCompletedDelegate<T>((x) =>
            {
                action.Invoke(x);
            });

            JsonHelper<CommentContainer>.GetFromUri(uri);
        }

    }
}
