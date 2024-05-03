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
    public class CompletedBuyerAdderTests
    {
        private Mock<DbSet<CompletedBuyerModel>> _mockSet;
        private Mock<BuyerDbContext> _mockContext;
        private IBuyerAdder<CompletedBuyerModel> _adder;

        public CompletedBuyerAdderTests()
        {
            _mockSet = new Mock<DbSet<CompletedBuyerModel>>();
            _mockContext = new Mock<BuyerDbContext>();
            _adder = new CompletedBuyerAdder(_mockContext.Object);
        }

        [Fact]
        public void Add_ShouldAddBuyerToContext()
        {
            //Arrange
            var buyer = new CompletedBuyerModel();
            _mockContext.Setup(m => m.CompletedBuyers).Returns(_mockSet.Object);

            //Act
            _adder.Add(buyer);

            //Assert
            _mockSet.Verify(m => m.Add(It.IsAny<CompletedBuyerModel>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void AddAndReturn_ShouldAddBuyerToContextAndReturnIt()
        {
            // Arrange
            var buyer = new CompletedBuyerModel();

            _mockContext.Setup(m => m.CompletedBuyers).Returns(_mockSet.Object);

            // Act
            var returnedBuyer = _adder.AddAndReturn(buyer);

            // Assert
            _mockSet.Verify(m => m.Add(It.IsAny<CompletedBuyerModel>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.Equal(buyer, returnedBuyer);
        }
    }

}
