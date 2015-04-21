using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using test.DAL;
using System.Data;

namespace testLXJ.test
{
    public partial class getAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //加载省数据
                string sql = "SELECT * FROM SetArea A WHERE A.ParentId=1 ";
                DataTable dt = SqlServerHelper.GetDataSet(sql, null).Tables[0];
                this.ddl_province.DataTextField = "Name";
                this.ddl_province.DataValueField = "Id";
                this.ddl_province.DataSource = dt;
                this.ddl_province.DataBind();            
            }

        }
    }
}