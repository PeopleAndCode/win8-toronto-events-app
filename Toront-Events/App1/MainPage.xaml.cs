using Bing.Maps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
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

            LocationTag hTag = new LocationTag("Crystal's house", 43.77091, -79.41133,
                "WHAT DO YOU WANT FROM ME??");
            LocationTag pTag = new LocationTag("People&Code Home Base", 43.650374, -79.393859,
                "DANSZE IS HERE.  HE's REALLY DAMN CUTE YOUSHOULD COME AND SHMEX HIM");


            locationList.Items.Add(new LocationTag("Crystal's house", 43.77091, -79.41133, "WHAT DO YOU WANT FROM ME??"));
            locationList.Items.Add(new LocationTag("People&Code Home Base", 43.650374, -79.393859, "DANSZE IS HERE.  HE's REALLY DAMN CUTE YOUSHOULD COME AND SHMEX HIM"));

            //add items to document
            this.Read("Resources/events.xml");

            //example pushpin
            Pushpin pushpin = new Pushpin();
            pushpin.Text = "WHAT yoUCLOCKEDONMOIOIOIOI";
            MapLayer.SetPosition(pushpin, new Location(43.77091, -79.41133));

            myMap.Children.Add(pushpin);
        }


        public void Read(string fileName)
        {
            Debug.WriteLine(">>> START XML PARSING");

            XmlReader reader = XmlReader.Create("Resources/events.xml");

            // Parse the file and display each of the nodes.
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    //handle the main entries container
                    if (reader.Name.Equals("viewentries"))
                    {
                        Debug.WriteLine(">>>Found main entry list! Looking in!");
                        while (reader.Read())
                        {
                            //handle the entries
                            if (reader.Name.Equals("viewentry"))
                            {
                                Debug.WriteLine(">>> >>>Found entry #" + reader.GetAttribute("position") + "! Looking in.");
                            }

                        }

                        Debug.WriteLine(">>>End of main entry list! YAY!");
                    }
                }


                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    Debug.WriteLine("END NAME: " + reader.Name);
                }
                //switch (reader.NodeType)
                //{
                //    case XmlNodeType.Element:
                //        //Debug.WriteLine(reader.Name);
                //        Debug.WriteLine("ELEMENT>> NAME: " + reader.Name + " VALUE: " + reader.Value);
                //        break;
                //    case XmlNodeType.Text:
                //        Debug.WriteLine("TEXT VALUE: " + reader.Value);
                //        break;
                //    case XmlNodeType.XmlDeclaration:
                //        break;
                //    case XmlNodeType.ProcessingInstruction:
                //        //Debug.WriteLine(reader.Name + "::::::::" + reader.Value);
                //        break;
                //    case XmlNodeType.Comment:
                //        //Debug.WriteLine(reader.Value);
                //        break;
                //    case XmlNodeType.EndElement:
                //        //Debug.WriteLine("END!!");
                //        break;
                //}
            }

            Debug.WriteLine(">>> END OF XML PARSING");
        }
 

        private async void pushpinTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Hello from Seattle.");
            await dialog.ShowAsync();
        }

        private async void listTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            LocationTag selectedTag = ((LocationTag) (locationList.SelectedItem));
            myMap.Center = selectedTag.location;

            //MessageDialog dialog = new MessageDialog(selectedTag.info);
            //await dialog.ShowAsync();
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
