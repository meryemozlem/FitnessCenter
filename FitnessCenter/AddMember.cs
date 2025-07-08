using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//sql added
using System.Data.SqlClient;

namespace FitnessCenter
{
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }
        //DB Connected, bağlantı dizesi
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mozay\Documents\FitnessDb.mdf;Integrated Security=True;Connect Timeout=30;");

        private void AddMember_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AddNameTB.Text == null || PhoneTB.Text == "" ||  AgeTB.Text == null || AmntTB.Text == "" )
            {
                MessageBox.Show("Fill in the missing fields.");
            }
            else
            {
                try
                {
                    
                    //selectedItem=Seçilen Öğe.
                    //ExecuteNonQuery(), SELECT dışındaki SQL komutlarını çalıştırır.
                    cnn.Open();
                    string query = "INSERT INTO UyeTBL VALUES ('"+AddNameTB.Text+"','"+PhoneTB.Text+"', '"+GenCB.SelectedItem.ToString()+"', '"+AgeTB.Text+"', '"+AmntTB.Text+"', '"+TimingCB.SelectedItem.ToString()+"')";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member added successfully.");
                    cnn.Close();

                    AddNameTB.Text = "";
                    PhoneTB.Text = "";
                    AgeTB.Text = "";
                    AmntTB.Text = "";
                    GenCB.SelectedIndex = -1; // Seçili öğeyi kaldırır
                    TimingCB.SelectedIndex = -1; // Seçili öğeyi kaldırır

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Main mn = new Main();
            mn.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNameTB.Text = "";
            PhoneTB.Text = "";
            AgeTB.Text = "";
            AmntTB.Text = "";
            GenCB.SelectedIndex = -1; // Seçili öğeyi kaldırır
            TimingCB.SelectedIndex = -1; // Seçili öğeyi kaldırır
            MessageBox.Show("Fields cleared successfully.");

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
