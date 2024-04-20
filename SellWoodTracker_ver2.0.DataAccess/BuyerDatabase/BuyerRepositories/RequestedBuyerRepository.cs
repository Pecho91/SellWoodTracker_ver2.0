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

        public RequestedBuyerRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BuyerDbContext>();
            optionsBuilder.UseSqlServer(App.ConnectionString);

            _context = new BuyerDbContext(optionsBuilder.Options);
        }

        public void Add(RequestedBuyerModel entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(RequestedBuyerModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RequestedBuyerModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public RequestedBuyerModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RequestedBuyerModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
