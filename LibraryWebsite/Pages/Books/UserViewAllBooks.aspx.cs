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
    public partial class UserViewAllBooks : System.Web.UI.Page
    {
        public DataTable dt = new DataTable();
        public string connectionString = @"Data Source=DESKTOP-LJMF3MS;Initial Catalog=Library;Integrated Security=True";

        public string selectStatement;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                selectStatement = "select * from  Books;";
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

                        List<string> categories = GetData(dt, 2);
                        categories = categories.Distinct().ToList<string>();
                        categories.Insert(0, string.Empty);
                        dropDownBoxCategory.DataSource = categories;
                        dropDownBoxCategory.DataBind();


                        dt.Columns["B_Id"].ColumnName = "ID";
                        dt.Columns["B_Title"].ColumnName = "Book Title";
                        dt.Columns["B_Category"].ColumnName = "Category";
                        dt.Columns["B_Author"].ColumnName = "Author";
                        dt.Columns["B_Status"].ColumnName = "Available ";
                        gridview.DataSource = dt;
                        gridview.DataBind();

                    }
                    catch { }
                }
            }
        }

        protected void dropDownBoxCategorySelectionChanged(object sender, EventArgs e)
        {
            string category = dropDownBoxCategory.Text;
            if (category != string.Empty)
            {
                dt = new DataTable();
                selectStatement = "select * from  Books where B_Category=@Category order by B_Title;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
                {
                    try
                    {
                        cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = category;
                        // open connection, execute command, close connection
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        conn.Close();

                        List<string> books = GetData(dt, 1);
                        books = books.Distinct().ToList<string>();
                        books.Insert(0, string.Empty);
                        dropDownBoxBookTitle.DataSource = books;
                        dropDownBoxBookTitle.DataBind();

                        dt.Columns["B_Id"].ColumnName = "ID";
                        dt.Columns["B_Title"].ColumnName = "Book Title";
                        dt.Columns["B_Category"].ColumnName = "Category";
                        dt.Columns["B_Author"].ColumnName = "Author";
                        dt.Columns["B_Status"].ColumnName = "Available ";
                        gridview.DataSource = dt;
                        gridview.DataBind();
                    }
                    catch { }
                }
            }
            else
            {
                selectStatement = "select * from  Books;";
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
                        dropDownBoxBookTitle.Items.Clear();


                        dt.Columns["B_Id"].ColumnName = "ID";
                        dt.Columns["B_Title"].ColumnName = "Book Title";
                        dt.Columns["B_Category"].ColumnName = "Category";
                        dt.Columns["B_Author"].ColumnName = "Author";
                        dt.Columns["B_Status"].ColumnName = "Available ";
                        gridview.DataSource = dt;
                        gridview.DataBind();
                    }
                    catch { }
                }
            }

        }

        protected void dropDownBoxBookTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = dropDownBoxCategory.SelectedValue.ToString();
            string book = dropDownBoxBookTitle.SelectedValue.ToString();
            if (book != string.Empty)
            {
                dt = new DataTable();
                selectStatement = "select * from  Books where B_Title=@book;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
                {
                    try
                    {
                        cmd.Parameters.Add("@book", SqlDbType.VarChar).Value = book;
                        // open connection, execute command, close connection
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        conn.Close();

                        dt.Columns["B_Id"].ColumnName = "ID";
                        dt.Columns["B_Title"].ColumnName = "Book Title";
                        dt.Columns["B_Category"].ColumnName = "Category";
                        dt.Columns["B_Author"].ColumnName = "Author";
                        dt.Columns["B_Status"].ColumnName = "Available ";
                        gridview.DataSource = dt;
                        gridview.DataBind();
                    }
                    catch { }
                }
            }
            else
            {
                dt = new DataTable();
                selectStatement = "select * from  Books where B_Category=@Category order by B_Title;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
                {
                    try
                    {
                        cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = category;
                        // open connection, execute command, close connection
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        conn.Close();

                        List<string> books = GetData(dt, 1);
                        books = books.Distinct().ToList<string>();
                        books.Insert(0, string.Empty);
                        dropDownBoxBookTitle.DataSource = books;
                        dropDownBoxBookTitle.DataBind();

                        dt.Columns["B_Id"].ColumnName = "ID";
                        dt.Columns["B_Title"].ColumnName = "Book Title";
                        dt.Columns["B_Category"].ColumnName = "Category";
                        dt.Columns["B_Author"].ColumnName = "Author";
                        dt.Columns["B_Status"].ColumnName = "Available ";
                        gridview.DataSource = dt;
                        gridview.DataBind();
                    }
                    catch { }
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