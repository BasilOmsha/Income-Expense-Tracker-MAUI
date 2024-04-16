﻿using CommunityToolkit.Mvvm.ComponentModel;
using Mapsui;
using Mapsui.Projections;
using Mapsui.UI.Maui;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace incomeExpensTrckMAUI.ViewModels.Pages
{
    public partial class MapsPageViewModel : BaseViewModel
    {
        private IGeolocation geolocation;

        private Location location;

        [ObservableProperty]
        MapView mapViewElement = new();

        //readonly MapControl mapControl = new();


        private double lastClickedLatitude = 0.0;
        private double lastClickedLongitude = 0.0;

        public ObservableCollection<Pin> PinStored = new ObservableCollection<Pin>();

        public MapsPageViewModel(IGeolocation geolocation)
        {
            Title = "Expense Map";

            //MapControl = new MapControl();
            //MapViewElement = new Map();

            //MapControl.Map = MapViewElement;

            this.geolocation = geolocation;

            MapViewElement = new MapView();

            MapInit();
        }

        public async void MapInit()
        {
            location = new();
            await GetMyLocation();
            DrawMap();
        }

        public async Task GetMyLocation() // This will get my current location. But with the emulator, it will get the location I set as the default location.
        {
            try
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Best,
                    Timeout = TimeSpan.FromSeconds(30)
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine($" {e.Message}");
            }
        }

        public void DrawMap()
        {
            //setup mapsui
            MapViewElement.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());

            //add a pin
            AddPin(location.Latitude, location.Longitude, Colors.Blue);

            //navigate to my location
            var (x, y) = SphericalMercator.FromLonLat(location.Longitude, location.Latitude);
            MapViewElement.Map.Home = n => n.CenterOnAndZoomTo(new MPoint(x, y), n.Resolutions[16]);

            //add handlers
            MapViewElement.MapClicked += OnMapClicked;
            //mapViewElement.PinClicked += OnPinClicked;

        }

        public void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            double Y = e.Point.Latitude;
            double X = e.Point.Longitude;

            lastClickedLongitude = X;
            lastClickedLatitude = Y;

            // Debug output to verify the coordinates
            Debug.WriteLine("Map clicked");
            Debug.WriteLine($"Longitude: {lastClickedLongitude}, Latitude: {lastClickedLatitude}");

            // Add a pin at the clicked location
            AddPin(lastClickedLatitude, lastClickedLongitude, Colors.Purple);

            if (PinStored.Count == 1)
            {
                // Only one pin stored (curret location with emulator usage), add a new pin
                AddPin(lastClickedLatitude, lastClickedLongitude, Colors.Purple);
            }
            else if (PinStored.Count > 2)
            {
                // More than two pins stored, remove the last two pins
                Debug.WriteLine("Count is " + PinStored.Count);

                // Retrieve the last two pins
                var lastPin = PinStored[^1]; // Using index from end syntax for clarity
                var secondToLastPin = PinStored[^2];

                // Remove pins from UI
                MapViewElement.Pins.Remove(lastPin);
                MapViewElement.Pins.Remove(secondToLastPin);

                // Remove pins from internal list
                PinStored.Remove(lastPin);
                PinStored.Remove(secondToLastPin);

                Debug.WriteLine("Last two pins removed.");
            }

            foreach (var item in PinStored)
            {
                Debug.Write("pins " + item.Position);
            }
        }

        public void AddPin(double latitude, double longitude, Color c)
        {
            var myPin = new Pin(MapViewElement)
            {
                Position = new Position(latitude, longitude),
                Type = PinType.Pin,
                Label = "some text",
                Address = "more text",
                Scale = 0.7F,
                Color = c,
            };
            MapViewElement.Pins.Add(myPin);
            PinStored.Add(myPin);
        }
    }
}
