using System;
using System.Collections.Generic;
using UserBudgetingApp2.MainCode;
using System.Windows;
using System.Windows.Controls;
using UserBudgetingApp2.ExceptionHandling;

namespace UserBudgetingApp2.MVVM.View
{//start of namespace

    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {//start of class

        public HomeView()
        {
            
            InitializeComponent();
            HideComponents();
        
        }

        public static double monthlyIncome;
        public static double monthlyTaxDeducted;
        public static string name;
        public static List<double> monthlyExpense; //created generic List for expenses instead of an array.
        public static List<Expense> expenseList; //created  Expense List to store the Expense related info

        private void SubmitButton_Clicked(object sender, RoutedEventArgs e)
        {//start of button event method.

            try
            {//start of try statement

                if (rentingRB.IsChecked == true) //If statment chekcks if the user selects the rent Radio button
                { //start of first if statement

                    tbPropPrice.Clear();
                    tbDeposit.Clear();
                    tbInterestRate.Clear();
                    tbRepaymentMonths.Clear();


                    //Stores the data from text boxes that the user has entered into variables
                    name = tbUserName.Text;
                    monthlyIncome = Convert.ToDouble(tbMonthlyIncome.Text);
                    monthlyTaxDeducted = Convert.ToDouble(tbMonthlyTax.Text);


                    //stores the regular monthly expenses into a Generic List
                    monthlyExpense = new List<double>();
                    monthlyExpense.Insert(0, Convert.ToDouble(tbGroceries.Text));
                    monthlyExpense.Insert(1, Convert.ToDouble(tbWaterAndLights.Text));
                    monthlyExpense.Insert(2, Convert.ToDouble(tbTravelCosts.Text));
                    monthlyExpense.Insert(3, Convert.ToDouble(tbTele.Text));
                    monthlyExpense.Insert(4, Convert.ToDouble(tbOtherExpenses.Text));

                    //rent object created
                    double rent = Convert.ToDouble(tbMonthlyRent.Text);

                    //the Variables with values are passed through the object to the Rent Class and General Expense Class
                    Rent rentData = new Rent(rent);
                    GeneralExpense geData = new GeneralExpense(monthlyTaxDeducted, monthlyExpense);


                    expenseList = new List<Expense>(); //initialised new Expense List.
                    expenseList.Add(rentData);         //Adding Rent Object to expenseList
                    expenseList.Add(geData);           //Adding GeneralExpense Object to expenseList.

                    //User Object Created to Pass User related data
                    User userData = new User(name, monthlyIncome, expenseList);


                    if (userData.FinalAmount < 0)
                    {//start of if statment

                        throw new NegativeValueException(); //throws a new custom exception in a case of negative monthly balance.

                    }//end of if statment

                    ListHandler.userList.Add(userData);//Adding the User Object to the  UserList in the ListHandler Class.


                    //storing the display message in a string variable.
                    string output =  "=================================" + "\n" +
                                     "NAME  : " + userData.Name.ToUpper() + "\n" +
                                     "------------------------------------------------------" + "\n" +
                                     "Gross Monthly Income \t : R" + userData.MonthlyIncome + "\n" +
                                     "Monthly Tax And Expenses \t : R" + (geData.MonthlyTaxDeducted + geData.TotalMonthlyExpenses) + "\n" +
                                     "Monthly Rent \t\t : R" + rentData.MonthlyRent + "\n" +
                                     "------------------------------------------------------" + "\n" +
                                     "Net Income After Deductions \t : R" + userData.FinalAmount + "\n" +
                                     "=================================";

                    //the display of a report after the user clicks on the submit button.
                    MessageBox.Show(output, "REPORT");


                    HideComponents(); //Hides the compoonents when the user is done inputting the data
                    ResetTextBoxes(); //Resets the text Boxes

                }//end of first if statment.

                if (buyingPropRB.IsChecked == true) //If statment chekcks if the user selects the rent Buying property button.
                {//start of second if statement.



                    //Stores the data from text boxes that the user has entered into variables
                    name = tbUserName.Text;
                    monthlyIncome = Convert.ToDouble(tbMonthlyIncome.Text);
                    monthlyTaxDeducted = Convert.ToDouble(tbMonthlyTax.Text);

                    //stores the regular monthly expenses into a Generic List ~ TASK 2
                    monthlyExpense = new List<double>();
                    monthlyExpense.Insert(0, Convert.ToDouble(tbGroceries.Text));
                    monthlyExpense.Insert(1, Convert.ToDouble(tbWaterAndLights.Text));
                    monthlyExpense.Insert(2, Convert.ToDouble(tbTravelCosts.Text));
                    monthlyExpense.Insert(3, Convert.ToDouble(tbTele.Text));
                    monthlyExpense.Insert(4, Convert.ToDouble(tbOtherExpenses.Text));

                    //stores the Home Loan related data into the variables below
                    double propertyPrice = Convert.ToDouble(tbPropPrice.Text);
                    double deposit = Convert.ToDouble(tbDeposit.Text);
                    double interestRate = Convert.ToDouble(tbInterestRate.Text);
                    double repaymentMonths = Convert.ToDouble(tbRepaymentMonths.Text);

                    //the Variables with values are passed through the object to the HomeLoan Class
                    HomeLoan hlData = new HomeLoan(propertyPrice, deposit, interestRate, repaymentMonths);
                    GeneralExpense geData = new GeneralExpense(monthlyTaxDeducted, monthlyExpense);

                    expenseList = new List<Expense>(); //initialised new Expense List.
                    expenseList.Add(hlData);           //Adding Rent Object to expenseList
                    expenseList.Add(geData);           //Adding GeneralExpense Object to expenseList

                    //User Object Created to Pass User related data
                    User userData = new User(name, monthlyIncome, expenseList);

                   

                    //This if statment checks whether the Final amount/ money left for the month is negative
                    if (userData.FinalAmount < 0)
                    {//start of if statement

                        throw new NegativeValueException(); //throws a new custom exception in a case of negative monthly balance.

                    }//end of if statement

                    ListHandler.userList.Add(userData);//Adding the User Object to the  UserList in the ListHandler Class.



                    //this if statement checks whether the monthly home loan installments are third of the gross monthly income after getting a boolean check in the homeloan class.
                    if (hlData.MonthlyHomeLoanRepayments == 0)
                    {//start of if statement

                        MessageBox.Show(hlData.AlertMessage, "Warning!");

                    }//end of if statement

                    //storing the display message in a string variable.
                    string output = ("======================================" + "\n" +
                                     "NAME  : " + userData.Name.ToUpper() + "\n" +
                                     "-------------------------------------------------------------" + "\n" +
                                     "Gross Monthly Income \t : R" + userData.MonthlyIncome + "\n" +
                                     "Monthly Tax And Expenses \t : R" + (geData.MonthlyTaxDeducted + geData.TotalMonthlyExpenses) + "\n" +
                                     "Monthly Loan Installments \t : R" + hlData.MonthlyHomeLoanRepayments + "\n" +
                                     "-------------------------------------------------------------" + "\n" +
                                     "Net Income After Deductions \t : R" + userData.FinalAmount + "\n" +
                                     "======================================");

                    //the display of a report after the user clicks on the submit button.
                    MessageBox.Show(output, "REPORT");

                    HideComponents(); //Hides the compoonents when the user is done inputting the data
                    ResetTextBoxes(); //Resets the text Boxes



                }//end of second if statement

                tbUserName.Clear();

            }//end of try statment

            //this catch statement throws an error and resets the text fields if the user has inputted wrong syntax or the text boxes have been left empty.
            catch (FormatException)
            {//start of first catch statement

                MessageBox.Show("Please Enter A Correct Syntax!!", "ERROR",MessageBoxButton.OK, MessageBoxImage.Warning);

                ResetTextBoxes();   //Hides the compoonents when the user is done inputting the data
                HideComponents();   //Resets the text Boxes

            }//end of the first catch statement

            catch (NegativeValueException output)
            {//start of seconf catch statement

                MessageBox.Show(output.Message, "WARNING");

                ResetTextBoxes();   //Hides the compoonents when the user is done inputting the data
                HideComponents();   //Resets the text Boxes

            } //end of second catch statement.

        }//end of submit button method

      


       
        //Method For when the rent radio button is checked/clicked
        private void RentRB_Checked(object sender, RoutedEventArgs e)
        {
            rentBorder.Visibility = Visibility.Visible;
            submitButton.Visibility = Visibility.Visible;
        }

        //Method For when the rent radio button is unchecked
        private void RentRB_Unchecked(object sender, RoutedEventArgs e)
        {
            rentBorder.Visibility = Visibility.Hidden;
        }

        //Method For when the Home Loan radio button is checked/clicked
        private void BuyingPropRB_Checked(object sender, RoutedEventArgs e)
        {
            propBorder.Visibility = Visibility.Visible;
            submitButton.Visibility = Visibility.Visible;
        }

        //Method For when the Home Loan radio button is unchecked
        private void BuyingPropRB_Unchecked(object sender, RoutedEventArgs e)
        {
            propBorder.Visibility = Visibility.Hidden;
        }

        //Hides The components on the User Control.
        private void HideComponents()
        {//start of HideComponents() method

            rentBorder.Visibility = Visibility.Hidden;
            propBorder.Visibility = Visibility.Hidden;
            submitButton.Visibility = Visibility.Hidden;

        }//end of HideComponents() method

        //resets all the text fields.
        public void ResetTextBoxes()
        {//start of resetTextBoxes() method

            tbMonthlyIncome.Clear();
            tbMonthlyTax.Clear();
            tbGroceries.Clear();
            tbWaterAndLights.Clear();
            tbTele.Clear();
            tbTravelCosts.Clear();
            tbOtherExpenses.Clear();
            tbPropPrice.Clear();
            tbDeposit.Clear();
            tbInterestRate.Clear();
            tbRepaymentMonths.Clear();
            tbMonthlyRent.Clear();
            rentingRB.IsChecked = false;
            buyingPropRB.IsChecked = false;


        }//end of resetTextBoxes() method

    }//end of class

}//end of namespace
