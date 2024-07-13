using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace car_rental
{
    public partial class Return1 : Form
    {
        public Return1()
        {
            InitializeComponent();
        }
     
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\LOCHANA LAPTOP\Documents\car rent.mdf"";Integrated Security=True;Connect Timeout=30");

        /*private void fillcombo()
        {
            Con.Open();
            string query = "select Regno from vehicle where available='"+"YES"+"'";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Regno", typeof(string));
            dt.Load(rdr);
            carreg.ValueMember = "Regno";
            carreg.DataSource = dt;
            Con.Close();
        }*/
        private void fillCustomer()
        {
            Con.Open();
            string query = "select orderId from Rentbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("orderId", typeof(int));
            dt.Load(rdr);
            oridsb.ValueMember = "orderId";
            oridsb.DataSource = dt;
            Con.Close();
        }

        private void fetchCustName()
        {
            Con.Open();
            string query = "select * from Rentbl where orderId="+ oridsb.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CusName.Text = dr["CusName"].ToString();
                regno.Text = dr["CarRegNo"].ToString();
                RenDte.Text = dr["RentDte"].ToString();
                Fee.Text = dr["Fee"].ToString();
            }
            Con.Close();
        }
        private void populate()
        {
            Con.Open();
            string query = "SELECT * FROM ordertbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            retrntb.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void updateonRent()
        {
            Con.Open();
            //SqlCommand cmd = new SqlCommand("update Rentbl set available='"+"YES"+"' where Regno='" +regno.ToString() +"';");
            
            string query = "update vehicle set available ='"+"YES"+"' where Regno='" +regno.Text+"';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            Con.Close();
        }
        private void oridsb_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainui main = new mainui();
            main.Show();
        }

        private void Return1_Load(object sender, EventArgs e)
        {
            //fillcombo();
            fillCustomer();
            populate();


           


        }

        private void oridsb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CusName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text=="" || retrn.Text=="" )
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update ordertbl set CusName=@CusName,VehRegNo=@VehRegNo,ReturnDte=@ReturnDte,TotalPrice=@TotalPrice where OrderId=@OrderId", Con);
                    cmd.Parameters.AddWithValue("@OrderId", int.Parse(oridsb.Text));
                    cmd.Parameters.AddWithValue("@CusName", CusName.Text);
                    cmd.Parameters.AddWithValue("@VehRegNo", regno.Text);
                    cmd.Parameters.AddWithValue("@ReturnDte", retrn.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("TotalPrice", guna2TextBox1.Text);
                    
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    updateonRent();
                    populate();
                    MessageBox.Show("Data Sucessfully updated.");
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (oridsb.Text=="" || guna2TextBox1.Text=="" || CusName.Text=="" || regno.Text=="")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ordertbl values (@OrderId,@CusName,@VehRegNo,@ReturnDte,@TotalPrice)", Con);
                    cmd.Parameters.AddWithValue("@OrderId", int.Parse(oridsb.Text));
                    cmd.Parameters.AddWithValue("@CusName", CusName.Text);
                    cmd.Parameters.AddWithValue("@VehRegNo", regno.Text);
                    cmd.Parameters.AddWithValue("@ReturnDte", retrn.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@TotalPrice", guna2TextBox1.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    updateonRent();
                    populate();
                    MessageBox.Show("Data Sucessfully added.");
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            retrn.Text = string.Empty;
            guna2TextBox1.Text = string.Empty;
        }

        /*private void retrntb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                DataGridViewRow row = this.retrntb.Rows[e.RowIndex];

                oridsb.Text = row.Cells["OrderId"].Value.ToString();
                CusName.Text = row.Cells["CusName"].Value.ToString();
                regno.Text = row.Cells["VehRegNo"].Value.ToString();
                retrn.Text = row.Cells["ReturnDte"].Value.ToString();
                guna2TextBox1.Text = row.Cells["TotalPrice"].Value.ToString();


            }
        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            if (oridsb.Text=="")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete ordertbl where orderId=@orderId", Con);
                    cmd.Parameters.AddWithValue("@orderId", int.Parse(oridsb.Text));
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

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void oridsb_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void guna2TileButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            retrn.Text = string.Empty;
            guna2TextBox1.Text = string.Empty;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || retrn.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update ordertbl set CusName=@CusName,VehRegNo=@VehRegNo,ReturnDte=@ReturnDte,TotalPrice=@TotalPrice where OrderId=@OrderId", Con);
                    cmd.Parameters.AddWithValue("@OrderId", int.Parse(oridsb.Text));
                    cmd.Parameters.AddWithValue("@CusName", CusName.Text);
                    cmd.Parameters.AddWithValue("@VehRegNo", regno.Text);
                    cmd.Parameters.AddWithValue("@ReturnDte", retrn.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("TotalPrice", guna2TextBox1.Text);

                    cmd.ExecuteNonQuery();
                    Con.Close();
                    updateonRent();
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
            if (oridsb.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete ordertbl where orderId=@orderId", Con);
                    cmd.Parameters.AddWithValue("@orderId", int.Parse(oridsb.Text));
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

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (oridsb.Text == "" || guna2TextBox1.Text == "" || CusName.Text == "" || regno.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ordertbl values (@OrderId,@CusName,@VehRegNo,@ReturnDte,@TotalPrice)", Con);
                    cmd.Parameters.AddWithValue("@OrderId", int.Parse(oridsb.Text));
                    cmd.Parameters.AddWithValue("@CusName", CusName.Text);
                    cmd.Parameters.AddWithValue("@VehRegNo", regno.Text);
                    cmd.Parameters.AddWithValue("@ReturnDte", retrn.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@TotalPrice", guna2TextBox1.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    updateonRent();
                    populate();
                    MessageBox.Show("Data Sucessfully added.");
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainui main = new mainui();
            main.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            vehicles main = new vehicles();
            main.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            customers main = new customers();
            main.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            rental main = new rental();
            main.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            User main = new User();
            main.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            this.Hide();
            User main = new User();
            main.Show();
        }

        private void retrntb_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.retrntb.Rows[e.RowIndex];

                oridsb.Text = row.Cells["OrderId"].Value.ToString();
                CusName.Text = row.Cells["CusName"].Value.ToString();
                regno.Text = row.Cells["VehRegNo"].Value.ToString();
                retrn.Text = row.Cells["ReturnDte"].Value.ToString();
                guna2TextBox1.Text = row.Cells["TotalPrice"].Value.ToString();


            }
        }
    }
}
