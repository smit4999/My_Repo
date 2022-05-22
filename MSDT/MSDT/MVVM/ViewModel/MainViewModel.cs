using System;
using System.Windows;
using MSDT.Core;
using MSDT.MVVM.View;

namespace MSDT.MVVM.ViewModel
{
    class MainViewModel: ObservableObject
    {

        public Relay HomeViewCommand { get; set; }

        public Relay UserViewCommand { get; set; }

        public Relay AllUser { get; set; }


        public HomeViewModel HomeVM { get; set; }

        public UserViewModel UserVM { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

       static public bool AllUserActivated = false;

        public MainViewModel()
        {
          
            HomeVM = new HomeViewModel();
            UserVM = new UserViewModel();
           

            CurrentView = HomeVM;

            HomeViewCommand = new Relay(o =>
            {
                CurrentView = HomeVM;
            });

            UserViewCommand = new Relay(o =>
            {
                CurrentView = UserVM;
            });

            AllUser = new Relay(o =>
            {
                
                if (AllUserActivated == false)
                {
                    AllUserActivated = true;
                    WindowAllUser wau = new WindowAllUser();
                    wau.Show();                    
                }
                                                
            });

        }


    }
}
