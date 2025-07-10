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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            usernameTB.Text = "";
            passTB.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameTB == null || passTB.Text == "")
            {
                MessageBox.Show("Fill in the missing fields.");
            }
            else if (usernameTB.Text == "admin" && passTB.Text == "0123")
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }   
            else
            {
                 MessageBox.Show("Invalid username or password.");
            }
            
        }
    }
}
