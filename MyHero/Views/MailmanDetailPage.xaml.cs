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
using Microsoft.Phone.Shell;
using MyHero.ViewModels;

namespace MyHero.Views
{
    public partial class MailmanDetailPage : PhoneApplicationPage
    {
        public MailmanDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (!PhoneApplicationService.Current.State.ContainsKey("Mailman"))
            {
                MessageBox.Show("Il n'y pas de données présentes");
                NavigationService.GoBack();
                return;
            }

            //model = PhoneApplicationService.Current.State["Mailman"] as EventsListViewModel;
        }
    }
}