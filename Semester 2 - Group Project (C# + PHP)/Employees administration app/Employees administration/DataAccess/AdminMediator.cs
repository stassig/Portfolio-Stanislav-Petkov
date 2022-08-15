using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Employees_administration
{
    public class AdminMediator : DataAccess, IBasicDatabaseFunctions<Administrator>
    {
        public AdminMediator() { }

        public bool Add(Administrator admin)
        {
            if (ConnOpen())
            {
                query = "INSERT INTO user (username, password, role) VALUES ( @username, @password, @role)";

                SqlQuery(query);
                AddWithValue("@username", admin.Username);
                AddWithValue("@password", admin.Password);
                AddWithValue("@role", "Administrator");
                NonQueryEx();
                admin.ID = Convert.ToInt32(command.LastInsertedId);

                Close();
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }

        public bool Remove(Administrator admin)
        {
            if (ConnOpen())
            {
                query = "DELETE from user WHERE id = @id";
                SqlQuery(query);
                AddWithValue("@id", admin.ID);
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

        public List<Administrator> GetAll()
        {
            if (ConnOpen())
            {
                query = "SELECT * FROM user WHERE role = @role";
                SqlQuery(query);
                command.Parameters.AddWithValue("@role", "Administrator");

                List<Administrator> admins = new List<Administrator>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Administrator admin = new Administrator(
                        reader["username"].ToString(),
                        reader["password"].ToString());

                    admin.ID = Convert.ToInt32(reader["id"]);
                    admins.Add(admin);
                }
                Close();
                return admins;
            }
            else
            {
                Close();
                return null;
            }
        }
    }
}
