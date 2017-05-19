using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryWebsite.Pages.Return
{
    public partial class AdminReturnBook : System.Web.UI.Page
    {
        public DataTable dt = new DataTable();
        public string connectionString = @"Data Source=DESKTOP-LJMF3MS;Initial Catalog=Library;Integrated Security=True";

        public string selectStatement;
        public string insertStatement;
        public string updateStatement;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dt = new DataTable();
                selectStatement = "select L_Id, U_Email From((Loan inner join  Books on Loan.B_Id = Books.B_Id) inner join Users on Loan.U_Id = Users.U_ID) where L_ReturnedDate is null;";
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
                    }
                    catch { }
                }

                List<string> emails = GetData(dt, 1);
                emails = emails.Distinct().ToList<string>();
                emails.Insert(0, string.Empty);
                dropDownBoxEmail.DataSource = emails;
                dropDownBoxEmail.DataBind();



                #region GridView and update fined

                dt = new DataTable();
                selectStatement = "select L_Id, L_ReturnDate, L_Fined from Loan where L_Fined!=1;";
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
                    }
                    catch { }
                }

                foreach(DataRow x in dt.Rows)
                {
                    if(Convert.ToDateTime(x[1]) < System.DateTime.Now)
                    {
                        int loanID = Convert.ToInt32(x[0]);
                        updateStatement = "update Loan set L_Fined=1 where L_Id=@loanID;";
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        using (SqlCommand cmd = new SqlCommand(updateStatement, conn))
                        {
                            try
                            {
                                // set up the command's parameters
                                cmd.Parameters.Add("@loanID", SqlDbType.Int).Value = loanID;
                                // open connection, execute command, close connection
                                conn.Open();
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                int result = cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            catch { }
                        }
                    }

                }

                dt = new DataTable();
                selectStatement = "select L_Id, B_Title, U_Email, L_BorrowDate, L_ReturnDate, L_Fined, L_ReturnedDate From((Loan inner join  Books on Loan.B_Id = Books.B_Id) inner join Users on Loan.U_Id = Users.U_ID ) where L_ReturnedDate is null;";
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
                    }
                    catch { }
                }

                dt.Columns.Remove("L_ReturnedDate");
                dt.Columns["L_Id"].ColumnName = "ID";
                dt.Columns["B_Title"].ColumnName = "Book Title";
                dt.Columns["U_Email"].ColumnName = "User Email";
                dt.Columns["L_BorrowDate"].ColumnName = "Borrow Date";
                dt.Columns["L_ReturnDate"].ColumnName = "Return Date";
                dt.Columns["L_Fined"].ColumnName = "Fined";
                gridview.DataSource = dt;
                gridview.DataBind();

                #endregion

            }
        }



        protected void dropDownBoxEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropDownBoxEmail.Text != string.Empty)
            {
                dt = new DataTable();
                selectStatement = "select L_Id, B_Title, U_Email, L_BorrowDate, L_ReturnDate, L_Fined, L_ReturnedDate From((Loan inner join  Books on Loan.B_Id = Books.B_Id) inner join Users on Loan.U_Id = Users.U_ID) where U_Email=@email and L_ReturnedDate is null;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
                {
                    try
                    {
                        // set up the command's parameters
                        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = dropDownBoxEmail.Text;
                        // open connection, execute command, close connection
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        conn.Close();
                    }
                    catch { }
                }

                List<string> books = GetData(dt, 1);
                books.Insert(0, string.Empty);
                dropDownBoxBookTitle.DataSource = books;
                dropDownBoxBookTitle.DataBind();

                dt.Columns.Remove("L_ReturnedDate");
                dt.Columns["L_Id"].ColumnName = "ID";
                dt.Columns["B_Title"].ColumnName = "Book Title";
                dt.Columns["U_Email"].ColumnName = "User Email";
                dt.Columns["L_BorrowDate"].ColumnName = "Borrow Date";
                dt.Columns["L_ReturnDate"].ColumnName = "Return Date";
                dt.Columns["L_Fined"].ColumnName = "Fined";
                gridview.DataSource = dt;
                gridview.DataBind();

            }
            else
            {
                dt = new DataTable();
                selectStatement = "select L_Id, B_Title, U_Email, L_BorrowDate, L_ReturnDate, L_Fined, L_ReturnedDate From((Loan inner join  Books on Loan.B_Id = Books.B_Id) inner join Users on Loan.U_Id = Users.U_ID) where L_ReturnedDate is null;";
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
                    }
                    catch { }
                }

                dropDownBoxBookTitle.Items.Clear();
                dt.Columns.Remove("L_ReturnedDate");
                dt.Columns["L_Id"].ColumnName = "ID";
                dt.Columns["B_Title"].ColumnName = "Book Title";
                dt.Columns["U_Email"].ColumnName = "User Email";
                dt.Columns["L_BorrowDate"].ColumnName = "Borrow Date";
                dt.Columns["L_ReturnDate"].ColumnName = "Return Date";
                dt.Columns["L_Fined"].ColumnName = "Fined";
                gridview.DataSource = dt;
                gridview.DataBind();
            }


        }

        protected void dropDownBoxBookTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropDownBoxBookTitle.Text != string.Empty)
            {
                dt = new DataTable();
                selectStatement = "select L_Id, B_Title, U_Email, L_BorrowDate, L_ReturnDate, L_Fined, L_ReturnedDate From((Loan inner join  Books on Loan.B_Id = Books.B_Id) inner join Users on Loan.U_Id = Users.U_ID) where U_Email=@email and B_Title=@title and L_ReturnedDate is null ;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
                {
                    try
                    {
                        // set up the command's parameters
                        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = dropDownBoxEmail.Text;
                        cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = dropDownBoxBookTitle.Text;
                        // open connection, execute command, close connection
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        conn.Close();
                    }
                    catch { }
                }
                dt.Columns.Remove("L_ReturnedDate");
                dt.Columns["L_Id"].ColumnName = "ID";
                dt.Columns["B_Title"].ColumnName = "Book Title";
                dt.Columns["U_Email"].ColumnName = "User Email";
                dt.Columns["L_BorrowDate"].ColumnName = "Borrow Date";
                dt.Columns["L_ReturnDate"].ColumnName = "Return Date";
                dt.Columns["L_Fined"].ColumnName = "Fined";
                gridview.DataSource = dt;
                gridview.DataBind();
            }
            else
            {
                dt = new DataTable();
                selectStatement = "select L_Id, B_Title, U_Email, L_BorrowDate, L_ReturnDate, L_Fined, L_ReturnedDate From((Loan inner join  Books on Loan.B_Id = Books.B_Id) inner join Users on Loan.U_Id = Users.U_ID) where U_Email=@email and L_ReturnedDate is null;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
                {
                    try
                    {
                        // set up the command's parameters
                        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = dropDownBoxEmail.Text;
                        // open connection, execute command, close connection
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        conn.Close();
                    }
                    catch { }
                }

                List<string> books = GetData(dt, 1);
                books.Insert(0, string.Empty);
                dropDownBoxBookTitle.DataSource = books;
                dropDownBoxBookTitle.DataBind();

                dt.Columns.Remove("L_ReturnedDate");
                dt.Columns["L_Id"].ColumnName = "ID";
                dt.Columns["B_Title"].ColumnName = "Book Title";
                dt.Columns["U_Email"].ColumnName = "User Email";
                dt.Columns["L_BorrowDate"].ColumnName = "Borrow Date";
                dt.Columns["L_ReturnDate"].ColumnName = "Return Date";
                dt.Columns["L_Fined"].ColumnName = "Fined";
                gridview.DataSource = dt;
                gridview.DataBind();
            }
        }


        protected void btnReturn_Click(object sender, EventArgs e)
        {
            int loanID = Convert.ToInt32(gridview.Rows[0].Cells[0].Text);
            DateTime nowDate = System.DateTime.Now;

            updateStatement = "update Loan set L_ReturnedDate=@nowDate where L_Id=@loanID;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateStatement, conn))
            {
                try
                {

                    // set up the command's parameters
                    cmd.Parameters.Add("@nowDate", SqlDbType.Date).Value = nowDate;
                    cmd.Parameters.Add("@loanID", SqlDbType.Int).Value = loanID;

                    // open connection, execute command, close connection
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch { }

            }

            dt = new DataTable();
            selectStatement = "select B_Id From Loan where L_Id=@loanID;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                try
                {
                    // set up the command's parameters
                    cmd.Parameters.Add("@loanID", SqlDbType.Int).Value = loanID;
                    // open connection, execute command, close connection
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    conn.Close();
                }
                catch { }
            }

            int bookID = Convert.ToInt32(GetData(dt, 0)[0]);
            updateStatement = "update Books set B_Status=@bookStatus where B_Id=@bookID;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateStatement, conn))
            {
                try
                {

                    // set up the command's parameters
                    cmd.Parameters.Add("@bookStatus", SqlDbType.Bit).Value = true;
                    cmd.Parameters.Add("@bookID", SqlDbType.Int).Value = bookID;
                    // open connection, execute command, close connection
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch { }

            }

            Response.Redirect("~/Pages/Return/AdminReturnBook.aspx");
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