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
                            order.AddOrder("smallcoffee");
                            break;
                        case "m":
                            order.AddOrder("mediumcoffee");
                            break;
                        case "l":
                            order.AddOrder("largecoffee");
                            break;
                    }
                }
                int sugarCounter = 0;
                string sugarPack = null;
                while (sugarCounter < 3 && sugarPack != "0")
                {
                    Console.WriteLine("Would you like sugar? 0 = No, 1 adds one pack of sugar, Max 3");
                    sugarPack = Console.ReadLine();
                    if (sugarPack == "0")
                        break;
                    if (sugarPack != "1")
                    {
                        Console.WriteLine("Will add only one sugar pack at a time");
                        sugarPack = "1";
                    }
                    int sugar;
                    int.TryParse(sugarPack, out sugar);
                    if (sugar > 3 || sugarCounter > 3)
                    {
                        sugar = 3;
                        Console.WriteLine("Maximum allowed sugar is 3 packs, sorry!");
                    }
                    sugarCounter += sugar;

                    order.AddOrder("sugar");
                }



                int creamCounter = 0;
                string creamPack = null;
                while (creamCounter < 3 && creamPack != "0")
                {
                    Console.WriteLine("Would you like cream? 0 = No, 1 adds one pack of cream at a time, Max 3");
                    creamPack = Console.ReadLine();
                    if (creamPack == "0")
                        break;
                    if (creamPack != "1")
                    {
                        Console.WriteLine("Will add only one cream pack at a time");
                        creamPack = "1";
                    }
                    int cream;
                    int.TryParse(creamPack, out cream);
                    if (cream > 3)
                    {
                        cream = 3;
                        Console.WriteLine("Maximum allowed cream is 3 packs, sorry!");
                    }
                    creamCounter += cream;
                    order.AddOrder("cream");
                }

                //make order
                Console.WriteLine("Would you like another order? Y/N");
                var anotherOrder = Console.ReadLine();
                if (!string.IsNullOrEmpty(anotherOrder) && anotherOrder.ToLower() == "n")
                {
                    //Issue the bill
                    var orders = order.GetOrders();
                    Console.WriteLine("Here is summary of your order:");
                    foreach (var item in orders)
                    {
                        Console.WriteLine(item);
                    }

                    Checkout checkout = new Checkout(order);

                    var totalBill = order.GetTotalPrice();
                    
                    Console.WriteLine("Your total is: {0:C}",totalBill/100f);

                    //Obtain the money from the customer
                    Console.WriteLine("Please insert your money:");

                    int insertedMoney = 0;
                    while (insertedMoney < totalBill)
                    {
                        var bill = Console.ReadLine();
                        if (!string.IsNullOrEmpty(bill))
                        {
                            double dollar;
                            double.TryParse(bill, out dollar);

                            var cents = (dollar*100).ToString();

                            if (checkout.ValidBill(cents))
                            {
                                insertedMoney += (int)(dollar*100);
                                checkout.AddMoney(cents);
                            }
                            else
                            {
                                Console.WriteLine("Please insert valid bills or coins");
                            }
                        }
                    }
                    
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
