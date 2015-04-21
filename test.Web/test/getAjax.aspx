<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getAjax.aspx.cs" Inherits="testLXJ.test.getAjax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AJAX无刷新省市县三级联动</title>
    <%-- <script type="text/javascript" src="../AJAX/getText.ashx"></script>--%>
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" language="javascript">
        //jb函数会根据不同的浏览器初始化个xmlhttp对象
        function jb() {
            var xmlhttp;
            if (window.XMLHttpRequest) {
                // code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {
                // code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            return xmlhttp;
        }
        $(document).ready(function () {
            $("#ddl_province").change(function () {
                var prov = document.getElementById("ddl_province").value;                
                ajaxurl = "../AJAX/getText.ashx?province=" + prov;                
                var xmlhttp = jb();
                xmlhttp.open("GET", ajaxurl, true);
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        var responseTxt = xmlhttp.responseText;
                        if (responseTxt.length > 0) {
                            //clear
                            document.getElementById("ddl_city").options.length = 0;
                            //set
                            var data1 = responseTxt.split(";");
                            for (var i = 0; i < data1.length; i++) {
                                var data2 = data1[i].split(":");
                                document.getElementById("ddl_city").options.add(new Option(data2[0], data2[1]));
                            }
                        }
                    }
                }
                xmlhttp.send();
            });

            $("#ddl_city").change(function () {
                var prov = document.getElementById("ddl_city").value; 
                ajaxurl = "../AJAX/getText.ashx?city=" + prov;
                var xmlhttp = jb();
                xmlhttp.open("GET", ajaxurl, true);
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        var responseTxt = xmlhttp.responseText;
                        if (responseTxt.length > 0) {
                            //clear
                            document.getElementById("ddl_district").options.length = 0;
                            //set
                            var data1 = responseTxt.split(";");
                            for (var i = 0; i < data1.length; i++) {
                                var data2 = data1[i].split(":");
                                document.getElementById("ddl_district").options.add(new Option(data2[0], data2[1]));
                            }
                        }
                    }
                }
                xmlhttp.send();
            });
        });
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddl_province" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="ddl_city" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="ddl_district" runat="server">
        </asp:DropDownList>
    </div>
    </form>
</body>
</html>
