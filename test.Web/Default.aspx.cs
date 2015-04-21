using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testLXJ.Code;

namespace testLXJ
{
    public partial class _Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //测试github

        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_logout_click(object sender, EventArgs e)
        {
            //清空当前分站凭证
            ClearCert();

            //调用webservice清空主站凭证




        }
    }
}
