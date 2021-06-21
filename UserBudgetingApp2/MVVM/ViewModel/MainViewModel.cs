using UserBudgetingApp2.Core;

namespace UserBudgetingApp2.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand AddUserCommand { get; set; }
        
        public RelayCommand VehicleCommand { get; set; }

        public RelayCommand ReportCommand { get; set; }

        public RelayCommand StatisticCommand { get; set; }




        public AddUserViewModel AddUserVM { get; set; }

        public VehicleViewModel VehicleVM { get; set; }

        public ReportViewModel ReportVM { get; set; }

        public StatisticViewModel StatisticVM { get; set; }
 

        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set 
            {
                currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            AddUserVM = new AddUserViewModel();
            VehicleVM = new VehicleViewModel();
            ReportVM = new ReportViewModel();
            StatisticVM = new StatisticViewModel();
          

            CurrentView = AddUserVM;

            AddUserCommand = new RelayCommand(o =>
            {

                CurrentView = AddUserVM;

            });

            VehicleCommand = new RelayCommand(o =>
            {

                CurrentView = VehicleVM;

            });

            ReportCommand = new RelayCommand(o =>
            {

                CurrentView = ReportVM;

            });

            StatisticCommand = new RelayCommand(o =>
            {

                CurrentView = StatisticVM;

            });

        }


        }



    }
