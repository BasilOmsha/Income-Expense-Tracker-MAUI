using incomeExpensTrckMAUI.ViewModels;

namespace incomeExpensTrckMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel mainPageViewModel;

        //public MainPage()
        //{
        //    InitializeComponent();

        //}
        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel; // Set the binding context to MainPageViewModel
            this.mainPageViewModel = mainPageViewModel;
        }
    }
}