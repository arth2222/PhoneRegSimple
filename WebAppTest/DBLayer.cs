using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppTest
{
    public class DBLayer
    {
        public DataTable GetPersonsByLastName(string lastName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PhoneRegConnString"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from Person where LastName = @lastName", conn);
                cmd.CommandType = CommandType.Text;

                //params here
                cmd.Parameters.Add("@lastName", SqlDbType.NVarChar, 50).Value = lastName;

                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conn.Close();
            }
            return dt;
        }
    }
}