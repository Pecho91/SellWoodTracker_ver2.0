using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerRepositories;
using SellWoodTracker_ver2._0.Models.Buyers;
using SellWoodTracker_ver2_0.Services.BuyerServices;
using SellWoodTracker_ver2_0.ViewModels.Base;
using SellWoodTracker_ver2_0.ViewModels.RelayCommands;
using SellWoodTracker_ver2_0.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SellWoodTracker_ver2_0.ViewModels.MainViewModels
{
    public class AddNewBuyerViewModel : ViewModelBase
    {
        private  BuyersServices _buyersServices;

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
            _buyersServices = new BuyersServices(new RequestedBuyerRepository(App.ConnectionString), new CompletedBuyerRepository(App.ConnectionString));
            _newBuyer = new RequestedBuyerModel();
            CetZoneDataTime();
          
            AddNewBuyerCommand = new RelayCommand(ExecuteAddNewBuyerCommand);
        }

        private void ExecuteAddNewBuyerCommand(object obj)
        {
            _buyersServices.AddRequestedBuyer(_newBuyer);
            _newBuyer = new RequestedBuyerModel();
            CetZoneDataTime();
            OnPropertyChanged(nameof(NewBuyer));
            
        }

        private void CetZoneDataTime()
        {
            TimeZoneInfo cetZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            DateTime cetTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
            _newBuyer.DateTime = cetTime;          
        }
    }
}
