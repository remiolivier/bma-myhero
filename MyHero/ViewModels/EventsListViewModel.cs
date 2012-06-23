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
            JsonHelper<EventContainer>.QueryCompleted += new QueryCompletedDelegate<EventContainer>((x) =>
            {
                foreach(var evt in x.events)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        ItemsByDate.Add(evt);
                    });
                }
            });

            JsonHelper<EventContainer>.GetFromUri("http://bactisme.frandroid.com/bemyapp/?action=get_event_list");

            //ItemsByDate.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "34", Image = "/Images/01.png" });
            //ItemsByDate.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "4", Image = "/Images/01.png" });
            //ItemsByDate.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "3", Image = "/Images/01.png" });
            //ItemsByDate.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "34", Image = "/Images/01.png" });
            //ItemsByDate.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "34", Image = "/Images/01.png" });
            //ItemsByDate.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "21", Image = "/Images/01.png" });
            //ItemsByDate.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "34", Image = "/Images/01.png" });
            //ItemsByDate.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "63", Image = "/Images/01.png" });
            //ItemsByDate.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "34", Image = "/Images/01.png" });
            //ItemsByDate.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "10", Image = "/Images/01.png" });


            //ItemsByPopularity.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "63", Image = "/Images/01.png" });
            //ItemsByPopularity.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "34", Image = "/Images/01.png" });
            //ItemsByPopularity.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "34", Image = "/Images/01.png" });
            //ItemsByPopularity.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "34", Image = "/Images/01.png" });
            //ItemsByPopularity.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "34", Image = "/Images/01.png" });;
            //ItemsByPopularity.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "34", Image = "/Images/01.png" });
            //ItemsByPopularity.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "21", Image = "/Images/01.png" });
            //ItemsByPopularity.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "10", Image = "/Images/01.png" });
            //ItemsByPopularity.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "4", Image = "/Images/01.png" });
            //ItemsByPopularity.Add(new Event() { Description = "Une description", Date = DateTime.Now.ToShortTimeString(), Popularity = "3", Image = "/Images/01.png" });
        }
    }
}
