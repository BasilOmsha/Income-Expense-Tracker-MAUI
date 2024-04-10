using incomeExpensTrckMAUI.ViewModels;

namespace incomeExpensTrckMAUI.Views;

public partial class IncomeView : ContentView
{
    private readonly IncomeViewModel incomeViewModel = new();

    public IncomeView()
    {
        InitializeComponent();
        BindingContext = incomeViewModel;
    }

    //public IncomeView(IncomeViewModel incomeViewModel)
    //{
    //    this.incomeViewModel = incomeViewModel;
    //    BindingContext = incomeViewModel;
    //}
}