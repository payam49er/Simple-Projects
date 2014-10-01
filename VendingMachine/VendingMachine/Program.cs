using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {

            Order order = new Order();
          
            while (true)
            {

                Console.WriteLine("Enter the size of coffee s=Small, m=Medium, l= Large");
                var coffeeSize = Console.ReadLine();
                if (!string.IsNullOrEmpty(coffeeSize))
                {
                    switch (coffeeSize.ToLower())
                    {
                        case "s":
                            order.AddOrder(new Coffee(Coffee.Size.Small));
                            break;
                        case "m":
                            order.AddOrder(new Coffee(Coffee.Size.Medium));
                            break;
                        case "l":
                            order.AddOrder(new Coffee(Coffee.Size.Large));
                            break;
                    }
                }
               

                
                order.OrderAddOn(Addon.AddOnNames.Sugar);

                order.OrderAddOn(Addon.AddOnNames.Cream);

               
                Console.WriteLine("Would you like another order? Y/N");
                var anotherOrder = Console.ReadLine();
                if (!string.IsNullOrEmpty(anotherOrder) && anotherOrder.ToLower() == "n")
                {
                    //Issue the bill
                   
                    Console.WriteLine("Here is the summary of your order:");
                    
                   
                    Checkout checkout = new Checkout(order);

                    checkout.GenerateOrderSummary();

                   

                    //Obtain the money from the customer
                    Console.WriteLine("Please insert your money:");

                    checkout.ProcessMoney();
                    
                    Console.WriteLine("Here is your change:");

                    var change = checkout.CalculateReturn();
                    Console.WriteLine("{0:C}",change/100f);

                    Console.WriteLine("Here is your coffee");

                    checkout.ZeroBalance();
                    order.ClearOrderList();
                    
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Would you like to stop the machine? Y/N");
                    Console.BackgroundColor = ConsoleColor.Black;
                    var stop = Console.ReadLine();
                    if(stop.ToLower() == "y")
                        Environment.Exit(0);

                }
            }

            Console.Read();
        }
    }
}
