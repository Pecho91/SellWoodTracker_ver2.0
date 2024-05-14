using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerRepositories;
using SellWoodTracker_ver2._0.Models.Buyers;
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
using SellWoodTracker_ver2_0.Services.CompletedBuyerServices;
using SellWoodTracker_ver2_0.Locators;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.CompletedBuyerRepositories;

namespace SellWoodTracker_ver2_0.ViewModels.MainViewModels
{
    public class CompletedBuyersViewModel : ViewModelBase
    {
        private DeleteCompletedBuyer _deleteCompletedBuyer;
        private PreviewCompletedBuyers _previewCompletedBuyers;

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
        public ICommand ExportToExcelCompletedBuyersCommand { get; }
        public CompletedBuyersViewModel()
        {

            _deleteCompletedBuyer = new DeleteCompletedBuyer(CompletedBuyerServicesLocator.CompletedBuyerRemover);
            _previewCompletedBuyers = new PreviewCompletedBuyers(CompletedBuyerServicesLocator.CompletedBuyerGetter);

            DeleteCompletedBuyerCommand = new RelayCommand(ExecuteDeleteCompletedBuyer);
            ExportToExcelCompletedBuyersCommand = new RelayCommand(ExecuteExportToExcelCompletedBuyers);
            LoadCompletedBuyers();
        }

        private void LoadCompletedBuyers()
        {
            CompletedBuyers = new ObservableCollection<CompletedBuyerModel>(_previewCompletedBuyers.GetAllCompletedBuyers());
        }

        private void ExecuteDeleteCompletedBuyer(object obj)
        {
            if (_selectedCompletedBuyer != null)
            {
                bool confirmed = ShowConfirmationDialog("Are you sure you want to delete?", "Confirmation");
                if (confirmed)
                {
                    _deleteCompletedBuyer.RemoveCompletedBuyer(SelectedCompletedBuyer.Id);
                    CompletedBuyers.Remove(SelectedCompletedBuyer);
                }
            }
            Debug.WriteLine("RemoveCompletedBuyerButton clicked");
        }

        private void ExecuteExportToExcelCompletedBuyers(object obj)
        {
            bool confirmed = ShowConfirmationDialog("Are you sure you want to export to Exel?", "Confirmation");
            if(confirmed)
            {
                string filePath = "C:\\Users\\andri\\OneDrive\\Desktop\\SellWoodTrackerExport\\completed_buyers.xlsx";
                var completedBuyersExport = new CompletedBuyersExportToExcel(CompletedBuyerServicesLocator.CompletedBuyerGetter);
                completedBuyersExport.ExportToExcelCompletedBuyers(filePath);
                MessageBox.Show("Export to Excel completed successfully.", "Export Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private bool ShowConfirmationDialog(string messageText, string captionText)
        {
            MessageBoxResult result = MessageBox.Show(messageText, captionText, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}
