using System;
using System.Windows;
using System.Windows.Controls;
using UserBudgetingApp2.ExceptionHandling;
using UserBudgetingApp2.MainCode;

namespace UserBudgetingApp2.MVVM.View
{
    /// <summary>
    /// Interaction logic for VehicleView.xaml
    /// </summary>
    public partial class VehicleView : UserControl
    {
        public VehicleView()
        {
            InitializeComponent();
        }

        private void submitButton_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {//start of try statement

                string makeAndModel = tbMakeAndModel.Text;
                double purchasePrice = Convert.ToDouble(tbVPurchasePrice.Text);
                double vDeposiMade = Convert.ToDouble(tbDepositMade.Text);
                double vInterestRate = Convert.ToDouble(tbVInterestRate.Text);
                double insurancePrem = Convert.ToDouble(tbInsurancePremium.Text);

                Vehicle vData = new Vehicle(makeAndModel, purchasePrice, vDeposiMade, vInterestRate, insurancePrem);


                int count = ListHandler.userList.Count - 1;


                if ((ListHandler.userList[count].FinalAmount - vData.MonthlyVehicleRepayments) < 0)
                {//start of if statment

                    throw new NegativeValueException(); //throws a new custom exception in a case of negative monthly balance.

                }//end of if statment

                HomeView.expenseList.Add(vData);

                string output = ("=================================" + "\n" +
                                 "NAME  : " + ListHandler.userList[count].Name.ToUpper() + "\n" +
                                 "------------------------------------------------------" + "\n" +
                                 "Car Make & Model \t : " + vData.MakeAndModel + "\n" +
                                 "Car Purchase Price \t : R" + vData.PurchasePrice + "\n" +
                                 "Deposit Made \t : R" + vData.VDepositMade + "\n" +
                                 "Interest Rate \t : " + vData.VInterestRate + "%\n" +
                                 "Insurcance Premium  : R" + vData.InsurancePrem + "\n" +
                                 "------------------------------------------------------" + "\n" +
                                 "Car Installments Per Month : R" + vData.MonthlyVehicleRepayments + "\n" +
                                 "=================================");

                //the display of a report after the user clicks on the submit button.
                MessageBox.Show(output, "REPORT");

                resetTextBoxes();

            }//end of try statement

            catch (NullReferenceException)
            {//start of first catch statement

                
                MessageBox.Show("Please Add A User First!!", "ERROR!", MessageBoxButton.OK, MessageBoxImage.Warning);

            }//end of first catch statemetn
            catch (FormatException)
            {//start of second statement

                MessageBox.Show("Please Enter A Correct Syntax!!", "ERROR");

                resetTextBoxes();

            }//end of the second catch statement
            catch (NegativeValueException output)
            {//start of third catch statement

                MessageBox.Show(output.Message, "WARNING");

                resetTextBoxes();


            } //end of third catch statement.
        }

        public void resetTextBoxes()
        {
            tbMakeAndModel.Clear();
            tbVPurchasePrice.Clear();
            tbDepositMade.Clear();
            tbVInterestRate.Clear();
            tbInsurancePremium.Clear();
        }
    }
}
