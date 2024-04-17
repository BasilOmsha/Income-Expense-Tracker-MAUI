using incomeExpensTrckMAUI.ViewModels.Pages;
using Mapsui;
using Mapsui.Projections;
using Mapsui.UI.Maui;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace incomeExpensTrckMAUI.Views.Pages.MapsPages;

public partial class MapsPageView : ContentPage
{
    private readonly MapsPageViewModel mapsPageViewModel;

    public MapsPageView(MapsPageViewModel mapsPageViewModel)
    {
        InitializeComponent();
        this.mapsPageViewModel = mapsPageViewModel;
        BindingContext = mapsPageViewModel;

        // Subscribe to MapClicked event
        //mapViewElement.MapClicked += mapsPageViewModel.OnMapClicked;
        mapViewElement.PinClicked += mapsPageViewModel.OnPinClicked;

    }
}