using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Checkout
    {

        private readonly List<string> paidMoney = new List<string>();
        private readonly List<string> validBills = new List<string>{"5","10","25","100","500","1000","2000"}; 

        private readonly IOrder _order;

        public Checkout(IOrder order)
        {
            _order = order;
        }


        public void AddMoney(string money)
        {
            paidMoney.Add(money);
        }

        public int CalculateReturn()
        {
            int inputMoney = 0;
            foreach (var money in paidMoney)
            {
                int value;
                int.TryParse(money, out value);
                inputMoney += value;
            }

            return inputMoney - _order.GetTotalPrice();
        }

        public bool ZeroBalance()
        {
            if (CalculateReturn() == 0)
            {
                paidMoney.Clear();
                return true;
            }
            return false;
        }

        public bool ValidBill(string bill)
        {
            return validBills.Contains(bill);
        }
    }
}
