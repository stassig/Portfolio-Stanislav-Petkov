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
    public partial class fmRules : Form
    {
        //Instance Variables
        private House myHouse;

        //Constructor
        public fmRules(House house)
        {
            InitializeComponent();
            this.myHouse = house;
            //get all of the house rules
            Admin admin = this.myHouse.HouseAdmin;
            this.rtxtHouseRules.Text = admin.GetAllRulesAsString();           
        }
        //Events  ↓ ↓ ↓

        //Submit button is pressed --> add a new suggestion to the list of suggestions
        private void btnSumbitRuleSuggestion_Click(object sender, EventArgs e)
        {
            this.myHouse.AddSuggestion(this.rtxSuggestion.Text, this.rtxReason.Text);
            this.rtxReason.Text = "";
            this.rtxSuggestion.Text = "";
            //Get confirmation
            MessageBox.Show("Your suggestion has been submitted.");
        }

        private void reasoningLabel_Click(object sender, EventArgs e)
        {

        }

        private void rtxtHouseRules_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
