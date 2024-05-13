using Microsoft.EntityFrameworkCore;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerContext;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerRepositories
{
    public class CompletedBuyerRepository : IBuyerRepository<CompletedBuyerModel>
    {
        private readonly BuyerDbContext _context;

        public CompletedBuyerRepository(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BuyerDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            _context = new BuyerDbContext(optionsBuilder.Options);
        }

        public void Add(CompletedBuyerModel entity)
        {
            _context.CompletedBuyers.Add(entity);
            _context.SaveChanges();
        }

        public void Edit(CompletedBuyerModel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<CompletedBuyerModel> GetAll()
        {
            return _context.CompletedBuyers.ToList();
        }

        public CompletedBuyerModel GetById(int id)
        {
            return _context.CompletedBuyers.Find(id);
        }

        public CompletedBuyerModel AddAndReturn(CompletedBuyerModel entity)
        {
            _context.CompletedBuyers.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public CompletedBuyerModel RemoveAndReturn(int id)
        {
            var buyer = _context.CompletedBuyers.Find(id);
            _context.CompletedBuyers.Remove(buyer);
            _context.SaveChanges();
            return buyer;
        }

        public CompletedBuyerModel GetByFirstName(string firstName)
        {
            return _context.CompletedBuyers.FirstOrDefault(b => b.FirstName == firstName);
        }

        public void Remove(int id)
        {
            var entity = _context.CompletedBuyers.Find(id);
            _context.CompletedBuyers.Remove(entity);
            _context.SaveChanges();
        }
    }
}
