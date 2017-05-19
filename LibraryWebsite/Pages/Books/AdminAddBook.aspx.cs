using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace LibraryWebsite.Pages.Books
{
    public partial class AdminAddBook : System.Web.UI.Page
    {
        public DataTable dt = new DataTable();
        public string connectionString = @"Data Source=DESKTOP-LJMF3MS;Initial Catalog=Library;Integrated Security=True";

        public string selectStatement;
        public string insertStatement;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                selectStatement = "select distinct B_Category from  Books order by B_Category;";
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

                        dropDownBoxCategory.DataSource = GetData(dt, 0);
                        dropDownBoxCategory.DataBind();

                    }
                    catch { }
                }
            }
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {

            dropDownBoxCategory.Items.Insert(0,txtBoxNewCategory.Text);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string category= dropDownBoxCategory.Text;
            string title = txtBoxBookTitle.Text;
            string author = txtBoxBookAuthor.Text;

            insertStatement = "insert into Books(B_Category, B_Title, B_Author) values(@category, @title, @author);";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(insertStatement, conn))
            {
                try
                {

                    // set up the command's parameters
                    cmd.Parameters.Add("@category", SqlDbType.NVarChar).Value = category;
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;
                    cmd.Parameters.Add("@author", SqlDbType.NVarChar).Value = author;
                    // open connection, execute command, close connection
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch { }

            }

            Response.Redirect("~/Pages/Books/AdminAddBook.aspx");
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