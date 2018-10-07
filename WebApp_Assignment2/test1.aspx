<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test1.aspx.cs" Inherits="WebApp_Assignment2.test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style/searchList.css"/>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <asp:textbox runat="server" id="mySearch" onkeyup="getSearchQry()" onpaste="getSearchQry()" style="margin-left: 500px"></asp:textbox>
            <div id="searchReqDiv"></div>
            <div style="width: 100%; height:300px; background-color: lightblue;"></div>
        </div>
    </form>
    <script type="text/javascript" charset="utf-8" src="script/searchList.js"></script>
</body>
</html>
