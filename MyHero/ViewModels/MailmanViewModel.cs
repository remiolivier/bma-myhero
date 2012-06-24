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
using Microsoft.Phone.Shell;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MyHero.ViewModels
{
    public class MailmanViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<String> imageBadges;
        public ObservableCollection<String> ImageBadges
        {
            get
            {
                return this.imageBadges;
            }
            set
            {
                if (this.imageBadges != value)
                {
                    this.imageBadges = value;
                    NotifyPropertyChanged("ImageBadges");
                }
            }
        }

        private Mailman postier;
        public Mailman Postier 
        {
            get
            {
                return this.postier;
            }
            set
            {
                if (this.postier != value)
                {
                    this.postier = value;
                    NotifyPropertyChanged("Postier");
                }
            }
        }
        public MailmanViewModel()
        {
            Postier = new Mailman();
        }

        public void Load()
        {
           Mailman PostierPartiel = PhoneApplicationService.Current.State["OneMailMan"] as Mailman;
           PostierPartiel.url_photo = PostierPartiel.url_photo.Replace("http://bactisme.frandroid.com/bemyapp/","");
           PostierPartiel.url_photo = PostierPartiel.url_photo.Insert(0, "http://bactisme.frandroid.com/bemyapp/");
            //on charge les badges
           ImageBadges = new ObservableCollection<string>();
           foreach (String Names in PostierPartiel.badges)
           {
              String NamesTempory = Names.Insert(0, "/Images/Badges/");
              ImageBadges.Add(NamesTempory + ".png");
           }
           Postier = PostierPartiel;
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
