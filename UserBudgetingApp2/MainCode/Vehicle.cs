//Kunal Goyal
//18021553
//PROG POE

using System;


namespace UserBudgetingApp2.MainCode
{
    class Vehicle : Expense
    {
        //private variables created
        private string makeAndModel;
        private double purchasePrice;
        private double vDepositMade;
        private double vInterestRate;
        private double insurancePrem;


        //A constructor that takes in values from the buyVehicle WPF Class.
        public Vehicle(string makeAndModel, double purchasePrice, double vDepositMade, double vInterestRate, double insurancePrem)
            
        {
           MakeAndModel = makeAndModel;
           PurchasePrice = purchasePrice;
           VDepositMade = vDepositMade;
           VInterestRate = vInterestRate;
           InsurancePrem = insurancePrem;
        }

        //Get And Set Variables
        public string MakeAndModel { get => makeAndModel; set => makeAndModel = value; }
        public double PurchasePrice { get => purchasePrice; set => purchasePrice = value; }
        public double VDepositMade { get => vDepositMade; set => vDepositMade = value; }
        public double VInterestRate { get => vInterestRate; set => vInterestRate = value; }
        public double InsurancePrem { get => insurancePrem; set => insurancePrem = value; }

        //Get Variable to Store the Method Calculated Values.
        public double MonthlyVehicleRepayments { get => monthlyVehicleRepaymentsCalc(); }



        public double monthlyVehicleRepaymentsCalc()
        {//start of monthlyHomeLoanRepaymentsCalc() method.

            double vehiclePriceAfterDeposit = PurchasePrice - VDepositMade;
            double numberOfYears = 5.0;
            double calculationOfLoanRepayment = vehiclePriceAfterDeposit * (1 + (VInterestRate / 100) * (numberOfYears));
            double monthlyInstallments = calculationOfLoanRepayment / 60;
            monthlyInstallments += InsurancePrem;


            //this if statement checks if the monthlyInstallments are 3rd of the grossMonthlyIncome.

            //returning a 2 decimal format value  
            //(C# Cookbook, 2021),  Reference in ReferenceList textfile
            return Math.Round(monthlyInstallments, 2);

        }//end of monthlyHomeLoanRepaymentsCalc() method.


    }
}
