using incomeExpensTrckMAUI.Views.Pages.ExpensePages;
using incomeExpensTrckMAUI.Views.Pages.MapsPages;

namespace incomeExpensTrckMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddExpensePageView), 
                typeof(AddExpensePageView));

            Routing.RegisterRoute(nameof(ExpenseDetailPageView),
                typeof(ExpenseDetailPageView));

            Routing.RegisterRoute(nameof(MapModalView),
                typeof(MapModalView));

            Routing.RegisterRoute(nameof(AddExpensePageView),
               typeof(AddExpensePageView));
        }
    }
}