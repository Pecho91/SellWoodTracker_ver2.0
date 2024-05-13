using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerContext;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.RequestedBuyerRepositories
{
    public class RequestedBuyerGetter : IBuyerGetter<RequestedBuyerModel>
    {
        private readonly BuyerDbContext _context;

        public RequestedBuyerGetter(BuyerDbContext context)
        {
            _context = context;
        }

        public RequestedBuyerModel GetById(int id)
        {
            return _context.RequestedBuyers.Find(id);
        }

        public IEnumerable<RequestedBuyerModel> GetAll()
        {
            return _context.RequestedBuyers.ToList();
        }

        public RequestedBuyerModel GetByFirstName(string firstName)
        {
            return _context.RequestedBuyers.FirstOrDefault(b => b.FirstName == firstName);
        }

        
    }
}
