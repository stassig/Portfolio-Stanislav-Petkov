using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectStudentHousing
{
    public partial class AddEventForm : Form
    {
        //Instance Variables
        private bool cursorDown;
        private Point offset;

        //Properties
        public Event ReturnEvent { get; set; }

        //Constructor
        public AddEventForm()
        {
            InitializeComponent();
        }

        //Events ↓ ↓ ↓

        //Cancel button is pressed --> close the current form and return to the tenant form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //Submit button is pressed
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //If all of the neccessary information has been filled in 
            if (IsFormValid())
            {
                //Create a new event and return to the tenant form
                this.ReturnEvent = new Event(this.tbEventName.Text, this.tbEventStartDate.Text, this.tbEndDate.Text, House.eventNumber,this.tbEventStartTime.Text,this.tbEventFinishTime.Text,Convert.ToInt32(this.tbNumberOfPeople.Text));
                House.eventNumber++;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
           
        }

        //Methods ↓ ↓ ↓

        //Check if all of the mandatory fields have been filled in
        private bool IsFormValid()
        {
            string inputStartDate = this.tbEventStartDate.Text;
            DateTime startDate, endDate;
            string inputEndDate = this.tbEndDate.Text;
            string inputStartHour = this.tbEventStartTime.Text;
            string inputEndHour = this.tbEventFinishTime.Text;
            string participants = this.tbNumberOfPeople.Text;
            DateTime hour;
            int people;
            if (inputStartHour != null && inputStartHour !="")
            {
                if (DateTime.TryParse(inputStartHour, out hour))
                {
                    String.Format("{0:t/HH/mm}", hour);
                }
                else
                {
                    MessageBox.Show("Please introduce a valid hour!");
                    return false;
                }
            }
            if (inputEndHour != null && inputEndHour != "")
            {
                if (DateTime.TryParse(inputEndHour, out hour))
                {
                    String.Format("{0:t/HH/mm}", hour);

                }
                else
                {
                    MessageBox.Show("Please introduce a valid hour!");
                    return false;
                }
            }
            if (participants != null && participants != "")
            {
                if (int.TryParse(participants, out people) == false || people<1)
                {
                    MessageBox.Show("Please fill a pozitive number!");
                    return false;

                }
            }
            if (this.tbEventName.TextLength == 0)
            {
                MessageBox.Show("Please fill the event name!");
                return false;
            }

            if (DateTime.TryParse(inputStartDate, out startDate))
            {
                String.Format("{0:d/MM/yyyy}", startDate);
            }
            else
            {
                MessageBox.Show("Please introduce a valid start date!");
                return false;
            }
            if (DateTime.TryParse(inputEndDate, out endDate))
            {
                String.Format("{0:d/MM/yyyy}", endDate);

            }
            else
            {
                MessageBox.Show("Please introduce a valid ending date!");
                return false;
            }
            if (Compare(endDate, startDate) == -1)
            {
                MessageBox.Show("Please enter a valid date interval!");
                return false;
            }

            return true;
        }

        //Checks if the finish data is valid compared to the starting one
        public static int Compare(DateTime t1, DateTime t2)
        {
            if (t1 > t2)
            {
                return 1;
            }
            else if (t1 == t2)
            {
                return 0;
            }
            return -1;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void AddEventForm_Load(object sender, EventArgs e)
        {

        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            cursorDown = true;
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            if (cursorDown == true)
            {
                Point currentPos = PointToScreen(e.Location);
                Location = new Point(currentPos.X - offset.X, currentPos.Y - offset.Y);
            }
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            cursorDown = false;
        }
    }
}
