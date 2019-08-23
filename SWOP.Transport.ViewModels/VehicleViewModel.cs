using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace SWOP.Transport.ViewModels
{
    public class VehicleViewModel : ViewModelBase
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly INavigationService navigationService;


        public IEnumerable<VehicleType> VehicleTypes => Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>();

        public IEnumerable<Employee> Employees { get; set; }
        public Employee Employee { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public VehicleViewModel(
            IVehicleRepository vehicleRepository, 
            IEmployeeRepository employeeRepository,
            INavigationService navigationService)
        {
            this.vehicleRepository = vehicleRepository;
            this.employeeRepository = employeeRepository;
            this.navigationService = navigationService;

            SaveCommand = new RelayCommand(() => Save());
            CancelCommand = new RelayCommand(() => Cancel());

            Load();
        }

        private void Load()
        {
            Employees = employeeRepository.Get();

            if (navigationService.Parameter==null)
            {
                Vehicle = new Vehicle();
                Employee = new Policeman();

             //   Vehicle.Owner = Employee;
            }
            else
            {
                Vehicle = vehicleRepository.Get((int)navigationService.Parameter);
            }
        }

        private void Cancel()
        {
            navigationService.GoBack();
        }

        public Vehicle Vehicle { get; set; }

        public bool IsNew => Vehicle.Id == 0;


        private void Save()
        {
            if (IsNew)
            {
                // vehicleRepository.Add(Vehicle);

                vehicleRepository.Add(Vehicle, Employee);
            }
            else
            {
                vehicleRepository.Update(Vehicle);
            }

            navigationService.GoBack();
        }
    }
}
