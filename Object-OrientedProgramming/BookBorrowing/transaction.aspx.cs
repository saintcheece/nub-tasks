using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookBorrowing
{
    public partial class transaction : System.Web.UI.Page
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlCommand cmd2;
        string str;
        DataSet ds;
        MySqlDataAdapter da;
        static int rowindex = 0;
        static int rowcount = 0;
        static int flag;
        string bilang;
        string count;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("Data Source= localhost; Database=library; User Id=root; Password=''");
            con.Open();

            if (!IsPostBack)
            {
                ddlfilter.Items.Insert(0, new ListItem("ALL", "ALL"));
                ddlfilter.Items.Insert(1, new ListItem("OUT/ BORROWED", "OUT"));
                ddlfilter.Items.Insert(2, new ListItem("IN/ RETURNED", "IN"));

                Connect();

                foreach (Control cntrl in FormBorder.Controls)
                {
                    if (cntrl is TextBox)
                    {
                        var txt = cntrl as TextBox;
                        txt.Enabled = false;
                    }
                }
                txtborrowerid.Enabled = true;
                if (Session["borrowerid"] != null)
                {
                    txtborrowerid.Text = Session["borrowerid"].ToString();
                    str = "Select DISTINCT(borrowername), numberofbooksallowed, numberofbooksborrowed, borrowerid from borrowerinfo where borrowerid='" + txtborrowerid.Text + "'";
                    cmd = new MySqlCommand(str, con);

                    ds = new DataSet();

                    da = new MySqlDataAdapter(cmd);

                    da.Fill(ds);

                    txtborrowername.Text = ds.Tables[0].Rows[rowindex]["borrowername"].ToString();
                    txtbooksallowed.Text = ds.Tables[0].Rows[rowindex]["numberofbooksallowed"].ToString();
                    txtbooksborrowed.Text = ds.Tables[0].Rows[rowindex]["numberofbooksborrowed"].ToString();

                    if (txtbooksallowed.Text == "0")
                    {
                        Response.Write("<script>alert('Return Books First!')</script>");
                        btnBorrow.Enabled = false;
                    }
                }
                else
                {
                    Response.Redirect("borrower.aspx");
                }
                DateTime dt = DateTime.Now;
                txttransactiondate.Text = dt.ToString().Substring(0, 10);

                Connect1();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvShowData.DataSource = ds;
                    gvShowData.DataBind();
                }

            }
            con.Close();
            txtbookid.Enabled = true;
        }
        public void Connect1()
        {
            str = "Select * from bookinfo";
            cmd = new MySqlCommand(str, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
        }

        public void Connect()
        {
            str = "Select * from transactioninfo";
            cmd = new MySqlCommand(str, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
        }
        public void Loaddata()
        {
            txtborrowerid.Text = ds.Tables[0].Rows[rowindex]["borrowerid"].ToString();
            txttransactionid.Text = ds.Tables[0].Rows[rowindex]["transid"].ToString();
            txttransactioncatid.Text = ds.Tables[0].Rows[rowindex]["transcatid"].ToString();
            txtbookid.Text = ds.Tables[0].Rows[rowindex]["bookid"].ToString();
            txttransactiondate.Text = ds.Tables[0].Rows[rowindex]["transdate"].ToString();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("borrower.aspx");
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = -1;
        }
        protected void btnAnother_Click(object sender, EventArgs e)
        {
            Response.Redirect("borrower.aspx");
        }
        protected void btnBorrow_Click(object sender, EventArgs e)
        {
            txttransactioncatid.Text = "CAT001";
            DateTime today = DateTime.Today;
            DateTime futureDate = today.AddDays(3);

            string result = futureDate.ToString("dd/MM/yyyy");
            txtreturndate.Text = result;

            GenerateID(txtborrowerid.Text);

            borrowBook();
            bookBrwdNum();

            btnBorrow.Enabled = false;
        }

        public void bookBrwdNum()
        {
            if (!int.TryParse(txtbooksallowed.Text, out int bksallowednum) ||
                !int.TryParse(txtbooksborrowed.Text, out int bksborrowednum))
            {
                // Error handling: Failed to parse book numbers
                return;
            }

            int newbksallowednum = bksallowednum - 1;
            txtbooksallowed.Text = newbksallowednum.ToString();
            int newbksborrowednum = bksborrowednum + 1;
            txtbooksborrowed.Text = newbksborrowednum.ToString();

            string connectionString = "Data Source=localhost; Database=library; User Id=root; Password=''";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE borrowerinfo SET numberofbooksallowed = @nobksallowed, numberofbooksborrowed = @nobksborrowed WHERE borrowerid = @borrowerid";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@nobksallowed", newbksallowednum);
                        command.Parameters.AddWithValue("@nobksborrowed", newbksborrowednum);
                        command.Parameters.AddWithValue("@borrowerid", txtborrowerid.Text);
                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    // Error handling: Handle any database-related exceptions
                    Console.WriteLine("Database error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        public void bookRtrnNum()
        {
            if (!int.TryParse(txtbooksallowed.Text, out int bksallowednum) ||
                !int.TryParse(txtbooksborrowed.Text, out int bksborrowednum))
            {
                // Error handling: Failed to parse book numbers
                return;
            }

            int newbksallowednum = bksallowednum + 1;
            txtbooksallowed.Text = newbksallowednum.ToString();
            int newbksborrowednum = bksborrowednum - 1;
            txtbooksborrowed.Text = newbksborrowednum.ToString();

            string connectionString = "Data Source=localhost; Database=library; User Id=root; Password=''";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE borrowerinfo SET numberofbooksallowed = @nobksallowed, numberofbooksborrowed = @nobksborrowed WHERE borrowerid = @borrowerid";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@nobksallowed", newbksallowednum);
                        command.Parameters.AddWithValue("@nobksborrowed", newbksborrowednum);
                        command.Parameters.AddWithValue("@borrowerid", txtborrowerid.Text);
                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    // Error handling: Handle any database-related exceptions
                    Console.WriteLine("Database error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void borrowBook()
        {
            if (txtstatus.Text == "IN")
            {
                txtstatus.Text = "OUT";
            }
            using (MySqlConnection connection = new MySqlConnection("Data Source= localhost; Database=library; User Id=root; Password=''"))
            {
                connection.Open();
                string newValue = txtstatus.Text;
                string updateQuery = "UPDATE bookinfo SET status = @status WHERE bookid='" + txtbookid.Text + "'";

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@status", newValue);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void returnBook()
        {
            if (txtstatus.Text == "OUT")
            {
                txtstatus.Text = "IN";
            }
            using (MySqlConnection connection = new MySqlConnection("Data Source= localhost; Database=library; User Id=root; Password=''"))
            {
                connection.Open();
                string newValue = txtstatus.Text;
                string updateQuery = "UPDATE bookinfo SET status = @status WHERE bookid='" + txtbookid.Text + "'";

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@status", newValue);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        protected void btnFind_Click(object sender, EventArgs e)
        {
            str = "Select DISTINCT(booktitle), bookid, status from bookinfo where bookid='" + txtbookid.Text + "'";
            cmd = new MySqlCommand(str, con);

            ds = new DataSet();

            da = new MySqlDataAdapter(cmd);

            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                txtbooktitle.Text = ds.Tables[0].Rows[rowindex]["booktitle"].ToString();
                txtstatus.Text = ds.Tables[0].Rows[rowindex]["status"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID/Does Not Exist!')</script>");
            }

            if (txtstatus.Text == "IN")
            {
                btnReturn.Enabled = false;
                btnBorrow.Enabled = true;
            }
            else if (txtstatus.Text == "OUT")
            {
                btnBorrow.Enabled = false;

                str = "Select bookid, borrowerid from transactioninfo where bookid='" + txtbookid.Text + "' and borrowerid='" + txtborrowerid.Text + "'";
                cmd = new MySqlCommand(str, con);

                ds = new DataSet();

                da = new MySqlDataAdapter(cmd);

                da.Fill(ds);
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    btnReturn.Enabled = true;
                }
                else
                {
                    btnReturn.Enabled = false;
                }
            }

        }

        protected void GenerateID(string borrowerID)
        {
            string type = "?-";
            string typeAndDate;
            string lastid;

            //return/borrow
            if (txtstatus.Text.Equals("IN"))
            {
                type = "B-";
                typeAndDate = type + DateTime.Now.ToString("ddMMyyyy");

                //number
                str = "SELECT * FROM transactioninfo WHERE left(transid, 10) = '" + typeAndDate + "' AND borrowerid = '" + borrowerID + "'";
                cmd = new MySqlCommand(str, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                try
                {
                    lastid = ds.Tables[0].Rows[0]["transid"].ToString().Substring(0, 10);
                }
                catch (IndexOutOfRangeException)
                {
                    lastid = "err";
                }

                if (lastid.Equals(typeAndDate))
                {
                    txttransactionid.Text = ds.Tables[0].Rows[0]["transid"].ToString();
                }
                else
                {
                    str = "SELECT * FROM transactioninfo WHERE left(transid, 10) = '" + typeAndDate + "' ORDER BY transid DESC";
                    cmd = new MySqlCommand(str, con);
                    ds = new DataSet();
                    da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);

                    int ilanna;
                    try
                    {
                        ilanna = ds.Tables[0].Rows.Count;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        ilanna = 0;
                    }

                    if (ilanna > 0)
                    {
                        try
                        {
                            string huli = ds.Tables[0].Rows[0]["transid"].ToString();
                            string last = huli.Substring(huli.LastIndexOf('-') + 1).ToString();

                            int lastno = Convert.ToInt16(last);

                            lastno++;
                            if (lastno.ToString().Length == 1)
                            {
                                bilang = "00" + lastno.ToString();
                            }
                            if (lastno.ToString().Length == 2)
                            {
                                bilang = "0" + lastno.ToString();
                            }
                            if (lastno.ToString().Length == 3)
                            {
                                bilang = lastno.ToString();
                            }
                            txttransactionid.Text = typeAndDate + "-" + bilang;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            txttransactionid.Text = typeAndDate + "-" + "001";
                        }
                    }
                    else
                    {
                        txttransactionid.Text = typeAndDate + "-" + "001";
                    }
                }
            }
            else
            {
                type = "R-";
                typeAndDate = type + DateTime.Now.ToString("ddMMyyyy");
                str = "SELECT * FROM transactioninfo WHERE left(transid, 10) = '" + typeAndDate + "' ORDER BY transid DESC";
                cmd = new MySqlCommand(str, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                int ilanna;
                try
                {
                    ilanna = ds.Tables[0].Rows.Count;
                }
                catch (IndexOutOfRangeException)
                {
                    ilanna = 0;
                }

                if (ilanna > 0)
                {
                    string huli = ds.Tables[0].Rows[0]["transid"].ToString();
                    string last = huli.Substring(huli.LastIndexOf('-') + 1).ToString();

                    int lastno = Convert.ToInt16(last);

                    lastno++;
                    if (lastno.ToString().Length == 1)
                    {
                        bilang = "00" + lastno.ToString();
                    }
                    if (lastno.ToString().Length == 2)
                    {
                        bilang = "0" + lastno.ToString();
                    }
                    if (lastno.ToString().Length == 3)
                    {
                        bilang = lastno.ToString();
                    }
                    txttransactionid.Text = typeAndDate + "-" + bilang;
                }
                else
                {
                    txttransactionid.Text = typeAndDate + "-" + "001";
                }
            }

            //date
            

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string transcat;
            string transid = txttransactionid.Text;
            string bkid = txtbookid.Text;
            string brwrid = txtborrowerid.Text;
            string transcatid = txttransactioncatid.Text;
            string transdate = txttransactiondate.Text;
            string returndate = txtreturndate.Text;
            if (txttransactioncatid.Text == "CAT001")
            {
                transcat = "BORROW";
            }
            else
            {
                transcat = "RETURN";
            }


            con.Open();
            if (flag == 0)
            {
                str = "insert into transactioninfo (transid, transcatid, transcatdetail, borrowerid, bookid, transdate, returndate) values(@transidno, @transcatidno, @transcatdeets, @brwridno, @bkidno, @transdeyt, @returndeyt)";
            }
            cmd = new MySqlCommand(str, con);

            if (con.State == ConnectionState.Open)
            {
                cmd.Parameters.AddWithValue("@transidno", transid);
                cmd.Parameters.AddWithValue("@transcatidno", transcatid);
                cmd.Parameters.AddWithValue("@transcatdeets", transcat);
                cmd.Parameters.AddWithValue("@brwridno", brwrid);
                cmd.Parameters.AddWithValue("@bkidno", bkid);
                cmd.Parameters.AddWithValue("@transdeyt", transdate);
                cmd.Parameters.AddWithValue("@returndeyt", returndate);
                try
                {
                    txttransactioncatid.Enabled = false;
                    txttransactiondate.Enabled = false;
                    txttransactionid.Enabled = false;
                    btnSave.Enabled = false;
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Record Saved!')</script>");
                    Connect();
                    Loaddata();
                }
                catch (SqlException exp)
                {
                    Response.Write("<script>alert('Record not Saved!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Connection Failed!')</script>");
            }
            con.Close();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            txttransactioncatid.Text = "CAT001";
            str = "Select * from transactioninfo where bookid='" + txtbookid.Text + "' and borrowerid='" + txtborrowerid.Text + "' and transcatid='" + txttransactioncatid.Text + "'";
            cmd = new MySqlCommand(str, con);

            ds = new DataSet();

            da = new MySqlDataAdapter(cmd);

            da.Fill(ds);
            if (ds.Tables[0].Rows.Count >= 1)
            {
                txttransactiondate.Text = ds.Tables[0].Rows[rowindex]["transdate"].ToString();
                txtreturndate.Text = ds.Tables[0].Rows[rowindex]["returndate"].ToString();
                txttransactioncatid.Text = "CAT002";
                DateTime today = DateTime.Today;

                string rtdate = txtreturndate.Text;
                string ctdate = today.ToString("dd/MM/yyyy");
                string c = ctdate.Substring(0, 2);
                string r = rtdate.Substring(0, 2);

                int cr = int.Parse(c);
                int rt = int.Parse(r);

                int ans = cr - rt;
                if (ans >= 1)
                {
                    string penaltyMessage = "Returned Late! Received Penalty! Missed " + ans + " days(s)!";
                    Response.Write("<script>alert('Returned Successfully!')</script>");
                    Response.Write("<script>alert('" + penaltyMessage + "')</script>");

                }
                else
                {
                    Response.Write("<script>alert('Returned Successfully!')</script>");
                    Response.Write("<script>alert('Returned Book on Time!')</script>");
                }
            }

            GenerateID(txtborrowerid.Text);

            returnBook();
            bookRtrnNum();
        }

        protected void btnlandingpage_Click(object sender, EventArgs e)
        {
            Response.Redirect("LandingPage.aspx");
        }

        protected void txtborrowername_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnfilter_Click(object sender, EventArgs e)
        {
            if(ddlfilter.SelectedValue == "ALL")
            {
                str = "SELECT * " +
                "FROM bookinfo";
            }
            else
            {
                str = "SELECT * " +
                "FROM bookinfo " +
                "WHERE status = '" + ddlfilter.SelectedValue + "'";
            }
            
            cmd = new MySqlCommand(str, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            gvShowData.DataSource = ds;
            gvShowData.DataBind();
        }
    }
}