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
using System.Windows.Input;
using System.Windows;

namespace SellWoodTracker_ver2_0.ViewModels.MainViewModels
{
    public class CompletedBuyersViewModel : ViewModelBase
    {
        private BuyersServices _buyersServices;

        private ObservableCollection<CompletedBuyerModel> _completedBuyers;
        public ObservableCollection<CompletedBuyerModel> CompletedBuyers
        {
            get { return _completedBuyers; }

            set
            {
                _completedBuyers = value;
                OnPropertyChanged(nameof(CompletedBuyerModel));
            }
        }

        private CompletedBuyerModel _selectedCompletedBuyer;
        public CompletedBuyerModel SelectedCompletedBuyer
        {
            get { return _selectedCompletedBuyer; }
            set
            {
                _selectedCompletedBuyer = value;
                OnPropertyChanged(nameof(SelectedCompletedBuyer));
            }
        }

        public ICommand DeleteCompletedBuyerCommand { get; }
        public CompletedBuyersViewModel()
        {

            _buyersServices = new BuyersServices(new RequestedBuyerRepository(App.ConnectionString), new CompletedBuyerRepository(App.ConnectionString));

            DeleteCompletedBuyerCommand = new RelayCommand(ExecuteDeleteCompletedBuyer);
            LoadCompletedBuyers();
        }

        private void LoadCompletedBuyers()
        {
            CompletedBuyers = new ObservableCollection<CompletedBuyerModel>(_buyersServices.GetAllCompletedBuyers());
        }

        private void ExecuteDeleteCompletedBuyer(object obj)
        {
            if (_selectedCompletedBuyer != null)
            {
                bool confirmed = ShowDeleteConfirmationDialog("Are you sure you want to delete?", "Confirmation");
                if (confirmed)
                {
                    _buyersServices.RemoveCompletedBuyer(SelectedCompletedBuyer.Id);
                    CompletedBuyers.Remove(SelectedCompletedBuyer);
                }
            }
            Debug.WriteLine("RemoveCompletedBuyerButton clicked");
        }

        private bool ShowDeleteConfirmationDialog(string messageText, string captionText)
        {
            MessageBoxResult result = MessageBox.Show(messageText, captionText, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}
