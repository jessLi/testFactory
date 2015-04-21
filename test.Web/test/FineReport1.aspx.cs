using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test.WEB.test
{
    public partial class FineReport1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            //调用的方法放在页面顶部
            // ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "OpenFineReport()", true);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "OpenFineReport()", true);
        }
    }
}