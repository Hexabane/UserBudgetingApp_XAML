//Kunal Goyal
//18021553
//PROG POE

using System.Collections.Generic;


namespace UserBudgetingApp2.MainCode
{//start of namespeace
    public class User
    {//start of Use Class.

        public string name;
        private double monthlyIncome;
        private  List<Expense> expenseList;

        
        public User()
        {

        }
        //A constructor that takes in values from the addUser WPF Class
        public User(string name, double monthlyIncome, List<Expense> expenseList)
        {
            Name = name;
            MonthlyIncome = monthlyIncome;
            ExpenseList = expenseList;
        }

        //Get And Set Variables
        public string Name { get => name; set => name = value; }
        public double MonthlyIncome { get => monthlyIncome; set => monthlyIncome = value; }
        public  List<Expense> ExpenseList { get => expenseList; set => expenseList = value; }

        //Get Variable to Store the Method Calculated Values.
        public double FinalAmount { get => FinalAmountCalc(); }


        //Method that Calculates the User's Final Amount/ Money that the user will be left with.
        public double FinalAmountCalc()
        {//start of finalamountcalc() method

            double rent = 0;
            double tax = 0;
            double expenses = 0;
            double installments = 0;



            foreach (Expense item in expenseList)
            {//start of foreach

                if (item.GetType().Name.ToString() == ("GeneralExpense"))
                {//start of first if statement

                    var test = (GeneralExpense)item;

                    tax = test.MonthlyTaxDeducted;
                    expenses = test.TotalMonthlyExpenses;

                }//end of first if statement

                if (item.GetType().Name.ToString() == ("HomeLoan"))
                {//start of second if statement

                    var test = (HomeLoan)item;

                    installments = test.MonthlyHomeLoanRepayments;

                }//end if second if statement

                if (item.GetType().Name.ToString() == ("Rent"))
                {//sart if third if statement

                    var test = (Rent)item;

                    rent = test.MonthlyRent;

                }//end if third if statement
              
            }//end of foreach

            return MonthlyIncome - tax - expenses - rent - installments; //returns the final amount

        }//end of finalamountcalc() class

    }//end of class

}//end of namespace
