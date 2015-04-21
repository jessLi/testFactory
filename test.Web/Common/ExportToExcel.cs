using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

namespace testLXJ.Common
{
    public static class ExportToExcel
    {
        public static void ExportToExcel1(string fileName, GridView gridView)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            }

            Page page = new Page();
            HtmlForm form =new HtmlForm();
            gridView.EnableViewState=false;
            page.EnableEventValidation = false;           
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(gridView);            

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
            HttpContext.Current.Response.ContentType = "application/ms-excel";

            System.IO.StringWriter strWrite = new StringWriter();
            System.Web.UI.HtmlTextWriter txtWrite = new HtmlTextWriter(strWrite);
            page.RenderControl(txtWrite);           

            HttpContext.Current.Response.Write(strWrite);
            HttpContext.Current.Response.End();

            
        }
    }
}