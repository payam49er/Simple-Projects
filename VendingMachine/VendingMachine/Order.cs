using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Order:IOrder
    {
        private readonly List<string> _orderList = new List<string>(); 

        public void AddOrder(string name)
        {
            _orderList.Add(name);
        }

        private int GetPrice(string item)
        {
            int price = 0;
            switch (item)
            {
                case "smallcoffee":
                    price = 175;
                    break;
                case "mediumcoffee":
                    price = 200;
                    break;
                case "largecoffee":
                    price = 225;
                    break;
                case "sugar":
                    price = 25;
                    break;
                case "cream":
                    price = 25;
                    break;

            }

            return price;
        }

        public List<string> GetOrders()
        {
           return _orderList;
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (var order in _orderList)
            {
                var price = GetPrice(order);
                totalPrice += price;
            }

            return totalPrice;
        }

        public void ClearOrderList()
        {
            _orderList.Clear();
        }

    }
}
