using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessCenter
{
    public partial class SeeMmbers : Form
    {
        public SeeMmbers()
        {
            InitializeComponent();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mozay\Documents\FitnessDb.mdf;Integrated Security=True;Connect Timeout=30;");

        private void Uyeler() 
        {
            //DataTable	- DataSet
            //Tek tablo - Birden fazla tablo(ve ilişkiler)
            cnn.Open();
            string query = "SELECT * FROM UyeTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, cnn);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            ListMembrDGV.DataSource = ds.Tables[0];
            cnn.Close();
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SeeMmbers_Load(object sender, EventArgs e)
        {
            Uyeler();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }
    }
}
