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
    public class CompletedBuyerEditor : IBuyerEditor<CompletedBuyerModel>
    {
        private readonly BuyerDbContext _context;

        public CompletedBuyerEditor(BuyerDbContext context)
        {
            _context = context;
        }

        public void Edit(CompletedBuyerModel buyer)
        {
            _context.Entry(buyer).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
