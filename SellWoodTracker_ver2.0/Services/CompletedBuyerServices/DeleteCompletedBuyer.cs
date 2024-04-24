using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Services.CompletedBuyerServices
{
    public class DeleteCompletedBuyer
    {
        private readonly IBuyerRemover<CompletedBuyerModel> _completedBuyerRemover;

        public DeleteCompletedBuyer(IBuyerRemover<CompletedBuyerModel> completedBuyerRemover)
        {
            _completedBuyerRemover = completedBuyerRemover;
        }

        public void RemoveCompletedBuyer(int id)
        {
            _completedBuyerRemover.Remove(id);
        }
    }
}
