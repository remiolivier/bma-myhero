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
        protected MailmanViewModel model;
        public MailmanDetailPage()
        {
            InitializeComponent();
            model = new MailmanViewModel();
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
            model.Load();
            this.DataContext = model;
        }
    }
}