<%@ Page Language="C#" AutoEventWireup="true" CodeFile="posting.aspx.cs" Inherits="posting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Posting Page</title>
      <style>
        .box{
            background-color: #C0C0C0; 
            border-style: solid; 
            border-width: 1.5px; 
            margin: auto; 
            width: 650px; 
            height: 450px;
            padding: 10px;
            margin-top: 100px;
            text-align:center;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="box" style="text-align:center;margin-top:50px;padding-top:50px">
        <h1 style="text-align: center; font-size: 35px">Posting Page</h1>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="comment" runat="server" Height="110px" Width="281px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Post" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Cancel" />
        <br />
       
        <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:localDB7ConnectionString %>" SelectCommand="SELECT * FROM [posts]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
