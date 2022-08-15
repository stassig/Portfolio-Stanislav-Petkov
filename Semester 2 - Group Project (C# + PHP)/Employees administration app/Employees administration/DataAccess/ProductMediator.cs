using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Employees_administration
{
    public class ProductMediator : DataAccess, IBasicDatabaseFunctions<Product>,
        IUpdateFunction<Product>
    {
        public ProductMediator() { }

        public bool Add(Product product)
        {
            if (ConnOpen())
            {
                query = "INSERT INTO product (name, costPrice, sellingPrice, inStock, maxCapacity," +
                    " Threshold, sold, size, Department_ID) VALUES (@name, @costPrice, @sellingPrice, @inStock," +
                    " @maxCapacity, @Threshold, @sold, @size, @Department_ID)";

                SqlQuery(query);

                AddWithValue("@name", product.Name);
                AddWithValue("@costPrice", product.CostPrice);
                AddWithValue("@sellingPrice", product.SellingPrice);
                AddWithValue("@inStock", product.InStock);
                AddWithValue("@maxCapacity", product.MaxCapacity);
                AddWithValue("@Threshold", product.Threshold);
                AddWithValue("@sold", product.Sold);
                AddWithValue("@size", product.Size);
                AddWithValue("@Department_ID", product.DepartmentID);

                NonQueryEx();

                product.ID = Convert.ToInt32(command.LastInsertedId);

                Close();
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }

        public bool Remove(Product product)
        {
            if (ConnOpen())
            {
                query = "DELETE from product WHERE id = @product_id";
                SqlQuery(query);
                AddWithValue("@product_id", product.ID);
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

        public List<Product> GetAll()
        {
            if (ConnOpen())
            {
                query = "SELECT * FROM product";
                SqlQuery(query);

                List<Product> products = new List<Product>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product(
                        reader["name"].ToString(),
                        Convert.ToInt32(reader["inStock"]),
                        Convert.ToInt32(reader["sold"]),
                        Convert.ToDecimal(reader["costPrice"]),
                        Convert.ToDecimal(reader["sellingPrice"]),
                        Convert.ToDecimal(reader["size"]),
                        Convert.ToInt32(reader["maxCapacity"]),
                        Convert.ToInt32(reader["Threshold"]),
                        Convert.ToInt32(reader["Department_ID"]));

                    product.ID = Convert.ToInt32(reader["id"]);
                    products.Add(product);
                }
                Close();
                return products;

            }
            else
            {
                Close();
                return null;
            }
        }

        public bool Update(Product product)
        {
            if (ConnOpen())
            {
                query = "UPDATE product SET name = @name, inStock = @inStock, costPrice = @costPrice, " +
                    "sellingPrice = @sellingPrice, maxCapacity =  @maxCapacity, Threshold =  @Threshold, " +
                    "sold = @sold, size = @size, Department_ID = @Department_ID WHERE id = @id";

                SqlQuery(query);
                AddWithValue("@name", product.Name);
                AddWithValue("@costPrice", product.CostPrice);
                AddWithValue("@sellingPrice", product.SellingPrice);
                AddWithValue("@inStock", product.InStock);
                AddWithValue("@maxCapacity", product.MaxCapacity);
                AddWithValue("@Threshold", product.Threshold);
                AddWithValue("@sold", product.Sold);
                AddWithValue("@size", product.Size);
                AddWithValue("@Department_ID", product.DepartmentID);
                AddWithValue("@id", product.ID);
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
    }
}
