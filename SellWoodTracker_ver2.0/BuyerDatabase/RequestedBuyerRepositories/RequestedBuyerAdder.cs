using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerContext;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.RequestedBuyerRepositories
{
    public class RequestedBuyerAdder : IBuyerAdder<RequestedBuyerModel>
    {
        private readonly BuyerDbContext _context;

        public RequestedBuyerAdder(BuyerDbContext context)
        {
            _context = context;
        }
        public void Add(RequestedBuyerModel buyer)
        {
            _context.RequestedBuyers.Add(buyer);
            _context.SaveChanges();
        }

        public RequestedBuyerModel AddAndReturn(RequestedBuyerModel buyer)
        {
            _context.RequestedBuyers.Add(buyer);
            _context.SaveChanges();
            return buyer;
        }
    }
}
