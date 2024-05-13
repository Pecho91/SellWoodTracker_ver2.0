using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.CompletedBuyerRepositories;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Services.ReportServices
{
    class PreviewTotalMetricAmount
    {
        private readonly IBuyerGetter<CompletedBuyerModel> _totalMetricAmount;

        public PreviewTotalMetricAmount(IBuyerGetter<CompletedBuyerModel> totalMetricAmount)
        {
            _totalMetricAmount = totalMetricAmount;
        }

        public decimal CalculateTotalMetricAmount()
        {
            return _totalMetricAmount.GetAll().Sum(x => x.MetricAmount);
        }
    }
}
