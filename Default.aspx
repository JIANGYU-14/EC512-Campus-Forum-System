<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Forum</title>
     <style>
        .box{
            background-color: #C0C0C0; 
            border-style: solid; 
            border-width: 1.5px; 
            margin: auto; 
            width: 1650px; 
            height: 850px;
            padding: 10px;
            margin-top: 100px;
            text-align:center;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="box" style="text-align:center">
    <div>
        <h1 style="text-align: center; font-size: 35px">Online Forum</h1>
        <div style="text-align:left">
        Username:<asp:TextBox ID="username" runat="server"></asp:TextBox>
        Password:<asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign In" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Sign Out" />
        <br />
        New Username:<asp:TextBox ID="newun" runat="server"></asp:TextBox>
        New Password:<asp:TextBox ID="newpw" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Sign Up" OnClick="Button2_Click" />
            <br />
        <br />
        
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Add New Posts" />
        
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Label" Visible="false"></asp:Label>
        </div>
        <p style="text-align:center">
        <asp:Table ID="Table1" runat="server">
        </asp:Table>
            </p>
        <br />
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:localDB7ConnectionString %>" SelectCommand="SELECT * FROM [userdata]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:localDB7ConnectionString %>" SelectCommand="SELECT * FROM [posts]"></asp:SqlDataSource>
        <br />
    </div>
    </form>
</body>
</html>
