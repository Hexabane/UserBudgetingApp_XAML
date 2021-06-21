//Kunal Goyal
//18021553
//PROG POE


using System.Windows;
using System.Windows.Input;



namespace UserBudgetingApp2
{//start of namespace

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {//start of class

        public MainWindow()
        {
            InitializeComponent();
        }

        //Method for when the mouse enters a list view item / the side bar menu.
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {//start of mouse enter.

            // Set ToolTip Visibility
            if (Tg_Btn.IsChecked == true)
            {//start of first if statement


                tt_home.Visibility = Visibility.Collapsed;
                tt_contact.Visibility = Visibility.Collapsed;
                tt_report.Visibility = Visibility.Collapsed;
                tt_Statistic.Visibility = Visibility.Collapsed;

            }//end of second if statement

            else
            {//start if elese statement

                tt_home.Visibility = Visibility.Visible;
                tt_contact.Visibility = Visibility.Visible;
                tt_report.Visibility = Visibility.Visible;
                tt_Statistic.Visibility = Visibility.Visible;

            }//end of else statement



        }//end of mouse enter

        //(Design Pro, 2020) **REFERENCE IN REFERENCE LIST**
        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }


    }//end of class

}//end of namespace