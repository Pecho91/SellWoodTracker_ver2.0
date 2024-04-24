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
    public class CompletedBuyerGetter : IBuyerGetter<CompletedBuyerModel>
    {
        private readonly BuyerDbContext _context;

        public CompletedBuyerGetter(BuyerDbContext context)
        {
            _context = context;
        }

        public CompletedBuyerModel GetById(int id)
        {
            return _context.CompletedBuyers.Find(id);
        }

        public IEnumerable<CompletedBuyerModel> GetAll()
        {
            return _context.CompletedBuyers.ToList();
        }

        public CompletedBuyerModel GetByFirstName(string firstName)
        {
            return _context.CompletedBuyers.FirstOrDefault(b => b.FirstName == firstName);
        }

        
    }
}
