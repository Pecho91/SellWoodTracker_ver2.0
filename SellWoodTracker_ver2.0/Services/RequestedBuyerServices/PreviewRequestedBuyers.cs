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
    public class PreviewRequestedBuyers
    {
        private readonly IBuyerGetter<RequestedBuyerModel> _requestedBuyerGetter;

        public PreviewRequestedBuyers(IBuyerGetter<RequestedBuyerModel> requestedBuyerGetter)
        {
            _requestedBuyerGetter = requestedBuyerGetter;

        }
        public IEnumerable<RequestedBuyerModel> GetAllRequestedBuyers()
        {
            return _requestedBuyerGetter.GetAll();
        }
    }
}
