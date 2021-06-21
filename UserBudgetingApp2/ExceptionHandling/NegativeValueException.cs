//Kunal Goyal
//18021553
//POE Task 1 and Task 2

using System;

namespace UserBudgetingApp2.ExceptionHandling
{//start of namespace

    //**(Creating Custom Exception in C# Examples - Dot Net Tutorials, n.d.), Reference in ReferenceList TextFile.**

    //This is a class created which serves a purpose for a custom Exception, in this case if the value is negative.

    public class NegativeValueException : Exception
    {//start of NegativeValueException Class
        public override string Message
        {
            get
            {
                return "Your Net Income is Negative Therefore, Please Rework On your Expenses!!";
            }

        }

    }//end of NegativeValueException Class

}//end of namespace
