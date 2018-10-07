<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApp_Assignment2.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <style>
        body {
            font-family: "Century Gothic", CenturyGothic, AppleGothic, sans-serif;
            background: #000000;
            margin: 0px;

        }

        input[type=text],
        input[type=password] {
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
            text-align: center;
        }

        .myBtn {
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
            grid-template-columns: repeat(auto-fit, 200px);
            justify-content: center;
        }

        .myBtn:hover {
            opacity: 0.8;
        }

        #loginBtn{
            background-color:gray;
        }

        #cancelBtn {
            background-color:red;
        }

        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
            position: relative;
        }

        img.avatar {
            padding-left:5%;
            width: 90%;
            height: 90;
            border-radius: 100%;
            justify-content:center;
        }

        .login {
            width: 500px;
            display: flex;
            height: auto;
            margin: auto;
            background-color: black;
            display: grid;
            grid-template-columns: repeat(auto-fit, 300px);
            justify-content: center;
            grid-gap: 30px;
        }
        #username {
            width: 100%;
            
        }
        #password {
            width:100%;
        }


    </style>

</head>
<body>
    <form id="form2" runat="server">
        <div class="login">

            <div class="imgcontainer">
                <img src="https://www.nasa.gov/sites/all/themes/custom/nasatwo/images/nasa-logo.svg" alt="" class="avatar">
            </div>

            <div class="loginInput">
                <asp:TextBox ID="username" type="text" placeholder="Username" runat="server" OnTextChanged="VerifyInput" required AutoPostBack="true"/>

                <asp:TextBox ID="password" type="password" placeholder="Password" runat="server" OnTextChanged="VerifyInput" required AutoPostBack="true"/>
                <br />

                <asp:Button ID="loginBtn" class="myBtn" runat="server" Text="Login" OnClick="loginBtn_Click" />
                <asp:Button ID="cancelBtn" CssClass="myBtn" runat="server" Text="Cancel" UseSubmitBehavior="false" OnClick="cancelBtn_Click" />
            </div>

        </div>

    </form>

</body>
</html>
