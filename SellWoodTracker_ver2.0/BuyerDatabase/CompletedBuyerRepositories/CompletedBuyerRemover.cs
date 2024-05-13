using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerContext;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.CompletedBuyerRepositories
{
    public class CompletedBuyerRemover : IBuyerRemover<CompletedBuyerModel>
    {
        private readonly BuyerDbContext _context;

        public CompletedBuyerRemover(BuyerDbContext context)
        {
            _context = context;
        }

        public void Remove(int id)
        {
            var buyer = _context.CompletedBuyers.Find(id);
            _context.CompletedBuyers.Remove(buyer);
            _context.SaveChanges();
        }

        public CompletedBuyerModel RemoveAndReturn(int id)
        {
            var buyer = _context.CompletedBuyers.Find(id);
            _context.CompletedBuyers.Remove(buyer);
            _context.SaveChanges();
            return buyer; ;
        }
    }
}
