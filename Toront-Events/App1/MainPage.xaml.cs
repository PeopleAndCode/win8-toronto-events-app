using Bing.Maps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
        public const bool DEBUG = false;
        private Dictionary<string, LocationTag> tags;
        private Dictionary<string, ListBoxItem> itemTags;
        private Dictionary<string, Pushpin> pinTags;
        private Pushpin lastPin = null;

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
            myMap.MapType = MapType.Road;


            //add items to document
            this.ReadAndAdd("Resources/library-data.xml");

        }


        public void ReadAndAdd(string fileName)
        {
            Debug.WriteLineIf(DEBUG, ">>> START XML PARSING");

            XmlReader reader = XmlReader.Create(fileName);

            // Parse the file and add locations to list
            LocationTag hTag = null;
            tags = new Dictionary<string, LocationTag>();
            itemTags = new Dictionary<string, ListBoxItem>();
            pinTags = new Dictionary<string, Pushpin>();

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    //handle the main entries container
                    if (reader.Name.Equals("Placemark"))
                    {
                        Debug.WriteLineIf(DEBUG, ">>> >>>start new place mark entry"); 
                        hTag = new LocationTag();
                    }

                    if (reader.Name.Equals("name"))
                    {
                        hTag.name = reader.ReadElementContentAsString();
                        Debug.WriteLineIf(DEBUG, ">>> >>> >>>name of place: " + hTag.name);
                    }

                    if (reader.Name.Equals("description"))
                    {
                        hTag.description = reader.ReadElementContentAsString();
                        Debug.WriteLineIf(DEBUG, ">>> >>> >>>description: " + hTag.description);
                    }

                    if (reader.Name.Equals("address"))
                    {
                        hTag.address = reader.ReadElementContentAsString();
                        Debug.WriteLineIf(DEBUG, ">>> >>> >>>address: " + hTag.address);
                    }

                    if (reader.Name.Equals("phoneNumber"))
                    {
                        hTag.phoneNumber = reader.ReadElementContentAsString();
                        Debug.WriteLineIf(DEBUG, ">>> >>> >>>phone: " + hTag.address);
                    }

                    if (reader.Name.Equals("coordinates"))
                    {
                        string loc = reader.ReadElementContentAsString();
                        hTag.location = new Location(Double.Parse(loc.Split(',')[1]), Double.Parse(loc.Split(',')[0]));
                        Debug.WriteLineIf(DEBUG, ">>> >>> >>>location: " + hTag.location);
                    }


                }


                if (reader.NodeType == XmlNodeType.EndElement && reader.Name.Equals("Placemark"))
                {

                    ListBoxItem item = new ListBoxItem();
                    item.Content = hTag.name;
                    locationList.Items.Add(item);
                    item.Tapped += new Windows.UI.Xaml.Input.TappedEventHandler(entryTapped);

                    //adds pushpin for the current entry pushpin
                    Pushpin pushpin = new Pushpin();
                    Style style = App.Current.Resources["PushPinStyle"] as Style;
                    //pushpin.Style = style;
                    pushpin.Tapped += new Windows.UI.Xaml.Input.TappedEventHandler(entryTapped);
                    pushpin.Text = hTag.name;
                    MapLayer.SetPosition(pushpin, hTag.location);
                    myMap.Children.Add(pushpin);

                    //add stuff to dictionaries
                    tags.Add(hTag.name, hTag);
                    itemTags.Add(hTag.name, item);
                    pinTags.Add(hTag.name, pushpin);

                    Debug.WriteLineIf(DEBUG, ">>> >>>end of place mark entry");
                }
            }

            Debug.WriteLineIf(DEBUG, ">>> END OF XML PARSING");
        }
 

        private async void entryTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            String name = null;

            if (sender is ListBoxItem)
            {
                name = (sender as ListBoxItem).Content.ToString();
            }
            if (sender is Pushpin)
            {
                name = (sender as Pushpin).Text.ToString();

                locationList.SelectedItem = itemTags[name];
                locationList.ScrollIntoView(itemTags[name]);
            }

            LocationTag hTag = tags[name];
            Pushpin pin = pinTags[name];

            if (lastPin != null)
            {
                lastPin.Background = new SolidColorBrush(Colors.Green);
            }
            pin.Background = new SolidColorBrush(Colors.Red);
            lastPin = pin;

            myMap.SetView(hTag.location, 15.5);

            nameBlock.Text = hTag.name;
            addressBlock.Text = hTag.address;
            phoneBlock.Text = "Phone: " + hTag.phoneNumber;

        }

        private async void listTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            //LocationTag selectedTag = ((LocationTag) (locationList.SelectedItem));
            //myMap.Center = selectedTag.location;

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
