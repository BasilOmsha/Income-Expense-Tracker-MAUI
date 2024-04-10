using incomeExpensTrckMAUI.ViewModels;

namespace incomeExpensTrckMAUI.Views;

public partial class IncomeView : ContentView
{
    private readonly IncomeViewModel incomeViewModel;

    public IncomeView()
    {
        InitializeComponent();
    }

    public IncomeView(IncomeViewModel incomeViewModel)
    {
        this.incomeViewModel = incomeViewModel;
        BindingContext = incomeViewModel;
    }
}