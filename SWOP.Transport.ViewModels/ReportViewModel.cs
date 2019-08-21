using SWOP.Transport.IRepositories;
using SWOP.Transport.Models.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.ViewModels
{
    public class ReportViewModel : ViewModelBase
    {
        private readonly IReportRepository reportRepository;

        public Report Report { get; set; }

        public ReportViewModel(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;

            Report = reportRepository.Get();
        }
    }
}
