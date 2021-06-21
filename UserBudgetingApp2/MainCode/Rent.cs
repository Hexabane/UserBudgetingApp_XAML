//Kunal Goyal
//18021553
//PROG POE

namespace UserBudgetingApp2.MainCode
{
    class Rent : Expense //This Class Inherits from Expense Class
    {//start of Rent Class.

        private double monthlyRent;

        
        public Rent()
        {

        }
        //A constructor that takes in values from the addUser Wpf Class.
        public Rent(double monthlyRent)
        {
            this.MonthlyRent = monthlyRent;
        }

        //Get And Set Variables
        public double MonthlyRent { get => monthlyRent; set => monthlyRent = value; }

    }//end of Rent Class.

}//end of namespace.
