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


namespace car_rental
{
    public partial class rental : Form
    {
        public rental()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\LOCHANA LAPTOP\Documents\car rent.mdf"";Integrated Security=True;Connect Timeout=30");
        private void fillcombo()
        {
            Con.Open();
            string query = "select Regno from vehicle where available='"+"YES"+"'";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr ;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Regno",typeof(string));
            dt.Load(rdr);
            carr.ValueMember = "Regno";
            carr.DataSource = dt;
            Con.Close();
        }
        private void fillCustomer() 
        {
            Con.Open();
            string query = "select CusId from custbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CusId", typeof(int));
            dt.Load(rdr);
            cusidsb.ValueMember = "CusId";
            cusidsb.DataSource = dt;
            Con.Close();
        }

        private void fetchCustName()
        {
            Con.Open();
            string query = "select * from custbl where CusId="+ cusidsb.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand (query, Con);
            DataTable dt = new DataTable ();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill (dt);
            foreach(DataRow dr in dt.Rows)
            {
                cusname.Text = dr["Name"].ToString();
            }
            Con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainui main = new mainui();
            main.Show();
        }
        private void populate()
        {
            Con.Open();
            string query = "SELECT * FROM Rentbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            UserDGV3.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (orid.Text=="" || fee.Text=="" || cusname.Text=="" || carr.Text=="")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Rentbl values (@orderId,@CarRegNo,@CusId,@CusName,@RentDte,@RetnDte,@Fee)", Con);
                    cmd.Parameters.AddWithValue("@orderId", int.Parse(orid.Text));
                    cmd.Parameters.AddWithValue("@CarRegNo", carr.Text);
                    cmd.Parameters.AddWithValue("@CusId", cusidsb.Text);
                    cmd.Parameters.AddWithValue("@CusName", cusname.Text);
                    cmd.Parameters.AddWithValue("@RentDte", rent.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@RetnDte", retrn.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Fee", float.Parse(fee.Text));
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (orid.Text=="" || carr.Text=="" || cusidsb.Text=="" || cusname.Text=="" || fee.Text=="")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update Rentbl set CarRegNo=@CarRegNo, CusId=@CusId, CusName=@CusName ,RentDte=@RentDte, RetnDte=@RetnDte, Fee=@Fee where orderId=@orderId", Con);
                    cmd.Parameters.AddWithValue("@orderId", int.Parse(orid.Text));
                    cmd.Parameters.AddWithValue("@CarRegNo", int.Parse(carr.Text));
                    cmd.Parameters.AddWithValue("@CusId", cusidsb.Text);
                    cmd.Parameters.AddWithValue("@CusName", cusname.Text);
                    cmd.Parameters.AddWithValue("@RentDte", rent.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@RetnDte", retrn.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Fee", fee.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (orid.Text=="")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete Rentbl where orderId=@orderId", Con);
                    cmd.Parameters.AddWithValue("@orderId", int.Parse(orid.Text));
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

        private void updateonRent()
        {
            Con.Open();
            string query = "update vehicle set available ='"+"NO"+"' where Regno='" +carr.SelectedValue.ToString() +"';";
            SqlCommand cmd = new SqlCommand(query, Con);  
            cmd.ExecuteNonQuery();
            Con.Close();
        }
        private void rental_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillCustomer();
            populate();
        }

        /*private void UserDGV3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                DataGridViewRow row = this.UserDGV3.Rows[e.RowIndex];

                orid.Text = row.Cells["orderId"].Value.ToString();
                carreg.Text = row.Cells["CarRegNo"].Value.ToString();
                cusidsb.Text = row.Cells["CusId"].Value.ToString();
                cusname.Text = row.Cells["CusName"].Value.ToString();
                rent.Text = row.Cells["RentDte"].Value.ToString();
                retrn.Text = row.Cells["RetnDte"].Value.ToString();
                fee.Text = row.Cells["Fee"].Value.ToString();


            }
        }*/

        private void cusidsb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            orid.Text = string.Empty;
            cusname.Text = string.Empty;
            fee.Text = string.Empty;
            
        }

        private void carreg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cusidsb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UserDGV3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.UserDGV3.Rows[e.RowIndex];

                orid.Text = row.Cells["orderId"].Value.ToString();
                carr.Text = row.Cells["CarRegNo"].Value.ToString();
                cusidsb.Text = row.Cells["CusId"].Value.ToString();
                cusname.Text = row.Cells["CusName"].Value.ToString();
                rent.Text = row.Cells["RentDte"].Value.ToString();
                retrn.Text = row.Cells["RetnDte"].Value.ToString();
                fee.Text = row.Cells["Fee"].Value.ToString();


            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cusname_TextChanged(object sender, EventArgs e)
        {

        }

        private void cusidsb_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cusidsb_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (orid.Text == "" || fee.Text == "" || cusname.Text == "" || carr.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Rentbl values (@orderId,@CarRegNo,@CusId,@CusName,@RentDte,@RetnDte,@Fee)", Con);
                    cmd.Parameters.AddWithValue("@orderId", int.Parse(orid.Text));
                    cmd.Parameters.AddWithValue("@CarRegNo", carr.Text);
                    cmd.Parameters.AddWithValue("@CusId", cusidsb.Text);
                    cmd.Parameters.AddWithValue("@CusName", cusname.Text);
                    cmd.Parameters.AddWithValue("@RentDte", rent.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@RetnDte", retrn.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Fee", float.Parse(fee.Text));
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (orid.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete Rentbl where orderId=@orderId", Con);
                    cmd.Parameters.AddWithValue("@orderId", int.Parse(orid.Text));
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

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (orid.Text == "" || carr.Text == "" || cusidsb.Text == "" || cusname.Text == "" || fee.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update Rentbl set CarRegNo=@CarRegNo, CusId=@CusId, CusName=@CusName ,RentDte=@RentDte, RetnDte=@RetnDte, Fee=@Fee where orderId=@orderId", Con);
                    cmd.Parameters.AddWithValue("@orderId", int.Parse(orid.Text));
                    cmd.Parameters.AddWithValue("@CarRegNo", int.Parse(carr.Text));
                    cmd.Parameters.AddWithValue("@CusId", cusidsb.Text);
                    cmd.Parameters.AddWithValue("@CusName", cusname.Text);
                    cmd.Parameters.AddWithValue("@RentDte", rent.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@RetnDte", retrn.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Fee", fee.Text);
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

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            orid.Text = string.Empty;
            cusname.Text = string.Empty;
            fee.Text = string.Empty;
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();

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
