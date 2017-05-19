using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace LibraryWebsite.Pages.Borrow
{
    public partial class WebForm1 : System.Web.UI.Page
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


                        dropDownBoxCategory.DataSource = dt;
                        dropDownBoxCategory.DataValueField = "B_Category";
                        dropDownBoxCategory.DataBind();
                        
                        conn.Close();
                    }
                    catch
                    {

                    }

                }


             dt = new DataTable();
             selectStatement = "select distinct B_Title from  Books where (B_Category=@Category and B_Status != 0) order by B_Title;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                try
                {
                    cmd.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = dropDownBoxCategory.SelectedValue.ToString();
                    // open connection, execute command, close connection
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    dropDownBoxBookTitle.DataSource = dt;
                    dropDownBoxBookTitle.DataValueField = "B_Title";
                    dropDownBoxBookTitle.DataBind();

                    conn.Close();
                }
                catch
                {

                }

            }
                selectStatement = "select distinct U_Email from  Users order by U_Email;";
                dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
                {
                    try
                    {
                        // open connection, execute command, close connection
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        dropDownBoxEmails.DataSource = dt;
                        dropDownBoxEmails.DataValueField = "U_Email";
                        dropDownBoxEmails.DataBind();

                        conn.Close();
                    }
                    catch
                    {

                    }
                }
            }
            
        }

        protected void dropDownBoxCategorySelectionChanged(object sender, EventArgs e)
        {
            dt = new DataTable();
            string connectionString = @"Data Source=(LocalDB)\v11.0; AttachDbFilename=|DataDirectory|\Library.mdf ;Integrated Security=True";
            selectStatement = "select B_Category from  Books;";
            selectStatement = "select distinct B_Title from  Books where (B_Category=@Category and B_Status != 0) order by B_Title;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                try
                {
                    cmd.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = dropDownBoxCategory.SelectedValue.ToString();
                    // open connection, execute command, close connection
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    dropDownBoxBookTitle.DataSource = dt;
                    dropDownBoxBookTitle.DataValueField = "B_Title";
                    dropDownBoxBookTitle.DataBind();

                    conn.Close();
                }
                catch
                {

                }
            }
        }

        protected void btnBorrowClick(object sender, EventArgs e)
        {
            string email = dropDownBoxEmails.Text;
            string category = dropDownBoxCategory.Text;
            string title = dropDownBoxBookTitle.Text;
            DateTime borrowDate =  System.DateTime.Now;
            string borrowPeriod = txtBoxBorrowPeriod.Text;
            string password = txtBoxPassword.Text;
            int userID;
            int bookID; 


           
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



             if (borrowPeriod != null && password != null)
             {
                 if (dt.Rows.Count == 0)
                 {
                     //show error

                 }

                 else
                 {
                     userID = Convert.ToInt32(GetData(dt)[0]);

                     dt = new DataTable();
                     selectStatement = "select B_Id from  Books where B_Category=@category and B_Title=@title;";
                     using (SqlConnection conn = new SqlConnection(connectionString))
                     using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
                     {
                         try
                         {
                             // set up the command's parameters
                             cmd.Parameters.Add("@category", SqlDbType.VarChar).Value = category;
                             cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
                             // open connection, execute command, close connection
                             conn.Open();
                             SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                             adapter.Fill(dt);
                             conn.Close();
                         }
                         catch
                         {

                         }
                     }

                     bookID = Convert.ToInt32(GetData(dt)[0]);


                     insertStatement = "insert into Loan(U_Id, B_Id, L_BorrowDate, L_ReturnDate, L_Fined) values(@userID, @bookID, @borrowDate, @returnDate, @fined);";

                     using (SqlConnection conn = new SqlConnection(connectionString))
                     using (SqlCommand cmd = new SqlCommand(insertStatement, conn))
                     {
                         try
                         {

                             // set up the command's parameters
                             cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                             cmd.Parameters.Add("@bookID", SqlDbType.Int).Value = bookID;
                             cmd.Parameters.Add("@borrowDate", SqlDbType.Date).Value = borrowDate;
                             cmd.Parameters.Add("@returnDate", SqlDbType.Date).Value = borrowDate.AddDays(Convert.ToInt32(borrowPeriod)).ToString(); ;
                             cmd.Parameters.Add("@fined", SqlDbType.BigInt).Value = false;
                             // open connection, execute command, close connection
                             conn.Open();
                             int result = cmd.ExecuteNonQuery();
                             conn.Close();
                         }
                         catch { }

                     }

                     updateStatement = "update Books set B_Status=@status where B_Id=@bookID;";

                     using (SqlConnection conn = new SqlConnection(connectionString))
                     using (SqlCommand cmd = new SqlCommand(updateStatement, conn))
                     {
                         try
                         {

                             // set up the command's parameters
                             cmd.Parameters.Add("@status", SqlDbType.Bit).Value = false;
                             cmd.Parameters.Add("@bookID", SqlDbType.Int).Value = bookID;

                             // open connection, execute command, close connection
                             conn.Open();
                             int result = cmd.ExecuteNonQuery();
                             conn.Close();
                         }
                         catch { }

                     }

                     Response.Redirect("~/Pages/Borrow/AdminBorrowBook.aspx");
                 }
             }
               
           
        }

        private List<string> GetData(DataTable dt)
        {
            List<string> y = new List<string>();
            foreach (DataRow x in dt.Rows)
                y.Add(x[0].ToString());
            return y;
        }

        protected void password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            dt = new DataTable();
            selectStatement = "select U_Id from  Users where U_Email=@email and U_Password=@password;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(selectStatement, conn))
            {
                try
                {
                    // set up the command's parameters
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = dropDownBoxEmails.Text;
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
    }
}