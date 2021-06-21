//Kunal Goyal
//18021553
//POE Task 2
using UserBudgetingApp2.MVVM.View;

namespace UserBudgetingApp2.MainCode
{//start of name space


     /*
     |=====================================================================================================================|
     | This Class is For Creating any warning/error messages using delegates, which delegates the methods wherever needed  |      ~ TASK 2
     |=====================================================================================================================|
     */

    class DelegateWorker  
    {//start of class

       public delegate void ExpenseDelegate(string message); //public delegate created with type voide and string parameters.

       public static string WarningMessageExpense(ExpenseDelegate expenseDelegate)
        {//start of WarningmessageExpense() method.
            

            if (ReportView.totalExpenses > (ReportView.userIncome * 0.75))
            {
                string output = ("Your Total Monthly Expenses exceed " + "\n" + " 75% of your gross monthly income!!");
                expenseDelegate(output);
                return output;
            }
            else
            {
                return null;
            }

           

        }//end of WarningMessageExpense() method.

      
    }//end of class

} //end of namespace
