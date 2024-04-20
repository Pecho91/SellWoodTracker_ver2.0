using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.Models.Buyers
{
    public class RequestedBuyerModel
    {
        public int Id { get; set; }

        /// <summary>
        /// The first name of the person
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the person
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The primary email address of the person
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The primary cell phone number of the person
        /// </summary>
        public string CellphoneNumber { get; set; }

        /// <summary>
        /// Date order
        /// </summary>
        public DateTime DateTime { get; set; }

        
        public decimal MetricAmount
        {
            get => Math.Round(_metricAmount, 2);
            set => _metricAmount = value;
        }

        private decimal _metricAmount;

        /// <summary>
        /// Price of m3
        /// </summary>
        public decimal MetricPrice
        {
            get => Math.Round(_metricPrice, 2);
            set => _metricPrice = value;
        }

        private decimal _metricPrice;

        /// <summary>
        /// Gross income (metric price * metric amount)
        /// </summary>
        private decimal _grossIncome;
        public decimal GrossIncome
        {
            get => Math.Round(_grossIncome, 2);
            set => _grossIncome = value;
        }

        
    }
}
