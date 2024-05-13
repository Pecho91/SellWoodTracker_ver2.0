using Microsoft.EntityFrameworkCore;
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
    public class RequestedBuyerEditor : IBuyerEditor<RequestedBuyerModel>
    {
        private readonly BuyerDbContext _context;

        public RequestedBuyerEditor(BuyerDbContext context)
        {
            _context = context;
        }
        public void Edit(RequestedBuyerModel buyer)
        {
            _context.Entry(buyer).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
