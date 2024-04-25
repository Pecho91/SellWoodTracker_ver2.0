﻿using Microsoft.EntityFrameworkCore;
using Moq;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerContext;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.RequestedBuyerRepositories;
using SellWoodTracker_ver2._0.Models.Buyers;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.Tests.BuyerDatabaseTests.RequestedBuyerRepositoriesTests
{
    public class RequestedBuyerAdderTests
    {
        private Mock<DbSet<RequestedBuyerModel>> _mockSet;
        private Mock<BuyerDbContext> _mockContext;
        private IBuyerAdder<RequestedBuyerModel> _adder;

        public RequestedBuyerAdderTests()
        {
            _mockSet = new Mock<DbSet<RequestedBuyerModel>>();
            _mockContext = new Mock<BuyerDbContext>();
            _adder = new RequestedBuyerAdder(_mockContext.Object);
        }

        [Fact]
        public void Add_ShouldAddBuyerToContext()
        {
            //Arrange
            var buyer = new RequestedBuyerModel();
            _mockContext.Setup(m => m.RequestedBuyers).Returns(_mockSet.Object);

            //Act
            _adder.Add(buyer);

            //Assert
            _mockSet.Verify(m => m.Add(It.IsAny<RequestedBuyerModel>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Fact]
        public void AddAndReturn_ShouldAddBuyerToContextAndReturnIt()
        {
            // Arrange
            var buyer = new RequestedBuyerModel();

            _mockContext.Setup(m => m.RequestedBuyers).Returns(_mockSet.Object);

            // Act
            var returnedBuyer = _adder.AddAndReturn(buyer);

            // Assert
            _mockSet.Verify(m => m.Add(It.IsAny<RequestedBuyerModel>()), Times.Once());
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.Equal(buyer, returnedBuyer);
        }
    }
}
