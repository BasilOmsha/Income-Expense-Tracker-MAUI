﻿using incomeExpensTrckMAUI.Views.Pages.ExpensePages;

namespace incomeExpensTrckMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddExpensePageView), 
                typeof(AddExpensePageView));
        }
    }
}