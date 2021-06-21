using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UserBudgetingApp2.MainCode;
namespace UserBudgetingApp2.MVVM.View
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {//start of class

        public ReportView()
        {
            InitializeComponent();
            PopulateListBox();
            HideComponents();
        }

        public void PopulateListBox()
        {//start of populateListBox() method

          foreach(var item in ListHandler.userList)
            {
                lbViewUsers.Items.Add(item.Name.ToUpper());
            }
        }//end of populateListBox() method


        public static double totalExpenses; //public static variable created for storing the total expenses
        public static double userIncome; //public static variable created for storing the userincome
        /*
       |=====================================================================================================================|
       | This action method stores in the textfields to display data based on what the user has selected from the ListBox, It|
       | Uses Linq to search and sort the GenericList which has data for multiple users and display accordingly.             |      
       |=====================================================================================================================|
       */
        private void lbViewUsers_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {//start of selected index changed
            try
            {
                lbUserExpenses.Items.Clear();  //Clears the ListBox that displays Expenses after each different user is selected.
                ClearText(); //clears textboxes after each different user is selected


                string selectedItem = lbViewUsers.SelectedItem.ToString(); //gets the selected item by the user from the listbox 

                List<string> displayExpenseData = new List<string>(); //List created to store all the expense data.
                totalExpenses = 0;
                userIncome = 0;



                List<User> userData = ListHandler.userList;  //a new List is created to go through the user data

                //** (Corey, 2017). Reference in ReferenceList TextFile. **
                //LINQ statement to sort through the list and look  for the selected user and respective data and store it with that data.
                userData = userData.Where(x => x.Name.ToUpper() == selectedItem).ToList(); 
 
                foreach (var User in userData)
                {//start of first foreach loop

                    tbUserName.Text = User.Name.ToUpper().ToString(); //gets the Username of the selected user.
                    tbMonthlyIncome.Text = User.MonthlyIncome.ToString(); //gets the monthly income of the selected user.

                    userIncome = User.MonthlyIncome;

                    


                    foreach (Expense item in User.ExpenseList)
                    {//start of 2nd foreach loop

                        //IF STATEMENTS that gets the data based on what the user is saved with and fills the text boxes with the selected user data.

                        if (item.GetType().Name.ToString() == ("GeneralExpense"))
                        {//start of first if statement.

                            var generalExpense = (GeneralExpense)item;

                            //displying selected user data.
                            tbMonthlyExpenses.Text = generalExpense.TotalMonthlyExpenses.ToString();
                            tbTaxDeducted.Text = generalExpense.MonthlyTaxDeducted.ToString();

                            //storing the expense in a expense data list to later output it in descending order.
                            displayExpenseData.Add( "Total Monthly Misc. Expenses : R" + generalExpense.TotalMonthlyExpenses);
                            displayExpenseData.Add( "Total Tax Deducted : R" + generalExpense.MonthlyTaxDeducted);

                            //Calculating total expenses.
                            totalExpenses += generalExpense.TotalMonthlyExpenses + generalExpense.MonthlyTaxDeducted;


                        }//end of first if statement.

                        if (item.GetType().Name.ToString() == ("Rent"))
                        {//start of second if statment

                            var rent = (Rent)item;

                            labelHL.Visibility = Visibility.Hidden;
                            labelHLR.Visibility = Visibility.Hidden;
                            tbHLInstallments.Visibility = Visibility.Hidden;
                            labelRent.Visibility = Visibility.Visible;
                            labelRentR.Visibility = Visibility.Visible;
                            tbMonthlyRent.Visibility = Visibility.Visible;

                            //displying selected user data.
                            tbMonthlyRent.Text = rent.MonthlyRent.ToString();
                            tbMoneyLeft.Text = User.FinalAmount.ToString();

                            //storing the rent data in a expense data list to later output it in descending order.
                            displayExpenseData.Add("Monthly rent : R" + rent.MonthlyRent);

                            //Calculating total expenses.
                            totalExpenses += rent.MonthlyRent;

                        }//end of second if statement
                      
                        if (item.GetType().Name.ToString() == ("HomeLoan"))
                        {//start of third if statement

                            var homeLoan = (HomeLoan)item;

                            labelHL.Visibility = Visibility.Visible;
                            labelHLR.Visibility = Visibility.Visible;
                            tbHLInstallments.Visibility = Visibility.Visible;
                            labelRent.Visibility = Visibility.Hidden;
                            labelRentR.Visibility = Visibility.Hidden;
                            tbMonthlyRent.Visibility = Visibility.Hidden;

                            //displying selected user data.
                            tbHLInstallments.Text = homeLoan.MonthlyHomeLoanRepayments.ToString();
                            tbMoneyLeft.Text = User.FinalAmount.ToString();


                            //data for HomeLoan data stored in the List for displaying Expense Data
                            displayExpenseData.Add("Monthly HomeLoan Installments : R" + homeLoan.MonthlyHomeLoanRepayments);

                            //Calculating total expenses.
                            totalExpenses += homeLoan.MonthlyHomeLoanRepayments;


                        }//end of third if statement.

                        if (item.GetType().Name.ToString() == ("Vehicle"))
                        {//start of fourth if statement

                            var vehicle = (Vehicle)item;

                            tbMakeAndModel.Text = vehicle.MakeAndModel.ToString();
                            tbPurchasePrice.Text = vehicle.PurchasePrice.ToString();
                            tbDepositMade.Text = vehicle.VDepositMade.ToString();
                            tbInterestRate.Text = vehicle.VInterestRate.ToString();
                            tbInsurnacePremium.Text = vehicle.InsurancePrem.ToString();
                            tbVehicleInstallments.Text = vehicle.MonthlyVehicleRepayments.ToString();

                            tbMoneyLeft.Text = Math.Round(Convert.ToDouble(tbMoneyLeft.Text) - vehicle.MonthlyVehicleRepayments, 2).ToString();

                            //data for Vehicle stored in the List for displaying Expense Data
                            displayExpenseData.Add("Monthly Vehicle Installments : R" + vehicle.MonthlyVehicleRepayments);

                            //variable totalExpenses adds Vehicle repayments.
                            totalExpenses += vehicle.MonthlyVehicleRepayments;



                        }//end of fourth if statement

                    }//end  of second forloop

                    
                }//end of first for loop

                //Calls the method that displays the Expenses in Descending Order ~ TASK 2
                DisplayAndSortExpenses(displayExpenseData);
                //Calls the method for alert Message.
                alertMessage();

            }//end of try statement 

            catch (NullReferenceException)
            {
                //ignore exception for whenever a blank area is clicked on the ListBox.
            }

        }//start of selected index changed

           /*
        |=====================================================================================================================|
        | This Method displays the Alert message after its been delegated in the DelegateWorker Class                         |   
        |=====================================================================================================================|
        */
        public void alertMessage()
        {//start of alertMessage method

            if (DelegateWorker.WarningMessageExpense(expenseAlert) != null)
            {
                MessageBox.Show(DelegateWorker.WarningMessageExpense(expenseAlert), "WARNING");


            }
        }//end of alertMessage method

        /*
       |=====================================================================================================================|
       | This Method Displays and sorts the Expenses in the second List box in ViewUsers/Report Form                         |  
       |=====================================================================================================================|
       */
        public void DisplayAndSortExpenses(List<string> displayExpenseData)
        {//start of method

            //variable var created to sort the List of Expense data in to Descending order the alphaetical
            var expenseData = displayExpenseData.Select(s => new { Str = s, Split = s.Split('R') })
                              .OrderByDescending(x => double.Parse(x.Split[1]))
                              .ThenBy(x => x.Split[0]).Select(x => x.Str).ToList();

            //Adds the Variable var data into the list Box.
            for (int i = 0; i < expenseData.Count; i++)
            {
                lbUserExpenses.Items.Add(expenseData[i]);

            }
            lbUserExpenses.Items.Add("");
            lbUserExpenses.Items.Add("Total Net Expenses : R" + totalExpenses);

        } //end of method

        public static void expenseAlert(string message)
        {
            
        }


        //clears the text boxes for vehicle fields
        public void ClearText()
        {
            tbVehicleInstallments.Clear();
            tbPurchasePrice.Clear();
            tbInsurnacePremium.Clear();
            tbInterestRate.Clear();
            tbDepositMade.Clear();
            tbMakeAndModel.Clear();
              
        }

        //hides the Rent and homeloan related components on the Form
        public void HideComponents()
        {//start of hideComponents() method

            labelHL.Visibility = Visibility.Hidden;
            labelHLR.Visibility = Visibility.Hidden;
            tbHLInstallments.Visibility = Visibility.Hidden;
            labelRent.Visibility = Visibility.Hidden;
            labelRentR.Visibility = Visibility.Hidden;
            tbMonthlyRent.Visibility = Visibility.Hidden;

        }//end of hideComponents() method

    }//end of class

}//end of namespace
