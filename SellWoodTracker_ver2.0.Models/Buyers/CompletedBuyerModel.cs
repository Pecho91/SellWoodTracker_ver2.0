using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.Models.Buyers
{
    public class CompletedBuyerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellphoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateTime { get; set; }

        private decimal _metricAmount;
        public decimal MetricAmount
        {
            get => Math.Round(_metricAmount, 2);
            set => _metricAmount = value;
        }

        private decimal _metricPrice;
        public decimal MetricPrice
        {
            get => Math.Round(_metricPrice, 2);
            set => _metricPrice = value;
        }

        private decimal _grossIncome;
        public decimal GrossIncome
        {
            get => Math.Round(_grossIncome, 2);
            set => _grossIncome = value;
        }
    }
}
