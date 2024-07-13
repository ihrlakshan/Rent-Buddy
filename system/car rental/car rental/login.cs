using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace car_rental
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\LOCHANA LAPTOP\Documents\car rent.mdf"";Integrated Security=True;Connect Timeout=30");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select count(*)from USertbl where Username = '"+userid.Text+"'and Password ='"+pass.Text+"'";
             Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query,Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() =="1")
            {
                mainui mainui = new mainui();
                mainui.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            Con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            userid.Text = string.Empty;
            pass.Text = string.Empty;
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            string query = "select count(*)from USertbl where Username = '" + userid.Text + "'and Password ='" + pass.Text + "'";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                mainui mainui = new mainui();
                mainui.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            Con.Close();
        }
    }
}
