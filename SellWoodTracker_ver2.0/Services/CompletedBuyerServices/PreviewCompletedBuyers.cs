using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Services.CompletedBuyerServices
{
    public class PreviewCompletedBuyers
    {
        private readonly IBuyerGetter<CompletedBuyerModel> _completedBuyerGetter;

        public PreviewCompletedBuyers(IBuyerGetter<CompletedBuyerModel> completedBuyerGetter)
        {
            _completedBuyerGetter = completedBuyerGetter;

        }
        public IEnumerable<CompletedBuyerModel> GetAllCompletedBuyers()
        {
            return _completedBuyerGetter.GetAll();
        }
    }
}
