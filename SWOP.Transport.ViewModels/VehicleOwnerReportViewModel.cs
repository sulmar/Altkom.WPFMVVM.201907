using SWOP.Transport.IRepositories;
using SWOP.Transport.Models.Reports;

namespace SWOP.Transport.ViewModels
{
    public class VehicleOwnerReportViewModel : ViewModelBase
    {
        private readonly IReportRepository reportRepository;

        public VehicleOwnerReport Report { get; set; }

        public VehicleOwnerReportViewModel(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;

            Report = reportRepository.GetVehicleOwnerReport();
        }
    }


}
