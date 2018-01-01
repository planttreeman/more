<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="newdkRoom.aspx.cs" Inherits="User_dkRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="ggd" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" AutoGenerateColumns="False" DataKeyNames="iRoomID" 
        Height="154px" Width="315px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="iRoomID" HeaderText="房间编号" />
            <asp:BoundField DataField="vcRoomClass" HeaderText="房间类型" />
            <asp:BoundField DataField="numRoomPrice" HeaderText="房间价格" />
            <asp:BoundField DataField="iRoomZT" HeaderText="房间状态" />
            <asp:HyperLinkField DataNavigateUrlFields="iRoomID" 
                DataNavigateUrlFormatString="~/User/pageBookRoom.aspx?iRoomID={0}" 
                HeaderText="预订房间" Text="预订" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/User/pageUserMenu.aspx">返回主界面</asp:HyperLink>
</asp:Content>

