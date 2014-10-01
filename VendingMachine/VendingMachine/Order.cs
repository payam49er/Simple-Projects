using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Order:IOrder
    {
        private readonly List<Product> _orderList = new List<Product>(); 

        public void AddOrder(Product product)
        {
            _orderList.Add(product);
        }

        public List<Product> GetOrders()
        {
           return _orderList;
        }

        
        public void ClearOrderList()
        {
            _orderList.Clear();
        }

        public void OrderAddOn(Addon.AddOnNames name)
        {
            int AddOnCount = 0;
            string addOn = null;
            while (AddOnCount < 3 && addOn != "0")
            {
                Console.WriteLine("Would you like {0}? 0 = No, 1 adds one {1}, Max 3", name, name);
                addOn = Console.ReadLine();
                if (addOn == "0")
                    break;
                if (addOn != "1")
                {
                    Console.WriteLine("Will add only one {0} pack at a time", name);
                    addOn = "1";
                }
                int addOnCount;
                int.TryParse(addOn, out addOnCount);
                if (addOnCount > 3 || AddOnCount > 3)
                {
                    addOnCount = 3;
                    Console.WriteLine("Maximum allowed {0} is 3 packs, sorry!", name);
                }
                AddOnCount += addOnCount;

                AddOrder(new Addon(name));
            }
        }

    }
}
