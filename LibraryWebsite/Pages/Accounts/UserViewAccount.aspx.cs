using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace LibraryWebsite.Pages.Accounts
{
    public partial class UserViewAccount : System.Web.UI.Page
    {
        public DataTable dt = new DataTable();
        public string connectionString = @"Data Source=DESKTOP-LJMF3MS;Initial Catalog=Library;Integrated Security=True";

        public string selectStatement;
        public string deleteStatement;
        public string updateStatement;
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["Email"].ToString();
            if (!Page.IsPostBack)
            {

                selectStatement = "select U_Email, U_FirstName, U_LastName, U_Phone from  Users where U_Email=@email;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
                {
                    try
                    {
                        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                        // open connection, execute command, close connection
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        conn.Close();

                        lblEmail.Text = email;
                        lblFirstName.Text = GetData(dt, 1)[0];
                        lblLastName.Text = GetData(dt, 2)[0];
                        txtBoxPhone.Text = GetData(dt, 3)[0];

                    }
                    catch { }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string email = Session["Email"].ToString();
            string phone = txtBoxPhone.Text;
            string password = txtBoxPassword.Text;

            updateStatement = "update Users set U_Phone=@phone, U_Password=@password where U_Email=@email;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateStatement, conn))
            {
                try
                {
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                    // open connection, execute command, close connection
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Response.Redirect("~/Pages/Accounts/UserViewAccount.aspx");
                }
                catch { }
            }

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