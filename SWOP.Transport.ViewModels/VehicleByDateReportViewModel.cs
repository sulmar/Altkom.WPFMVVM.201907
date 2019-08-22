using SWOP.Transport.IRepositories;
using SWOP.Transport.Models.Reports;
using System.Windows.Input;

namespace SWOP.Transport.ViewModels
{
    public class VehicleByDateReportViewModel : ViewModelBase
    {
        private readonly IReportRepository reportRepository;
        private VehicleByDateReport _report;

        public VehicleByDateReport Report
        {
            get => _report;
            set
            {
                _report = value;
                OnPropertyChanged();
            }
        }

        public bool IsRemoved { get; set; }

        public ICommand LoadCommand { get; set; }

        public VehicleByDateReportViewModel(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;

            LoadCommand = new RelayCommand(() => Load());
        }

        private void Load()
        {
            Report = reportRepository.GetVehicleByDateReport(IsRemoved);
        }
    }


}
