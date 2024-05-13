using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface
{
    public interface IBuyerEditor<T> where T : class
    {
        void Edit(T entity);
    }
}
