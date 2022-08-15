using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees_administration
{
    public partial class LoginForm : Form
    {
        private ApplicationManager applicationManager;
        private DataEncryptor dataEncryptor;

        public LoginForm()
        {
            this.dataEncryptor = new DataEncryptor();
            this.applicationManager = new ApplicationManager();
            if (!this.applicationManager.LoadAllData())
            {
                MessageBox.Show("Please turn on your VPN before starting the application.");
                Environment.Exit(1);
            }

            InitializeComponent();     
        }

        //Login button
        private void button1_Click(object sender, EventArgs e)
        {

           if(this.tbLoginUsername.Text != "" && this.tbLoginPassword.Text != "")
            {
                string password = this.dataEncryptor.Encrypt(tbLoginPassword.Text);
                User user = this.applicationManager.UserManager.LoginCheck(tbLoginUsername.Text, password);

                if (user != null)
                {
                    if (user is Administrator)
                    {
                        AdministrationForm admin = new AdministrationForm(this.applicationManager);
                        this.Hide();
                        DialogResult result = admin.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            this.Show();
                        }
                     
                    }
                    else if (user is Manager)
                    {
                        lbAttendanceRateSpecificDate manager = new lbAttendanceRateSpecificDate(this.applicationManager, -1);
                        this.Hide();
                        DialogResult result = manager.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            this.Show();
                        }
                    }
                    else
                    {
                        Employee employee = (Employee)user;
                        if (employee.contractType != EmployeeContractType.Terminated)
                        {
                            if (employee.Role == Role.Cashier)
                            {
                                CashierForm cashierForm = new CashierForm(this.applicationManager);
                                this.Hide();
                                DialogResult result = cashierForm.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    this.Show();
                                }
                            }
                            else if (employee.Role == Role.DepotWorker)
                            {
                                depotWorkerForm depotForm = new depotWorkerForm(this.applicationManager);
                                this.Hide();
                                DialogResult result = depotForm.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    this.Show();
                                }
                            }
                            else if (employee.Role == Role.DepartmentManager)
                            {
                                lbAttendanceRateSpecificDate managerForm = new lbAttendanceRateSpecificDate(this.applicationManager,employee.DepartmentID);
                                this.Hide();
                                DialogResult result = managerForm.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    this.Show();
                                }
                            }
                            else { MessageBox.Show("You don't have proper authorization to access this application."); }
                        }
                        else { MessageBox.Show("Your contract with the company has been terminated."); }
                    }
                }
                else { MessageBox.Show("Invalid credentials."); }

                this.tbLoginPassword.Text = "";
                this.tbLoginUsername.Text = "";
            }
            else { MessageBox.Show("Please fill in both password and username fields."); }
           
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
