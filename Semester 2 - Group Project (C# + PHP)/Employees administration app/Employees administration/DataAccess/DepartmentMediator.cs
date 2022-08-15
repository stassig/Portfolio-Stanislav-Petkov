using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_administration
{
    class DepartmentMediator : DataAccess, IBasicDatabaseFunctions<Department>
    {
        public bool Add(Department department)
        {
            if (ConnOpen())
            {
                query = "INSERT INTO department (name, manager_id) VALUES (@name, @manager_id)";

                SqlQuery(query);

                AddWithValue("@name", department.Name);
                AddWithValue("@manager_id", department.ManagerID);
                NonQueryEx();

                department.ID = Convert.ToInt32(command.LastInsertedId);

                Close();
                return true;
            }
            else
            {
                Close();
                return false;
            }
        }

        public List<Department> GetAll()
        {
            if (ConnOpen())
            {
                query = "SELECT * FROM department";
                SqlQuery(query);
                List<Department> departments = new List<Department>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Department department = new Department(
                        Convert.ToInt32(reader["id"]),
                        reader["name"].ToString());
                
                        int id = Convert.ToInt32(reader["manager_id"]);
                    if (id != -1)
                    {
                        department.AssignManager(id);
                    }
                        
                    
                    departments.Add(department);
                }
                Close();
                return departments;

            }
            else
            {
                Close();
                return null;
            }
        }

        public bool Remove(Department department)
        {
            if (ConnOpen())
            {
                query = "DELETE from department WHERE id = @id";
                SqlQuery(query);
                AddWithValue("@id", department.ID);
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

        public bool Update(Department department, int newManagerID, string newDepartmentName)
        {
            if (ConnOpen())
            {
                bool assignedManager = false;

                query = "SELECT * FROM department WHERE id = @id";

                SqlQuery(query);
                AddWithValue("@id", department.ID);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if(Convert.ToInt32(reader["manager_id"]) != -1)
                {
                    assignedManager = true;                    
                }
                reader.Close();

                if (assignedManager)
                {
                    query = "UPDATE employee SET role = @role1 WHERE id = @employee_id";
                    SqlQuery(query);
                    AddWithValue("@employee_id", department.ManagerID);
                    AddWithValue("@role1", Role.Regular.ToString());
                    NonQueryEx();
                }

                query = "UPDATE department SET name = @name, manager_id = @manager_id WHERE id = @id";

                SqlQuery(query);
                AddWithValue("@name", newDepartmentName);
                AddWithValue("@manager_id", newManagerID);
                AddWithValue("@id", department.ID);
                NonQueryEx();

                query = "UPDATE employee SET role = @role WHERE id = @manId";

                SqlQuery(query);
                AddWithValue("@role", Role.DepartmentManager.ToString());
                AddWithValue("@manId", newManagerID);
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
