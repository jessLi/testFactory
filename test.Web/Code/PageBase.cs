using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;


namespace testLXJ.Code
{
    public class PageBase : System.Web.UI.Page
    {
        private static string _tokenUrl = "http://www.passport.com";

        protected override void OnLoad(EventArgs e)
        {
            if (Session["Token"] != null)
            {
                //分站凭证存在 
                Response.Write("恭喜，分站凭证存在，您被授权访问该页面！");
            }
            else
            {
                //令牌验证结果 
                if (Request.QueryString["Token"] != null)
                {
                    if (Request.QueryString["Token"] != "$Token$")
                    {
                        //持有令牌 
                        string tokenValue = Request.QueryString["Token"];
                        //调用WebService获取主站凭证
                        //防止令牌伪造
                        //此处还可使用公钥私钥的非对称加密策略                        
                        //SSO.SiteA.RefPassport.TokenService tokenService = new SSO.SiteA.RefPassport.TokenService();
                        //object o = tokenService.TokenGetCredence(tokenValue);
                        PassportService.PassportServiceSoapClient serv_p = new PassportService.PassportServiceSoapClient();
                        object o = serv_p.GetCredenceByToken(tokenValue);
                        if (o != null)
                        {
                            //令牌正确 
                            Session["Token"] = o;
                            Response.Write("恭喜，令牌存在，您被授权访问该页面！");
                        }
                        else
                        {
                            //令牌错误 
                            Response.Redirect(this.replaceToken());
                        }
                    }
                    else
                    {
                        //未持有令牌 
                        Response.Redirect(this.replaceToken());
                    }
                }
                //未进行令牌验证，去主站验证 
                else
                {
                    Response.Redirect(this.getTokenURL());
                }
            }
            base.OnLoad(e);
        }
        /// <summary> 
        /// 获取带令牌请求的URL 
        /// 在当前URL中附加上令牌请求参数 
        /// </summary> 
        /// <returns></returns> 
        private string getTokenURL()
        {
            string url = Request.Url.AbsoluteUri;
            Regex reg = new Regex(@"^.*\?.+=.+$");
            if (reg.IsMatch(url))
                url += "&Token=$Token$";
            else
                url += "?Token=$Token$";
            return _tokenUrl+"/gettoken.aspx?BackURL=" + Server.UrlEncode(url);
        }
        /// <summary> 
        /// 去掉URL中的令牌 
        /// 在当前URL中去掉令牌参数 
        /// </summary> 
        /// <returns></returns> 
        private string replaceToken()
        {
            string url = Request.Url.AbsoluteUri;
            url = Regex.Replace(url, @"(\?|&)Token=.*", "", RegexOptions.IgnoreCase);
            return _tokenUrl+"/userlogin.aspx?BackURL=" + Server.UrlEncode(url);
        }


        protected void ClearCert()
        {
            Session["Token"] = null;
        
        }


    }
}

