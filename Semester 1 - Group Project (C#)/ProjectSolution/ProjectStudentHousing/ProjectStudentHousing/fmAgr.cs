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
    public partial class fmAgr : Form
    {
        //Instance Variables
        private House myHouse;

        //Constructor
        public fmAgr(House house)
        {
            InitializeComponent();
            this.myHouse = house;
        }

        //Methods  ↓ ↓ ↓

        //Update the listbox with agreements
        private void UpdateAgreements()
        {
            this.lbAgreements.Items.Clear();
            List<Agreement> allAgreements = this.myHouse.HouseAgreements;
            for (int i = 0; i < allAgreements.Count; i++)
            {
                this.lbAgreements.Items.Add(allAgreements[i].GetInfo());
            }

        }

        //Events  ↓ ↓ ↓
       
        //Add agreement button is pressed
        private void btnAddAgreement_Click(object sender, EventArgs e)
        {
            //A new agreement is added with the inputted description 
            string agreementDescription = this.tbAgreement.Text;
            this.myHouse.AddAgreement(agreementDescription);
            //The textbox, showing the agreements, is updated            
            this.UpdateAgreements();
            this.tbAgreement.Text = "";
        }

        //Agreement form loads --> update the list of all the current agreements
        private void fmAgr_Load(object sender, EventArgs e)
        {
            this.UpdateAgreements();
        }

        //Remove agreement button is pressed --> remove agreement at the selected index
        private void btnRemoveAgreement_Click(object sender, EventArgs e)
        {
            if (this.lbAgreements.SelectedIndex > -1)
            {
                this.myHouse.RemoveAgreement(this.lbAgreements.SelectedIndex);
                this.UpdateAgreements();
            }
            else
            {
                MessageBox.Show("Please select an agreement to be removed.");
            }
        }

        //Edit button is pressed --> edit a certain agreement
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Change the agreement and update the list, showing all of the agreements
            this.myHouse.ChangeAgreement(this.lbAgreements.SelectedIndex + 1, this.tbEditAgreement.Text);
            this.UpdateAgreements();
            this.tbEditAgreement.Text = "";
        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }
    }
}
