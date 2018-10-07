<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addNews.aspx.cs" Inherits="WebApp_Assignment2.addNews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="style/style.css"/>
    <link rel="stylesheet" type="text/css" href="style/HovrableArticle.css"/>
    <link rel="stylesheet" type="text/css" href="style/footer.css"/>
    <link rel="stylesheet" type="text/css" href="style/createContent.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <main>
                <div>
                    <p>
                        <label for="Title">Title: </label>
                        <input type="text" name="title" id="Title" runat="server" onkeyup="checkContent()" />
                    </p>
                    <p>
                        <label for="Content">Content: </label>
                        <textarea name="content" rows="5" id="Content" runat="server" onkeyup="checkContent()"></textarea>
                    </p>
                    <p>
                        <asp:fileupload id="FileUploadControl" runat="server"  />
                    </p>
                    <p>
                        <asp:button id="submitBtn" onclick="submitBtn_Click" text="Submit" runat="server" />
                    </p>
                    <p>
                        <asp:Button ID="cancelBtn" runat="server" Text="Cancel" UseSubmitBehavior="false" OnClick="cancelBtn_Click" />
                    </p>
                </div>
        </main>
    </form>
    <script>
        function checkContent() {
	        if(document.getElementById("content").value==="" || document.getElementById("title").value==="") { 
                document.getElementById('submitBtn').disabled = true; 
            } else { 
                document.getElementById('submitBtn').disabled = false;
            }
        }
    </script>
</body>
</html>
