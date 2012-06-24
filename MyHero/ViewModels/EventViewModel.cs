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
using MyHero.Services;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MyHero.ViewModels
{
    public class EventViewModel : INotifyPropertyChanged
    {
        private Event eventDetail;
        public Event EventDetail
        {
            get
            {
                return this.eventDetail;
            }
            set
            {
                if (this.eventDetail != value)
                {
                    this.eventDetail = value;
                    NotifyPropertyChanged("EventDetail");
                }
            }
        }

        private Comment commentEvent;
        public Comment CommentEvent
        {
            get
            {
                return this.commentEvent;
            }
            set
            {
                if (this.commentEvent != value)
                {
                    this.commentEvent = value;
                    NotifyPropertyChanged("CommentEvent");
                }
            }
        }

        
       // public MailMan Postier { get; set; }

        public ObservableCollection<double> coordonnees { get; set; }
        public ObservableCollection<Comment> CommentsByEvent { get; set; }

        public EventViewModel()
        {
            EventDetail = new Event();
            CommentsByEvent = new ObservableCollection<Comment>();
            CommentEvent = new Comment();
          //  Postier = new MailMan();
        }

        public void Load()
        {
            //chargement de l'event 

            Event eventtempory = PhoneApplicationService.Current.State["OneEvent"] as Event;
            //on fait un petit bricolage pour mettre en bon état l'image 
            eventtempory.url_photo = eventtempory.url_photo.Replace("http://bactisme.frandroid.com/bemyapp/","");
            eventtempory.url_photo=eventtempory.url_photo.Insert(0,"http://bactisme.frandroid.com/bemyapp/");

            EventService.GetAddressByGeoLocAction(eventtempory.loc, x =>
            {
                foreach (var adress in x)
                {
                    eventtempory.address = adress.Label;
                    break;
                }
                //on transforme l'adresse de l'image de la categorie
                eventtempory.category = "/Images/Categories/icon-cat-" + eventtempory.category + ".png";
                EventDetail = eventtempory;
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    CommentService.GetCommentaryByEvent(EventDetail, c =>
                    {
                        CommentsByEvent.Clear();
                        foreach (var com in c.comments)
                        {
                            CommentsByEvent.Add(com);
                        }
                    });
                });
            });

        }

        //public void AddComs()
        //{
        //    if (EventDetail._id != null)
        //    {
        //        CommentEvent.Event_id = EventDetail._id;
        //    }
        //    CommentService.InsertEvent(CommentEvent, c =>
        //        {
        //            CommentsByEvent.Clear();
        //            foreach (var com in c.comments)
        //            {
        //                CommentsByEvent.Add(com);
        //            }
        //        });
        //}

        public void AddLike()
        {
            
        }

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
}
