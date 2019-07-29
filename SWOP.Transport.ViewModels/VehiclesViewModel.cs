using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System.Collections.Generic;

namespace SWOP.Transport.ViewModels
{
    public class VehiclesViewModel : ViewModelBase
    {
        public ICollection<Vehicle> Vehicles { get; set; }

        public Vehicle SelectedVehicle { get; set; }

        private IVehicleRepository vehicleRepository;

        public VehiclesViewModel(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;

            Vehicles = vehicleRepository.Get();
        }

        
    }
}
