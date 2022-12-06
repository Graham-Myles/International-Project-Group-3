using System.Data;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // bool valid = false;
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            SqlConnection con = new SqlConnection("Data Source=GRAHAMPC;Initial Catalog=appDB;Integrated Security=True");
            try
            {

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblAdmin WHERE UserName = '" + txtUserName.Text + "' AND password = '" + txtPassword.Text + "' ", con);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count == 1)
                {
                    // valid = true;
                    FrmMain m1 = new FrmMain();
                    m1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details");
                    txtUserName.Clear();
                    txtPassword.Clear();
                }

            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMain m1 = new FrmMain();
            m1.Show();
            this.Hide();
        }
    }
}
