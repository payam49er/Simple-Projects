using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Checkout
    {

        private readonly List<string> _paidMoney = new List<string>();
        private readonly List<string> _validBills = new List<string>{"5","10","25","100","500","1000","2000"}; 

        private readonly IOrder _order;

        public Checkout(IOrder order)
        {
            _order = order;
        }


        public void AddMoney(string money)
        {
            _paidMoney.Add(money);
        }

        public int CalculateReturn()
        {
            int inputMoney = 0;
            foreach (var money in _paidMoney)
            {
                int value;
                int.TryParse(money, out value);
                inputMoney += value;
            }

            return inputMoney - GetTotalPrice();
        }

        public bool ZeroBalance()
        {
            if (CalculateReturn() == 0)
            {
                _paidMoney.Clear();
                return true;
            }
            return false;
        }

        public bool ValidBill(string bill)
        {
            return _validBills.Contains(bill);
        }

       
        public int GetTotalPrice()
        {
            int totalPrice = 0;

            var orders = _order.GetOrders();

            foreach (var order in orders)
            {
                var price = order.Price;
                totalPrice += price;
            }

            return totalPrice;
        }

        public void GenerateOrderSummary()
        {
            var orders = _order.GetOrders();
            foreach (var item in orders)
            {
                var orderSummary = string.Format("{0} {1:c}", item.Name, item.Price / 100f);
                Console.WriteLine(orderSummary);
            }

            var totalBill = GetTotalPrice();

            Console.WriteLine("Your total is: {0:C}", totalBill / 100f);

        }

        public void ProcessMoney()
        {
            int insertedMoney = 0;
            while (insertedMoney < GetTotalPrice())
            {
                var bill = Console.ReadLine();
                if (!string.IsNullOrEmpty(bill))
                {
                    double dollar;
                    double.TryParse(bill, out dollar);

                    var cents = (dollar * 100).ToString();

                    if (ValidBill(cents))
                    {
                        insertedMoney += (int)(dollar * 100);
                        AddMoney(cents);
                    }
                    else
                    {
                        Console.WriteLine("Please insert valid bills or coins");
                    }
                }
            }
        }

    }
}
