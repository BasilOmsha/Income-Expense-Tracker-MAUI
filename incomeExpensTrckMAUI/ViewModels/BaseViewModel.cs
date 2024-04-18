using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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


//public partial class BaseViewModel : INotifyPropertyChanged
//{

//    string _title;

//    public string Title
//    {
//        get => _title;
//        set
//        {
//            if (_title == value)
//                return;
//            _title = value;
//            OnPropertyChanged();
//        }
//    }

//    public event PropertyChangedEventHandler PropertyChanged;
//    private void OnPropertyChanged([CallerMemberName] string name = null)
//    {
//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
//    }
//}
