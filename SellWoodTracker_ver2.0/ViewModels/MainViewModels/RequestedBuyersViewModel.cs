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

namespace SellWoodTracker_ver2_0.ViewModels.MainViewModels
{
    public class RequestedBuyersViewModel : ViewModelBase
    {
        private MoveRequestedBuyer _moveRequestedBuyer;
        private DeleteRequestedBuyer _deleteRequestedBuyer;
        private PreviewRequestedBuyers _previewRequestedBuyer;

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

        public ICommand MoveRequestedBuyerToCompletedCommand { get; }
        public ICommand DeleteRequestedBuyerCommand { get; }
        public RequestedBuyersViewModel()
        {

            _moveRequestedBuyer = new MoveRequestedBuyer(RequestedBuyerServicesLocator.RequestedBuyerRemover, CompletedBuyerServicesLocator.CompletedBuyerAdder);
            _deleteRequestedBuyer = new DeleteRequestedBuyer(RequestedBuyerServicesLocator.RequestedBuyerRemover);
            _previewRequestedBuyer = new PreviewRequestedBuyers(RequestedBuyerServicesLocator.RequestedBuyerGetter);

            MoveRequestedBuyerToCompletedCommand = new RelayCommand(ExecuteMoveRequestedBuyerToCompleted);
            DeleteRequestedBuyerCommand = new RelayCommand(ExecuteDeleteRequestedBuyer);
            LoadRequestedBuyers();
        }

        private void LoadRequestedBuyers()
        {
            //TODO get all requested
            RequestedBuyers = new ObservableCollection<RequestedBuyerModel>(_previewRequestedBuyer.GetAllRequestedBuyers());           
        }

        public void ExecuteMoveRequestedBuyerToCompleted(object obj)
        {
            if (_selectedRequestedBuyer != null)
            {
                bool confirmed = ShowDeleteConfirmationDialog("Are you sure you want to complete the Buyer?", "Confirmation");
                if (confirmed)
                {
                    _moveRequestedBuyer.MoveRequestedBuyerToCompleted(SelectedRequestedBuyer.Id);
                    RequestedBuyers.Remove(SelectedRequestedBuyer);                    
                }
                Debug.WriteLine("CompleteSelectedButton clicked");
            }
        }

        private void ExecuteDeleteRequestedBuyer(object obj)
        {
            if (_selectedRequestedBuyer != null)
            {
                bool confirmed = ShowDeleteConfirmationDialog("Are you sure you want to delete?", "Confirmation");
                if (confirmed)
                {
                    _deleteRequestedBuyer.RemoveRequestedBuyer(SelectedRequestedBuyer.Id);
                    RequestedBuyers.Remove(SelectedRequestedBuyer);
                }
            }
            Debug.WriteLine("DeleteSelectedButton clicked");
        }

        private bool ShowDeleteConfirmationDialog(string messageText, string captionText)
        {
            MessageBoxResult result = MessageBox.Show(messageText, captionText, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}
