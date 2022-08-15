using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Employees_administration
{
    public class RestockRequestMediator : DataAccess, IBasicDatabaseFunctions<RestockRequest>
    {
        public List<RestockRequest> GetAll()
        {
            if (ConnOpen())
            {
                query = "SELECT r.id AS requestId, r.requestedAmount ,r.sentTime, p.name, p.id AS productId FROM restock_request AS r INNER JOIN product AS p ON r.product_id= p.id";
                SqlQuery(query);
                List<RestockRequest> requests = new List<RestockRequest>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    RestockRequest request = new RestockRequest(
                        Convert.ToInt32(reader["productId"]),
                        reader["name"].ToString(),
                        Convert.ToInt32(reader["requestedAmount"]),
                        reader["sentTime"].ToString());

                    request.ID = Convert.ToInt32(reader["requestId"]);
                    requests.Add(request);
                }
                Close();
                return requests;
            }
            else
            {
                Close();
                return null;
            }
        }
        public bool Remove(RestockRequest request)
        {
            if (ConnOpen())
            {
                query = "DELETE from restock_request WHERE id = @id";
                SqlQuery(query);
                command.Parameters.AddWithValue("@id", request.ID);
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

        public bool Add(RestockRequest restockRequest)
        {
            if (ConnOpen())
            {
                query = "INSERT INTO restock_request (requestedAmount, sentTime, product_id) VALUES (@requestedAmount, @sentTime, @product_id)";

                SqlQuery(query);

                AddWithValue("@requestedAmount", restockRequest.RequestedAmount);
                AddWithValue("@sentTime", restockRequest.SentTime.Replace("-", "/"));
                AddWithValue("@product_id", restockRequest.ProductId);

                NonQueryEx();

                restockRequest.ID = Convert.ToInt32(command.LastInsertedId);

                Close();
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }

        //private void RestockProduct(RestockRequest r)
        //{
        //    query = "UPDATE product SET inStock=maxCapacity WHERE id = @id";
        //        SqlQuery(query);
        //        command.Parameters.AddWithValue("@id", r.Product.ID);
        //        NonQueryEx();

        //}

        public bool RejectRequest(RestockRequest request)
        {
            if (ConnOpen())
            {
                query = "DELETE from restock_request WHERE id = @id";
                SqlQuery(query);
                command.Parameters.AddWithValue("@id", request.ID);
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
