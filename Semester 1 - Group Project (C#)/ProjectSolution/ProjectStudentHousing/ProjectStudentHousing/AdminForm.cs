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
    public partial class AdminForm : Form
    {
        //Instance variables
        private House adminHouse;
        private LoginForm formLogin;
        private Admin houseAdmin;

        private bool cursorDown;
        private Point offset;

        //Constructor
        public AdminForm(House newHouse, LoginForm form1)
        {
            InitializeComponent();
            //pass on all of the data from the login form
            this.adminHouse = newHouse;
            this.formLogin = form1;
            this.houseAdmin = this.adminHouse.HouseAdmin;
        }

        //Events  ↓ ↓ ↓

        //Display all the complains submitted by the tenants in a new form
        private void btnShowComplains_Click(object sender, EventArgs e)
        {
            List<Complain> houseComplains = this.adminHouse.TenantsComplains;
            ComplainsForm viewComplains = new ComplainsForm(this.houseAdmin.GetAllComplainsAsString(houseComplains));
            viewComplains.Show();
        }

        //Open form for tenants management, when Tenants button is pressed
        private void btnShowTenants_Click(object sender, EventArgs e)
        {
            TenantsManagerForm viewTenants = new TenantsManagerForm(this.adminHouse);
            viewTenants.Show();
        }

        //Rules button is pressed --> open rule manager form
        private void btnShowRules_Click(object sender, EventArgs e)
        {
            RulesForm viewRules = new RulesForm(this.adminHouse);
            viewRules.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        //Exit the admin account and goes back to login form, when the exit button is clicked
        private void btnQuitAccount_Click(object sender, EventArgs e)
        {
            this.Close();
            this.formLogin.Show();
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
