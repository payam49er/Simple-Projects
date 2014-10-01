using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public abstract class Product
    {
        public abstract string Name { get; set; }
        public abstract int Price { get; set; }

    }
}
