using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerContext;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.RequestedBuyerRepositories
{
    public class RequestedBuyerRemover : IBuyerRemover<RequestedBuyerModel>
    {
        private readonly BuyerDbContext _context;

        public RequestedBuyerRemover(BuyerDbContext context)
        {
            _context = context;
        }

        public void Remove(int id)
        {
            var buyer = _context.RequestedBuyers.Find(id);
            _context.RequestedBuyers.Remove(buyer);
            _context.SaveChanges();
        }

        public RequestedBuyerModel RemoveAndReturn(int id)
        {
            var buyer = _context.RequestedBuyers.Find(id);
            _context.RequestedBuyers.Remove(buyer);
            _context.SaveChanges();
            return buyer;
        }
    }
}
