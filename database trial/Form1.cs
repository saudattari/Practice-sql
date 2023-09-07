using Guna.UI2.WinForms;
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

namespace database_trial
{
    public partial class Form1 : Form
    {
        string address = "Data Source=DESKTOP-BTIF83O\\SQLEXPRESS;Initial Catalog=TestQuery;Integrated Security=True";
        string q = "SELECT *FROM Customers";
        public Form1()
        {
            InitializeComponent();
            show_data(q);
            metroComboBox1.SelectedIndex = 0;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlConnection con = new SqlConnection(address);
            //    con.Open();
            //    SqlCommand cmd = con.CreateCommand();
            //    cmd.CommandText = textBox1.Text;
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
            if(metroComboBox1.SelectedIndex == 1)
            {
                show_data(textBox1.Text);
            }
            else if(metroComboBox1.SelectedIndex == 2 || metroComboBox1.SelectedIndex == 3 || metroComboBox1.SelectedIndex == 4)
            {
                Update_data(textBox1.Text);
            }
        }
        private void show_data(string x)
        {
            try
            {
                string query = x;
                SqlConnection con = new SqlConnection(address);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Update_data(string x)
        {
            try
            {
                string query = x;
                SqlConnection con = new SqlConnection(address);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            show_data(q);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                metroComboBox1.Focus();
            }
        }

        private void metroComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            btn1.Focus();
        }

        private void btn1_Click_1(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 1)
            {
                show_data(textBox1.Text);
            }
            else if (metroComboBox1.SelectedIndex == 2 || metroComboBox1.SelectedIndex == 3 || metroComboBox1.SelectedIndex == 4)
            {
                Update_data(textBox1.Text);
            }
            else if(metroComboBox1.SelectedIndex == 5)
            {
                Alter_column(textBox1.Text);
            }
        }
        private void Alter_column(string x)
        {
            try
            {
                string query = x;
                SqlConnection con = new SqlConnection(address);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = x;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ok Added");
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            show_data(q);
        }
    }
}
