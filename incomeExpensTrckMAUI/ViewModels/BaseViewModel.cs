using CommunityToolkit.Mvvm.ComponentModel;

namespace incomeExpensTrckMAUI.ViewModels;

//This is the base class for all ViewModels in the application,
//it includes any common properties or methods that are used across multiple ViewModels
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotLoading))]
    private bool _isLoading;

    public bool IsNotLoading => !IsLoading;

}

