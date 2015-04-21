using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace testLXJ.test1219
{
    public partial class gvToExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
            }
        }

        public void InitData()
        {
            ViewState["Type"] = "display";
            gv.DataSource = GetTable();
            gv.DataBind();
        }

        /// <summary>
        /// 导出前，把按钮转换为文本
        /// </summary>
        /// <param name="gv"></param>
        public void DisableButtonControl(Control gv)
        {
            for (int i = 0; i < gv.Controls.Count; i++)
            {
                if (gv.Controls[i].GetType() == typeof(Button))
                {
                    Button btn = (Button)gv.Controls[i];
                    Literal l = new Literal();
                    l.Text = btn.Text;
                    gv.Controls.Remove(btn);
                    gv.Controls.AddAt(i, l);
                }
                if (gv.Controls[i].HasControls())
                {
                    DisableButtonControl(gv.Controls[i]);
                }
            }
        }

        public void btn_Export_click(object sender, EventArgs e)
        {
            DataTable table = GetTable();
            if (table != null && table.Rows.Count > 0)
            {
                ViewState["Type"] = "export";
                gv.DataSource = table;
                gv.DataBind();
                DisableButtonControl(gv);  //按钮换掉
                Common.ExportToExcel.ExportToExcel1("", gv);
            }
        } 

        public void btn_t_click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert(\"ok\");</script>");        
        }

        public void gv_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    //if (ViewState["Type"].ToString() == "export")  //导出时，把按钮换掉
            //    //{
            //    //   // int c = e.Row.Controls.Count;  //3
            //    //    Button btn = e.Row.Cells[1].FindControl("btn_t") as Button;
            //    //    e.Row.Cells[1].Controls.Remove(btn);                   
            //    //    Label l = new Label();
            //    //    l.Text = "test";
            //    //    e.Row.Cells[1].Controls.Add(l);
            //    //}
            //}
        }

        public void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        public DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            table.Columns.Add(new DataColumn("NAME", typeof(string)));
            DataRow row = table.NewRow();
            row[0] = 1;
            row[1] = "nancy";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 2;
            row[1] = "sanry";
            table.Rows.Add(row);
            return table;
        }
    }
}