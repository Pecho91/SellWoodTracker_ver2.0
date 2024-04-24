using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerRepositories;
using SellWoodTracker_ver2._0.Models.Buyers;
using SellWoodTracker_ver2_0.Services.BuyerServices;
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

namespace SellWoodTracker_ver2_0.ViewModels.MainViewModels
{
    public class RequestedBuyersViewModel : ViewModelBase
    {
        private BuyersServices _buyersServices;

        private ObservableCollection<RequestedBuyerModel> _requestedBuyers;
        public ObservableCollection<RequestedBuyerModel> RequestedBuyers
        {
            get { return _requestedBuyers; }

            set
            {
                _requestedBuyers = value;
                OnPropertyChanged(nameof(RequestedBuyerModel));
            }
        }

        private RequestedBuyerModel _selectedRequestedBuyer;
        public RequestedBuyerModel SelectedRequestedBuyer
        {
            get { return _selectedRequestedBuyer; }
            set
            {
                _selectedRequestedBuyer = value;
                OnPropertyChanged(nameof(SelectedRequestedBuyer));
            }
        }

        public ICommand DeleteRequestedBuyerCommand { get; }
        public RequestedBuyersViewModel()
        {

            _buyersServices = new BuyersServices(new RequestedBuyerRepository(App.ConnectionString), new CompletedBuyerRepository(App.ConnectionString));

            DeleteRequestedBuyerCommand = new RelayCommand(ExecuteDeleteRequestedBuyer);
            LoadRequestedBuyers();
        }

        private void LoadRequestedBuyers()
        {
            RequestedBuyers = new ObservableCollection<RequestedBuyerModel>(_buyersServices.GetAllRequestedBuyers());
        }

        private void ExecuteDeleteRequestedBuyer(object obj)
        {
            if (_selectedRequestedBuyer != null)
            {
                bool confirmed = ShowDeleteConfirmationDialog("Are you sure you want to delete?");
                if (confirmed)
                {
                    _buyersServices.RemoveRequestedBuyer(SelectedRequestedBuyer.Id);
                    RequestedBuyers.Remove(SelectedRequestedBuyer);
                }
            }
            Debug.WriteLine("RemoveRequestedBuyer clicked");
        }

        private bool ShowDeleteConfirmationDialog(string messageBoxText)
        {
            MessageBoxResult result = MessageBox.Show(messageBoxText, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}
