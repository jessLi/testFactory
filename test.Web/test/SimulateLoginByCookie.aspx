<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimulateLoginByCookie.aspx.cs" Inherits="test.WEB.test.SimulateLoginByCookie" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>通过发送cookie模拟登录</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="btn_login" Text="登录" OnClick="btn_login_Click" />
    
    </div>
    </form>
</body>
</html>
