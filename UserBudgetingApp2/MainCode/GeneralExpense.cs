//Kunal Goyal
//18021553
//PROG POE

using System.Collections.Generic;


namespace UserBudgetingApp2.MainCode
{
    class GeneralExpense : Expense
    {
        private double monthlyTaxDeducted;
        private List<double> monthlyExpenses;

        public GeneralExpense()
        { 
        }
        public GeneralExpense(double monthlyTaxDeducted, List<double> monthlyExpenses)
        {
            MonthlyTaxDeducted = monthlyTaxDeducted;
            MonthlyExpenses = monthlyExpenses;
        }

        public double MonthlyTaxDeducted { get => monthlyTaxDeducted; set => monthlyTaxDeducted = value; }
        public List<double> MonthlyExpenses { get => monthlyExpenses; set => monthlyExpenses = value; }

        public double TotalMonthlyExpenses { get => totalMonthlyExpensesCalc(); }

        //totalMonthlyExpensesCalc() is a method that calculates the total Regular monthly expenses by the user.
        private double totalMonthlyExpensesCalc()
        {//start of method

            double totalMonthlyExpenses = 0;

            //for loop is created to add all the values stored in the  MonthlyExpenses Array.
            for (int i = 0; i < MonthlyExpenses.Count; i++)
            {
                totalMonthlyExpenses += MonthlyExpenses[i];
            }


            return totalMonthlyExpenses;

        }//end of method
    }
}
