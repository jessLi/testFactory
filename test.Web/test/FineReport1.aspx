<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FineReport1.aspx.cs" Inherits="test.WEB.test.FineReport1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FineReport报表工具</title>
    <script type="text/javascript" language="javascript">
        function OpenFineReport(title, action) {
            //op=view,write
            var reportUrl = "http://localhost:8075/WebReport/ReportServer?reportlet=station.cpt&__bypagesize__=false&year=2014";
            window.open(reportUrl, title, "fullscreen");
        }
        function SetFineReport() {
            var iframeA = document.getElementById("iframeA");
            var reportUrl = "http://localhost:8075/WebReport/ReportServer?reportlet=station.cpt&__bypagesize__=false&year=2014";
             iframeA.src = reportUrl;
            //iframeA.document.location = reportUrl;
        }
    </script>
</head>
<body onload="SetFineReport()">
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn_ok" runat="server" OnClick="btn_ok_Click" Text="服务器报表测试" />
        <a href="javascript:void()" onclick="OpenFineReport()">客户端按钮测试</a>
        <br />
        <iframe id="iframeA" frameborder="0" scrolling="yes" width="900" height="700"></iframe>
    </div>
    </form>
</body>
</html>
