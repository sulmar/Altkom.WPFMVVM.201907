using SWOP.Transport.FakeRepositories;
using SWOP.Transport.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOP.Transport.WPFClient
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {

        }

        public VehiclesViewModel VehiclesViewModel => new VehiclesViewModel(new FakeVehicleRepository(new FakeRepositories.Fakers.VehicleFaker()));
        public EmployeesViewModel EmployeesViewModel => new EmployeesViewModel(new FakeEmployeeRepository());

    }
}
