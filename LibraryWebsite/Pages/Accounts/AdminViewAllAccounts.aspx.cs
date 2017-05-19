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
    public partial class AdminViewAllAccounts : System.Web.UI.Page
    {
        public DataTable dt = new DataTable();
        public string connectionString = @"Data Source=DESKTOP-LJMF3MS;Initial Catalog=Library;Integrated Security=True";

        public string selectStatement;
        public string deleteStatement;
        public string updateStatement;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                selectStatement = "select U_Id, U_Email, U_FirstName, U_LastName, U_Phone, U_Type from  Users order by U_Type;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
                {
                    try
                    {
                        // open connection, execute command, close connection
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        conn.Close();

                        List<string> emails = GetData(dt, 1);
                        emails = emails.Distinct().ToList<string>();
                        emails.Insert(0, string.Empty);
                        dropDownBoxEmails.DataSource = emails;
                        dropDownBoxEmails.DataBind();


                        dt.Columns["U_Id"].ColumnName = "ID";
                        dt.Columns["U_Email"].ColumnName = "Email";
                        dt.Columns["U_FirstName"].ColumnName = "First Name";
                        dt.Columns["U_LastName"].ColumnName = "Last Name";
                        dt.Columns["U_Phone"].ColumnName = "Phone";
                        dt.Columns["U_Type"].ColumnName = "Type";
                        gridview.DataSource = dt;
                        gridview.DataBind();

                    }
                    catch { }
                }
            }
        }

        protected void dropDownBoxEmails_SelectedIndexChanged(object sender, EventArgs e)
        {
            string email = dropDownBoxEmails.SelectedValue.ToString();
            if (email != string.Empty)
            {
                dt = new DataTable();
                selectStatement = "select U_Id, U_Email, U_FirstName, U_LastName, U_Phone, U_Type from  Users where U_Email=@email order by U_Type;";
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

                        dt.Columns["U_Id"].ColumnName = "ID";
                        dt.Columns["U_Email"].ColumnName = "Email";
                        dt.Columns["U_FirstName"].ColumnName = "First Name";
                        dt.Columns["U_LastName"].ColumnName = "Last Name";
                        dt.Columns["U_Phone"].ColumnName = "Phone";
                        dt.Columns["U_Type"].ColumnName = "Type";
                        gridview.DataSource = dt;
                        gridview.DataBind();
                    }
                    catch { }
                }
            }
            else
            {
                selectStatement = "select U_Id, U_Email, U_FirstName, U_LastName, U_Phone, U_Type from  Users order by U_Type;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
                {
                    try
                    {
                        // open connection, execute command, close connection
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        conn.Close();


                        dt.Columns["U_Id"].ColumnName = "ID";
                        dt.Columns["U_Email"].ColumnName = "Email";
                        dt.Columns["U_FirstName"].ColumnName = "First Name";
                        dt.Columns["U_LastName"].ColumnName = "Last Name";
                        dt.Columns["U_Phone"].ColumnName = "Phone";
                        dt.Columns["U_Type"].ColumnName = "Type";
                        gridview.DataSource = dt;
                        gridview.DataBind();
                    }
                    catch { }
                }
            }
        }

        protected void btnUpgrade_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(gridview.Rows[0].Cells[0].Text);


            updateStatement = "update Users set U_Type='Admin' where U_Id=@userID;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateStatement, conn))
            {
                try
                {
                    cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                    // open connection, execute command, close connection
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Response.Redirect("~/Pages/Accounts/AdminViewAllAccounts.aspx");
                }
                catch { }
            }



        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(gridview.Rows[0].Cells[0].Text);


            deleteStatement = "delete from Users where U_Id="+userID;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(deleteStatement, conn))
            {
                try
                {
                    //cmd.Parameters.Add("@U_Id", SqlDbType.Int).Value = userID;
                    // open connection, execute command, close connection
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Response.Redirect("~/Pages/Accounts/AdminViewAllAccounts.aspx");
                }
                catch 
                { 
                    
                }
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