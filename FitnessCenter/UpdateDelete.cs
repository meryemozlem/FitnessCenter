using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessCenter
{
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }

        SqlConnection cnn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mozay\Documents\FitnessDb.mdf;Integrated Security=True;Connect Timeout=30;");

        private void Uyeler()
        {
            cnn.Open();
            string query = "SELECT * FROM UyeTBL";
            SqlDataAdapter sda = new SqlDataAdapter(query, cnn);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            UpDeDGV.DataSource = ds.Tables[0];
            cnn.Close();
        }

        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            Uyeler();
        }
        /*Elle eklendi → Text kullan

Veriyle bağlı → SelectedValue kullan

Sıralı sabit değerler → SelectedIndex kullan*/
        int key = 0;
        private void UpDeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Tıklanan satırı seç
                UpDeDGV.Rows[e.RowIndex].Selected = true;

                // Artık SelectedRows[0] güvenli şekilde kullanılabilir
                DataGridViewRow row = UpDeDGV.SelectedRows[0];
                key = Convert.ToInt32(row.Cells[0].Value.ToString());

                NaSuTB.Text = row.Cells[1].Value.ToString();
                PhTB.Text = row.Cells[2].Value.ToString();
                AgeTB.Text = row.Cells[3].Value.ToString();
                GenCB.Text = row.Cells[4].Value.ToString();
                AmntTB.Text = row.Cells[5].Value.ToString();
                TmnCB.Text = row.Cells[6].Value.ToString();
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NaSuTB.Text = "";
            PhTB.Text = "";
            AgeTB.Text = "";
            GenCB.Text = null;
            AmntTB.Text = "";
            TmnCB.Text = null; // Seçili öğeyi kaldırır
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Main mn = new Main();
            mn.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("select member to delete");
            }
            else 
            {
                try
                {
                    cnn.Open();
                    string query = "DELETE FROM UyeTBL WHERE UId=" + key + "";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member deleted successfully.");
                    cnn.Close();
                    Uyeler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0 || NaSuTB.Text=="" || PhTB.Text==""||GenCB.Text==""|| AgeTB.Text==""|| AmntTB.Text==""|| TmnCB.Text=="")
            {
                MessageBox.Show("Missing Info");
            }
            else
            {
                try
                {
                    cnn.Open();
                    string query = "UPDATE UyeTBL set  UASoyad= '"+NaSuTB.Text+"', UTel='"+PhTB.Text+"', UCinsiyet='"+ GenCB.Text + "', UYas='"+AgeTB.Text+"', UOdeme='"+AmntTB.Text+"' , UZamanlama='"+TmnCB.Text+"' where UId="+key+"; ";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member updated successfully.");
                    cnn.Close();
                    Uyeler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
