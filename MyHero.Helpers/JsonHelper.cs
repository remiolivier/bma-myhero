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
using Newtonsoft.Json;
using System.ComponentModel;

namespace MyHero.Helpers
{
    public class JsonHelper<T>
    {
        public static event QueryCompletedDelegate<T> QueryCompleted;

        public static void GetFromUri(string uri)
        {
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler((x, y) =>
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
                    webClient.DownloadStringAsync(new Uri(uri));
                });
            bg.RunWorkerAsync();
        }

        static void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var result = JsonConvert.DeserializeObject<T>(e.Result);
                QueryCompleted.Invoke(result);
            }
            else
            {
                QueryCompleted.Invoke(default(T));
            }

        }
    }

    public delegate void QueryCompletedDelegate<T>(T result);
}
