using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using SWOP.Transport.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SWOP.Transport.WPFClient
{
    public class MyAuthorizeService : IAuthorizeService
    {
        private IEmployeeRepository employeeRepository;

        public MyAuthorizeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public bool IsValid(string username, string password)
        {
            Employee employee = employeeRepository.Authorize(username, password);

            if (employee != null)
            {
                // var p = Thread.CurrentPrincipal;

                return true;
            }

            else
            {
                return false;
            }

            
        }
    }
}
