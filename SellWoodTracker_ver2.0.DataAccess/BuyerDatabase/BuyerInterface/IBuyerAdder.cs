﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerInterface
{
    public interface IBuyerAdder<T> where T : class
    {
        void Add(T entity);
        T AddAndReturn(T entity);
    }
}
