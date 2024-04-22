using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyeInterface;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserInterfaces;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserRepositories;
using SellWoodTracker_ver2._0.Models.Buyers;

using SellWoodTracker_ver2_0.Services.LoginServices;
using SellWoodTracker_ver2_0.ViewModels.Base;
using SellWoodTracker_ver2_0.ViewModels.RelayCommands;
using SellWoodTracker_ver2_0.Views;

namespace SellWoodTracker_ver2_0.ViewModels.LoginViewModels
{
    public class LoginViewModel : ViewModelBase
    {    
        private readonly AuthenticationLoginService _authenticationLoginService;
        private readonly UserIdentityService _userIdentityService;
        
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

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        private bool _isViewVisible = true;
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        //Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        //Constructor
        public LoginViewModel()
        {
            if (App.ConnectionString == null)
            {
                throw new InvalidOperationException("Connection string is not initialized.");
            }
        
            _authenticationLoginService = new AuthenticationLoginService(new UserRepository(App.ConnectionString));
            _userIdentityService = new UserIdentityService();
            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            //RecoverPasswordCommand = new RelayCommand(p => ExecuteRecoverPasswordCommand("", ""));
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 4 || Password == null || Password.Length < 4)
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = _authenticationLoginService.AuthenticateLoginUser(Username, Password);
            if (isValidUser)
            {
                _userIdentityService.SetCurrentPrincipal(Username);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }

        private void ExecuteRecoverPasswordCommand(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
