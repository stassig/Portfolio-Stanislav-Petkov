using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Employees_administration
{
    public class ManagerMediator : DataAccess, IBasicDatabaseFunctions<Manager>
    {
        public ManagerMediator() { }

        public bool Add(Manager manager)
        {
            if (ConnOpen())
            {
                query = "INSERT INTO user (username, password, role) VALUES ( @username, @password, @role)";

                SqlQuery(query);
                AddWithValue("@username", manager.Username);
                AddWithValue("@password", manager.Password);
                AddWithValue("@role", "Manager");
                NonQueryEx();
                manager.ID = Convert.ToInt32(command.LastInsertedId);

                Close();
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }

        public bool Remove(Manager manager)
        {
            if (ConnOpen())
            {
                query = "DELETE from user WHERE id = @id";
                SqlQuery(query);
                AddWithValue("@id", manager.ID);
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

        public List<Manager> GetAll()
        {
            if (ConnOpen())
            {
                query = "SELECT * FROM user WHERE role = @role";
                SqlQuery(query);
                command.Parameters.AddWithValue("@role", "Manager");

                List<Manager> managers = new List<Manager>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Manager manager = new Manager(
                        reader["username"].ToString(),
                        reader["password"].ToString());

                    manager.ID = Convert.ToInt32(reader["id"]);
                    managers.Add(manager);
                }
                Close();
                return managers;
            }
            else
            {
                Close();
                return null;
            }
        }

    }
}
