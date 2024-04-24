using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Services.RequestedBuyerServices
{
    public class AddRequestedBuyer
    {
        private readonly IBuyerAdder<RequestedBuyerModel> _requestedBuyerAdder;

        public AddRequestedBuyer(IBuyerAdder<RequestedBuyerModel> requestedBuyerAdder)
        {
            _requestedBuyerAdder = requestedBuyerAdder;

        }

        public void AddNewRequestedBuyer(RequestedBuyerModel entity)
        {
            _requestedBuyerAdder.Add(entity);
        }
    }
}
