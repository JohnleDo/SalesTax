using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax
{
    class TableManager
    {
        private readonly List<Item> ListofItems;
        private Double TotalSalesTax;
        private Double TotalPrice;

        public TableManager()
        {
            this.ListofItems = new List<Item>();
            this.TotalSalesTax = 0.00;
            this.TotalPrice = 0.00;
        }

        public void AddItem(Item newItem)
        {
            bool itemFound = false;

            foreach (var item in this.ListofItems)
            {
                if (item.ItemName.ToLower() == newItem.ItemName.ToLower() && item.Price == newItem.Price && item.TaxRate == newItem.TaxRate)
                {
                    item.Quantity += newItem.Quantity;
                    this.TotalPrice -= newItem.TotalPrice;
                    this.TotalSalesTax -= item.TotalSalesTax;
                    item.UpdateTotalPrice();
                    this.TotalSalesTax += item.TotalSalesTax;
                    this.TotalPrice +=  item.TotalPrice;
                    itemFound = true;
                }
            }

            if (itemFound == false)
            {
                this.ListofItems.Add(newItem);
                this.TotalSalesTax += newItem.TotalSalesTax;
                this.TotalPrice += newItem.TotalPrice;
            }
        }

        public void PrintTable()
        {
            foreach (var item in this.ListofItems)
            {
                if (item.Quantity > 1)
                {
                    Console.WriteLine(string.Format("{0}: {1:0.00} ({2} @ {3:0.00})", item.ItemName, item.TotalPrice, item.Quantity, item.Price + (item.TotalSalesTax / item.Quantity)));
                }
                else
                {
                    Console.WriteLine(string.Format("{0}: {1:0.00}", item.ItemName, item.Price + (item.TotalSalesTax / item.Quantity)));
                }
            }
            Console.WriteLine(string.Format("Sales Taxes: {0:0.00}", this.TotalSalesTax));
            Console.WriteLine(string.Format("Total: {0:0.00}", this.TotalPrice));
            Console.WriteLine();
        }
    }
}
