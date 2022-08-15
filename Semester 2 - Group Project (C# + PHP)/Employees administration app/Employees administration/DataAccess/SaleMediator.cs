using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Employees_administration
{
    public class SaleMediator : DataAccess
    {
        public SaleMediator() { }

        public bool Add(Sale sale)
        {
            if (ConnOpen())
            {
                query = "INSERT INTO sales (product_id, quantity, date, profit) VALUES ( @product_id, @quantity, @date, @profit)";

                SqlQuery(query);
                AddWithValue("@product_id", sale.ProductId);
                AddWithValue("@quantity", sale.Quantity);
                AddWithValue("@date", sale.Date);
                AddWithValue("@profit", sale.Profit);
                NonQueryEx();

                Close();
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }

        public List<Sale> GetAll()
        {
            if (ConnOpen())
            {
                query = "SELECT * FROM sales";
                SqlQuery(query);

                List<Sale> sales = new List<Sale>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Sale sale = new Sale(
                       Convert.ToInt32(reader["product_id"]),
                         Convert.ToInt32(reader["quantity"]),
                         reader["date"].ToString(),
                         Convert.ToDecimal(reader["profit"]));

                    sales.Add(sale);
                }
                Close();
                return sales;
            }
            else
            {
                Close();
                return null;
            }
        }

    }
}
