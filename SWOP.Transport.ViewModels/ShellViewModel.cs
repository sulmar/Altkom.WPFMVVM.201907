using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SWOP.Transport.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        //public ICommand ShowVehiclesCommand { get; private set; }
        //public ICommand ShowEmployeesCommand { get; private set; }

        public ICommand ShowViewCommand { get; private set; }


        public ShellViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            //ShowVehiclesCommand = new RelayCommand(() => ShowVehicles());
            //ShowEmployeesCommand = new RelayCommand(() => ShowEmployees());

            ShowViewCommand = new RelayCommand<string>(p => ShowView(p));
        }

        private void ShowView(string viewname) => navigationService.Navigate(viewname);

        //private void ShowVehicles() => navigationService.Navigate("Vehicles");
        //private void ShowEmployees() => navigationService.Navigate("Employees");
    }
}
