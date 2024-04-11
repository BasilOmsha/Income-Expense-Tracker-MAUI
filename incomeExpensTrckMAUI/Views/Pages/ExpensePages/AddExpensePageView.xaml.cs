using incomeExpensTrckMAUI.ViewModels.Pages;

namespace incomeExpensTrckMAUI.Views.Pages.ExpensePages;

[XamlCompilation(XamlCompilationOptions.Compile)] // used to compile XAML into intermediate language
public partial class AddExpensePageView : ContentPage
{
    private readonly AddExpensePageViewModel addExpensePageViewModel;


    //public AddExpensePageView()
    //{
    //    InitializeComponent();
    //}

    public AddExpensePageView(AddExpensePageViewModel addExpensePageViewModel)
	{
		InitializeComponent();
        //this.addExpensePageViewModel = addExpensePageViewModel;
        BindingContext = addExpensePageViewModel;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}