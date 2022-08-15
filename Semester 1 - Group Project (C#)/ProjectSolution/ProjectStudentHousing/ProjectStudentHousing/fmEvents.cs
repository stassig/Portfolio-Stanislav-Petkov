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
    public partial class fmEvents : Form
    {
        //Instance Variables
        private House myHouse;

        //Constructor
        public fmEvents(House house)
        {
            InitializeComponent();
            this.myHouse = house;
        }

        //Methods  ↓ ↓ ↓

        //Update the listbox, displaying all of the events
        private void RefreshUI()
        {
            this.lbEventList.Items.Clear();
            List<Event> allEvents = this.myHouse.Events;
            for (int i = 0; i < allEvents.Count; i++)
            {
                this.lbEventList.Items.Add(allEvents[i].GetInfo());
            }
        }

        //Events  ↓ ↓ ↓

        //Add event button is pressed --> new event form is opened
        private void btnScheduleEvent_Click_1(object sender, EventArgs e)
        {
            using (var form = new AddEventForm())
            {
                var result = form.ShowDialog();
                //Event form is closed
                if (result == DialogResult.OK)
                {
                    //Pass the event from the event form to the tenant form
                    //and use its value to add a new event to the list
                    Event submittedEvent = form.ReturnEvent;
                    this.myHouse.AddEvent(submittedEvent);
                    //Update the listbox displaying events
                    this.RefreshUI();
                }
            }
        }

        //Delete event button is pressed
        private void btnDeleteEvent_Click_1(object sender, EventArgs e)
        {
            //If an event is selected from the listbox --> it is removed and the listbox is updated
            if (this.lbEventList.SelectedIndex > -1)
            {
                this.myHouse.RemoveEvent(this.lbEventList.SelectedIndex);
                this.RefreshUI();
            }
            //Else, get a message
            else
            {
                MessageBox.Show("No event has been selected for removal.");
            }
        }

        //Details button pressed --> show details of a selected event
        private void btnShowDetails_Click_1(object sender, EventArgs e)
        {
            if (lbEventList.SelectedIndex != -1)
            {
                MessageBox.Show(this.myHouse.Events[lbEventList.SelectedIndex].GetInfo());
            }
        }

        //Event form loads --> update the list of all of the current events
        private void fmEvents_Load(object sender, EventArgs e)
        {
            this.RefreshUI();
        }
    }
}
