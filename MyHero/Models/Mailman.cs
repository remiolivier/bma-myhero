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

namespace MyHero.Models
{
    public class Mailman
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string text { get; set; }
        public string address { get; set; }
        public NbPlus nb_plus { get; set; }
        public int total_plus { get; set; }
        public string url_photo { get; set; }
        public List<string> badges { get; set; }
        public string phone_id { get; set; }
        public List<int> loc { get; set; }
    }

    public class NbPlus
    {
        public int incident { get; set; }
        public int social { get; set; }
        public int animaux { get; set; }
        public int photos { get; set; }
    }

    public class MailmanContainer
    {
        public List<Mailman> mailmans { get; set; }
    }
}
