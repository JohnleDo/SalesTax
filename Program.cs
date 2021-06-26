using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTax
{
    class Program
    {
        static double FindTaxRate()
        {
            while (true)
            {
                Console.Write("Is the item imported? (Y/N) : ");
                var imported = Console.ReadLine();

                if (imported.ToLower() == "y" || imported.ToLower() == "yes")
                {
                    while (true)
                    {
                        Console.Write("Is this item a book, food, or medical product? (Y/N): ");
                        var otherType = Console.ReadLine();

                        if (otherType.ToLower() == "y" || otherType.ToLower() == "yes")
                        {
                            return 0.05;
                        }
                        else if (otherType.ToLower() == "n" || otherType.ToLower() == "no")
                        {
                            return 0.15;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input, please try again.");
                        }
                    }

                }
                else if (imported.ToLower() == "n" || imported.ToLower() == "no")
                {
                    while (true)
                    {
                        Console.Write("Is this item a book, food, or medical product? (Y/N): ");
                        var otherType = Console.ReadLine();

                        if (otherType.ToLower() == "y" || otherType.ToLower() == "yes")
                        {
                            return 0.00;
                        }
                        else if (otherType.ToLower() == "n" || otherType.ToLower() == "no")
                        {
                            return 0.10;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input, please try again.");
                        }
                    }
                }

                else
                {
                    Console.WriteLine("Invalid Input, please try again.");
                }
            }
        }

        static TableManager MenuOptions(TableManager itemTable)
        {
            var item = new Item();
            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove all Items");
                Console.WriteLine("3. Exit");
                Console.Write("Option: ");
                var userInput = Console.ReadLine();
                Console.WriteLine("-----------------------------------");

                try
                {
                    switch (userInput)
                    {
                        case "1":
                            Console.Write("Enter Name of item: ");
                            item.ItemName = Console.ReadLine();

                            Console.Write("Enter the quantity of item: ");
                            item.Quantity = Int32.Parse(Console.ReadLine());

                            Console.Write("Item Price: ");
                            item.Price = Double.Parse(Console.ReadLine());

                            item.TaxRate = FindTaxRate();
                            item.UpdateTotalPrice();
                            itemTable.AddItem(item);

                            Console.WriteLine("\n***** Output *****");
                            itemTable.PrintTable();
                            return itemTable;

                        case "2":
                            itemTable = new TableManager();
                            return itemTable;

                        case "3":
                            Console.WriteLine("Exitting Program...");
                            System.Threading.Thread.Sleep(2000);
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid Input, please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return itemTable;
                }
            }
        }

        static void Main(string[] args)
        {
            var itemTable = new TableManager();
            Console.WriteLine("===============================================");
            Console.WriteLine("Welcome To The SalesTaxes Program");
            Console.WriteLine("===============================================");

            while (true)
            {
                itemTable = MenuOptions(itemTable);
            }
        }
    }
}
