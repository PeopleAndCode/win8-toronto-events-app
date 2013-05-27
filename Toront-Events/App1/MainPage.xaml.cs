﻿using Bing.Maps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            InitializeMap();
        }

        void InitializeMap()
        {
            double MAIN_WIDTH = mainGrid.Width;
            double MAIN_HEIGHT = mainGrid.Height;

            myMap.Center = new Location(43.77091, -79.41133);
            myMap.ZoomLevel = 12;
            myMap.MapType = MapType.Aerial;

            Button helloButton = new Button();
            helloButton.Margin = new Thickness(0);
            helloButton.Content = "HELLO WORLD!";

            TextBlock helloBlock = new TextBlock();
            helloBlock.Text = "CLICK TCLICK THAT BUTTONCLICK THAT BUTTONCLICK THAT BUTTONCLICK THAT BUTTON";


            Grid helloGrid = new Grid();
            helloGrid.Children.Add(helloBlock);
            helloGrid.Children.Add(helloButton);


            locationList.Items.Add(helloGrid); 


            Pushpin pushpin = new Pushpin();
            pushpin.Text = "OMG ZE CUTE";
            MapLayer.SetPosition(pushpin, new Location(43.77091, -79.41133));
            myMap.Children.Add(pushpin);
        }

        private async void pushpinTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Hello from Seattle.");
            await dialog.ShowAsync();
        }



        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
