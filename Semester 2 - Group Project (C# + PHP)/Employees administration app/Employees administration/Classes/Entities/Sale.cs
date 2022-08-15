using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
   public class Sale
    {
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public string Date { get; private set; }
        public decimal Profit { get; private set; }

        public Sale(int productId, int quantity, string date, decimal profit)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Date = date;
            this.Profit = profit;
        }
    }
}
