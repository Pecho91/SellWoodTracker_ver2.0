using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserRepositories;
using SellWoodTracker_ver2_0.ViewModels.LoginViewModels;
using SellWoodTracker_ver2_0.ViewModels.RelayCommands;
using SellWoodTracker_ver2_0.ViewModels.Base;

namespace SellWoodTracker_ver2_0.Commands
{
    public class LoginCommand : ViewModelBase
    {
        private IUserRepository _userRepository;

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private SecureString _password;
        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginCommand()
        {
            _userRepository = new UserRepository();
        }

        public bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        public bool ExecuteLoginCommand(object obj)
        {         
            var isValidUser = _userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExecuteRecoverPasswordCommand(string v1, string v2)
        {
            throw new NotImplementedException();
        }


    }
}
