using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookBorrowing
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnManageBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("book.aspx");
        }


        protected void btntransaction_Click(object sender, EventArgs e)
        {
            Response.Redirect("transaction.aspx");
        }



        protected void btnManagePatrons_Click(object sender, EventArgs e)
        {
            Response.Redirect("borrower.aspx");

        }
    }
}