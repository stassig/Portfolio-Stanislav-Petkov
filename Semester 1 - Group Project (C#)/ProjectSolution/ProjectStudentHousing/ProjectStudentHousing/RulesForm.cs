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
    public partial class RulesForm : Form
    {
        //Instance Variables
        private House house;
        private Admin admin;
        
        private bool cursorDown;
        private Point offset;

        //Constructor
        public RulesForm(House house)
        {
            InitializeComponent();
            this.house = house;
            this.admin = this.house.HouseAdmin;
        }

        //Methods  ↓ ↓ ↓

        //Update the list of suggestions
        private void UpdateSuggesstions()
        {
            this.lbSuggestions.Items.Clear();
            List<Suggestion> ruleSuggestions = this.house.Suggestions;
            for (int i = 0; i < ruleSuggestions.Count; i++)
            {
                this.lbSuggestions.Items.Add($"#{i + 1} " + ruleSuggestions[i].GetInfo());
            }
        }

        //Update the list of rules
        private void UpdateRules()
        {
            this.lbRules.Items.Clear();
            List<Rule> allRules = this.admin.HouseRules;
            for (int i = 0; i < allRules.Count; i++)
            {
                this.lbRules.Items.Add(allRules[i].GetInfo());
            }
        }

        //Method to add a new rule that has been suggested by a tenant
        private void AddSuggestionAsRule()
        {
            //Get all suggestions
            List<Suggestion> ruleSuggestions = this.house.Suggestions;
            //Get the description of the selected suggestion
            string description = ruleSuggestions[this.lbSuggestions.SelectedIndex].Description;
            //Add it as a new rule and update the house rules
            this.admin.AddRule(description);
            this.UpdateRules();
            //Remove the implemented suggestion from the list of current suggestions
            Suggestion suggestion = ruleSuggestions[this.lbSuggestions.SelectedIndex];
            this.lbSuggestions.Items.RemoveAt(this.lbSuggestions.SelectedIndex);
            this.house.RemoveSuggestion(suggestion);
            //Update the listbox, displaying the suggestions
            this.UpdateSuggesstions();
            this.lbSuggestions.SelectedIndex = -1;
        }

        //Events  ↓ ↓ ↓

        //Add a new rule, when the add button is pressed
        private void btnAddRule_Click(object sender, EventArgs e)
        {
            //If a suggestion is selected, implement it as a new rule
            if (this.lbSuggestions.SelectedIndex > -1)
            {
                this.AddSuggestionAsRule();
            }          
            //Else, implement a new rule based on admin's own idea
            else
            {
                if (this.rtxtRule.Text != "")
                {                    
                    this.admin.AddRule(this.rtxtRule.Text);
                    this.UpdateRules();
                    this.rtxtRule.Text = "";
                }
                else
                {
                    MessageBox.Show("Please enter a new rule description.");
                }

            }
        }

        //Remove button is pressed --> removes rule at the selected index
        private void btnRemoveRule_Click(object sender, EventArgs e)
        {
            if (lbRules.SelectedIndex > -1)
            {
                this.admin.RemoveRule(this.lbRules.SelectedIndex);
                this.UpdateRules();
            }
            else
            {
                MessageBox.Show("Please select a rule.");
            }
        }

        //Update the list of suggestions that have been submitted
        private void RulesForm_Load(object sender, EventArgs e)
        {
            this.UpdateSuggesstions();
            this.UpdateRules();
        }

        //When the change button is pressed, change the description of a certain rule  
        private void btnChange_Click_1(object sender, EventArgs e)
        {
            if (lbRules.SelectedIndex > -1)
            {                
                //Change the rule and update the house rules
                this.admin.ChangeRule(this.lbRules.SelectedIndex + 1, this.rtxtNewDescription.Text);
                this.UpdateRules();
                this.rtxtNewDescription.Text = "";
            }
            else
            {
                MessageBox.Show("Please select a rule to change.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
