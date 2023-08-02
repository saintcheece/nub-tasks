using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace BookBorrowing
{
    public partial class Book : System.Web.UI.Page
    {

        MySqlConnection con;
        MySqlCommand cmd;
        string str;
        DataSet ds;
        MySqlDataAdapter da;
        static int rowindex = 0;
        static int rowcount = 0;
        static int flag;
        int bilang;
        string count;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("Data Source= localhost; Database=library; User Id=root; Password=''");
            con.Open();
            if (!IsPostBack)
            {
                rblstatus.Items.Insert(0, new ListItem("IN", "IN"));

                rblstatus.Items.Insert(1, new ListItem("OUT", "OUT"));

                ddlbookcategory.Items.Insert(0, new ListItem("Select", "NA"));
                ddlbookcategory.Items.Insert(1, new ListItem("BC01", "BC01"));
                ddlbookcategory.Items.Insert(2, new ListItem("BC02", "BC02"));
                ddlbookcategory.Items.Insert(3, new ListItem("BC03", "BC03"));
                Connect();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Loaddata();
                    gvShowData.DataSource = ds;
                    gvShowData.DataBind();
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                    btnFirst.Enabled = true;
                    btnLast.Enabled = true;

                }
                else
                {
                    btnFirst.Enabled = false;
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnReload.Enabled = false;

                }
                txtbookcatdetail.Enabled = false;
                txtbookid.Enabled = false;
                txtbooktitle.Enabled = false;
                txtcopynum.Enabled = false;
                txtdaysallowed.Enabled = false;
                rblstatus.Enabled = false;
                ddlbookcategory.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
            con.Close();
            

        }
        protected void btnMultipleSearch_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = -1;
        }
        public void Connect()
        {
            str = "Select * from bookinfo";
            cmd = new MySqlCommand(str, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
        }
        public void Loaddata()
        {
            txtbookid.Text = ds.Tables[0].Rows[rowindex]["bookid"].ToString();
            txtbooktitle.Text = ds.Tables[0].Rows[rowindex]["booktitle"].ToString();
            txtbookcatdetail.Text = ds.Tables[0].Rows[rowindex]["bookcatdetail"].ToString();
            txtcopynum.Text = ds.Tables[0].Rows[rowindex]["copynum"].ToString();
            txtdaysallowed.Text = ds.Tables[0].Rows[rowindex]["numberofdaysallowed"].ToString();
            rblstatus.SelectedValue = ds.Tables[0].Rows[rowindex]["status"].ToString();
            ddlbookcategory.SelectedValue = ds.Tables[0].Rows[rowindex]["bookcategory"].ToString();
        }

        public void cleartext()
        {
            txtbooktitle.Text = "";
            txtcopynum.Text = string.Empty;
            txtdaysallowed.Text = null;
            rblstatus.ClearSelection();
            txtbookid.Text = string.Empty;
            ddlbookcategory.ClearSelection();
            txtbookcatdetail.Text = string.Empty;
        }
        protected void btnSearchID_Click(object sender, EventArgs e)
        {
            try
            {
                //str = "Select a.booktitle, a.bookcategory, a.bookid, a.status, a.copynum, a.numberofdaysallowed, a.bookcatdetail from bookinfo a where a.bookid= '" + txtentbookidno.Text + "' order by a.bookid";
                str = "SELECT * " +
                      "FROM bookinfo " +
                      "WHERE bookid = '"+txtentbookidno.Text+"'" +
                      "ORDER BY bookid";
                cmd = new MySqlCommand(str, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Loaddata();
                    Response.Write("<script>alert('This Should Be Working');</script>");
                }
                else
                {
                    Response.Write("<script>alert('No Records Found');</script>");

                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            con.Open();
            rowindex = 0;
            Connect();
            Loaddata();
            con.Close();
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnFirst.Enabled = true;
            btnLast.Enabled = true;
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            rowindex = 0;
            con.Open();
            Connect();
            Loaddata();
            con.Close();
            Response.Write("<script>alert('First Record Reached')</script>");
            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            rowindex--;
            con.Open();
            Connect();
            if (rowindex >= 0)
            {
                Loaddata();
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            else
            {
                Response.Write("<script>alert('First Record Reached')</script>");
                rowindex = 0;
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
            }
            con.Close();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            rowindex++;
            con.Open();
            Connect();
            if (rowindex <= ds.Tables[0].Rows.Count - 1)
            {
                Loaddata();
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
            }
            else
            {
                Response.Write("<script>alert('Last Record Reached')</script>");
                rowindex = ds.Tables[0].Rows.Count - 1;

                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            con.Close();
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            con.Open();
            Connect();
            rowindex = ds.Tables[0].Rows.Count - 1;
            Loaddata();
            con.Close();
            Response.Write("<script>alert('Last Record Reached')</script>");
            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = false;
            btnLast.Enabled = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            cleartext();

            txtbooktitle.Enabled = true;
            txtbookcatdetail.Enabled = false;
            txtcopynum.Enabled = true;
            rblstatus.SelectedIndex = 0;
            txtdaysallowed.Enabled = true;
            ddlbookcategory.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnFirst.Enabled = false;
            btnLast.Enabled = false;
            btnSearchID.Enabled = false;
            btnReload.Enabled = false;
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            flag = 1;
            txtbooktitle.Enabled = true;
            ddlbookcategory.Enabled = true;
            txtcopynum.Enabled = true;
            txtdaysallowed.Enabled = true;
            rblstatus.Enabled = true;
            txtbookcatdetail.Enabled = true;

            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnFirst.Enabled = false;
            btnLast.Enabled = false;
            btnSearchID.Enabled = false;
            btnReload.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            txtbooktitle.Enabled = false;
            txtbookid.Enabled = false;
            txtbookcatdetail.Enabled = false;

            btnSave.Enabled = false;
            btnEdit.Enabled = false;
            btnAdd.Enabled = true;
            btnCancel.Enabled = false;
            btnDelete.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnFirst.Enabled = true;
            btnLast.Enabled = true;
            btnSearchID.Enabled = true;

            string bkid = txtbookid.Text;
            string bktitle = txtbooktitle.Text;
            string bkcatdetail = txtbookcatdetail.Text;
            string bkcpynum = txtcopynum.Text;
            string bkdays = txtdaysallowed.Text;
            string bkstatus = rblstatus.SelectedValue;
            string bookcat = ddlbookcategory.SelectedValue;

            con.Open();
            if (flag == 0)
            {
                str = "insert into bookinfo (bookid, booktitle, bookcategory, bookcatdetail, copynum, status, numberofdaysallowed) values(@bookidno, @booktitle, @bookctgry, @bookctgrydtl, @bkcpynum, @bksts, @bkdeys)";
            }
            else if (flag == 1)
            {
                str = "update bookinfo set bookid=@bookidno, booktitle=@booktitle, bookcategory=@bookctgry, bookcatdetail=@bookctgrydtl, copynum=@bkcpynum, status=@bksts, numberofdaysallowed=@bkdeys where bookid=@bookidno";
            }
            cmd = new MySqlCommand(str, con);

            if (con.State == ConnectionState.Open)
            {
                cmd.Parameters.AddWithValue("@bookidno", bkid);
                cmd.Parameters.AddWithValue("@booktitle", bktitle);
                cmd.Parameters.AddWithValue("@bookctgry", bookcat);
                cmd.Parameters.AddWithValue("@bookctgrydtl", bkcatdetail);
                cmd.Parameters.AddWithValue("@bkcpynum", bkcpynum);
                cmd.Parameters.AddWithValue("@bksts", bkstatus);
                cmd.Parameters.AddWithValue("@bkdeys", bkdays);

                try
                {
                    txtbooktitle.Enabled = false;
                    txtbookid.Enabled = false;
                    txtbookcatdetail.Enabled = false;
                    btnSave.Enabled = false;
                    btnEdit.Enabled = true;
                    btnAdd.Enabled = true;
                    btnCancel.Enabled = false;
                    btnDelete.Enabled = true;
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                    btnFirst.Enabled = true;
                    btnLast.Enabled = true;
                    btnSearchID.Enabled = true;
                    btnReload.Enabled = true;

                    txtbookcatdetail.Enabled = false;
                    txtbookid.Enabled = false;
                    txtbooktitle.Enabled = false;
                    txtcopynum.Enabled = false;
                    txtdaysallowed.Enabled = false;
                    rblstatus.Enabled = false;
                    ddlbookcategory.Enabled = false;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Record Saved!')</script>");
                    Connect();
                    Loaddata();
                }
                catch (SqlException exp)
                {
                    Response.Write("<script>alert('Record not Saved!: "+exp+"')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Connection Failed!')</script>");
            }
            con.Close();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            con.Open();
            Connect();
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (flag == 0)
                {
                    rowindex = 0;
                }
                Loaddata();
            }
            con.Close();
            txtbooktitle.Enabled = false;
            txtbookid.Enabled = false;
            txtbookcatdetail.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnCancel.Enabled = false;
            btnDelete.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
            btnFirst.Enabled = true;
            btnLast.Enabled = true;
            btnSearchID.Enabled = true;
            flag = 0;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            string bookid = txtbookid.Text;
            str = "delete from bookinfo where bookid = @bookidno";
            cmd = new MySqlCommand(str, con);
            cmd.Parameters.AddWithValue("@bookidno", bookid);
            cmd.ExecuteNonQuery();
            Connect();
            if (ds.Tables[0].Rows.Count >= 0)
            {
                rowindex = 0;
                Loaddata();
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnFirst.Enabled = true;
                btnLast.Enabled = true;
            }
            con.Close();
        }

        protected void rblstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void ddlbookcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            str = "Select DISTINCT(bookcategory), bookcatdetail from bookinfo where bookcategory='" + ddlbookcategory.SelectedValue + "'";
            cmd = new MySqlCommand(str, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);

            txtbookcatdetail.Text = ds.Tables[0].Rows[0]["bookcatdetail"].ToString();

            string selectedCategory = ddlbookcategory.SelectedValue;
            string bookId = "";

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                con.Open();

                string query = "SELECT MAX(bookid) FROM bookinfo WHERE bookcategory = @Category";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Category", selectedCategory);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    string lastBookId = result.ToString();
                    string categoryPrefix = selectedCategory + "-";

                    if (lastBookId.StartsWith(categoryPrefix))
                    {
                        int lastSerialNumber;
                        if (int.TryParse(lastBookId.Substring(categoryPrefix.Length), out lastSerialNumber))
                        {
                            int newSerialNumber = lastSerialNumber + 1;
                            bookId = categoryPrefix + newSerialNumber.ToString("D3");
                        }
                    }
                }

                con.Close();
            }

            txtbookid.Text = bookId;
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");

        }

        protected void btnAddTransaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("transaction.aspx");

        }

        protected void btnborrower_Click(object sender, EventArgs e)
        {
            Response.Redirect("borrower.aspx");
        }
    }
}