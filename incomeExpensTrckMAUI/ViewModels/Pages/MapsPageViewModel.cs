using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using incomeExpensTrckMAUI.Models;
using incomeExpensTrckMAUI.Services;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.UI.Maui;
using Mapsui.Widgets;
using Mapsui.Widgets.ScaleBar;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace incomeExpensTrckMAUI.ViewModels.Pages
{
    public partial class MapsPageViewModel : BaseViewModel
    {
        private IGeolocation geolocation;
        private readonly ExpenseService expenseService;
        private Location location;

        private MyLocationLayer? _myLocationLayer;

        [ObservableProperty]
        MapView mapViewElement;

        public ObservableCollection<Expense> ExpenseLocations { get; private set; } = new();

        public MapsPageViewModel(IGeolocation geolocation, ExpenseService expenseService)
        {
            Title = "Expense Map";
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
                location = await geolocation.GetLocationAsync(new GeolocationRequest
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
            MapViewElement.Map.Widgets.Add(new MapInfoWidget(MapViewElement.Map));
            MapViewElement.Map.Widgets.Add(new ScaleBarWidget(MapViewElement.Map) { TextAlignment = Alignment.Center });

            //add a pin
            AddPin(location.Latitude, location.Longitude, Colors.Blue, "Current Location", "Me");

            _myLocationLayer?.Dispose();
            _myLocationLayer = new MyLocationLayer(MapViewElement.Map)
            {
                IsCentered = false,
            };

            MapViewElement.Map.Layers.Add(_myLocationLayer);

            MapViewElement.Map.Navigator.ZoomToLevel(14);

            //var center = new MPoint(24.478288503698295, 60.97635155698171); // This is the default location I set for the emulator as the location property is not working with the emulator.
            var center = new MPoint(location.Longitude, location.Latitude);
            Debug.WriteLine($" {center.X} {center.Y}");


            //Transform the location to mercator
            //navigate to my location
            //var (x, y) = SphericalMercator.FromLonLat(location.Longitude, location.Latitude);
            var sphericalMercatorCoordinate = SphericalMercator.FromLonLat(center.X, center.Y).ToMPoint();
            //MapViewElement.Map.Home = n => n.CenterOnAndZoomTo(new MPoint(x, y), n.Resolutions[16]);
            MapViewElement.Map.Home = n => n.CenterOnAndZoomTo(sphericalMercatorCoordinate, n.Resolutions[16]);

            _myLocationLayer.UpdateMyLocation(sphericalMercatorCoordinate, true);

            foreach (var expense in ExpenseLocations)
            {
                AddPin(Convert.ToDouble(expense.Latitude), Convert.ToDouble(expense.Longitude), Colors.Red, expense.Note, expense.Location);
            }
            //add handlers
            //MapViewElement.PinClicked += OnPinClicked;
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

        [RelayCommand]
        void Refresh()
        {
            try
            {
                GetExpenseLocations();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DrawMap();
            }
        }
    }
}
