﻿#pragma checksum "C:\Users\Remix\Documents\GitHub\bma-myhero\MyHero\Views\EventsListPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C5D803CAB3F6CF21044F907F68C3F06D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace MyHero.Views {
    
    
    public partial class EventsListPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appbar_MapButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appbar_RefreshButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/MyHero;component/Views/EventsListPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.appbar_MapButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appbar_MapButton")));
            this.appbar_RefreshButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appbar_RefreshButton")));
        }
    }
}

