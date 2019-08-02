using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SWOP.Transport.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IAuthorizeService authorizeService;

        //public ICommand ShowVehiclesCommand { get; private set; }
        //public ICommand ShowEmployeesCommand { get; private set; }

        public ICommand ShowViewCommand { get; private set; }

        public bool IsAuthenticated => authorizeService.IsAuthenticated;


        public ShellViewModel(INavigationService navigationService, IAuthorizeService authorizeService)
        {
            this.navigationService = navigationService;
            this.authorizeService = authorizeService;

            authorizeService.AuthenticatedChanged += AuthorizeService_AuthenticatedChanged;


            //ShowVehiclesCommand = new RelayCommand(() => ShowVehicles());
            //ShowEmployeesCommand = new RelayCommand(() => ShowEmployees());

            ShowViewCommand = new RelayCommand<string>(p => ShowView(p));
        }

        private void AuthorizeService_AuthenticatedChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(IsAuthenticated));
        }

        private void ShowView(string viewname) => navigationService.Navigate(viewname);

        //private void ShowVehicles() => navigationService.Navigate("Vehicles");
        //private void ShowEmployees() => navigationService.Navigate("Employees");

      
    }
}
