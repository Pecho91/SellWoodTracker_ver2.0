using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerRepositories;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.RequestedBuyerRepositories;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Services.RequestedBuyerServices
{
    public class MoveRequestedBuyer
    {
        private readonly IBuyerRemover<RequestedBuyerModel> _requestedBuyerRemover;
        private readonly IBuyerAdder<CompletedBuyerModel> _completedBuyerAdder;

        public MoveRequestedBuyer(IBuyerRemover<RequestedBuyerModel> requestedBuyerRemover, IBuyerAdder<CompletedBuyerModel> completedBuyerAdder)
        {
            _requestedBuyerRemover = requestedBuyerRemover;
            _completedBuyerAdder = completedBuyerAdder;

        }
        public void MoveRequestedBuyerToCompleted(int id)
        {
            var requestedBuyer = _requestedBuyerRemover.RemoveAndReturn(id);
            var completedBuyer = new CompletedBuyerModel
            {
                FirstName = requestedBuyer.FirstName,
                LastName = requestedBuyer.LastName,
                CellphoneNumber = requestedBuyer.CellphoneNumber,
                EmailAddress = requestedBuyer.EmailAddress,
                DateTime = requestedBuyer.DateTime,
                MetricAmount = requestedBuyer.MetricAmount,
                MetricPrice = requestedBuyer.MetricPrice,
                GrossIncome = requestedBuyer.GrossIncome,
            };
            _completedBuyerAdder.AddAndReturn(completedBuyer);
        }
    }
}
