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
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Xml.Linq;
using static Guna.UI2.Native.WinApi;
using System.Security.Cryptography;

namespace car_rental
{
    public partial class User : Form
    {
        public User()
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
            string query = "SELECT * FROM USertbl";
            SqlDataAdapter da = new SqlDataAdapter(query,Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UID.Text=="")
            {
                MessageBox.Show("Enter User ID ");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete FROM USertbl Where Id=" + UID.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User deleted");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             if(UID.Text=="" || UNAME.Text=="" || UPASS.Text=="")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try 
                {
                    Con.Open();
                    string query = "insert into USertbl values(" +UID.Text +",'" +UNAME.Text +"','" + UPASS.Text + "')";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Added");
                    Con.Close();
                    populate();
                }
                catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void User_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
                    // Get the selected row
                    DataGridViewRow row = UserDGV.Rows[e.RowIndex];

                    // Retrieve the values from the selected row
                    string column1Value = row.Cells["Id"].Value.ToString();
                    string column2Value = row.Cells["Username"].Value.ToString(); // Replace "Column1" with the actual column name
                    string column3Value = row.Cells["Password"].Value.ToString(); // Replace "Column2" with the actual column name

                    // Display the values in the input text boxes
                    UID.Text = column1Value;
                    UNAME.Text = column2Value;
                    UPASS.Text = column3Value;
     
        }
        
  

        private void button3_Click(object sender, EventArgs e)
        {
            if (UID.Text=="" || UNAME.Text=="" || UPASS.Text=="")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update USertbl set Username='" +UNAME.Text +"',Password=' "+UPASS.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Updated ");
                    Con.Close();
                    populate();
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

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (UID.Text == "" || UNAME.Text == "" || UPASS.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into USertbl values(" + UID.Text + ",'" + UNAME.Text + "','" + UPASS.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Added");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            /*if (UID.Text == "" || UNAME.Text == "" || UPASS.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update USertbl set Username='" + UNAME.Text + "',Password=' " + UPASS.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Successfully Updated ");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }*/
            if (UID.Text == "" || UNAME.Text == "" || UPASS.Text == "")
            {
                MessageBox.Show("Complete All Details.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update USertbl set Username=@Username, Password=@Password where Id=@Id", Con);
                    cmd.Parameters.AddWithValue("@Id", int.Parse(UID.Text));
                    cmd.Parameters.AddWithValue("@Username", UNAME.Text);
                    cmd.Parameters.AddWithValue("@Password", UPASS.Text);
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
            if (UID.Text == "")
            {
                MessageBox.Show("Enter User ID ");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete FROM USertbl Where Id=" + UID.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User deleted");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);

                }

            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            UID.Text = string.Empty;
            UNAME.Text = string.Empty;
            UPASS.Text = string.Empty;
        }

        private void UserDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            // Get the selected row
            DataGridViewRow row = UserDGV.Rows[e.RowIndex];

            // Retrieve the values from the selected row
            string column1Value = row.Cells["Id"].Value.ToString();
            string column2Value = row.Cells["Username"].Value.ToString(); // Replace "Column1" with the actual column name
            string column3Value = row.Cells["Password"].Value.ToString(); // Replace "Column2" with the actual column name

            // Display the values in the input text boxes
            UID.Text = column1Value;
            UNAME.Text = column2Value;
            UPASS.Text = column3Value;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return1 main = new Return1();
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

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            vehicles main = new vehicles();
            main.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainui main = new mainui();
            main.Show();
        }
    }
}
