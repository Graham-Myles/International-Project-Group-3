﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Reader
    {
        public static void Read()
        {
            /*string line;

            using (SqlConnection con = new SqlConnection(@"Data Source=GRAHAMPC;Initial Catalog=appDB;Integrated Security=True"))
            {
                con.Open();
                using (StreamReader file = new StreamReader(@"Desktop/WorkSmartDataCapture.txt"))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');

                        SqlCommand cmd = new SqlCommand("INSERT INTO appDB(Gas_Status, Steps, Heartrate) VALUES (@Gas_Status, @Steps, @HeartRate)", con);
                        cmd.Parameters.AddWithValue("@Gas_Status", fields[0].ToString());
                        cmd.Parameters.AddWithValue("@Steps", fields[1].ToString());
                        cmd.Parameters.AddWithValue("@Heartrate", fields[2].ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
            }*/
        }
    }
}
