using System.Data;
using System.Data.SqlClient;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Data Source=DESKTOP-0QJH2EI\SQLEXPRESS;Initial Catalog=test;Integrated Security=True

            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter the username!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter the password!");
            }
            else
            {

                try
                {

                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0QJH2EI\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("SELECT [admin_id],[name],[surname],[password] FROM [test].[dbo].[tblAdmin] WHERE [name] = @username AND [password] = @password", conn);
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Login successful!");


                        Main frmmain = new Main();
                        frmmain.Show();
                        Visible = false;

                    }
                    else
                    {
                        MessageBox.Show("Login or password incorrect!");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error -> " + ex.Message);
                }

            }
        }
    }
}