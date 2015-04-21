<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gvToExcel.aspx.cs" Inherits="testLXJ.test1219.gvToExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridView生成excel表格</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn_Export" runat="server" Text="导出" OnClick="btn_Export_click" />
        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" OnRowCreated="gv_RowCreated" OnRowDataBound="gv_RowDataBound">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="序号" />
                <asp:TemplateField HeaderText="按钮">
                    <ItemTemplate>
                        <asp:Button ID="btn_t" runat="server" Text='<%# Eval("NAME") %>' OnClick="btn_t_click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NAME" HeaderText="名称" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
