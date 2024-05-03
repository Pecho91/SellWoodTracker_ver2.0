using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerRepositories;
using SellWoodTracker_ver2._0.Models.Buyers;
using SellWoodTracker_ver2_0.Locators;
using SellWoodTracker_ver2_0.Services.RequestedBuyerServices;
using SellWoodTracker_ver2_0.ViewModels.Base;
using SellWoodTracker_ver2_0.ViewModels.RelayCommands;
using SellWoodTracker_ver2_0.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SellWoodTracker_ver2_0.ViewModels.MainViewModels
{
    public class AddNewBuyerViewModel : ViewModelBase
    {
        private  AddRequestedBuyer _addRequestedBuyer;

        private RequestedBuyerModel _newBuyer;
        public RequestedBuyerModel NewBuyer
        {
            get
            {
                return _newBuyer;
            }
            set
            {
                if (_newBuyer != value)
                {
                    _newBuyer = value;
                    OnPropertyChanged(nameof(NewBuyer));
                }
            }
        }

        public ICommand AddNewBuyerCommand { get; }
        public ICommand ClearFieldsCommand { get; }

        public AddNewBuyerViewModel()
        {
            _addRequestedBuyer = new AddRequestedBuyer(RequestedBuyerServicesLocator.RequestedBuyerAdder);

            _newBuyer = new RequestedBuyerModel();
            CetZoneDataTime();
          
            AddNewBuyerCommand = new RelayCommand(ExecuteAddNewBuyerCommand, CanExecuteAddNewBuyerCommand);
        }

        private void ExecuteAddNewBuyerCommand(object obj)
        {
            bool confirmed = ShowAddNewBuyerConfirmationDialog("Do you want to ADD new Buyer?", "Confirmation");
            if (confirmed)
            {
                _addRequestedBuyer.AddNewRequestedBuyer(_newBuyer);
                _newBuyer = new RequestedBuyerModel();
                CetZoneDataTime();
                OnPropertyChanged(nameof(NewBuyer));
            }         
            Debug.WriteLine("RemoveCompletedBuyerButton clicked");
        }

        private bool CanExecuteAddNewBuyerCommand(object obj)
        {
            var nullableProperties = new List<string> { "CellphoneNumber", "EmailAddress" };

            var type = typeof(RequestedBuyerModel);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (nullableProperties.Contains(property.Name))
                {
                    continue;
                }

                var value = property.GetValue(_newBuyer);
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        private void CetZoneDataTime()
        {
            TimeZoneInfo cetZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            DateTime cetTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
            _newBuyer.DateTime = cetTime;          
        }

        private bool ShowAddNewBuyerConfirmationDialog(string messageText, string captionText)
        {
            MessageBoxResult result = MessageBox.Show(messageText, captionText, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}
