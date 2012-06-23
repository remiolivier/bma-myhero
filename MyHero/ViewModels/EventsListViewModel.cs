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
            EventService.GetEventsByDate((x) =>
            {
                foreach(var evt in x.events)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        ItemsByDate.Add(evt);
                    });
                }
            });
        }
    }
}
