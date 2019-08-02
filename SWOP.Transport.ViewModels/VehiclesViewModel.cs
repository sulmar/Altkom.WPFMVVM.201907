using FluentValidation;
using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using SWOP.Transport.Models.SearchCriterias;
using SWOP.Transport.Models.Validators;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWOP.Transport.ViewModels
{
    public class VehiclesViewModel : ViewModelBase
    {
        public ICollection<Vehicle> Vehicles
        {
            get => _vehicles;
            set
            {
                _vehicles = value;
                //OnPropertyChanged(nameof(Vehicles));
                OnPropertyChanged();
            }
        }

        public Vehicle SelectedVehicle { get; set; }

        public VehicleSearchCriteria Criteria { get; set; }

        private IVehicleRepository vehicleRepository;
        private ICollection<Vehicle> _vehicles;

        public ICommand SearchCommand { get; set; }

        public VehiclesViewModel(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;

            this.Criteria = new VehicleSearchCriteria();

            SearchCommand = new RelayCommand(async () => await SearchAsync());

           // Vehicles = vehicleRepository.Get();
        }

        private async Task SearchAsync()
        {
            IValidator validator = new VehicleSearchCriteriaValidator();

            var results = validator.Validate(Criteria);

            // this.Vehicles = vehicleRepository.Get(Criteria);

            this.Vehicles = await vehicleRepository.GetAsync(Criteria);
        }


        private bool CanSearch => !Criteria.HasErrors;


    }
}
