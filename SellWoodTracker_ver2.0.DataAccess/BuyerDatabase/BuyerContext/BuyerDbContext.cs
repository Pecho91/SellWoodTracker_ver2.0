using Microsoft.EntityFrameworkCore;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerContext
{
    public class BuyerDbContext : DbContext
    {
        public DbSet<RequestedBuyerModel> RequestedBuyers { get; set; }
        public DbSet<CompletedBuyerModel> CompletedBuyers { get; set;}
     
        public BuyerDbContext(DbContextOptions<BuyerDbContext> options) : base(options)
        {

        }
    }
}
