﻿#pragma checksum "C:\Users\Remix\Documents\GitHub\bma-myhero\MyHero\Views\AddressLocationPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A87040522E5CA435C07166DAB3C4807D"
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
    
    
    public partial class AddressLocationPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Image btnLocalize;
        
        internal System.Windows.Controls.StackPanel spAddress;
        
        internal System.Windows.Controls.TextBox txtAddress;
        
        internal System.Windows.Controls.Button btnSearch;
        
        internal System.Windows.Controls.Image btnAddress;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MyHero;component/Views/AddressLocationPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.btnLocalize = ((System.Windows.Controls.Image)(this.FindName("btnLocalize")));
            this.spAddress = ((System.Windows.Controls.StackPanel)(this.FindName("spAddress")));
            this.txtAddress = ((System.Windows.Controls.TextBox)(this.FindName("txtAddress")));
            this.btnSearch = ((System.Windows.Controls.Button)(this.FindName("btnSearch")));
            this.btnAddress = ((System.Windows.Controls.Image)(this.FindName("btnAddress")));
        }
    }
}

