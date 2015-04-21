<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testLog.aspx.cs" Inherits="test.WEB.test.testLog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>输入数字记录信息，输入非数字记录错误</p>
    <asp:TextBox  ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" />    
    </div>
    <div>
    <p>测试webservice接口调用-有参数与无参数</p>
     <asp:TextBox  ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="调用接口" OnClick="Button2_Click" /> 
    <asp:Label ID="Label2" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
