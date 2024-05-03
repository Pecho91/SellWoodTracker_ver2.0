using Microsoft.EntityFrameworkCore;
using Moq;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerContext;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.CompletedBuyerRepositories;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.Tests.BuyerDatabaseTests.CompletedBuyerRepositoriesTests
{
    public class CompletedBuyerRemoverTests
    {
        private Mock<DbSet<CompletedBuyerModel>> _mockSet;
        private Mock<BuyerDbContext> _mockContext;
        private IBuyerRemover<CompletedBuyerModel> _remover;

        public CompletedBuyerRemoverTests()
        {
            _mockSet = new Mock<DbSet<CompletedBuyerModel>>();
            _mockContext = new Mock<BuyerDbContext>();
            _remover = new CompletedBuyerRemover(_mockContext.Object);
        }

        [Fact]
        public void Remove_ShouldRemoveBuyerToContext()
        {
            // Arrange
            var buyer = new CompletedBuyerModel();
            int buyerId = 1;
            buyer.Id = buyerId;

            _mockSet.Setup(m => m.Find(buyerId)).Returns(buyer);
            _mockContext.Setup(m => m.CompletedBuyers).Returns(_mockSet.Object);

            // Act
            _remover.Remove(buyerId);

            // Assert
            _mockSet.Verify(m => m.Remove(buyer), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void RemoveAndReturn_ShouldRemoveBuyerFromContextAndReturnIt()
        {
            // Arrange
            var buyer = new CompletedBuyerModel();
            int buyerId = 1;
            buyer.Id = buyerId;

            _mockSet.Setup(m => m.Find(buyerId)).Returns(buyer);
            _mockContext.Setup(m => m.CompletedBuyers).Returns(_mockSet.Object);

            // Act
            var returnedBuyer = _remover.RemoveAndReturn(buyerId);

            // Assert
            _mockSet.Verify(m => m.Remove(buyer), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.Equal(buyer, returnedBuyer);
        }
    }
}
