using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental
{
    public partial class mainui : Form
    {
        public mainui()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                this.Hide();
                vehicles main = new vehicles();
                main.Show();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                this.Hide();
                customers main = new customers();
                main.Show();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                this.Hide();
                User main = new User();
                main.Show();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            rental main = new rental();
            main.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return1 main = new Return1();
            main.Show();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {

            this.Hide();
            vehicles main = new vehicles();
            main.Show();

        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            {
                this.Hide();
                customers main = new customers();
                main.Show();

            }
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            rental main = new rental();
            main.Show();
        }

        private void guna2TileButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return1 main = new Return1();
            main.Show();
        }

        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            User main = new User();
            main.Show();
        }

        private void guna2TileButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
