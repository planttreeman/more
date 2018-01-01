<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="pageReg.aspx.cs" Inherits="pageReg" %>

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
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    出生年月<br />
    <asp:Calendar ID="calBirthday" runat="server" BackColor="White" 
        BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" 
        Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" 
        Width="330px">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
            Height="8pt" />
        <DayStyle BackColor="#CCCCCC" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" 
            Font-Size="12pt" ForeColor="White" Height="12pt" />
        <TodayDayStyle BackColor="#999999" ForeColor="White" />
    </asp:Calendar>
    <br />
    <br />
    联系方式&nbsp; <asp:TextBox ID="txtUserPhone" runat="server" 
        TabIndex="2"></asp:TextBox>
    <br />
    <br />
    性别<asp:RadioButton ID="rbUserSex1" runat="server" Checked="True" Text="男" />
    <asp:RadioButton ID="rbUserSex2" runat="server" Text="女" />
    <br />
    <br />
    身份证号&nbsp;&nbsp;&nbsp; 
    <asp:TextBox ID="txtUserIDCard" runat="server" 
        TabIndex="2" Width="202px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnReg" runat="server" Text="注  册" onclick="btnReg_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnEsc" runat="server" Text="取  消" />
<br />

</asp:Content>

