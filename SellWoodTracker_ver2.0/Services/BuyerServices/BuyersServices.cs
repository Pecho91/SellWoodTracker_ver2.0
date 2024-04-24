using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface;
using SellWoodTracker_ver2._0.Models.Buyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Services.BuyerServices
{
    public class BuyersServices
    {
        private readonly IBuyerRepository<RequestedBuyerModel> _requestedBuyerRepository;
        private readonly IBuyerRepository<CompletedBuyerModel> _completedBuyerRepository;

        public BuyersServices(IBuyerRepository<RequestedBuyerModel> requestedBuyerRepository, IBuyerRepository<CompletedBuyerModel> completedBuyerRepository)
        {
            _requestedBuyerRepository = requestedBuyerRepository;
            _completedBuyerRepository = completedBuyerRepository;
        }

        public IEnumerable<RequestedBuyerModel> GetAllRequestedBuyers()
        {
            return _requestedBuyerRepository.GetAll();
        }
        public IEnumerable<CompletedBuyerModel> GetAllCompletedBuyers()
        {
            return _completedBuyerRepository.GetAll();
        }

        public void AddRequestedBuyer(RequestedBuyerModel entity)
        {
            _requestedBuyerRepository.Add(entity);
        }

        public void RemoveRequestedBuyer(int id)
        {
            _requestedBuyerRepository.Remove(id);
        }

        public void RemoveCompletedBuyer(int id)
        {
            _completedBuyerRepository.Remove(id);
        }

        public void MoveRequestedBuyerToCompleted(int id)
        {
            var requestedBuyer = _requestedBuyerRepository.RemoveAndReturn(id);
            var completedBuyer = new CompletedBuyerModel
            {
                FirstName = requestedBuyer.FirstName,
                LastName = requestedBuyer.LastName,
                CellphoneNumber = requestedBuyer.CellphoneNumber,
                EmailAddress = requestedBuyer.EmailAddress,
                DateTime = requestedBuyer.DateTime,
                MetricAmount = requestedBuyer.MetricAmount,
                MetricPrice = requestedBuyer.MetricPrice,
                GrossIncome = requestedBuyer.GrossIncome,              
            };
            _completedBuyerRepository.AddAndReturn(completedBuyer);
        }

    } 
}
