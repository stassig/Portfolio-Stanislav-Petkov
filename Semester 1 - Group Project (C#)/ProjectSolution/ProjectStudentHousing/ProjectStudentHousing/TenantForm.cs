
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
    public partial class TenantForm : Form
    {
        //Instance variables
        private House myHouse;
        private LoginForm formLogin;
        private string username;        

        private bool cursorDown;
        private Point offset;

        //Constructor
        public TenantForm(House studentHouse, string name, LoginForm form1)
        {
            InitializeComponent();
            //transfers all data from the first form
            this.myHouse = studentHouse;
            this.formLogin = form1;
            //needed to find which tenant is logged in
            this.username = name;                      
        }
        
        //Events  ↓ ↓ ↓

        //Exit button is pressed --> Close the tenant form and go back to login
        private void btnExitAccount_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void TenantForm_Load(object sender, EventArgs e)
        {
            this.lbWelcome.Text = $"Welcome, {this.username}!";
        }      

        private void btnEvents_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnEvents.Height;
            pnlNav.Top = btnEvents.Top;
            pnlNav.Left = btnEvents.Left;
            btnEvents.BackColor = Color.FromArgb(64, 96, 130);
            lblTabName.Text = "Events";

            this.pnlFormLoader.Controls.Clear();
            fmEvents FmEvents = new fmEvents(this.myHouse) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FmEvents.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FmEvents);
            FmEvents.Show();

        }

        private void btnComplaints_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnComplaints.Height;
            pnlNav.Top = btnComplaints.Top;
            pnlNav.Left = btnComplaints.Left;
            btnComplaints.BackColor = Color.FromArgb(64, 96, 130);
            lblTabName.Text = "Complaints";

            this.pnlFormLoader.Controls.Clear();
            fmComplaints FmComplaints = new fmComplaints(this.myHouse, this.username) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FmComplaints.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FmComplaints);
            FmComplaints.Show();
        }

        private void btnAgreements_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnAgreements.Height;
            pnlNav.Top = btnAgreements.Top;
            pnlNav.Left = btnAgreements.Left;
            btnAgreements.BackColor = Color.FromArgb(64, 96, 130);
            lblTabName.Text = "Agreements";

            this.pnlFormLoader.Controls.Clear();
            fmAgr FmAgr = new fmAgr(this.myHouse) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FmAgr.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FmAgr);
            FmAgr.Show();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnRules.Height;
            pnlNav.Top = btnRules.Top;
            pnlNav.Left = btnRules.Left;
            btnRules.BackColor = Color.FromArgb(64, 96, 130);
            lblTabName.Text = "Rules";

            this.pnlFormLoader.Controls.Clear();
            fmRules FmRules = new fmRules(this.myHouse) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FmRules.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FmRules);
            FmRules.Show();
        }

        private void btnEvents_Leave(object sender, EventArgs e)
        {
            btnEvents.BackColor = Color.FromArgb(11, 51, 95);
        }

        private void btnComplaints_Leave(object sender, EventArgs e)
        {
            btnComplaints.BackColor = Color.FromArgb(11, 51, 95);
        }

        private void btnAgreements_Leave(object sender, EventArgs e)
        {
            btnAgreements.BackColor = Color.FromArgb(11, 51, 95);
        }

        private void btnRules_Leave(object sender, EventArgs e)
        {
            btnRules.BackColor = Color.FromArgb(11, 51, 95);
        }

        private void tbnBackToHome_Click(object sender, EventArgs e)
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

        private void pnlNav_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEvents_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
