using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FitnessCenter
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mozay\Documents\FitnessDb.mdf;Integrated Security=True;Connect Timeout=30;");

        private void FillName()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT UAdSoyad FROM UyeTBL", cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("UAdSoyad", typeof(string));
            dt.Load(reader);
            NasuCB.ValueMember = "UAdSoyad";
            NasuCB.DataSource = dt;
            cnn.Close();
        }

        private void Uyeler()
        {
          
            cnn.Open();
            string query = "SELECT * FROM OdemeTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, cnn);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            PaymentDGV.DataSource = ds.Tables[0];
            cnn.Close();
        }
        private void NameFilter()
        {

            cnn.Open();
            string query = "SELECT * FROM OdemeTBL WHERE OUye LIKE @uye";
            SqlDataAdapter sda = new SqlDataAdapter(query, cnn);
            sda.SelectCommand.Parameters.AddWithValue("@uye", "%" + araTB.Text + "%");

            DataTable dt = new DataTable();
            sda.Fill(dt);
            PaymentDGV.DataSource = dt;
            cnn.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NasuCB.Text = "";
            AmntTB.Text = "";

        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Main mn = new Main();
            mn.Show();
            this.Hide();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            FillName();
            Uyeler();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (NasuCB.Text == "" || AmntTB.Text == "")
            {
                MessageBox.Show("Fill in the missing fields.");
            }
            else
            {
                string amountperiod = $"{PeriodDTP.Value.Month:D2}-{PeriodDTP.Value.Year}";

                cnn.Open();

                string checkQuery = "SELECT COUNT(*) FROM OdemeTBL WHERE OUye = @uye AND OAy = @ay";
                SqlDataAdapter sda = new SqlDataAdapter(checkQuery, cnn);
                sda.SelectCommand.Parameters.AddWithValue("@uye", NasuCB.SelectedValue.ToString());
                sda.SelectCommand.Parameters.AddWithValue("@ay", amountperiod);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("This member has already paid for this month.");
                }
                else
                {
                    try
                    {
                        string insertQuery = "INSERT INTO OdemeTBL (OAy, OUye, OMiktar) VALUES (@ay, @uye, @miktar)";
                        SqlCommand cmd = new SqlCommand(insertQuery, cnn);
                        cmd.Parameters.AddWithValue("@ay", amountperiod);
                        cmd.Parameters.AddWithValue("@uye", NasuCB.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@miktar", AmntTB.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Payment added successfully.");
                        NasuCB.Text = "";
                        AmntTB.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

                cnn.Close();
                Uyeler();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameFilter();
            araTB.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Uyeler();
        }
    }
}
