
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserInterfaces;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserRepositories;
using SellWoodTracker_ver2._0.Models.Users;
using SellWoodTracker_ver2_0.Services.UserServices;
using SellWoodTracker_ver2_0.ViewModels.Base;

namespace SellWoodTracker_ver2_0.ViewModels.MainViewModels
{
    public class MainViewModel : ViewModelBase
    {
        
        private readonly UserAccountPreview _userAccountPreview;

        private UserAccountModel _currentUserAccount;
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
            _userAccountPreview = new UserAccountPreview(new UserRepository());          
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            CurrentUserAccount = _userAccountPreview.GetCurrentUserAccount();
        }
    }
}
