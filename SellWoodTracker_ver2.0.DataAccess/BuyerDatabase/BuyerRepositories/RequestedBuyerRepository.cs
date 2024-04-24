using Microsoft.EntityFrameworkCore;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyeInterface;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerContext;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerRepositories
{
    public class RequestedBuyerRepository : IBuyerRepository<RequestedBuyerModel>
    {
        private readonly BuyerDbContext _context;

        public RequestedBuyerRepository(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BuyerDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            _context = new BuyerDbContext(optionsBuilder.Options);
        }

        public void Add(RequestedBuyerModel entity)
        {
            _context.RequestedBuyers.Add(entity);
            _context.SaveChanges();
        }

        public void Edit(RequestedBuyerModel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<RequestedBuyerModel> GetAll()
        {
            return _context.RequestedBuyers.ToList();
        }

        public RequestedBuyerModel GetById(int id)
        {
            return _context.RequestedBuyers.Find(id);
        }

        public RequestedBuyerModel RemoveAndReturn(int id)
        {
            var buyer = _context.RequestedBuyers.Find(id);
            _context.RequestedBuyers.Remove(buyer);
            _context.SaveChanges();
            return buyer;
        }

        public RequestedBuyerModel GetByFirstName(string firstName)
        {
            return _context.RequestedBuyers.FirstOrDefault(b => b.FirstName == firstName);    
        }

        public void Remove(int id)
        {
            var entity = _context.RequestedBuyers.Find(id);
            _context.RequestedBuyers.Remove(entity);
            _context.SaveChanges();
        }

       
    }
}
