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
    public partial class fmComplaints : Form
    {
        //Instance Variables
        private House myHouse;
        private string username;

        //Constructor
        public fmComplaints(House house, string username)
        {
            InitializeComponent();
            this.myHouse = house;
            this.username = username;
        }

        //Events  ↓ ↓ ↓       
       
        //Submit button is pressed 
        private void btnSubmitComplain_Click(object sender, EventArgs e)
        {
            if (this.cmbComplains.SelectedIndex > -1)
            {
                //Submit anonymously
                if (this.cbAnonymously.Checked)
                {
                    this.myHouse.AddComplainAnonymously(this.cmbComplains.Text, this.rtxtComplain.Text);
                }
                //Submit normally
                else
                {
                    this.myHouse.AddComplain(this.cmbComplains.Text, this.rtxtComplain.Text, this.username);
                    
                }

                //Reset the text fields and give confirmation
                this.rtxtComplain.Text = "";
                this.cmbComplains.Text = "";
                MessageBox.Show("Your complain has been submitted!");
            }
            else
            {
                MessageBox.Show("Please select to what the complain is related to.");
            }
        }

        private void frmComplaints_Load(object sender, EventArgs e)
        {

        }
    }
}
