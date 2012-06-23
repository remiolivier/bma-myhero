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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyHero.Helpers;
using MyHero.Models;
using MyHero.Services;

namespace MyHero.ViewModels
{
    public class EventsListViewModel
    {
        public EventsListViewModel()
        {
            ItemsByDate = new ObservableCollection<Event>();
            ItemsByPopularity = new ObservableCollection<Event>();
        }

        public ObservableCollection<Event> ItemsByDate { get; set; }
        public ObservableCollection<Event> ItemsByPopularity { get; set; }

        public void Load()
        {
            EventService.GetEventsByDate(App.CurrentAddress, x =>
            {
                ItemsByDate.Clear();
                foreach(var evt in x.events)
                {
                    evt.url_photo = string.Format("{0}{1}", App.BASE_URL, evt.url_photo);
                    ItemsByDate.Add(evt);
                }
            });

            EventService.GetEventsByPopularity(App.CurrentAddress, (x) =>
            {
                ItemsByPopularity.Clear();
                foreach (var evt in x.events)
                {
                    evt.url_photo = string.Format("{0}{1}", App.BASE_URL, evt.url_photo);
                    ItemsByPopularity.Add(evt);
                }
            });
        }

        public void Clear()
        {
            ItemsByDate.Clear();
            ItemsByPopularity.Clear();
        }
    }
}
