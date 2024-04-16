using incomeExpensTrckMAUI.ViewModels.Pages;
using Mapsui.UI.Maui;

namespace incomeExpensTrckMAUI.Views.Pages.MapsPages;

public partial class MapModalView : ContentPage
{
    private readonly MapModalViewModel mapModalViewModel;

    public MapModalView(MapModalViewModel mapModalViewModel)
	{
		InitializeComponent();
        this.mapModalViewModel = mapModalViewModel;
        BindingContext = mapModalViewModel;

        // Link the XAML map view to the ViewModel's map property if necessary
        mapView.MapClicked += mapModalViewModel.OnMapClicked;
    }
}