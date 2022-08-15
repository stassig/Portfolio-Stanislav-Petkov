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
    public partial class ComplainsForm : Form
    {
        //Instance Variables
        private string allComplains = "";

        private bool cursorDown;
        private Point offset;

        //Constructor
        public ComplainsForm(string allComplains)
        {
            InitializeComponent();
            this.allComplains = allComplains;
        }

        //Events ↓ ↓ ↓
        private void ComplainsForm_Load(object sender, EventArgs e)
        {
            this.rtxtAllComplains.Text = this.allComplains;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
