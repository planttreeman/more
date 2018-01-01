<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="pageLogin.aspx.cs" Inherits="pageLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
<asp:TextBox ID="txtUserName" runat="server" TabIndex="1"></asp:TextBox>
<br />
<asp:Label ID="Label2" runat="server" Text="密码"></asp:Label>
&nbsp;&nbsp;
<asp:TextBox ID="txtPWD" runat="server" TextMode="Password" TabIndex="2"></asp:TextBox>
<br />
<asp:Button ID="btnLogin" runat="server" Text="登  录" onclick="btnLogin_Click" 
        TabIndex="3" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnEsc" runat="server" Text="取  消" onclick="btnEsc_Click" 
        TabIndex="4" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:LinkButton ID="lkbtn_pageReg" runat="server" onclick="lkbtn_pageReg_Click">未注册，跳转到注册页面</asp:LinkButton>
</asp:Content>

