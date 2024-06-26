﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserInterfaces;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserRepositories;
using SellWoodTracker_ver2._0.Models.Users;
using SellWoodTracker_ver2_0.Services.UserServices;
using SellWoodTracker_ver2_0.ViewModels.Base;
using SellWoodTracker_ver2_0.ViewModels.RelayCommands;
using SellWoodTracker_ver2_0.Views;

namespace SellWoodTracker_ver2_0.ViewModels.MainViewModels
{
    public class MainViewModel : ViewModelBase
    {
        
        private readonly UserAccountPreview _userAccountPreview;

        
        private ViewModelBase _currentChildView;
        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        private string _caption;
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

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

        public ICommand AddNewBuyerViewCommand { get; set; }
        public ICommand RequestedBuyersViewCommand {  get; set; }
        public ICommand CompletedBuyersViewCommand { get; set;}

        public ICommand ReportViewCommand { get; set; }

        public MainViewModel()
        {
            var userServiceFactory = new UserServiceFactory(App.ConnectionString);
            var connectionManager = userServiceFactory.CreateSqlConnectionManager();
            var commandExecutor = userServiceFactory.CreateSqlCommandExecutor(connectionManager);
            
            _userAccountPreview = new UserAccountPreview(new UserGetter(connectionManager, commandExecutor));

            AddNewBuyerViewCommand = new RelayCommand(ExecuteAddNewBuyerViewCommand);
            RequestedBuyersViewCommand = new RelayCommand(ExecuteRequestedBuyersViewCommand);
            CompletedBuyersViewCommand = new RelayCommand(ExecuteCompletedBuyersViewCommand);
            ReportViewCommand = new RelayCommand(ExecuteReportViewCommand);

            ExecuteRequestedBuyersViewCommand(null);           
            LoadCurrentUserData();
        }

        private bool CanExecuteAddNewBuyerViewCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteAddNewBuyerViewCommand(object obj)
        {
            CurrentChildView = new AddNewBuyerViewModel();
            Caption = "ADDNEW_BUYER";
        }

        private bool CanExecuteRequestedBuyersViewCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteRequestedBuyersViewCommand(object obj)
        {
            CurrentChildView = new RequestedBuyersViewModel();
            Caption = "REQ_BUYERS";
        }

        private bool CanExecuteCompletedBuyersViewCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteCompletedBuyersViewCommand(object obj)
        {
            CurrentChildView = new CompletedBuyersViewModel();
            Caption = "COMP_BUYERS";
        }

        private void ExecuteReportViewCommand(object obj)
        {
            CurrentChildView = new ReportViewModel();
            Caption = "REPORT";
        }

        private void LoadCurrentUserData()
        {
            CurrentUserAccount = _userAccountPreview.GetCurrentUserAccount();
        }
    }
}
