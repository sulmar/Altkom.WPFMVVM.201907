using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using SWOP.Transport.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
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

        public bool IsAuthenticated => Thread.CurrentPrincipal.Identity.IsAuthenticated;

        public string UserName => Thread.CurrentPrincipal.Identity.Name;

        public event EventHandler AuthenticatedChanged;

        public bool IsInRole(string role) => Thread.CurrentPrincipal.IsInRole(role);

        public bool IsValid(string username, string password)
        {
            Employee employee = employeeRepository.Authorize(username, password);

            if (employee != null)
            {
                IList<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, employee.FullName),
                    new Claim(ClaimTypes.Surname, employee.LastName),
                    new Claim(ClaimTypes.MobilePhone, employee.Phone),
                    new Claim(ClaimTypes.Email, employee.Email),
                    new Claim(ClaimTypes.Role, "developer"),
                    new Claim(ClaimTypes.Role, "trainer"),
                };

                IIdentity identity = new ClaimsIdentity(claims, "altkom");

                IPrincipal principal = new ClaimsPrincipal(identity);

                Thread.CurrentPrincipal = principal;

                AuthenticatedChanged?.Invoke(this, EventArgs.Empty);

                return identity.IsAuthenticated;
            }

            else
            {
                return false;
            }

            
        }
    }
}
