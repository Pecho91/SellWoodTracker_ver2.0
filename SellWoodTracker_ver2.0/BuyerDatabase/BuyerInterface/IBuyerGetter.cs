using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface
{
    public interface IBuyerGetter<T> where T : class
    {
        T GetById(int id); 
        IEnumerable<T> GetAll();
        T GetByFirstName(string firstName);
        //T GetByMetricAmount(decimal metricAmount);
        //T GetByMetricPrice(decimal metricPrice);
    }
}
