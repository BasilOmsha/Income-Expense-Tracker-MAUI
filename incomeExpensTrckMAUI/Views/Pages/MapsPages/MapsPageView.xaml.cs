namespace incomeExpensTrckMAUI.Views.Pages.MapsPages;

public partial class MapsPageView : ContentPage
{
	public MapsPageView()
	{
		InitializeComponent();

        var mapControl = new Mapsui.UI.Maui.MapControl();
        mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        Content = mapControl;
    }
}