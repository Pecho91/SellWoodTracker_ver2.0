using SellWoodTracker_ver2._0.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SellWoodTracker_ver2._0.Models.Buyers;

namespace SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyeInterface
{
    public interface IBuyerRepository<T> where T : class
    {
        void Add(T entity);
        void Edit(T entity);
        void Remove(int id);
        T GetById(int id);
        T RemoveAndReturn(int id);
        T GetByFirstName(string firstName);
        IEnumerable<T> GetAll();
        
    }
}
