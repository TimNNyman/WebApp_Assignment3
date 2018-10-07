<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsArticle.aspx.cs" Inherits="WebApp_Assignment2.newsArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="style/style.css">
    <link rel="stylesheet" type="text/css" href="style/footer.css">
    <link rel="stylesheet" type="text/css" href="style/HovrableArticle.css?"/>
    <script type="text/javascript" charset="utf-8" src="script/index.js"></script>

    <style>
    img {
        display: block;
        margin-left: auto;
        margin-right: auto;
        float: left;
        margin: 10px;
        width: 300px;
        height: auto;
    }

    #myDiv .title {
        font-size: 30px;
    }
</style>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <nav>
        <div class="Logo">
            <a href="default.aspx">
                <img src="https://www.nasa.gov/sites/all/themes/custom/nasatwo/images/nasa-logo.svg" alt="">
            </a>
        </div>

        <div class="Search">
            <form id="Search">
                <div>
                    <input type="search" id="mySearch" name="Search" placeholder="Search the site..." size="30px" style="border-right:0px" style="margin-right:0px">
                    <input class="searchButton" type="submit" value="Search">
                </div>
            </form>

            <div class="Share">
                <a href="#"></a>
            </div>
        </div>

        <div class="TopNav1">
            <ul>
                <li>
                    <a href="#">Mission</a>
                </li>
                <li>
                    <a href="#">Press Releases</a>
                </li>
                <li>
                    <a href="#">Media</a>
                </li>
                <li>
                    <a href="#">Follow WWRA</a>
                </li>
                <li>
                    <a href="#">WWRA Associates</a>
                </li>
                <li>
                    <a href="login.aspx">Login</a>
                </li>
            </ul>
        </div>


        <div class="TopNav2">
            <ul>
                <li>
                    <a href="addNews.aspx">Add news</a>
                </li>
                <li>
                    <a href="#">Raptors</a>
                </li>
                <li>
                    <a href="#">Short arms</a>
                </li>
                <li>
                    <a href="#">Research</a>
                </li>
                <li>
                    <a href="#">John Hammond</a>
                </li>
                <li>
                    <a href="#">History</a>
                </li>
            </ul>
        </div>
    </nav>
    <div id="navDiv">
    </div>
    <main>

        <div class="mainArticle">

            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

        </div>

    </main>
     <footer>
        <div id="footerDiv">
            <a id="footer-logo" href="#">
                <img src="https://www.nasa.gov/sites/all/themes/custom/nasatwo/images/nasa-logo.svg" alt="">
            </a>
            <div id="footer-info">
                <p>National&nbsp;Aeronautics and Space&nbsp;Administration</p>
                <p>NASA Official: Brian Dunbar</p>
            </div>
        </div>
        <ul id="footer-links">
            <li>
                <a href="#">No Fear Act</a>
            </li>
            <li>
                <a href="#">FOIA</a>
            </li>
            <li>
                <a href="#">Privacy</a>
            </li>
            <li>
                <a href="#">Office of Inspector General</a>
            </li>
            <li>
                <a href="#">Office of Special Counsel</a>
            </li>
            <li>
                <a href="#">Agency Financial Reports</a>
            </li>
            <li>
                <a href="#">Contact NASA</a>
            </li>
        </ul>
    </footer>

    </form>


</body>
</html>
