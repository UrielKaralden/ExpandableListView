﻿using ExpandableListView.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpandableListView
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ExpandableList();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
