using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryWebsite.Pages.Report
{

    public partial class AdminReports : System.Web.UI.Page
    {
        public DataTable dt = new DataTable();
        public string connectionString = @"Data Source=DESKTOP-LJMF3MS;Initial Catalog=Library;Integrated Security=True";

        public string selectStatement;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dt = new DataTable();
                selectStatement = "SELECT COUNT(*) FROM Users where U_Type='User';";
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
                int usersNumber = Convert.ToInt32(GetData(dt, 0)[0]);

                dt = new DataTable();
                selectStatement = "SELECT COUNT(*) FROM Users where U_Type='Admin';";
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
                int adminsNumber = Convert.ToInt32(GetData(dt, 0)[0]);

                dt = new DataTable();
                selectStatement = "SELECT COUNT(distinct B_Title) FROM Books;";
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
                int booksNumber = Convert.ToInt32(GetData(dt, 0)[0]);

                dt = new DataTable();
                selectStatement = "SELECT COUNT(distinct B_Category) FROM Books;";
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
                int categoriesNumber = Convert.ToInt32(GetData(dt, 0)[0]);

                dt = new DataTable();
                selectStatement = "SELECT COUNT(L_Id) FROM Loan";
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
                int borrowedNumber = Convert.ToInt32(GetData(dt, 0)[0]);

                dt = new DataTable();
                selectStatement = "SELECT COUNT(L_Id) FROM Loan where L_ReturnedDate is null";
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
                int borrowingNumber = Convert.ToInt32(GetData(dt, 0)[0]);


                dt = new DataTable();
                selectStatement = "SELECT COUNT(L_Id) FROM Loan where L_ReturnedDate is not null;";
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
                int returnedNumber = Convert.ToInt32(GetData(dt, 0)[0]);

                dt = new DataTable();
                selectStatement = "SELECT COUNT(L_Id) FROM Loan where L_Fined=1;";
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
                int finedNumber = Convert.ToInt32(GetData(dt, 0)[0]);

                lblUsersNumber.Text = usersNumber.ToString();
                lblBooksNumber.Text = booksNumber.ToString();
                lblBorrowedNumber.Text = borrowedNumber.ToString();
                lblReturnedNumber.Text = returnedNumber.ToString();
                lblAdminNumber.Text = adminsNumber.ToString();
                lblBookCategoriesNumber.Text = categoriesNumber.ToString();
                lblCurrentlyBorrowedNumber.Text = borrowingNumber.ToString();
                lblFinedNumber.Text = finedNumber.ToString();


                //////////////////////////////////////////////////////////////////
                dt = new DataTable();
                selectStatement = "select COUNT(B_Id) as bookCount, B_Category from Books group by B_Category;";
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

                foreach (DataRow x in dt.Rows)
                {
                    PieChart1.PieChartValues.Add(new AjaxControlToolkit.PieChartValue
                    {
                        Category = x["B_Category"].ToString(),
                        Data = Convert.ToDecimal(x["bookCount"])
                    });

                }

                List<string> availability = new List<string>();
                availability.Add("Available Books");
                availability.Add("Not Available Books");
                int y = booksNumber - borrowingNumber;
                List<int> availabilityNumber = new List<int>();
                availabilityNumber.Add(y);
                availabilityNumber.Add(borrowingNumber);

                y = 0;
                foreach (string x in availability)
                {
                    PieChart2.PieChartValues.Add(new AjaxControlToolkit.PieChartValue
                    {
                        Category = x,
                        Data = availabilityNumber[y],
                    });
                    y++;
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