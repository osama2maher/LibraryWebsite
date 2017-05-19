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
    public partial class Login : Page
    {
        public DataTable dt = new DataTable();
        public string connectionString = @"Data Source=DESKTOP-LJMF3MS;Initial Catalog=Library;Integrated Security=True";
        public string selectStatement;
        public string insertStatement;
        public string updateStatement;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn(object sender, EventArgs e)
        {
            string email = Email.Text;
            string password = Password.Text;


            dt = new DataTable();
            selectStatement = "select U_Id, U_Type from  Users where U_Email=@email and U_Password=@password;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                try
                {
                    // set up the command's parameters
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                    // open connection, execute command, close connection
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    conn.Close();
                }
                catch { }
            }

            if (dt.Rows.Count != 0)
            {
                string userType = GetData(dt,1)[0].Trim();
                if (userType == "Admin")
                {
                    Session["Email"] = email;
                    Session["Type"] = userType;
                    Response.Redirect("~/Pages/Main/AdminMain.aspx");
                }
                if (userType == "User")
                {
                    Session["Email"] = email;
                    Session["Type"] = userType;
                    Response.Redirect("~/Pages/Main/UserMain.aspx");
                }
            }



        }

        protected void passwordValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string email = Email.Text;
            string password = Password.Text;

            dt = new DataTable();
            selectStatement = "select U_Id from  Users where U_Email=@email and U_Password=@password;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                try
                {
                    // set up the command's parameters
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                    // open connection, execute command, close connection
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    conn.Close();
                }
                catch { }
            }

            if (dt.Rows.Count == 0)
                args.IsValid = false;
        }

        protected void emailValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            string email = Email.Text;
            string password = Password.Text;

            dt = new DataTable();
            selectStatement = "select U_Id from  Users where U_Email=@email and U_Password=@password;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                try
                {
                    // set up the command's parameters
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                    // open connection, execute command, close connection
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    conn.Close();
                }
                catch { }
            }
            if (dt.Rows.Count == 0)
                args.IsValid = false;
        }

        private List<string> GetData(DataTable dt, int index)
        {
            List<string> y = new List<string>();
            foreach (DataRow x in dt.Rows)
                y.Add(x[index].ToString());
            return y;
        }
    }
}