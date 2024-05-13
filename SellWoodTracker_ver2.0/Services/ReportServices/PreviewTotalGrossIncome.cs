using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Services.ReportServices
{
    class PreviewTotalGrossIncome
    {
        private readonly IBuyerGetter<CompletedBuyerModel> _totalGrossIncome;

        public PreviewTotalGrossIncome(IBuyerGetter<CompletedBuyerModel> totalGrossIncome)
        {
            _totalGrossIncome = totalGrossIncome;
        }

        public decimal CalculateTotalGrossIncome()
        {
            return _totalGrossIncome.GetAll().Sum(x => x.GrossIncome);
        }
    }
}
