using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using LibraryWebsite.Models;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace LibraryWebsite.Account
{
    public partial class Register : Page
    {
        public DataTable dt = new DataTable();
        public string connectionString = @"Data Source=DESKTOP-LJMF3MS;Initial Catalog=Library;Integrated Security=True";
        public string selectStatement;
        public string insertStatement;
        public string updateStatement;
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string email = txtBoxEmail.Text;
            string firstName = txtBoxFirstName.Text;
            string lastName = txtBoxLastName.Text;
            string phone = txtBoxPhone.Text;
            string pass = txtBoxPassword.Text;
            string type = "User";

            dt = new DataTable();
            selectStatement = "select U_Id from  Users where U_Email=@email;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                try
                {
                    // set up the command's parameters
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    // open connection, execute command, close connection
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    conn.Close();
                }
                catch { }
            }

            if(dt.Rows.Count == 0)
            {
                insertStatement = "insert into Users(U_Email, U_FirstName, U_LastName, U_Type, U_Phone, U_Password) values(@email, @firstName, @lastName, @type, @phone, @password);";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(insertStatement, conn))
                {
                    try
                    {

                        // set up the command's parameters
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                        cmd.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = firstName;
                        cmd.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = lastName;
                        cmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                        cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = pass;
                        // open connection, execute command, close connection
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch { }

                }

                Session["Email"] = email;
                Response.Redirect("~/Pages/Main/UserMain.aspx");
            }
                
        }

        private List<string> GetData(DataTable dt, int index)
        {
            List<string> y = new List<string>();
            foreach (DataRow x in dt.Rows)
                y.Add(x[index].ToString());
            return y;
        }

        protected void emailValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
                        string email = txtBoxEmail.Text;
 

            dt = new DataTable();
            selectStatement = "select U_Id from  Users where U_Email=@email;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                try
                {
                    // set up the command's parameters
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    // open connection, execute command, close connection
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    conn.Close();
                }
                catch { }
            }

            if (dt.Rows.Count != 0)
                args.IsValid = false;
        }
    }

}