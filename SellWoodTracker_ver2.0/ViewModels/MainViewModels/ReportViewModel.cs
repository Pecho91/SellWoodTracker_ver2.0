using SellWoodTracker_ver2._0.Models.Buyers;
using SellWoodTracker_ver2_0.Locators;
using SellWoodTracker_ver2_0.Services.CompletedBuyerServices;
using SellWoodTracker_ver2_0.Services.ReportServices;
using SellWoodTracker_ver2_0.Services.RequestedBuyerServices;
using SellWoodTracker_ver2_0.ViewModels.Base;
using SellWoodTracker_ver2_0.ViewModels.RelayCommands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.ViewModels.MainViewModels
{
     public class ReportViewModel : ViewModelBase
     {
        private PreviewTotalMetricAmount _previewTotalMetricAmount;
        private PreviewTotalGrossIncome _previewTotalGrossIncome;

        public string TotalMetricAmountText
        {
            get { return $"{TotalMetricAmount} m³"; }
        }

        private decimal _totalMetricAmount;
        public decimal TotalMetricAmount
        {
            get { return _totalMetricAmount; }
            set
            {
                _totalMetricAmount = value;
                OnPropertyChanged(nameof(TotalMetricAmount));
            }
        }

        private decimal _totalGrossIncome;
        public decimal TotalGrossIncome
        {
            get { return _totalGrossIncome; }
            set
            {
                _totalGrossIncome = value;
                OnPropertyChanged(nameof(TotalGrossIncome));
            }
        }

        public string TotalGrossIncomeText
        {
            get { return $"{TotalGrossIncome} €"; }
        }

        public ReportViewModel()
        {    
            _previewTotalMetricAmount = new PreviewTotalMetricAmount(CompletedBuyerServicesLocator.CompletedBuyerGetter);
            _previewTotalGrossIncome = new PreviewTotalGrossIncome(CompletedBuyerServicesLocator.CompletedBuyerGetter);

            LoadTotalMetricAmount();
            LoadTotalGrossIncome();
        }

        private void LoadTotalMetricAmount()
        {
            TotalMetricAmount = _previewTotalMetricAmount.CalculateTotalMetricAmount();
        }

        private void LoadTotalGrossIncome()
        {
            TotalGrossIncome = _previewTotalGrossIncome.CalculateTotalGrossIncome();
        }
    }
}
