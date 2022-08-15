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
    public partial class TenantsManagerForm : Form
    {
        //Instance Variables
        private House house;

        private bool cursorDown;
        private Point offset;

        //Constructor
        public TenantsManagerForm(House house)
        {
            InitializeComponent();
            this.house = house;
        }

        //Methods  ↓ ↓ ↓
        private void UpdateTenantsList()
        {
            this.lbTenants.Items.Clear();
            List<Tenant> allTenants = this.house.HouseMembers;
            for (int i = 0; i < allTenants.Count; i++)
            {
                this.lbTenants.Items.Add($"#{i + 1} " + allTenants[i].Name);
            }
        }

        //Events  ↓ ↓ ↓

        //Add a new user, when the button is pressed
        private void btnAddTenant_Click(object sender, EventArgs e)
        {
            //Gets the data and the lenght of the input
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Text;
            int nameLenght = username.ToCharArray().Count();
            int passLenght = password.ToCharArray().Count();

            //Both username and password are too short 
            if (nameLenght <= 4 && passLenght <= 4)
            {
                MessageBox.Show("Username and password are too short.");
            }
            //Username is too short
            else if (nameLenght <= 4)
            {
                MessageBox.Show("Username should be at least 5 characters.");
            }
            //Password is too short
            else if (passLenght <= 4)
            {
                MessageBox.Show("Password should contain at least 5 characters.");
            }
            //Everything is correct --> create a new account 
            else
            {
                this.house.AddTenant(username, password);
                UpdateTenantsList();
                MessageBox.Show("A new tenant was added to the list.");              
            }
            this.txtPassword.Text = "";
            this.txtUsername.Text = "";
        }

        //Update the list of all tenant, when form loads
        private void Tenants_Load(object sender, EventArgs e)
        {
            this.UpdateTenantsList();
        }

        //Remove user at selected index, when the button is pressed
        private void btnRemoveTenant_Click(object sender, EventArgs e)
        {
            if(this.lbTenants.SelectedIndex > -1)
            {
                this.house.RemoveTenant(this.lbTenants.SelectedIndex);
                this.UpdateTenantsList();
            }
            else
            {
                MessageBox.Show("No user has been selected.");
            }
        }

        //Display the login credentials about each user
        private void btnGetAllData_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.house.GetAllTenantsAsString());
        }

        private void btnExit_Click(object sender, EventArgs e)
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
