using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using incomeExpensTrckMAUI.Models;
using incomeExpensTrckMAUI.Services;
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
        private readonly ExpenseService expenseService;
        private Location location;

        [ObservableProperty]
        MapView mapViewElement = new();

        //readonly MapControl mapControl = new();


        private double lastClickedLatitude = 0.0;
        private double lastClickedLongitude = 0.0;

        public ObservableCollection<Pin> PinStored = new ObservableCollection<Pin>();

        public ObservableCollection<Expense> ExpenseLocations { get; private set; } = new();

        public MapsPageViewModel(IGeolocation geolocation, ExpenseService expenseService)
        {
            Title = "Expense Map";

            //MapControl = new MapControl();
            //MapViewElement = new Map();

            //MapControl.Map = MapViewElement;

            this.geolocation = geolocation;
            this.expenseService = expenseService;
            MapViewElement = new MapView();
            GetExpenseLocations();
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
            AddPin(location.Latitude, location.Longitude, Colors.Blue, "Current Location", "Me");

            //Transform the location to mercator

            //navigate to my location
            var (x, y) = SphericalMercator.FromLonLat(location.Longitude, location.Latitude);
            MapViewElement.Map.Home = n => n.CenterOnAndZoomTo(new MPoint(x, y), n.Resolutions[16]);

            //add handlers
            MapViewElement.PinClicked += OnPinClicked;

            foreach (var expense in ExpenseLocations)
            {
                AddPin(Convert.ToDouble(expense.Latitude), Convert.ToDouble(expense.Longitude), Colors.Red, expense.Note, expense.Location);
            }
        }

        public void OnPinClicked(object sender, PinClickedEventArgs e)
        {
            Debug.WriteLine($"Pin Clicked: {e.Pin.Label}");
            //Shell.Current.DisplayAlert("Pin Clicked", $"You clicked on {e.Pin.Label}", "Ok");
        }


        public void AddPin(double latitude, double longitude, Color c, string note, string location)
        {
            var myPin = new Pin(MapViewElement)
            {
                Position = new Position(latitude, longitude),
                Type = PinType.Pin,
                Label = note,
                Address = location,
                Scale = 0.7F,
                Color = c,
                Transparency = 0.4F
            };
            MapViewElement.Pins.Add(myPin);
            PinStored.Add(myPin);
        }

        void GetExpenseLocations()
        {
            try
            {
                if (ExpenseLocations.Any()) ExpenseLocations.Clear();
                var expenses = expenseService.GetExpenses();
                foreach (var expense in expenses) ExpenseLocations.Add(expense);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get expenses: {ex.Message}");
                Console.WriteLine($"Unable to get expenses: {ex.Message}");
                Shell.Current.DisplayAlert("Error", "Unable to get expenses", "Ok");
            }
            finally
            {

            }
        }
    }
}
