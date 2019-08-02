using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.ViewModels
{
    public interface IAuthorizeService
    {
        bool IsValid(string username, string password);
        bool IsInRole(string role);
        bool IsAuthenticated { get; }

        event EventHandler AuthenticatedChanged;
    }
}
