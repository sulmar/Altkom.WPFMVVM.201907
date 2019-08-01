using SWOP.Transport.IRepositories;
using SWOP.Transport.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace SWOP.Transport.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public IEnumerable<Profile> Profiles { get; set; }
        public Profile SelectedProfile { get; set; }

        public ICommand CancelCommand { get; private set; }
        public ICommand LoginCommand { get; private set; }


        private IProfileRepository profileRepository;

        public LoginViewModel(IProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;

            Profiles = profileRepository.Get();

            CancelCommand = new RelayCommand(() => Cancel());
            LoginCommand = new RelayCommand(() => Login());

        }

        private void Cancel()
        {
            
        }

        private void Login()
        {
            System.Threading.Thread.CurrentPrincipal
           
            
        }
    }
}
