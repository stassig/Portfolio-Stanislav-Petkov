using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    public class ProductStatisticsC
    {
        private SaleMediator saleMediator;

        public int SoldAmount { get; private set; }
        public decimal SingleTurnover { get; private set; }
        public decimal OverallTurnover { get; private set; }

        public ProductStatisticsC()
        {
            this.saleMediator = new SaleMediator();
        }

        public void GetSingleTurnoverAmountSoldTimePeriod(string startDate, string endDate, int productId)
        {
            this.SoldAmount = 0;
            this.SingleTurnover = 0;

            foreach (Sale sale in this.GetSalesForTimePeriod(startDate, endDate))
            {
                if (sale.ProductId == productId)
                {
                    this.SoldAmount += sale.Quantity;
                    this.SingleTurnover += sale.Profit;
                }
            }
            this.SingleTurnover = Math.Round(this.SingleTurnover, 2);
        }

        public decimal GetOverallTurnoverTimePeriod(string startDate, string endDate, Department department)
        {
            ProductManager productManager = new ProductManager();
            decimal overallTurnover = 0;

            foreach (Sale sale in this.GetSalesForTimePeriod(startDate, endDate))
            {
                Product product = productManager.Get(sale.ProductId);
                if (product != null)
                {
                    if (department.ID == product.DepartmentID)
                    {
                        overallTurnover += sale.Profit;
                    }
                }
            }
            return Math.Round(overallTurnover, 2);
        }

        public decimal GetOverallTurnoverTimePeriod(string startDate, string endDate)
        {
            decimal overallTurnover = 0;

            foreach (Sale sale in this.GetSalesForTimePeriod(startDate, endDate))
            {
                overallTurnover += sale.Profit;
            }
            return Math.Round(overallTurnover, 2);
        }

        private List<Sale> GetSalesForTimePeriod(string startDate, string endDate)
        {
            List<Sale> sales = new List<Sale>();
            DateTime startDate1 = DateTime.ParseExact(startDate, "MM/dd/yyyy", null);
            DateTime endDate1 = DateTime.ParseExact(endDate, "MM/dd/yyyy", null);

            foreach (Sale sale in this.saleMediator.GetAll())
            {
                if (DateTime.Compare(DateTime.ParseExact(sale.Date, "MM/dd/yyyy", null), startDate1) >= 0 &&
                    DateTime.Compare(DateTime.ParseExact(sale.Date, "MM/dd/yyyy", null), endDate1) <= 0)
                {
                    sales.Add(sale);
                }
            }
            return sales;
        }
    }
}

