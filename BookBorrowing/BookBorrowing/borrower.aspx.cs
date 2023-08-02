using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookBorrowing
{
    public partial class Borrower : System.Web.UI.Page
    {
        MySqlConnection con;
        MySqlCommand cmd;
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
                

                Connect();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Loaddata();
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
            }
            con.Close();
            txtborrowerid.Enabled = false;
            txtborrowername.Enabled = false;
            txtcourse.Enabled = false;
            txtsection.Enabled = false;
            txtbooksallowed.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        public void Connect()
        {
            str = "Select * from borrowerinfo";
            cmd = new MySqlCommand(str, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
        }

        public void Loaddata()
        {
            txtborrowerid.Text = ds.Tables[0].Rows[rowindex]["borrowerid"].ToString();
            txtborrowername.Text = ds.Tables[0].Rows[rowindex]["borrowername"].ToString();
            txtcourse.Text = ds.Tables[0].Rows[rowindex]["course"].ToString();
            txtsection.Text = ds.Tables[0].Rows[rowindex]["section"].ToString();
            txtbooksallowed.Text = ds.Tables[0].Rows[rowindex]["numberofbooksallowed"].ToString();
        }
        public void cleartext()
        {
            txtborrowerid.Text = "";
            txtborrowername.Text = string.Empty;
            txtcourse.Text = null;
            txtsection.Text = string.Empty;
            txtbooksallowed.Text = string.Empty;
        }
        protected void btnSearchID_Click(object sender, EventArgs e)
        {
            con.Open();
            Connect();
            try
            {
                str = "SELECT * FROM borrowerinfo WHERE borrowerid= '" + txtentborroweridno.Text + "' ORDER BY borrowerid";
                cmd = new MySqlCommand(str, con);
                ds = new DataSet();
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtborrowerid.Text = ds.Tables[0].Rows[0]["borrowerid"].ToString();
                    txtborrowername.Text = ds.Tables[0].Rows[0]["borrowername"].ToString();
                    txtcourse.Text = ds.Tables[0].Rows[0]["course"].ToString();
                    txtsection.Text = ds.Tables[0].Rows[0]["section"].ToString();
                    txtbooksallowed.Text = ds.Tables[0].Rows[0]["numberofbooksallowed"].ToString();
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
            finally
            {
                con.Close();
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
            flag = 0;
            cleartext();
            string dt = DateTime.Now.ToString("yyyy");
            con.Open();

            str = "Select borrowerid from borrowerinfo where left(borrowerid,4) = '" + dt + "' order by borrowerid desc limit 1";
            cmd = new MySqlCommand(str, con);
            ds = new DataSet();
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            int ilanna = ds.Tables[0].Rows.Count;
            string huli = ds.Tables[0].Rows[0]["borrowerid"].ToString();
            string last = huli.Substring(huli.Length - 3, 3).ToString();

            int lastno = Convert.ToInt16(last);
            txtborrowerid.Text = lastno.ToString();


            if (ilanna > 0)
            {
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
            }
            else
            {
                bilang = "001";
            }
            txtborrowerid.Text = dt + "-" + bilang;
            con.Close();

            txtborrowername.Enabled = true;
            txtcourse.Enabled = true;
            txtsection.Enabled = true;
            txtbooksallowed.Enabled = true;
            txtborrowerid.Focus();
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
            txtborrowername.Enabled = true;
            txtcourse.Enabled = true;
            txtsection.Enabled = true;

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
            txtborrowername.Enabled = false;
            txtcourse.Enabled = false;
            txtsection.Enabled = false;

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

            string brid = txtborrowerid.Text;
            string brname = txtborrowername.Text;
            string brcrs = txtcourse.Text;
            string brsec = txtsection.Text;
            int brbks = Convert.ToInt16(txtbooksallowed.Text);


            con.Open();
            if (flag == 0)
            {
                str = "insert into borrowerinfo (borrowerid, borrowername, course, section, numberofbooksallowed) values(@brwridno, @brwrname, @brwrcrs, @brwrsec, @booksallowed)";
            }
            else if (flag == 1)
            {
                str = "update borrowerinfo set borrowerid=@brwridno, borrowername=@brwrname, course=@brwrcrs, section=@brwrsec, numberofbooksallowed=@booksallowed where borrowerid=@brwridno";
            }
            cmd = new MySqlCommand(str, con);

            if (con.State == ConnectionState.Open)
            {
                cmd.Parameters.AddWithValue("@brwridno", brid);
                cmd.Parameters.AddWithValue("@brwrname", brname);
                cmd.Parameters.AddWithValue("@brwrcrs", brcrs);
                cmd.Parameters.AddWithValue("@brwrsec", brsec);
                cmd.Parameters.AddWithValue("@booksallowed", brbks);

                try
                {
                    txtborrowername.Enabled = false;
                    txtcourse.Enabled = false;
                    txtsection.Enabled = false;
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
            txtsection.Enabled = false;
            txtborrowername.Enabled = false;
            txtcourse.Enabled = false;
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
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            string borrowerid = txtborrowerid.Text;
            str = "delete from borrowerinfo where borrowerid = @brwridno";
            cmd = new MySqlCommand(str, con);
            cmd.Parameters.AddWithValue("@brwridno", borrowerid);
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

        protected void btMultipleSearch1_Click(object sender, EventArgs e)
        {
            Session["borrowerid"] = txtborrowerid.Text;
            Session["borrowername"] = txtborrowername.Text;
            Response.Redirect("Transaction.aspx");
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");

        }

        protected void btnborrower_Click(object sender, EventArgs e)
        {
            Response.Redirect("book.aspx");

        }
    }
}