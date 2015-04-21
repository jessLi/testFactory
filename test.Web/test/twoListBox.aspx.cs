using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using test.DAL;

namespace test.WEB.test
{
    public partial class twoListBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            
            }

        }

        protected void BindGrid()
        { 
            string sql1="SELECT * FROM SetArea A WHERE A.ParentId=1";
            sListBox.DataTextField = "Name";
            sListBox.DataValueField = "Id";
            sListBox.DataSource=SqlServerHelper.GetDataSet(sql1).Tables[0];
            sListBox.DataBind();

            dListBox.DataSource=null;
            dListBox.DataBind();
        
        }

        //数据保存到数据库
        protected void btn_save_click(object sender, EventArgs e)
        { 
            
        
        }
    }
}