using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    interface IOrder
    {
        void AddOrder(string orderName);
        List<string> GetOrders();
        int GetTotalPrice();
        void ClearOrderList();
    }
}
