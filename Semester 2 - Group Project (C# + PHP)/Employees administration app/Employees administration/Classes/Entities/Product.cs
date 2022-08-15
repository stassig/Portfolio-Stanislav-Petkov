using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class Product
    {
        public delegate void OutOfStockHandle(Product p);
        public event OutOfStockHandle ProductOutOfStock;

        public int ID { get; set; }
        public string Name { get; private set; }
        public decimal CostPrice { get; private set; }
        public decimal SellingPrice { get; private set; }
        public int InStock { get; private set; }
        public int MaxCapacity { get; private set; }
        public int Threshold { get; private set; }
        public int Sold { get; private set; }
        public decimal Size { get; private set; }
        public int DepartmentID { get; private set; }


        public Product(string name, int inStock, int sold, decimal costPrice, decimal sellingPrice,
            decimal size, int maxCapacity, int threshold, Department department)
        {
            this.Name = name;
            this.InStock = inStock;
            this.SellingPrice = sellingPrice;
            this.CostPrice = costPrice;
            this.Sold = sold;
            this.Size = size;
            this.MaxCapacity = maxCapacity;
            this.Threshold = threshold;
            this.DepartmentID = department.ID;
        }

        public Product(string name, int inStock, int sold, decimal costPrice, decimal sellingPrice,
           decimal size, int maxCapacity, int threshold, int DepartmentID)
        {
            this.Name = name;
            this.InStock = inStock;
            this.SellingPrice = sellingPrice;
            this.CostPrice = costPrice;
            this.Sold = sold;
            this.Size = size;
            this.MaxCapacity = maxCapacity;
            this.Threshold = threshold;
            this.DepartmentID = DepartmentID;
        }
        public bool CheckQuantity()
        {
            if (this.ProductOutOfStock != null)
            {
                if (this.InStock < this.Threshold)
                {
                    this.ProductOutOfStock(this);
                    return true;
                }
                else { return false; }                  
            }
            return false;
        }

        public void RestockProduct(int quantity)
        {
            this.InStock += quantity;
        }

        public bool SellProduct(int quantity)
        {
            if (quantity <= this.InStock)
            {
                this.InStock -= quantity;
                this.Sold += quantity;

                if (this.ProductOutOfStock != null)
                {
                    if (this.InStock < this.Threshold)
                        this.ProductOutOfStock(this);
                }

                return true;

            }
            else { return false; }
        }

        public void EditProduct(string name, decimal costPrice, decimal sellingPrice,
            decimal size, int threshold, int maxCapacity, int DepartmentID)
        {
            this.Name = name;
            this.CostPrice = costPrice;
            this.SellingPrice = sellingPrice;
            this.Size = size;
            this.Threshold = threshold;
            this.MaxCapacity = maxCapacity;
            this.DepartmentID = DepartmentID;
        }

        public override string ToString()
        {
            return $"ID: {this.ID}; Name: {this.Name}";
        }
    }
}
