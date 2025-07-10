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
        private void NameFilter()
        {

            cnn.Open();
            string query = "SELECT * FROM UyeTBL WHERE UAdSoyad LIKE @uye";
            SqlDataAdapter sda = new SqlDataAdapter(query, cnn);
            sda.SelectCommand.Parameters.AddWithValue("@uye", "%" + araUyeTB.Text + "%");
            SqlCommandBuilder builder = new SqlCommandBuilder();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ListMembrDGV.DataSource = dt;
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
            Main mn = new Main();
            mn.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameFilter();
            araUyeTB.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Uyeler();
        }
    }
}
