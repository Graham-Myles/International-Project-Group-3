using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace WinFormsApp1
{
    public partial class WorkSmart : Form
    {
        public WorkSmart()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        { //search tblEmployeeRecord
            SqlConnection con = new SqlConnection("Data Source=GRAHAMPC;Initial Catalog=appDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblEmpRecord where Record_id =@id", con);
            cmd.Parameters.AddWithValue("@id", txtempRecords.Text);
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
            cmd.Parameters.AddWithValue("@id", txtEmpID.Text);
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

        public int avgHeart = 0;
        public int stepsTotal = 0;
        public string gasVal = "Not Detected";

        public void btnStats_Click_1(object sender, EventArgs e)
        {
            string employee = txtEmpID.Text;
            if (employee == "100")
            {               
                try
                {
                    DataTable dt = new DataTable();
                    // add columns to datatable
                    dt.Columns.Add("Gas detection", typeof(System.Int32));
                    dt.Columns.Add("Steps", typeof(System.Int32));
                    dt.Columns.Add("Heart rate", typeof(System.Int32));
                    dataGridView1.DataSource = dt;

                    FileStream file = new FileStream(@"C:\Users\graam\Desktop\StreamCapture\CoolTerm Capture 2022-12-02 14-43-51.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader text = new StreamReader(file);
                    string[] splitter = text.ReadToEnd().Split(",");




                    for (int i = 0; i < splitter.Length - 1; i++) //loop for inputting values into datatable and fact checking them
                    {
                        if (i % 3 == 0)
                        {
                            dt.Rows.Add(splitter[i], splitter[i + 1], splitter[i + 2]); //adds data to datatable

                        }
                        if (splitter[i].Equals("1"))
                        {
                            gasVal = "Gas Detected";
                            MessageBox.Show(gasVal);
                        }

                        avgHeart = Convert.ToInt32(dt.Compute("AVG([Heart rate])", ""));

                        if (avgHeart >= avgHeart * 2)
                        {
                            MessageBox.Show("Heart rate spiked");
                        }
                        else if (avgHeart <= avgHeart / 2)
                        {
                            MessageBox.Show("Heart rate dropped");
                        }
                        this.Update();

                        stepsTotal = Convert.ToInt32(dt.Compute("SUM([Steps])", ""));
                    }
                   



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int empID = 100;
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            SqlConnection con = new SqlConnection("Data Source=GRAHAMPC;Initial Catalog=appDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tblEmpRecord (Employee_id, HeartRate, Steps, time_taken, Gas_Status) VALUES (@id, @hr, @st, @tm, @gs)", con);

            cmd.Parameters.AddWithValue("@id", empID);
            cmd.Parameters.AddWithValue("@hr", avgHeart);
            cmd.Parameters.AddWithValue("@st", stepsTotal);
            cmd.Parameters.AddWithValue("@tm", Convert.ToDateTime(time));
            cmd.Parameters.AddWithValue("@gs", gasVal);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

