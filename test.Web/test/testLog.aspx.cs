using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace test.WEB.test
{
    public partial class testLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Focus();            
            }
        }

        protected void Button1_Click(object sender,EventArgs e)
        {
            string input = TextBox1.Text.Trim();
            //字符串转换为int， //null, 格式不正确，溢出时报异常;          
            try
            {
                //格式不正确，溢出时报异常;
                Convert.ToInt32(input);
                Common.LogHelper.WriteLog("输入：" + input);
            }
            catch (Exception ex)
            {

                Common.LogHelper.WriteError("输入：" + input, ex);            
            }
            try
            {
                //null, 格式不正确，溢出时报异常;
                int.Parse(null);
                Common.LogHelper.WriteLog("输入：" + input);
            }
            catch (Exception ex)
            {

                Common.LogHelper.WriteError("输入：" + input, ex);
            }
            int i = 123; 
            //转换成功i为转换后的值，失败i为0： //null, 格式不正确，溢出时报异常;
            int.TryParse(null,out i);
            Common.LogHelper.WriteLog(i.ToString());
            
        
        }

        protected void Button2_Click(object sender,EventArgs e)
        {
            testLXJ.Service2.Service2SoapClient serv1 = new testLXJ.Service2.Service2SoapClient();
            if (TextBox2.Text.Trim() != "")
            {
                testLXJ.Service2.model m = serv1.GetModelById(TextBox2.Text.Trim());
                Label2.Text = "有参数：" + m.Name;
            }
            else
            {
                testLXJ.Service2.model m = serv1.GetModel();
                Label2.Text = "无参数：" + m.Name;
            }
        
        
        }
    }
}