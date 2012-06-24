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
using System.ComponentModel;

namespace MyHero.Models
{
    public class Comment:INotifyPropertyChanged
    {
        public string _Id { get; set; }
       

        public string Owner_pseudo
        {
            get
            {
                return this.owner_pseudo;
            }
            set
            {
                this.owner_pseudo = value;
                NotifyPropertyChanged("Owner_pseudo");
            }
        }

        private string owner_pseudo;
        

        public string Event_id 
        {
            get
            {
                return this.event_id;
            }
            set
            {
                this.event_id = value;
                NotifyPropertyChanged("Event_id");
            }
        }
        private string event_id;
        
        public Date Date { get; set; }
        

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
                NotifyPropertyChanged("Text");
            }
        }
        private string text;
        

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                });
            }
        }
    }

    public class CommentContainer
    {
        public List<Comment> comments { get; set; }
    }
}
