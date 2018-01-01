using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pageManagerMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEsc_Click(object sender, EventArgs e)
    {
        Session["UserName"] = null;
        Response.Redirect("~/Login/pageLogin.aspx");
    }
}