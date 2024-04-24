using Microsoft.EntityFrameworkCore;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerContext;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.CompletedBuyerRepositories;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.RequestedBuyerRepositories;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Locators
{
    public static class CompletedBuyerServicesLocator
    {
        // Initialize in App.cs
        public static BuyerDbContext DbContext { get; private set; }
        public static IBuyerAdder<CompletedBuyerModel> CompletedBuyerAdder { get; private set; }
        public static IBuyerEditor<CompletedBuyerModel> CompletedBuyerEditor { get; private set; }
        public static IBuyerGetter<CompletedBuyerModel> CompletedBuyerGetter { get; private set; }
        public static IBuyerRemover<CompletedBuyerModel> CompletedBuyerRemover { get; private set; }

        public static void Initialize(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BuyerDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            DbContext = new BuyerDbContext(optionsBuilder.Options);

            CompletedBuyerAdder = new CompletedBuyerAdder(DbContext);
            CompletedBuyerEditor = new CompletedBuyerEditor(DbContext);
            CompletedBuyerGetter = new CompletedBuyerGetter(DbContext);
            CompletedBuyerRemover = new CompletedBuyerRemover(DbContext);
        }
    }
}
