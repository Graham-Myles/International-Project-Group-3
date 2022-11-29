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

namespace WinFormsApp1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        { //search tblEmployeeRecord
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=test;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblEmpRecord where employee_id =@id",con);
            cmd.Parameters.AddWithValue("@id", int.Parse(txtEmpID.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        { //all tblEmployeeRecord
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=test;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblEmpRecord", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        { //specific employee
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=test;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblUser where emp_id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(txtEmpID.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //all employee
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=test;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblUser", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=test;Integrated Security=True;MultipleActiveResultSets=true"))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from [Highest Heartrate]", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("select * from [Lowest Heartrate]", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    dataGridView2.DataSource = dt1;
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("select * from [Most Steps]", con);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    dataGridView2.DataSource = dt2;
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd3 = new SqlCommand("select * from [Least Steps]", con);
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    dataGridView2.DataSource = dt3;
                    cmd3.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
               
            

        }
    }
    }

