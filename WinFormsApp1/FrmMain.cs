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
            dataGridView2.DataSource = dt;
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
            dataGridView2.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=test;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd_Min_Hrte = new SqlCommand("select MIN(HeartRate) AS LowestHeartrate from tblEmpRecord", con);
                SqlDataReader rd1 = cmd_Min_Hrte.ExecuteReader();

                SqlCommand cmd_high_Hrte = new SqlCommand("select MAX(HeartRate) AS HighestHeartRate from tblEmpRecord", con);
                SqlDataReader rd2 = cmd_high_Hrte.ExecuteReader();

                SqlCommand cmd_Min_STP = new SqlCommand("select MIN(Steps) AS LeastSteps from tblEmpRecord", con);
                SqlDataReader rd3 = cmd_Min_STP.ExecuteReader();

                SqlCommand cmd_high_STP = new SqlCommand("select MAX(Steps) AS MostSteps from tblEmpRecord", con);
                SqlDataReader rd4 = cmd_high_STP.ExecuteReader();

                
                txtLowHrte.Text = rd1[0].ToString();
                txtHighHrte.Text = rd1[0].ToString();
                txtLeastST.Text = rd3[0].ToString();
                txtMostST.Text = rd3[0].ToString();
                    
                

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
    }

