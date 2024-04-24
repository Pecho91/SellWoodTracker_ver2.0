
using Microsoft.EntityFrameworkCore;
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
    public class CompletedBuyerAdder : IBuyerAdder<CompletedBuyerModel>
    {
        private readonly BuyerDbContext _context;

        public CompletedBuyerAdder(BuyerDbContext context)
        {
            _context = context;
        }
        public void Add(CompletedBuyerModel buyer)
        {
            _context.CompletedBuyers.Add(buyer);
            _context.SaveChanges();
        }

        public CompletedBuyerModel AddAndReturn(CompletedBuyerModel buyer)
        {
            _context.CompletedBuyers.Add(buyer);
            _context.SaveChanges();
            return buyer;
        }
    }
}
