<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyCPH" Runat="Server">
    <asp:Panel visible="false" id="shadow" runat="server" style="position:absolute; min-width:100%; min-height:100%; background-color:white; z-index:2;">
        <h1>Account created! You may log in now.</h1>
    </asp:Panel>
    <div id="centre" style="align-content:center;">
    <asp:Panel runat="server" DefaultButton="submitItem">
    <asp:Table runat="server" Width="100%" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                Username:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="username" Width="50%" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                Password:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox TextMode="Password" Width="50%" ID="password" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                Retype Password:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox TextMode="Password" ID="vPassword" Width="50%" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                Gender:
            </asp:TableCell>
            <asp:TableCell>
                <asp:RadioButtonList RepeatDirection="Horizontal" ID="gender" runat="server">
                    <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                    <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                </asp:RadioButtonList>
            </asp:TableCell>
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                Birthdate:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox TextMode="Date" ID="bday" Text="01/01/1999" Width="50%" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                Postal Code:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox MaxLength="6" ID="poscod" Width="50%" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                Email Address:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="email" Width="50%" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell RowSpan="3"><asp:Button ID="submitItem" runat="server" CssClass="mainbtType" OnClick="submitItem_Click" Text="Create Account" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        
        </asp:Panel>
        <asp:Label ID="errorMsg" runat="server"></asp:Label>
        </div>
</asp:Content>

