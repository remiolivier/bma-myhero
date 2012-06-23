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
using System.Collections.ObjectModel;
using MyHero.Services;

namespace MyHero.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Mailman> Mailmans { get; set; }

        public MainViewModel()
        {
            Mailmans = new ObservableCollection<Mailman>();
        }

        public void Load()
        {
            MailmanService.GetTopMailman(mc =>
            {
                foreach (var evt in mc.mailmans)
                {
                    evt.url_photo = string.Format("{0}{1}", App.BASE_URL, evt.url_photo);
                    Mailmans.Add(evt);
                    evt.url_photo = string.Format("{0}{1}", App.BASE_URL, evt.url_photo);
                    Mailmans.Add(evt);
                    evt.url_photo = string.Format("{0}{1}", App.BASE_URL, evt.url_photo);
                    Mailmans.Add(evt);
                    evt.url_photo = string.Format("{0}{1}", App.BASE_URL, evt.url_photo);
                    Mailmans.Add(evt);
                    evt.url_photo = string.Format("{0}{1}", App.BASE_URL, evt.url_photo);
                    Mailmans.Add(evt);
                    evt.url_photo = string.Format("{0}{1}", App.BASE_URL, evt.url_photo);
                    Mailmans.Add(evt);
                    evt.url_photo = string.Format("{0}{1}", App.BASE_URL, evt.url_photo);
                    Mailmans.Add(evt);
                    evt.url_photo = string.Format("{0}{1}", App.BASE_URL, evt.url_photo);
                    Mailmans.Add(evt);
                }
            });
        }
    }
}
