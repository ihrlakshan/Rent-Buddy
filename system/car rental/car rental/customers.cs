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
using System.Collections;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Reflection;


namespace car_rental
{
    public partial class customers : Form
    {
        public customers()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\LOCHANA LAPTOP\Documents\car rent.mdf"";Integrated Security=True;Connect Timeout=30");

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void populate()
        {
            Con.Open();
            string query = "SELECT * FROM custbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGRV1.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (cusid.Text=="" || licenno.Text=="" || name.Text=="" || address.Text=="" || contactno.Text=="")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into custbl values (@CusId,@LicenseNo,@Name,@Address,@Contact)", Con);
                    cmd.Parameters.AddWithValue("@CusId", int.Parse(cusid.Text));
                    cmd.Parameters.AddWithValue("@LicenseNo", int.Parse(licenno.Text));
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@Address", address.Text);
                    cmd.Parameters.AddWithValue("@Contact", int.Parse(contactno.Text));
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainui main = new mainui();
            main.Show();
        }

        

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (cusid.Text=="" || licenno.Text=="" || name.Text=="" || address.Text=="" || contactno.Text=="")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update custbl set LicenseNo=@LicenseNo, Name=@Name, Address=@Address, Contact=@Contact where CusId=@CusId", Con);
                    cmd.Parameters.AddWithValue("@CusId", int.Parse(cusid.Text));
                    cmd.Parameters.AddWithValue("@LicenseNo", int.Parse(licenno.Text));
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@Address", address.Text);
                    cmd.Parameters.AddWithValue("@Contact", int.Parse(contactno.Text));
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
            if (cusid.Text=="")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete custbl where CusId=@CusId", Con);
                    cmd.Parameters.AddWithValue("@CusId", int.Parse(cusid.Text));
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

        private void customers_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void dataGRV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex>=0)
            //{
                //DataGridViewRow row = this.dataGRV1.Rows[e.RowIndex];

               // cusid.Text = row.Cells["CusId"].Value.ToString();
               // licenno.Text = row.Cells["LicenseNo"].Value.ToString();
              //  name.Text = row.Cells["Name"].Value.ToString();
               // address.Text = row.Cells["Address"].Value.ToString();
               // contactno.Text = row.Cells["Contact"].Value.ToString();


            //}

            //////////////////////////////////////////////////////////////////////
            //DataGRV2.CellContentClick += DataGRV2_CellContentClick;

            //licenno.Text = DataGRV2.Rows[e.RowIndex].Cells[0].Value.ToString();
            //name.Text = DataGRV2.Rows[e.RowIndex].Cells[1].Value.ToString();
            //address.Text = DataGRV2.Rows[e.RowIndex].Cells[2].Value.ToString();
            //contactno.Text = DataGRV2.Rows[e.RowIndex].Cells[3].Value.ToString();
            //////////////////////////////////////////////////////////////////////
            // Get the selected row
            //DataGridViewRow row = DataGRV2.Rows[e.RowIndex];

            //Retrieve the values from the selected row
            //string column1Value = row.Cells["license no"].Value.ToString();
            //string column2Value = row.Cells["name"].Value.ToString(); // Replace "Column1" with the actual column name
            //string column3Value = row.Cells["address"].Value.ToString(); // Replace "Column2" with the actual column name
            //string column4Value = row.Cells["contact no"].Value.ToString();
            //Display the values in the input text boxes
            //LicenseNo.Text = column1Value;
            //name.Text = column2Value;
            //address.Text = column3Value;
            //ContactNo.Text = column4Value;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            cusid.Text = string.Empty;
            licenno.Text = string.Empty;
            name.Text = string.Empty;
            address.Text = string.Empty;
            contactno.Text = string.Empty;
        }

        private void dataGRV1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (cusid.Text == "" || licenno.Text == "" || name.Text == "" || address.Text == "" || contactno.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into custbl values (@CusId,@LicenseNo,@Name,@Address,@Contact)", Con);
                    cmd.Parameters.AddWithValue("@CusId", int.Parse(cusid.Text));
                    cmd.Parameters.AddWithValue("@LicenseNo", int.Parse(licenno.Text));
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@Address", address.Text);
                    cmd.Parameters.AddWithValue("@Contact", int.Parse(contactno.Text));
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
            if (cusid.Text == "" || licenno.Text == "" || name.Text == "" || address.Text == "" || contactno.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update custbl set LicenseNo=@LicenseNo, Name=@Name, Address=@Address, Contact=@Contact where CusId=@CusId", Con);
                    cmd.Parameters.AddWithValue("@CusId", int.Parse(cusid.Text));
                    cmd.Parameters.AddWithValue("@LicenseNo", int.Parse(licenno.Text));
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@Address", address.Text);
                    cmd.Parameters.AddWithValue("@Contact", int.Parse(contactno.Text));
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
            if (cusid.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete custbl where CusId=@CusId", Con);
                    cmd.Parameters.AddWithValue("@CusId", int.Parse(cusid.Text));
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
            cusid.Text = string.Empty;
            licenno.Text = string.Empty;
            name.Text = string.Empty;
            address.Text = string.Empty;
            contactno.Text = string.Empty;
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGRV1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGRV1.Rows[e.RowIndex];

                cusid.Text = row.Cells["CusId"].Value.ToString();
                licenno.Text = row.Cells["LicenseNo"].Value.ToString();
                name.Text = row.Cells["Name"].Value.ToString();
                address.Text = row.Cells["Address"].Value.ToString();
                contactno.Text = row.Cells["Contact"].Value.ToString();


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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            rental main = new rental();
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
