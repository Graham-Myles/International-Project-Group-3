using Microsoft.VisualBasic.FileIO;
using System;
using System.Data;
using System.Data.SqlClient;

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
            SqlConnection con = new SqlConnection("Data Source=GRAHAMPC;Initial Catalog=appDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblEmpRecord where employee_id =@id", con);
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
            SqlConnection con = new SqlConnection("Data Source=GRAHAMPC;Initial Catalog=appDB;Integrated Security=True");
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
            SqlConnection con = new SqlConnection("Data Source=GRAHAMPC;Initial Catalog=appDB;Integrated Security=True");
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
            SqlConnection con = new SqlConnection("Data Source=GRAHAMPC;Initial Catalog=appDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblUser", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
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
                using (SqlConnection con = new SqlConnection("Data Source=GRAHAMPC;Initial Catalog=appDB;Integrated Security=True"))
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from tblEmpRecord", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("read uncessful");
            }
        }

        private void btnStats_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                List<String[]> fileContent = new List<string[]>();

                using (FileStream reader = File.OpenRead(@"C:\Users\graam\Desktop\StreamCapture\CoolTerm Capture 2022-12-02 14-43-51.txt")) // mind the encoding - UTF8
                using (TextFieldParser parser = new TextFieldParser(reader))
                {
                    parser.Delimiters = new[] { "," };
                    while (!parser.EndOfData)
                    {
                        string[] line = parser.ReadFields();
                        fileContent.Add(line);

                        DataTable dt = new DataTable();
                        // add columns to datatable
                        dt.Columns.Add("Gas detection", typeof(int));
                        dt.Columns.Add("Steps", typeof(int));
                        dt.Columns.Add("Heart rate", typeof(int));
                        dataGridView1.DataSource = dt;

                        DataRow dr = dt.NewRow();

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dr[i] = line[i];
                        }
                        dt.Rows.Add(dr);

                        //foreach (var array in line)
                        //{
                        //    DataRow dr = dt.NewRow();
                        //    dr["Gas detection"] = array.
                        //    dt.Rows.Add(array);
                        //}
                        //for (int i = 0; i < line.Length; i++)
                        //{
                        //    for (int j = 0; j <= 3; j++)
                        //    {
                        //        dt.Rows.Add(line);
                        //    }
                        //}
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

