using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace car_rental
{
    public partial class vehicles : Form
    {
        public vehicles()
        {
            InitializeComponent();
        }
     SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\LOCHANA LAPTOP\Documents\car rent.mdf"";Integrated Security=True;Connect Timeout=30");

        private void label2_Click(object sender, EventArgs e)
        {
           
        }
        private void populate()
        {
            Con.Open();
            string query = "SELECT * FROM vehicle";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGRVV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainui main = new mainui();
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RNO.Text=="" || year.Text=="" || model.Text=="" || Mil.Text=="")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into vehicle values (@Regno,@year,@model,@expdate,@milege,@available)",Con);                  
                    cmd.Parameters.AddWithValue("@Regno",RNO.Text);
                    cmd.Parameters.AddWithValue("@year", int.Parse(year.Text));
                    cmd.Parameters.AddWithValue("@model", model.Text);
                    cmd.Parameters.AddWithValue("@expdate", Dte.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@milege", int.Parse(Mil.Text));
                    cmd.Parameters.AddWithValue("@available", available.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    populate();
                    MessageBox.Show("Data Sucessfully added.");
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void vehicles_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RNO.Text=="" || year.Text=="" || model.Text=="" || Mil.Text=="" || available.Text=="")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update vehicle set year=@year, model=@model, expdate=@expdate, milege=@milege ,available=@available where Regno=@Regno", Con);
                    cmd.Parameters.AddWithValue("@Regno", int.Parse(RNO.Text));
                    cmd.Parameters.AddWithValue("@year", int.Parse(year.Text));
                    cmd.Parameters.AddWithValue("@model", model.Text);
                    cmd.Parameters.AddWithValue("@expdate", Dte.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@milege", int.Parse(Mil.Text));
                    cmd.Parameters.AddWithValue("@available", available.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    populate();
                    MessageBox.Show("Data Sucessfully updated.");
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RNO.Text=="")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete vehicle where Regno=@Regno", Con);
                    cmd.Parameters.AddWithValue("@Regno", int.Parse(RNO.Text));
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    populate();
                    MessageBox.Show("Data Sucessfully Deleted.");
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RNO.Text = string.Empty;
            model.Text = string.Empty;
            year.Text = string.Empty;
            Mil.Text = string.Empty;
        }

        /*private void dataGRVV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0) 
            {
                DataGridViewRow row = this.dataGRVV.Rows[e.RowIndex];

                RNO.Text = row.Cells["Regno"].Value.ToString();
                year.Text = row.Cells["year"].Value.ToString();
                model.Text = row.Cells["model"].Value.ToString();
                Dte.Text = row.Cells["expdate"].Value.ToString();
                Mil.Text = row.Cells["milege"].Value.ToString();
                available.Text = row.Cells["available"].Value.ToString();


            }
        }*/

        private void button6_Click(object sender, EventArgs e)
        {
            populate();
        }

        //private void search_SelectionChangeCommitted(object sender, EventArgs e)
        //{
            
        //}

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void available_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void search_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void search_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            string flag = "";
            if (search.SelectedItem.ToString() == "AVAILABLE")
            {
                flag = "YES";

            }
            else
            {
                flag = "NO";
            }
            Con.Open();
            string query = "SELECT * FROM vehicle where Available = '" + flag + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGRVV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void dataGRVV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGRVV.Rows[e.RowIndex];

                RNO.Text = row.Cells["Regno"].Value.ToString();
                year.Text = row.Cells["year"].Value.ToString();
                model.Text = row.Cells["model"].Value.ToString();
                Dte.Text = row.Cells["expdate"].Value.ToString();
                Mil.Text = row.Cells["milege"].Value.ToString();
                available.Text = row.Cells["available"].Value.ToString();


            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (RNO.Text == "" || year.Text == "" || model.Text == "" || Mil.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into vehicle values (@Regno,@year,@model,@expdate,@milege,@available)", Con);
                    cmd.Parameters.AddWithValue("@Regno", RNO.Text);
                    cmd.Parameters.AddWithValue("@year", int.Parse(year.Text));
                    cmd.Parameters.AddWithValue("@model", model.Text);
                    cmd.Parameters.AddWithValue("@expdate", Dte.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@milege", int.Parse(Mil.Text));
                    cmd.Parameters.AddWithValue("@available", available.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    populate();
                    MessageBox.Show("Data Sucessfully added.");
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (RNO.Text == "" || year.Text == "" || model.Text == "" || Mil.Text == "" || available.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update vehicle set year=@year, model=@model, expdate=@expdate, milege=@milege ,available=@available where Regno=@Regno", Con);
                    cmd.Parameters.AddWithValue("@Regno", RNO.Text);
                    cmd.Parameters.AddWithValue("@year", int.Parse(year.Text));
                    cmd.Parameters.AddWithValue("@model", model.Text);
                    cmd.Parameters.AddWithValue("@expdate", Dte.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@milege", int.Parse(Mil.Text));
                    cmd.Parameters.AddWithValue("@available", available.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    populate();
                    MessageBox.Show("Data Sucessfully updated.");
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (RNO.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete vehicle where Regno=@Regno", Con);
                    cmd.Parameters.AddWithValue("@Regno", RNO.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    populate();
                    MessageBox.Show("Data Sucessfully Deleted.");
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            RNO.Text = string.Empty;
            model.Text = string.Empty;
            year.Text = string.Empty;
            Mil.Text = string.Empty;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainui main = new mainui();
            main.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            rental main = new rental();
            main.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            customers main = new customers();
            main.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return1 main = new Return1();
            main.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            User main = new User();
            main.Show();
        }
    }
}
