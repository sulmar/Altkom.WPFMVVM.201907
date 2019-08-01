using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWOP.Transport.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public IEnumerable<Profile> Profiles { get; set; }
        public Profile SelectedProfile { get; set; }
    }
}
