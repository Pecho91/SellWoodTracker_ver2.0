using Microsoft.EntityFrameworkCore;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerContext;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.RequestedBuyerRepositories;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Locators
{
    public static class RequestedBuyerServicesLocator
    {
        // Initialize in App.cs
        public static BuyerDbContext DbContext { get; private set; }
        public static IBuyerAdder<RequestedBuyerModel> RequestedBuyerAdder { get; private set; }
        public static IBuyerEditor<RequestedBuyerModel> RequestedBuyerEditor { get; private set; }
        public static IBuyerGetter<RequestedBuyerModel> RequestedBuyerGetter { get; private set; }
        public static IBuyerRemover<RequestedBuyerModel> RequestedBuyerRemover { get; private set; }
        
        public static void Initialize(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BuyerDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            DbContext = new BuyerDbContext(optionsBuilder.Options);

            RequestedBuyerAdder = new RequestedBuyerAdder(DbContext);
            RequestedBuyerEditor = new RequestedBuyerEditor(DbContext);
            RequestedBuyerGetter = new RequestedBuyerGetter(DbContext);
            RequestedBuyerRemover = new RequestedBuyerRemover(DbContext);
        }
    }
}
