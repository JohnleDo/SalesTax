using System;

namespace SalesTax
{
    class Item
    {
        public String ItemName;
        public int Quantity;
        public Double TaxRate;
        public Double Price;
        public Double SalesTax;
        public Double TotalSalesTax;
        public Double TotalPrice;

        public Item()
        {
            this.ItemName = null;
            this.Quantity = 0;
            this.TaxRate = 0.00;
            this.Price = 0.00;
            this.SalesTax = 0.00;
            this.TotalSalesTax = 0.00;
            this.TotalPrice = 0;
        }

        public Item(string itemName, int quantity, Double taxRate, Double price)
        {
            this.ItemName = itemName;
            this.Quantity = quantity;
            this.TaxRate = taxRate; 
            this.Price = price;
            this.SalesTax = Math.Ceiling((this.Price * this.TaxRate) /.05 ) * .05;
            this.TotalSalesTax = this.SalesTax * this.Quantity;
            this.TotalPrice = (this.Price * this.Quantity) + this.SalesTax;
        }

        public void UpdateTotalPrice()
        {
            this.SalesTax = Math.Ceiling((this.Price * this.TaxRate) / .05) * .05;
            this.TotalSalesTax = this.SalesTax * this.Quantity;
            this.TotalPrice = (this.Price * this.Quantity) + this.TotalSalesTax;
        }
    }
}
