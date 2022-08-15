using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Employees_administration
{
    public class ShiftMediator : DataAccess, IBasicDatabaseFunctions<WorkShift>,
       IUpdateFunction<WorkShift>
    {
        public ShiftMediator() { }

        public bool Add(WorkShift shift)
        {
            if (ConnOpen())
            {
                query = "INSERT INTO workshift (employee_id, EmpName, Type, Date, wage, hours)" +
                    "VAlUES (@empid, @empname, @shift, @date, @dep, @always)";
                SqlQuery(query);
                AddWithValue("@empid", shift.empId);
                AddWithValue("@empname", shift.EmpName);
                AddWithValue("@shift", shift.Type);
                AddWithValue("@date", shift.Date);
                AddWithValue("@dep", shift.wageForShift);
                AddWithValue("@always", shift.hoursWorked);
                NonQueryEx();
                shift.ID = Convert.ToInt32(command.LastInsertedId);

                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        public bool Remove(WorkShift shift)
        {
            if (ConnOpen())
            {
                query = "DELETE from workshift WHERE ID = @workshift_id";
                SqlQuery(query);
                AddWithValue("@workshift_id", shift.ID);
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

        public List<WorkShift> GetAll()
        {
            if (ConnOpen())
            {
                query = "SELECT * FROM workshift";
                SqlQuery(query);

                List<WorkShift> workshifts = new List<WorkShift>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    WorkShift workshift = new WorkShift(
                        Convert.ToInt32(reader["employee_id"]),
                        reader["EmpName"].ToString(),
                        reader["Date"].ToString(),
                        (reader["Type"]).ToString(),
                        Convert.ToDecimal(reader["wage"]),
                        Convert.ToInt32(reader["hours"]));

                    workshift.ID = Convert.ToInt32(reader["ID"]);
                    if (reader["Cancelled"].ToString() == "True") { workshift.CancelShift(); }

                    workshifts.Add(workshift);
                }
                Close();
                return workshifts;

            }
            else
            {
                Close();
                return null;
            }
        }

        //Method for shift cancellation
        public bool Update(WorkShift shift)
        {
            if (ConnOpen())
            {
                query = "UPDATE workshift SET Cancelled = @Cancelled WHERE ID = @id";

                SqlQuery(query);
                AddWithValue("@Cancelled", "True");
                AddWithValue("@id", shift.ID);
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

        public int CheckAttendance(WorkShift shift, int employeeID)
        {
            int result = 0;

            if (ConnOpen())
            {
                DateTime date = DateTime.ParseExact(shift.Date, "MM/dd/yyyy", null);
                DateTime start = new DateTime();
                DateTime finish = new DateTime();
                if (shift.Type == "MORNING")
                {
                    start = new DateTime(date.Year, date.Month, date.Day, 7, 0, 0);
                    finish = new DateTime(date.Year, date.Month, date.Day, 15, 0, 0);
                }
                if (shift.Type == "AFTERNOON")
                {
                    start = new DateTime(date.Year, date.Month, date.Day, 15, 0, 0);
                    finish = new DateTime(date.Year, date.Month, date.Day, 23, 0, 0);
                }
                if (shift.Type == "EVENING")
                {
                    start = new DateTime(date.Year, date.Month, date.Day, 23, 0, 0);
                    finish = new DateTime(date.Year, date.Month, date.Day, 7, 0, 0);
                }

                query = "SELECT * FROM attendance WHERE employee_id = @id AND date = @date";

                SqlQuery(query);
                AddWithValue("@date", shift.Date);
                AddWithValue("@id", employeeID);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    if (reader["check_out"] != null)
                    {
                        DateTime checkIn = DateTime.ParseExact(reader["check_in"].ToString(), "MM/dd/yyyy H:mm", null);
                        DateTime checkOut = DateTime.ParseExact(reader["check_out"].ToString(), "MM/dd/yyyy H:mm", null);

                        if (DateTime.Compare(checkIn, start) <= 0 && DateTime.Compare(checkOut, finish) >= 0)
                        {
                            //Successful attendance - green
                            result = 1;
                        }
                        else if (DateTime.Compare(checkIn, start) <= 0 && DateTime.Compare(checkOut, finish) < 0)
                        {
                            //Potentially successful - yellow
                            result = 2;
                        }
                        else if (DateTime.Compare(checkIn, start) > 0 && DateTime.Compare(checkOut, finish) >= 0)
                        {
                            //Potentially successful - yellow
                            result = 2;
                        }
                        else { result = 0; }
                    }
                    else { result = 0; }
                }
                reader.Close();
                Close();
                return result;
            }
            else
            {
                Close();
                return result;
            }
        }
    }
}

