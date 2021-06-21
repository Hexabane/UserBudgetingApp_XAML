//Kunal Goyal
//18021553
//PROG POE

using System;

namespace UserBudgetingApp2.MainCode
{
    class HomeLoan : Expense
    {
        private double propertyPrice;
        private double depositMade;
        private double interestRate;
        private double months;

        private bool check = true;

        //A constructor that takes in values from the addUser WPF Class
        public HomeLoan(double propertyPrice, double depositMade, double interestRate, double months)
        {
            PropertyPrice = propertyPrice;
            DepositMade = depositMade;
            InterestRate = interestRate;
            Months = months;
        }

        //Get And Set Variables
        public double PropertyPrice { get => propertyPrice; set => propertyPrice = value; }
        public double DepositMade { get => depositMade; set => depositMade = value; }
        public double InterestRate { get => interestRate; set => interestRate = value; }
        public double Months { get => months; set => months = value; }
        public bool Check { get => check; set => check = value; }

        //Get Variable to Store the Method Calculated Values.
        public double MonthlyHomeLoanRepayments { get => monthlyHomeLoanRepaymentsCalc(); }

        public string AlertMessage { get => displayAlertMessage(); }


        //monthlyHomeLoanRepaymentsCalc() calculates the installments based on the values entered by the user.
        public double monthlyHomeLoanRepaymentsCalc()
        {//start of monthlyHomeLoanRepaymentsCalc() method.

            double propertyPriceAfterDeposit = PropertyPrice - DepositMade;
            double numberOfYears = Months / 12.0;
            double calculationOfLoanRepayment = propertyPriceAfterDeposit * (1 + (InterestRate / 100) * (numberOfYears));
            double monthlyInstallments = calculationOfLoanRepayment / Months;


            int count = ListHandler.userList.Count - 1;

            if(count < 0)
            {
                return 0;
            }


            //this if statement checks if the monthlyInstallments are 3rd of the grossMonthlyIncome.
            if (monthlyInstallments > (ListHandler.userList[count].MonthlyIncome / 3))
            {
             
                monthlyInstallments = 0;
            }

            //returning a 2 decimal format value  
            //(C# Cookbook, 2021),  Reference in ReferenceList textfile
            return Math.Round(monthlyInstallments, 2);

        }//end of monthlyHomeLoanRepaymentsCalc() method.


        //displayAlertMessage() is a method that displays a warning message if the variable 'Check' is false.
        public string displayAlertMessage()
        {//start of displayAlertMessage() method.

           
            string alert = "Your Home Loan Installments are more than the 3rd of your Gross Income Therefore, Home Loan is not possible!";
          
            return alert;
        }//end of displayAlertMessage() method.




    //}//end of HomeLoan Class.

}
}
