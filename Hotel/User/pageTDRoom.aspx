<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="pageTDRoom.aspx.cs" Inherits="User_pageTDRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:FormView ID="fvWareDetail" runat="server">
        <ItemTemplate>
            <table class="clear" frame="border" lang="ady" style="width:100%;">
                <tr>
                    <td class="style3">
                        <p>
                            房间<span>编号</span></p>
                    </td>
                    <td class="style1">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("iRoomID") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <p>
                            房间价格</p>
                    </td>
                    <td class="style6">
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("numRoomPrice") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <p>
                            房间类型</p>
                    </td>
                    <td class="style6">
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("vcRoomClass") %>'></asp:Label>
                    </td>
                </tr>
            </table>
            <table class="clear" frame="border" lang="ady" style="width:100%;">
                <tr>
                    <td class="style5">
                        <p>
                            房间状态</p>
                    </td>
                    <td class="style6">
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("iRoomZT") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <asp:Label ID="Label7" runat="server" Text="用户ID"></asp:Label>
&nbsp;&nbsp;
    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label6" runat="server" Text="结束时间"></asp:Label>
&nbsp;&nbsp;
    <asp:TextBox ID="txtDateStart" runat="server"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <asp:Button ID="BtnCheckOut" runat="server" Text="结帐" 
        onclick="BtnCheckOut_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/User/pageUserMenu.aspx">返回主界面</asp:HyperLink>
    <br />
</asp:Content>

