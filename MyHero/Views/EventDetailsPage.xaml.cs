using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using MyHero.ViewModels;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Shell;

namespace MyHero.Views
{
    public partial class EventDetailsPage : PhoneApplicationPage
    {
        protected EventViewModel model { get; set; }
        protected bool isCommenting = false;

        public EventDetailsPage()
        {
        InitializeComponent();
            model = new EventViewModel();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            model.Load();
            this.DataContext = model;
        }

        private void DivCommentaire_Click(object sender, RoutedEventArgs e)
        {
            FormCom.Visibility = Visibility.Visible;
            pivot.Visibility = System.Windows.Visibility.Collapsed;
            DivCommentaire.Visibility = Visibility.Collapsed;
            isCommenting = true;
        }

        private void AddComs_Click(object sender, RoutedEventArgs e)
        {
            AllComs.Items.Add(model.CommentEvent);
            pivot.Visibility = System.Windows.Visibility.Visible;
            FormCom.Visibility = Visibility.Collapsed;
            DivCommentaire.Visibility = Visibility.Visible;
            isCommenting = false;
        }

        private void Like_Click(object sender, EventArgs e)
        {
            model.AddLike();
            var btn = sender as ApplicationBarIconButton;
            btn.IsEnabled = false;
        }

        private void FbLink_Click(object sender, EventArgs e)
        {
            ShareLinkTask tweet = new ShareLinkTask();
            tweet.LinkUri = new Uri(model.EventDetail.url_photo);
            tweet.Message = "Evènement partagé " + model.EventDetail.text;
            tweet.Show();
        }

        private void TweetLink_Click(object sender, EventArgs e)
        {
            ShareLinkTask tweet = new ShareLinkTask();
            tweet.LinkUri = new Uri(model.EventDetail.url_photo);
            tweet.Message = "Evènement partagé " + model.EventDetail.text;
            tweet.Show();
        }

        private void MailLink_Click(object sender, EventArgs e)
        {
            EmailComposeTask task = new EmailComposeTask();
            task.Subject = "Evènement partagé";
            task.Body += model.EventDetail.text + "\r\n";
            task.Body +=  model.EventDetail.url_photo + "\r\n";
            task.Body += "Envoyé depuis My Hero Application à partir de Mon Windows Phone";
            task.Show();
        }
    }
}