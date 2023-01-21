using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace assignment4_OOP
{
    public partial class Form1 : Form
    {

        customer1 customer = new customer1();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer.CompanyName = textBox2.Text;
            customer.ContactName = textBox3.Text;
            customer.Phone = textBox4.Text;
            var success = customer.InsertCustomer(customer);
            dataGridView1.Visible = true;
            dataGridView1.DataSource = customer.GetEmployees();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Customer Added Succesfully");
            }
            else
            {
                MessageBox.Show("Customer Addtion Failed");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            customer.CompanyName = textBox2.Text;
            customer.ContactName = textBox3.Text;
            customer.Phone = textBox4.Text;
            customer.CustomerID = textBox1.Text;
            dataGridView1.Visible = true;
            var success = customer.UpdateCustomer(customer);
            dataGridView1.DataSource = customer.GetEmployees();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Customer Updated Succesfully");
            }
            else
            {
                MessageBox.Show("Customer Updation Failed");
            }
        }

        public void ClearControls()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            customer.CustomerID = textBox1.Text;
            var success = customer.DeleteCustomer(customer);
            dataGridView1.Visible = true;
            dataGridView1.DataSource = customer.GetEmployees();
            if (success)
            {
                ClearControls();
                MessageBox.Show("Customer Deleted Succesfully");
            }
            else
            {
                MessageBox.Show("Customer Deletion Failed");
            }

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.Visible = true;
            var index = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearControls();

        }
    }
}
