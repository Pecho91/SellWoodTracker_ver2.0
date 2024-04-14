﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SellWoodTracker_ver2._0.DataAccess.UserInterfaces;
using SellWoodTracker_ver2._0.DataAccess.UserRepositories;
using SellWoodTracker_ver2._0.Models;
using SellWoodTracker_ver2_0.ViewModels.Base;

namespace SellWoodTracker_ver2_0.ViewModels.MainViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository _userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get 
            { 
                return _currentUserAccount; 
            }
            set 
            {  
                _currentUserAccount = value; 
                OnPropertyChanged(nameof(CurrentUserAccount)); 
            }
        }

        public MainViewModel()
        {
            _userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = _userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName="Invalid user, not logged in";
            }
        }
    }
}