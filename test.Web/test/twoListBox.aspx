<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="twoListBox.aspx.cs" Inherits="test.WEB.test.twoListBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn_save" runat="server" Text="确定" OnClick="btn_save_click" />
        <asp:ListBox ID="sListBox" runat="server" SelectionMode="Multiple" Width="450" Height="300"></asp:ListBox>
        <input type="button" value=">>" onclick="SwapListBox(1)" /> 
        <input type="button" value="<<" onclick="SwapListBox(2)" />         
        <asp:ListBox ID="dListBox" runat="server" SelectionMode="Multiple" Width="450" Height="300"></asp:ListBox>
        <input type="button" value="上移" onclick="SwapListBoxTop(1)" /> 
        <input type="button" value="下移" onclick="SwapListBoxTop(-1)" />   
    </div>
    </form>
    <script type="text/javascript" language="javascript">
    //上下移动
        function SwapListBoxTop(b) {
            var dbox = document.getElementById("dListBox");            
            for (var i = 0; i < dbox.options.length; i++) {
                var selectitem = dbox.options[i];
                if (selectitem.selected) {
                    var selectIndex = i;
                    var nextIndex =eval(i - b);                                                        
                    var upitemv = dbox.options[nextIndex].value;
                    var upitemt = dbox.options[nextIndex].text;
                    var downv = dbox.options[selectIndex].value;
                    var downt = dbox.options[selectIndex].text;
                    dbox.options[selectIndex].value = upitemv;
                    dbox.options[selectIndex].text = upitemt;
                    dbox.options[nextIndex].value = downv;
                    dbox.options[nextIndex].text = downt;                     
                }
            }
        }
    //左右移动
        function SwapListBox(a) {
            var sbox;
            var dbox;
            if (a == 1) {
                sbox = document.getElementById("sListBox");
                dbox = document.getElementById("dListBox");
            }
            else {
                dbox = document.getElementById("sListBox");
                sbox = document.getElementById("dListBox");
            }

            for (var i = sbox.options.length - 1; i >= 0; i--) {
                var selectitem = sbox.options[i];
                if (selectitem.selected) {
                    sbox.options[i] = null;
                    selectitem.selected = (dbox.multiple || dbox.selectedIndex < 0) ? selectitem.selected : false;
                    //alert(selectitem);
                    dbox.appendChild(selectitem);
                }
            } 
        }
    </script>
</body>
</html>
