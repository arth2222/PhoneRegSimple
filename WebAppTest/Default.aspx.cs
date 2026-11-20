using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTest
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void ButtonSearchLastName_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt=GetPersonsByLastName(TextBoxLastNameSearch.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

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

        public void GetAllPersons()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PhoneRegConnString"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                //henter kun fra en tabell, så får ikke med telefonnummer. Fiks dette
                SqlCommand cmd = new SqlCommand("SELECT * from Person", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conn.Close();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }







        protected void ButtonInsertPerson_Click1(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PhoneRegConnString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Person (FirstName, LastName, Address, PostalCode)
                       VALUES (@Firstname, @Lastname, @Address, @Postalcode)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Firstname", TextBoxFirstName.Text);
                    cmd.Parameters.AddWithValue("@Lastname", TextBoxLastName.Text);
                    cmd.Parameters.AddWithValue("@Address", TextBoxAddress.Text);
                    cmd.Parameters.AddWithValue("@Postalcode", TextBoxPostalCode.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void ButtonShowAllPersons_Click(object sender, EventArgs e)
        {
            //kalle på metoden som henter alt i tabellen og binder til GridView
            GetAllPersons();
        }
    }//end class


}