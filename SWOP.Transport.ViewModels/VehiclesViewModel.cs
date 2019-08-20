using FluentValidation;
using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using SWOP.Transport.Models.SearchCriterias;
using SWOP.Transport.Models.Validators;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWOP.Transport.ViewModels
{
    public class VehiclesViewModel : ViewModelBase
    {

        private ObservableCollection<Vehicle> _vehicles;
        public ObservableCollection<Vehicle> Vehicles
        {
            get => _vehicles;
            set
            {
                _vehicles = value;
                //OnPropertyChanged(nameof(Vehicles));
                OnPropertyChanged();
            }
        }

        public Vehicle SelectedVehicle
        {
            get => _selectedVehicle;
            set
            {
                _selectedVehicle = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSelectedVehicle));
                UpdateCommand?.OnCanExecuteChanged();
                RemoveCommand?.OnCanExecuteChanged();
            }
        }

        public VehicleSearchCriteria Criteria { get; set; }

        private readonly IVehicleRepository vehicleRepository;
        private readonly INavigationService navigationService;

        private Vehicle _selectedVehicle;

        public ICommand SearchCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }

        

        public VehiclesViewModel(
            IVehicleRepository vehicleRepository, 
            INavigationService navigationService)
        {
            this.vehicleRepository = vehicleRepository;
            this.navigationService = navigationService;
            this.Criteria = new VehicleSearchCriteria();

            SearchCommand = new RelayCommand(async () => await SearchAsync());
            AddCommand = new RelayCommand(() => Add());
            UpdateCommand = new RelayCommand(() => Update(), () => IsSelectedVehicle);
            RemoveCommand = new RelayCommand(() => Remove(), () => IsSelectedVehicle);

            // Vehicles = vehicleRepository.Get();
        }

        public bool IsSelectedVehicle => SelectedVehicle != null;

        private void Add()
        {
            navigationService.Navigate("Vehicle");
        }

        private void Update()
        {
            navigationService.Navigate("Vehicle", SelectedVehicle.Id);
        }

        private void Remove()
        {
            vehicleRepository.Remove(SelectedVehicle.Id);
            Vehicles.Remove(SelectedVehicle);
        }

        private async Task SearchAsync()
        {
            IValidator validator = new VehicleSearchCriteriaValidator();

            var results = validator.Validate(Criteria);

            // this.Vehicles = vehicleRepository.Get(Criteria);

            this.Vehicles = new ObservableCollection<Vehicle>(await vehicleRepository.GetAsync(Criteria));
        }


        private bool CanSearch => !Criteria.HasErrors;


    }
}
