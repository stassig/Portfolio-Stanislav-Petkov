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
    public partial class CancellingEmployee_sContract : Form
    {
        private Employee employee;
        private UserManager userManager;
        private ShiftManager shiftManager;

        public CancellingEmployee_sContract(Employee employee, ApplicationManager applicationManager)
        {
            this.employee = employee;
            this.shiftManager = applicationManager.ShiftManager;
            this.userManager = applicationManager.UserManager;

            InitializeComponent();
        }

        private void CancellingEmployee_sContract_Load(object sender, EventArgs e)
        {

        }

        private bool DateCheck()
        {
            string now = DateTime.Now.ToString("MM/dd/yyyy");

            if (DateTime.Compare(this.dtpLastWorkingDate.Value, DateTime.ParseExact(now, "MM/dd/yyyy", null)) >= 0)
            {
                return true;
            }
            return false;
        }

        private void CancelContract()
        {
            if (this.employee.TerminateContract(this.rtbReason.Text.ToString(), this.dtpLastWorkingDate.Value))
            {
                this.userManager.Update(this.employee);
                this.shiftManager.RemoveEmployeesFutureShifts(this.employee);

                DialogResult box = MessageBox.Show("Employee's contract has been canceled successfully.");
                if (box == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnDoneCancelling_Click(object sender, EventArgs e)
        {
            if (this.rtbReason.Text != "")
            {
                if (this.DateCheck())
                {
                    if (this.shiftManager.CheckShiftsInTheFuture(this.employee, this.dtpLastWorkingDate.Value.ToString("MM/dd/yyyy")))
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to terminate this employee's contract on this selected date?  He has been scheduled for shifts after this date.", "", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            this.CancelContract();
                        }
                    }
                    else { this.CancelContract(); }
                }
                else { MessageBox.Show("Last working date can not be earlier than the current date."); }
            }
            else { MessageBox.Show("Please enter a reason for termination of contract."); }

        }

        private void btnCancelContractCancelling_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
