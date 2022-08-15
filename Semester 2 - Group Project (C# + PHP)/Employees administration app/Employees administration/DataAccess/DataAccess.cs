using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Employees_administration
{
    public abstract class DataAccess
    {
        protected MySqlConnection connection;
        protected MySqlCommand command;
        protected MySqlDataAdapter dataAdapter;
        protected DataTable dataTable;
        protected MySqlDataReader dataReader;
        protected string query = "";

        public DataAccess()
        {
            string database = "Server=studmysql01.fhict.local;Uid=dbi461415;Database=dbi461415;Pwd=password1";

            this.connection = new MySqlConnection(database);
        }


        public void AddWithValue(string parameterName, object value)
        {
            this.command.Parameters.AddWithValue(parameterName, value);
        }

        public void NonQueryEx()
        {
            this.command.ExecuteNonQuery();
        }

        public void Close()
        {
            this.connection.Close();
        }

        public DataRowCollection DataRow()
        {
            return this.dataTable.Rows;
        }

        public bool ConnOpen()
        {
            try
            {
                this.connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Can not connect");
                        break;

                    case 1045:
                        MessageBox.Show("Error in Database");
                        break;
                }
                return false;
            }
        }
        public bool QueryEx()
        {
            this.dataAdapter = new MySqlDataAdapter(this.command);
            this.dataTable = new DataTable();
            this.dataTable.Columns.Add("Person");
            this.dataAdapter.Fill(this.dataTable);
            if (this.dataTable.Rows.Count > 0)
                return true;
            else
                return false;

        }

        public void SqlQuery(string queryText)
        {
            this.command = new MySqlCommand(queryText, this.connection);
        }

    }
}

