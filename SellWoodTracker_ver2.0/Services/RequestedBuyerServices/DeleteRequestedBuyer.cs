using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerRepositories;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Services.RequestedBuyerServices
{
    public class DeleteRequestedBuyer
    {
        private readonly IBuyerRemover<RequestedBuyerModel> _requestedBuyerRemover;

        public DeleteRequestedBuyer(IBuyerRemover<RequestedBuyerModel> requestedBuyerRemover)
        {
            _requestedBuyerRemover = requestedBuyerRemover;
        }

        public void RemoveRequestedBuyer(int id)
        {
            _requestedBuyerRemover.Remove(id);
        }
    }
}
