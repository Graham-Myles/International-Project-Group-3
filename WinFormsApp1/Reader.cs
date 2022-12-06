using System.Data.SqlClient;

namespace WinFormsApp1
{
    internal class Reader
    {
        public static void Read()
        {
            string line;

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-C2RP5S6;Initial Catalog=test;Integrated Security=True"))
            {
                con.Open();
                using (StreamReader file = new StreamReader(@"Downloads/WorkSmartDataCapture.txt"))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');

                        SqlCommand cmd = new SqlCommand("INSERT INTO AppDB(Gas_Status, Steps, Heartrate) VALUES (@Gas_Status, @Steps, @HeartRate)", con);
                        cmd.Parameters.AddWithValue("@Gas_Status", fields[0].ToString());
                        cmd.Parameters.AddWithValue("@Steps", fields[1].ToString());
                        cmd.Parameters.AddWithValue("@Heartrate", fields[2].ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}
