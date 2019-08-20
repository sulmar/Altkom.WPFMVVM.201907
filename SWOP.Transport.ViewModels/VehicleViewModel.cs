using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SWOP.Transport.ViewModels
{
    public class VehicleViewModel : ViewModelBase
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly INavigationService navigationService;

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public VehicleViewModel(IVehicleRepository vehicleRepository, 
            INavigationService navigationService)
        {
            this.vehicleRepository = vehicleRepository;
            this.navigationService = navigationService;

            SaveCommand = new RelayCommand(() => Save());
            CancelCommand = new RelayCommand(() => Cancel());

            Load();
        }

        private void Load()
        {
            if (navigationService.Parameter==null)
            {
                Vehicle = new Vehicle();
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
                vehicleRepository.Add(Vehicle);
            }
            else
            {
                vehicleRepository.Update(Vehicle);
            }

            navigationService.GoBack();
        }
    }
}
