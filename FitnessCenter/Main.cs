using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessCenter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            AddMember addmem = new AddMember();
            addmem.Show();
            this.Hide();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientTileButton2_Click(object sender, EventArgs e)
        {
            UpdateDelete updel=new UpdateDelete();
            updel.Show();
            this.Hide();

        }

        private void guna2GradientTileButton4_Click(object sender, EventArgs e)
        {
            Payment py = new Payment();
            py.Show();
            this.Hide();
        }

        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            SeeMmbers seem = new SeeMmbers();
            seem.Show();
            this.Hide();
        }
    }
}
