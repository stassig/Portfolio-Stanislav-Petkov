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

    public partial class LoginForm : Form
    {
        //Instance variables
        private House newHouse;

        private bool cursorDown;
        private Point offset;

        //Constructor
        public LoginForm()
        {
            InitializeComponent();
            this.newHouse = new House("Hemelrijken", 135);            
            //Hardcoding examples to simulate a database

            //Tenants
            this.newHouse.AddTenant("Stanislav", "12345");
            this.newHouse.AddTenant("Kristiyan", "54321");
            this.newHouse.AddTenant("Stefan", "101010");
            
            //Rules
            this.newHouse.HouseAdmin.AddRule("Be Respectful");
            this.newHouse.HouseAdmin.AddRule("Be honest");
            this.newHouse.HouseAdmin.AddRule("Clean up after yourself");
            //Agreements
            this.newHouse.AddAgreement("No Screaming or Whining");
            this.newHouse.AddAgreement("No Touching the TV");
            this.newHouse.AddAgreement("No Pets allowed");
            //Complains
            this.newHouse.AddComplain("Noise", "John is too loud at night", "Stanislav");
            this.newHouse.AddComplainAnonymously("Cleaning", "Thomas is not cleaning after himself");
            this.newHouse.AddComplain("Other", "Peter is smoking in the house", "Stefan");
            //Events
            this.newHouse.AddEvent(new Event("Party", "20.01.2021", "21.01.2021", House.eventNumber, "20:00"));
            House.eventNumber++;
            this.newHouse.AddEvent(new Event("Family Gathering", "25.03.2021", "30.03.2021", House.eventNumber, "13:00", "18:00", 5));
            House.eventNumber++;
            this.newHouse.AddEvent(new Event("Study Week", "30.04.2021", "06.05.2021", House.eventNumber));
            House.eventNumber++;
        }

        //Events  ↓ ↓ ↓
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //login button is pressed
        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.txtName.Text;
            string password = this.txtPassword.Text;

            //if you enter admin as a username and the correct password --> opens admin form      
            if (this.newHouse.checkAdminDetails(username, password))
            {
                this.Hide();
                this.txtName.Text = "";
                this.txtPassword.Text = "";
                AdminForm adminForm = new AdminForm(this.newHouse, this);
                adminForm.Show();
            }
            else
            {
                //matching data found --> open tenant form
                if (this.newHouse.checkTenantDetails(username, password))
                {
                    //hides login form
                    this.Hide();
                    this.txtName.Text = "";
                    this.txtPassword.Text = "";
                    //Creates a new tenant form and passes on all of the needed data
                    TenantForm tenantForm = new TenantForm(this.newHouse, username, this);
                    tenantForm.Text = $"User: {username}";
                    tenantForm.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect password or username. Please try again!");
                }
            }
        }

        //Quit button is pressed --> the app stops
        private void btnStopApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        //the 3 methods below make it so you can move the form around by holding it by the top
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
