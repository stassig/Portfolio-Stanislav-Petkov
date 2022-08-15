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
    public partial class ViewSchedule : Form
    {
        private ShiftManager manager;

        private int Days;
        private DayOfWeek Day;
        private DateTime Monday;
        private DateTime Tuesday;
        private DateTime Wednesday;
        private DateTime Thursday;
        private DateTime Friday;
        private DateTime Saturday;
        private DateTime Sunday;

        public ViewSchedule(ShiftManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void ViewSchedule_Load(object sender, EventArgs e)
        {
            this.SetCurrentWeek();
            this.LoadAllShifts();
        }

        private void SetCurrentWeek()
        {
            this.Day = DateTime.Now.DayOfWeek;
            this.Days = Day - DayOfWeek.Monday;

            this.Monday = DateTime.Now.AddDays(-Days);
            this.Tuesday = Monday.AddDays(1);
            this.Wednesday = Monday.AddDays(2);
            this.Thursday = Monday.AddDays(3);
            this.Friday = Monday.AddDays(4);
            this.Saturday = Monday.AddDays(5);
            this.Sunday = Monday.AddDays(6);

            this.lblMonday.Text = Monday.ToString("MM/dd/yyyy");
            this.lblTuesday.Text = Tuesday.ToString("MM/dd/yyyy");
            this.lblWednesday.Text = Wednesday.ToString("MM/dd/yyyy");
            this.lblThursday.Text = Thursday.ToString("MM/dd/yyyy");
            this.lblFriday.Text = Friday.ToString("MM/dd/yyyy");
            this.lblSaturday.Text = Saturday.ToString("MM/dd/yyyy");
            this.lblSunday.Text = Sunday.ToString("MM/dd/yyyy");

        }

        private void ClearTextBoxes()
        {
            this.rtxMondayM.Text = "";
            this.rtxMondayA.Text = "";
            this.rtxMondayN.Text = "";
            this.rtxTuesdayM.Text = "";
            this.rtxTuesdayA.Text = "";
            this.rtxTuesdayN.Text = "";
            this.rtxWednesdayM.Text = "";
            this.rtxWednesdayA.Text = "";
            this.rtxWednesdayN.Text = "";
            this.rtxThursdayM.Text = "";
            this.rtxThursdayA.Text = "";
            this.rtxThursdayN.Text = "";
            this.rtxFridayM.Text = "";
            this.rtxFridayA.Text = "";
            this.rtxFridayN.Text = "";
            this.rtxSaturdayM.Text = "";
            this.rtxSaturdayA.Text = "";
            this.rtxSaturdayN.Text = "";
            this.rtxSundayM.Text = "";
            this.rtxSundayA.Text = "";
            this.rtxSundayN.Text = "";
        }

        private void LoadAllShifts()
        {
            this.ClearTextBoxes();

            List<WorkShift> AllShifts = this.manager.GetActiveShifts();
            
            foreach (WorkShift shift in AllShifts)
            {
                if (shift.Date == this.lblMonday.Text)
                {
                    if (shift.Type == "MORNING")
                    {
                        this.rtxMondayM.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "AFTERNOON")
                    {
                        this.rtxMondayA.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "EVENING")
                    {
                        this.rtxMondayN.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                }

                if (shift.Date == this.lblTuesday.Text)
                {
                    if (shift.Type == "MORNING")
                    {
                        this.rtxTuesdayM.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "AFTERNOON")
                    {
                        this.rtxTuesdayA.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "EVENING")
                    {
                        this.rtxTuesdayN.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                }

                if (shift.Date == this.lblWednesday.Text)
                {
                    if (shift.Type == "MORNING")
                    {
                        this.rtxWednesdayM.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "AFTERNOON")
                    {
                        this.rtxWednesdayA.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "EVENING")
                    {
                        this.rtxWednesdayN.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                }

                if (shift.Date == this.lblThursday.Text)
                {
                    if (shift.Type == "MORNING")
                    {
                        this.rtxThursdayM.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "AFTERNOON")
                    {
                        this.rtxThursdayA.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "EVENING")
                    {
                        this.rtxThursdayN.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                }
                if (shift.Date == this.lblFriday.Text)
                {
                    if (shift.Type == "MORNING")
                    {
                        this.rtxFridayM.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "AFTERNOON")
                    {
                        this.rtxFridayA.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "EVENING")
                    {
                        this.rtxFridayN.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                }
                if (shift.Date == this.lblSaturday.Text)
                {
                    if (shift.Type == "MORNING")
                    {
                        this.rtxSaturdayM.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "AFTERNOON")
                    {
                        this.rtxSaturdayA.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "EVENING")
                    {
                        this.rtxSaturdayN.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                }
                if (shift.Date == this.lblSunday.Text)
                {
                    if (shift.Type == "MORNING")
                    {
                        this.rtxSundayM.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "AFTERNOON")
                    {
                        this.rtxSundayA.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                    if (shift.Type == "EVENING")
                    {
                        this.rtxSundayN.AppendText(shift.EmpName + " id:" + shift.ID + Environment.NewLine);
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.SetCurrentWeek();
            this.LoadAllShifts();
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            this.Monday = this.Monday.AddDays(7);
            this.Tuesday = this.Tuesday.AddDays(7);
            this.Wednesday = this.Wednesday.AddDays(7);
            this.Thursday = this.Thursday.AddDays(7);
            this.Friday = this.Friday.AddDays(7);
            this.Saturday = this.Saturday.AddDays(7);
            this.Sunday = this.Sunday.AddDays(7);

            this.lblMonday.Text = this.Monday.ToString("MM/dd/yyyy");
            this.lblTuesday.Text = this.Tuesday.ToString("MM/dd/yyyy");
            this.lblWednesday.Text = this.Wednesday.ToString("MM/dd/yyyy");
            this.lblThursday.Text = this.Thursday.ToString("MM/dd/yyyy");
            this.lblFriday.Text = this.Friday.ToString("MM/dd/yyyy");
            this.lblSaturday.Text = this.Saturday.ToString("MM/dd/yyyy");
            this.lblSunday.Text = this.Sunday.ToString("MM/dd/yyyy");

            this.LoadAllShifts();
        }

        private void btnPreviousWeek_Click(object sender, EventArgs e)
        {
            this.Monday = this.Monday.AddDays(-7);
            this.Tuesday = this.Tuesday.AddDays(-7);
            this.Wednesday = this.Wednesday.AddDays(-7);
            this.Thursday = this.Thursday.AddDays(-7);
            this.Friday = this.Friday.AddDays(-7);
            this.Saturday = this.Saturday.AddDays(-7);
            this.Sunday = this.Sunday.AddDays(-7);

            this.lblMonday.Text = this.Monday.ToString("MM/dd/yyyy");
            this.lblTuesday.Text = this.Tuesday.ToString("MM/dd/yyyy");
            this.lblWednesday.Text = this.Wednesday.ToString("MM/dd/yyyy");
            this.lblThursday.Text = this.Thursday.ToString("MM/dd/yyyy");
            this.lblFriday.Text = this.Friday.ToString("MM/dd/yyyy");
            this.lblSaturday.Text = this.Saturday.ToString("MM/dd/yyyy");
            this.lblSunday.Text = this.Sunday.ToString("MM/dd/yyyy");

            this.LoadAllShifts();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
