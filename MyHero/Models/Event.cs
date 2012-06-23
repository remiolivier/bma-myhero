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
using MyHero.Models;

namespace MyHero.Models
{
    public class Event
    {
        public string _id { get; set; }
        public string mailman_id { get; set; }
        public string category { get; set; }
        public string text { get; set; }
        public int nb_plus { get; set; }
        public string url_photo { get; set; }
        public string address { get; set; }
        public Date date { get; set; }
        public List<double> loc { get; set; }
    }

    public class Id
    {
        public string id { get; set; }
    }

    public class Date
    {
        public int sec { get; set; }
        public int usec { get; set; }

        public override string ToString()
        {
            System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0);
            dtDateTime = dtDateTime.AddSeconds(sec).ToLocalTime();
            return dtDateTime.ToString();
        }
    }


    public class EventContainer
    {
        public List<Event> events { get; set; }
    }
}
