﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IOrder
    {
        void AddOrder(Product product);
        List<Product> GetOrders();
        void ClearOrderList();
    }
}
