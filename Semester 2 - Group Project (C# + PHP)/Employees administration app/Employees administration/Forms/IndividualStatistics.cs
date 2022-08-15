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
    public partial class IndividualStatistics : Form
    {
        private Employee employee;
        private IndividualEmployeeStatistics statistics;
        private ShiftManager shiftManager;

        public IndividualStatistics(ApplicationManager applicationManager, Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            this.shiftManager = applicationManager.ShiftManager;
            this.statistics = new IndividualEmployeeStatistics(applicationManager.UserManager, applicationManager.ShiftManager, employee);
            
            this.lblAttendanceRate.Text = this.statistics.GetIndividualAttendanceRate().ToString() + " %";
            this.lblTotalHoursWorked.Text = this.statistics.CalculateTotalHoursWorked().ToString() + " hours";
            this.lblTotalDaysAtTheCompany.Text = this.statistics.CalculateTotalDaysAtTheCompany().ToString() + " days";
            
            this.btnGreen.BackColor = Color.Green;
            this.btnRed.BackColor = Color.Red;
            this.btnYellow.BackColor = Color.Yellow;
        }

        private void FillShifts()
        {
            this.dgvWorkShifts.Rows.Clear();
            List<WorkShift> workShifts = this.statistics.GetPastEmployeeShifts();
            ShiftMediator mediator = new ShiftMediator();
           
            foreach (WorkShift shift in workShifts)
            {            
                 this.dgvWorkShifts.Rows.Add(shift.ID, shift.Type, shift.Date);                            
            }

            foreach (DataGridViewRow row in this.dgvWorkShifts.Rows)
            {
                WorkShift shift = this.shiftManager.Get(Convert.ToInt32(row.Cells["ID"].Value));
                int checker = mediator.CheckAttendance(shift, this.employee.ID);

                if (checker == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (checker == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
                else if (checker == 2)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void IndividualStatistics_Load(object sender, EventArgs e)
        {
            this.dgvWorkShifts.ColumnCount = 3;
            this.dgvWorkShifts.Columns[0].Name = "ID";
            this.dgvWorkShifts.Columns[1].Name = "Type";
            this.dgvWorkShifts.Columns[2].Name = "Date";

            this.dgvWorkShifts.Columns[0].Width = 60;
            this.dgvWorkShifts.Columns[1].Width = 100;
            this.dgvWorkShifts.Width = 270;

            this.dgvWorkShifts.BackgroundColor = this.dgvWorkShifts.DefaultCellStyle.BackColor;
            this.dgvWorkShifts.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvWorkShifts.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvWorkShifts.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvWorkShifts.BackColor = Color.White;
            this.dgvWorkShifts.BackColor = Color.White;
            this.dgvWorkShifts.RowHeadersVisible = false;
            //this.dgvWorkShifts.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

            this.FillShifts();
        }

        private void dgvWorkShifts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
