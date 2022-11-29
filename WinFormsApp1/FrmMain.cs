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
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=test;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from [Highest Heartrate],[Lowest Heartrate],[Most Steps],[Least Steps]", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
               
            

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Reader.Read();
                MessageBox.Show("Read success");
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=test;Integrated Security=True"))
                {
              
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Select * from tblEmpRecord", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView2.DataSource = dt;
                        cmd.ExecuteNonQuery();
                        con.Close();
                }
            }
            catch
            {
                MessageBox.Show("read uncessful");
            }
        }
    }
    }

