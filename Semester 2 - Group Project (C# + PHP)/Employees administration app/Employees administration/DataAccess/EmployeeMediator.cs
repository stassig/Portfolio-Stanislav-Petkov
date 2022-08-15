using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Employees_administration
{
    public class EmployeeMediator : DataAccess, IBasicDatabaseFunctions<Employee>,
        IUpdateFunction<Employee>
    {
        public EmployeeMediator() { }

        public bool Add(Employee e)
        {
            if (ConnOpen())
            {
                query = "INSERT INTO user (username, password, role) VALUES ( @username, @password, @role)";

                SqlQuery(query);
                AddWithValue("@username", e.Username);
                AddWithValue("@password", e.Password);
                AddWithValue("@role", "Employee");
                NonQueryEx();
                e.ID = Convert.ToInt32(command.LastInsertedId);

                query = "INSERT INTO employee (id, username, password, first_name, last_name, gender, email, contract_type, birth_date, first_working_date," +
                    " hourly_wage, country, town, street_name, street_number, zipcode, last_working_date, role, Department_ID)" +
                    "VALUES (@id, @username, @password, @name, @lastName, @gender, @email, @contractType, @birthDate, @firstWorkingDate," +
                    " @hourlyWage, @country, @town, @streetName, @streetNumber, @zipcode, @lastWorkingDate, @role, @Department_ID)";

                SqlQuery(query);
                AddWithValue("@id", e.ID);
                AddWithValue("@username", e.Username);
                AddWithValue("@password", e.Password);
                AddWithValue("@name", e.FirstName);
                AddWithValue("@lastName", e.LastName);
                AddWithValue("@gender", e.Gender.ToString());
                AddWithValue("@email", e.Email);
                AddWithValue("@contractType", e.contractType.ToString());
                AddWithValue("@birthDate", e.Bdate.Replace("-", "/"));
                AddWithValue("@firstWorkingDate", e.Sdate.Replace("-", "/"));
                AddWithValue("@hourlyWage", e.HourlyWage);
                AddWithValue("@country", e.Country);
                AddWithValue("@town", e.Town);
                AddWithValue("@streetName", e.StreetName);
                AddWithValue("@streetNumber", e.StreetNumber);
                AddWithValue("@zipcode", e.ZipCode);
                AddWithValue("@lastWorkingDate", e.LastWorkingDay.Replace("-","/"));
                AddWithValue("@role", e.Role.ToString());
                AddWithValue("@Department_ID", e.DepartmentID);
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

        public bool Remove(Employee e)
        {
            if (ConnOpen())
            {
                query = "DELETE from user WHERE id = @employee_id";
                SqlQuery(query);
                AddWithValue("@employee_id", e.ID);
                NonQueryEx();

                query = "DELETE from employee WHERE id = @id";
                SqlQuery(query);
                AddWithValue("@id", e.ID);
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

        public List<Employee> GetAll()
        {
            if (ConnOpen())
            {
                query = "SELECT * FROM employee";
                SqlQuery(query);

                List<Employee> employees = new List<Employee>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee(
                        reader["first_name"].ToString(),
                        reader["last_name"].ToString(),
                        reader["username"].ToString(),
                        reader["email"].ToString(),
                        reader["birth_date"].ToString(),
                        reader["first_working_date"].ToString(),
                        Convert.ToDecimal(reader["hourly_wage"]),
                        reader["password"].ToString(),
                        (Gender)Enum.Parse(typeof(Gender), reader["gender"].ToString()),
                        (EmployeeContractType)Enum.Parse(typeof(EmployeeContractType), reader["contract_type"].ToString()),
                        reader["street_name"].ToString(),
                       Convert.ToInt32(reader["street_number"]),
                       reader["zipcode"].ToString(),
                       reader["town"].ToString(),
                       reader["country"].ToString(),
                       reader["last_working_date"].ToString(),
                       (Role)Enum.Parse(typeof(Role), reader["role"].ToString()),
                    Convert.ToInt32(reader["Department_ID"]));

                    employee.ID = Convert.ToInt32(reader["id"]);
                    employees.Add(employee);
                }
                Close();
                return employees;

            }
            else
            {
                Close();
                return null;
            }
        }

        public bool Update(Employee e)
        {
            if (ConnOpen())
            {
                query = "UPDATE employee SET first_name = @name, last_name = @lastName, gender = @gender, email = @email, contract_type =  @contractType," +
                    " birth_date =  @birthDate, first_working_date = @firstWorkingDate, hourly_wage = @hourlyWage, country = @country," +
                    " town = @town, street_name = @streetName, street_number = @streetNumber, zipcode = @zipcode, last_working_date = @lastWorkingDate, role = @role," +
                    "Department_ID = @Department_ID" +
                    " WHERE id = @id";

                SqlQuery(query);
                AddWithValue("@name", e.FirstName);
                AddWithValue("@lastName", e.LastName);
                AddWithValue("@gender", e.Gender.ToString());
                AddWithValue("@email", e.Email);
                AddWithValue("@contractType", e.contractType.ToString());
                AddWithValue("@birthDate", e.Bdate.Replace("-", "/"));
                AddWithValue("@firstWorkingDate", e.Sdate.Replace("-", "/"));
                AddWithValue("@hourlyWage", e.HourlyWage);
                AddWithValue("@country", e.Country);
                AddWithValue("@town", e.Town);
                AddWithValue("@streetName", e.StreetName);
                AddWithValue("@streetNumber", e.StreetNumber);
                AddWithValue("@zipcode", e.ZipCode);
                AddWithValue("@lastWorkingDate", e.LastWorkingDay.Replace("-", "/"));
                AddWithValue("@id", e.ID);
                AddWithValue("@role", e.Role.ToString());
                AddWithValue("@Department_ID", e.DepartmentID);
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

        public bool TerminateContract(Employee e)
        {
            if (ConnOpen())
            {
                query = "UPDATE employee SET contract_type = @contractType, departure_reason = @departure_reason WHERE id = @id";
                SqlQuery(query);
                AddWithValue("@contractType", "Terminated");
                AddWithValue("@id", e.ID);
                AddWithValue("@departure_reason", e.DepartureReason);
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

        public List<Employee> GetAvailableEmployees(string weekday)
        {
            if (ConnOpen())
            {
                query = "SELECT * FROM employee WHERE Unavailability NOT LIKE @day";
                SqlQuery(query);
                this.AddWithValue("@day", "%" + weekday + "%");

                List<Employee> employees = new List<Employee>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee(
                        reader["first_name"].ToString(),
                        reader["last_name"].ToString(),
                        reader["username"].ToString(),
                        reader["email"].ToString(),
                        reader["birth_date"].ToString(),
                        reader["first_working_date"].ToString(),
                        Convert.ToDecimal(reader["hourly_wage"]),
                        reader["password"].ToString(),
                        (Gender)Enum.Parse(typeof(Gender), reader["gender"].ToString()),
                        (EmployeeContractType)Enum.Parse(typeof(EmployeeContractType), reader["contract_type"].ToString()),
                        reader["street_name"].ToString(),
                       Convert.ToInt32(reader["street_number"]),
                       reader["zipcode"].ToString(),
                       reader["town"].ToString(),
                       reader["country"].ToString(),
                       reader["last_working_date"].ToString(),
                       (Role)Enum.Parse(typeof(Role), reader["role"].ToString()),
                    Convert.ToInt32(reader["Department_ID"]));

                    employee.ID = Convert.ToInt32(reader["id"]);
                    employees.Add(employee);
                    if (reader["nightShifts"].ToString() == "Available")
                    {
                        employee.NightAvailability = true;
                    }
                    else { employee.NightAvailability = false; }
                }
                Close();
                return employees;

            }
            else
            {
                Close();
                return null;
            }
        }
    }
}
