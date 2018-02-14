<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="HealthStatus.aspx.cs" EnableEventValidation="false" Inherits="HealthStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>My Health Status</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyCPH" runat="Server">
    <div style="text-align: center; align-items: center; align-content: center; float: none;">
        <h1>My Health Status</h1>
        <asp:label runat="server" visible="false" id="msg"></asp:label>
        <br />
        <div id="leftGridView" style="float: left; min-height:50%; min-width: 40%;">
            <asp:gridview id="gridv" onrowcommand="gridv_RowCommand" runat="server" autogeneratecolumns="False" backcolor="White" bordercolor="#DEDFDE" borderstyle="None" borderwidth="1px" cellpadding="4" forecolor="Black" gridlines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField HeaderText="Problems" DataField="HealthProblem" >
            <HeaderStyle Width="300px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button runat="server" OnClick="removeProblem" Text="Remove" />
                    </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:gridview><br /><br />
            <asp:table runat="server">
        <asp:TableRow>
            <asp:TableCell>I am suffering from: </asp:TableCell>
            <asp:TableCell>
            <asp:DropDownList ID="healthProb" runat="server"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
            <asp:Button ID="submit" runat="server" OnClick="submit_Click" Text="Update Selected to My Health Status" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:table>
        </div>
        <div id="rightNutrients" style="float: right; align-items:center; margin:auto; align-content:center; text-align:center; min-width: 100%;">
            <h1>How much should you eat?</h1>
            <asp:GridView ID="nutrients" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" CellSpacing="2">
                <Columns>
                    <asp:BoundField DataField="Calories" HeaderText="Calroies (kcal)" NullDisplayText="0" />
                    <asp:BoundField DataField="Carbohydrate" HeaderText="Carbohydrates (g)" />
                    <asp:BoundField DataField="SaturatedFat" HeaderText="Saturated Fat (g)" />
                    <asp:BoundField DataField="PolyunsaturatedFat" HeaderText="Polyunsaturated Fat (g)" />
                    <asp:BoundField DataField="MonounsaturatedFat" HeaderText="Monounsaturated Fat (g)" />
                    <asp:BoundField DataField="TransFat" HeaderText="Trans Fat (g)" />
                    <asp:BoundField DataField="TotalFat" HeaderText="Total Fat (g)" />
                    <asp:BoundField DataField="Sodium" HeaderText="Sodium (mg)" />
                    <asp:BoundField DataField="Potassium" HeaderText="Potassium (mg)" />
                    <asp:BoundField DataField="Cholesterol" HeaderText="Cholesterol (g)" />
                    <asp:BoundField DataField="Protein" HeaderText="Protein (g)" />
                    <asp:BoundField DataField="Sugar" HeaderText="Sugar (g)" />
                    <asp:BoundField DataField="DietaryFibre" HeaderText="Dietary Fibre (g)" />
                    <asp:BoundField DataField="VitA" HeaderText="Vitamin A (mg)" />
                    <asp:BoundField DataField="VitC" HeaderText="Vitamin C" />
                    <asp:BoundField DataField="Calcium" HeaderText="Calcium (mg)" />
                    <asp:BoundField DataField="Iron" HeaderText="Iron (mg)" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
            <h1>What I ate</h1>
            <asp:GridView ID="foodintake" runat="server" Width="50%" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Food" HeaderText="Food" NullDisplayText="0" />
                    <asp:BoundField DataField="Qty"  HeaderText="Qty" NullDisplayText="0" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
</div>
        <br />
       
        </div>
</asp:Content>

