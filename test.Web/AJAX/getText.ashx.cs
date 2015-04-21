using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test.DAL;
using System.Data;



namespace testLXJ.AJAX
{
    /// <summary>
    /// getText 的摘要说明：
    /// </summary>
    public class getText : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("document.write(\"Hello World\");");
            string responseTxt = "";   
            //根据省获取市
            string prov = context.Request.QueryString["province"];
            if (!string.IsNullOrEmpty(prov))
            {
                // string sql = "SELECT * FROM SetArea A WHERE A.Id=" + prov + " OR A.ParentId="+prov;
                string sql = "SELECT * FROM SetArea A WHERE A.ParentId=" + prov;
                DataTable dt = SqlServerHelper.GetDataSet(sql, null).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        responseTxt += dt.Rows[i]["Name"] + ":" + dt.Rows[i]["Id"] + ";";
                    }
                }
                if (responseTxt.Length > 0)
                    responseTxt = responseTxt.Substring(0, responseTxt.Length - 1);
            }
            //根据市获取县区
            string city = context.Request.QueryString["city"];
            if (!string.IsNullOrEmpty(city))
            {                
                string sql = "SELECT * FROM SetArea A WHERE A.ParentId=" + city;
                DataTable dt = SqlServerHelper.GetDataSet(sql, null).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        responseTxt += dt.Rows[i]["Name"] + ":" + dt.Rows[i]["Id"] + ";";
                    }
                }
                if (responseTxt.Length > 0)
                    responseTxt = responseTxt.Substring(0, responseTxt.Length - 1);
            }
            context.Response.Write(responseTxt);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}