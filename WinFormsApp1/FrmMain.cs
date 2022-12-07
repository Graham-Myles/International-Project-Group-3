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
                DataTable dt = new DataTable();
                // add columns to datatable
                dt.Columns.Add("Gas detection", typeof(string));
                dt.Columns.Add("Steps", typeof(string));
                dt.Columns.Add("Heart rate", typeof(string));
                dataGridView1.DataSource = dt;

                string text = File.ReadAllText(@"C:\Users\graam\Desktop\StreamCapture\CoolTerm Capture 2022-12-02 14-43-51.txt");
                string[] splitter = text.Split(',');
                
                int heartrate;
                int avg = 0;

                for (int i = 0; i < splitter.Length-1; i++) //loop for inputting values into datatable and fact checking them
                {
                    if (i % 3 == 0)
                    {
                        dt.Rows.Add(splitter[i], splitter[i+1], splitter[i+2]); //adds data to datatable

                    }

                }
               // heartrate = Convert.ToInt32(dt.Compute("AVR(Heart rate)", ""));
                //for (int j = 0; j < dt.Rows.Count; j++)
                //{
                    //heartrate = Convert.ToInt32(dt.Rows[j]["Heart rate"]);
                    
                    //MessageBox.Show(heartrate + "");
                    //if (avg>heartInt)
                    //{
                    //    MessageBox.Show(avg + "");
                    //}
                    //else if (avg<heartInt)
                    //{
                    //    MessageBox.Show(avg + "");
                    //}
               //}




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

