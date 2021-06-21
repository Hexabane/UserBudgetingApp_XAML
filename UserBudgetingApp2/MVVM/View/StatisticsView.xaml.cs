using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UserBudgetingApp2.MainCode;
using UserBudgetingApp2.MVVM;


namespace UserBudgetingApp2.MVVM.View
{
    /// <summary>
    /// Interaction logic for StatisticsView.xaml
    /// </summary>
    public partial class StatisticsView : UserControl
    {
        public StatisticsView()
        {
            InitializeComponent();
            PopulateListBox();

            Chart.AxisX.Add(new Axis
            {
                Title="Month",
                Labels = new[] {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
            });

            Chart.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = YFormatter = value => value.ToString("C")
            });
        }

        //public SeriesCollection SeriesCollection { get; set; }
        //public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public void PopulateListBox()
        {//start of populateListBox() method

            foreach (var item in ListHandler.userList)
            {
                lbViewUsers.Items.Add(item.Name.ToUpper());
            }
        }//end of populateListBox() method

       
   
 
        private void lbViewUsers_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {

            string selectedItem = lbViewUsers.SelectedItem.ToString(); //gets the selected item by the user from the listbox 
           
            List<User> userData = ListHandler.userList;
            userData = userData.Where(x => x.Name.ToUpper() == selectedItem).ToList();

            ChartCode(userData);

            
        }

        public void ChartCode(List<User> userData)
        {



            //** (Corey, 2017). Reference in ReferenceList TextFile. **
            //LINQ statement to sort through the list and look  for the selected user and respective data and store it with that data.


            foreach (var User in userData)
            {//start of first foreach loop

                double monthlyIncome = User.MonthlyIncome;
                double totalExpenses = 0;
                double months = 0;
                double repayments = 0;

                foreach (Expense item in User.ExpenseList)
                {//start of 2nd foreach loop

                    //IF STATEMENTS that gets the data based on what the user is saved with and fills the text boxes with the selected user data.

                    if (item.GetType().Name.ToString() == ("GeneralExpense"))
                    {//start of first if statement.

                        var generalExpense = (GeneralExpense)item;

                        //Calculating total expenses.
                        totalExpenses += generalExpense.TotalMonthlyExpenses + generalExpense.MonthlyTaxDeducted;


                    }//end of first if statement.

                    if (item.GetType().Name.ToString() == ("Rent"))
                    {//start of second if statment

                        var rent = (Rent)item;

                        //Calculating total expenses.
                        totalExpenses += rent.MonthlyRent;

                    }//end of second if statement

                    if (item.GetType().Name.ToString() == ("HomeLoan"))
                    {//start of third if statement

                        var homeLoan = (HomeLoan)item;

                        //Calculating total expenses.
                        totalExpenses += homeLoan.MonthlyHomeLoanRepayments;
                        repayments = homeLoan.MonthlyHomeLoanRepayments;
                        months = homeLoan.Months;


                    }//end of third if statement.

                    if (item.GetType().Name.ToString() == ("Vehicle"))
                    {//start of fourth if statement

                        var vehicle = (Vehicle)item;

                        //variable totalExpenses adds Vehicle repayments.
                        totalExpenses += vehicle.MonthlyVehicleRepayments;



                    }//end of fourth if statement

                }//end  of second forloop

                Chart.Series.Clear();

                SeriesCollection series = new SeriesCollection();


                //SeriesCollection = new SeriesCollection
                //{
                //    new LineSeries
                //    {
                //        Title = "Series 1",
                //        Values = new ChartValues<double> {0,totalExpenses,totalExpenses,totalExpenses,totalExpenses}
                //    },
                //    new LineSeries
                //    {
                //        Title = "Series 2",
                //        Values = new ChartValues<double> {0,monthlyIncome,monthlyIncome,monthlyIncome,monthlyIncome },
                //        PointGeometry = null
                //    },


                //};

                double balance = 0;
                List<double> test = new List<double>();

                for(double i = months; i > -1; i--)
                {
                    if(i == 0)
                    {
                        totalExpenses = totalExpenses - repayments;
                    }
                }


                for (int i = 0; i < 11; i++)
                {
                    balance += (monthlyIncome - totalExpenses);
                    test.Add(balance);
                }
                series.Add
                    (

                    new LineSeries()
                    {
                        Title = "Expenses",
                        Values = new ChartValues<double> { 0, totalExpenses, totalExpenses, totalExpenses, totalExpenses, totalExpenses, totalExpenses, totalExpenses, totalExpenses, totalExpenses, totalExpenses, totalExpenses }
                    }

                    );

                series.Add
                    (
                    new LineSeries
                    {
                        Title = "Income",
                        Values = new ChartValues<double> { 0, monthlyIncome, monthlyIncome, monthlyIncome, monthlyIncome, monthlyIncome, monthlyIncome, monthlyIncome, monthlyIncome, monthlyIncome, monthlyIncome, monthlyIncome },

                    }
                    );

                series.Add
                    (
                    new LineSeries
                    {
                        Title = "Balance",
                        Values = new ChartValues<double> { 0, test[0], test[1], test[2], test[3], test[4], test[5], test[6], test[7], test[8], test[9], test[10] },

                    }
                    );

            

                Chart.Series = series;



            

            }//end of first fooreach loop


           


        }

        private void clearButton_Clicked(object sender, RoutedEventArgs e)
        {
           
          
           
            
        }
    }
}
