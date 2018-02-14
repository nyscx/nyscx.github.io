<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Food.aspx.cs" Inherits="updateFood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bodyCPH" runat="Server">
    <asp:Panel Visible="false" ID="alert" runat="server" Style="box-shadow: 10px 10px black; position: absolute; top: 50%; text-align: center; min-width: 35%; min-height: 5%; background-color: salmon; z-index: 1;">
        <p>Try to eat in moderation!</p>
        <b>
            <p>You have exceeded the recommended daily intake based on your stats for: </p>
        </b>
        <asp:Label ID="exceeded" runat="server"></asp:Label><br />
        <br />
        <asp:Button runat="server" ID="exceedClear" runat="server" Text="OK" OnClick="exceedClear_click" />
        <br />
        <br />
    </asp:Panel>
    <asp:Panel Visible="false" ID="shadow" runat="server" Style="position: absolute; min-width: 100%; min-height: 100%; background-color: black; z-index: 2;">
    </asp:Panel>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <asp:Panel ID="popup_clear" Visible="false" Style="text-align: center; background-color: white; z-index: 3; position: absolute; top: 35%; left: 40%; min-height: 100px; min-width: 400px;" runat="server">
        <br />
        Are you sure you want to clear your food list?
        <br />
        <br />
        <asp:Table Width="100%">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button runat="server" ID="yesClear" OnClick="yesClearClick" Text="Yes" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button runat="server" ID="noClear" OnClick="noClearClick" Text="No" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <asp:Panel ID="popup_save" Visible="false" Style="text-align: center; background-color: white; z-index: 3; position: absolute; top: 35%; left: 40%; min-height: 100px; min-width: 400px;" runat="server">
        <br />
        Are you sure you want to add items to your food list?
        <br />
        <br />
        <asp:Table Width="100%">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button runat="server" ID="save_yes" OnClick="save_yes_Click" Text="Yes" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button runat="server" ID="save_no" OnClick="noClearClick" Text="No" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <div style="background-color: papayawhip" id="mainCph" runat="server">
        <asp:Table Width="100%" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="chooseFood">
                    </asp:DropDownList>
                    <asp:Button runat="server" ID="submit" CausesValidation="false" OnClick="submit_Click" Text="Add to Food Intake" />
                    <asp:Button ID="saveFood" runat="server" OnClick="saveFood_Click" Text="Save Food List" Enabled="false" />
                    <asp:Button ID="clearFood" runat="server" OnClick="clearFood_Click" Text="Clear Food List" Enabled="false" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table runat="server" Width="30%" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="4" HorizontalAlign="Center">
                    <asp:Label runat="server" ID="selectedFood" CssClass="calorieInfo"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Calories:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="calories" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Saturated Fat:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="satFat" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Polyunsaturated Fat:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="polyFat" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Monounsaturated Fat:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="monoFat" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Trans Fat:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="transFat" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Total Fat:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="tFat" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Sodium:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="sodium" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Cholesterol:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="cholesterol" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Protein:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="protein" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Sugar:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="sugar" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Dietary Fibre:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="dFibre" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Vitamin A:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="vitA" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Vitamin C:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="vitC" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Calcium:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="calcium" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Iron:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="iron" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Total Carbohydrates:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="carbs" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Potassium:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="potassium" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                </asp:TableCell></asp:TableRow></asp:Table><asp:Table Width="100%" runat="server">
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell Width="10%" HorizontalAlign="Right">
                </asp:TableCell><asp:TableCell Width="80%" HorizontalAlign="Center">
                <asp:Label CssClass="calorieInfo" runat="server" Text="Total Nutrients Intake: "></asp:Label>
                </asp:TableCell><asp:TableCell Width="10%" HorizontalAlign="Left">
                </asp:TableCell><asp:TableCell />
            </asp:TableRow>
        </asp:Table>

        <asp:Table runat="server" Width="30%" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Calories:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="totalCal" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Saturated Fat:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="totalSatFat" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Polyunsaturated Fat:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalPolyFat" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Monounsaturated Fat:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalMonoFat" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Trans Fat:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalTransFat" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Total Fat:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalFat" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Sodium:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalSodium" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Cholesterol:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalCholesterol" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Protein:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalProtein" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Sugar:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalSugar" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Dietary Fibre:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalDFibre" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Vitamin A:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalVitA" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Vitamin C:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalVitC" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Calcium:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalCalcium" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Iron:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalIron" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Total Carbohydrates:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalCarb" Text="0" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                <asp:Label runat="server" Text="Potassium:" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                    <asp:Label runat="server" ID="TotalPotassium" Text="0" />
                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                </asp:TableCell><asp:TableCell HorizontalAlign="Left">
                </asp:TableCell></asp:TableRow></asp:Table></div><div id="chosen">
        <div id="b" style="float:left; min-width:45%;">
            <br />
        <b><span>You are adding:</span></b> <asp:Label runat="server" Visible="true" ID="whatIate"></asp:Label></div><div id="a" style="float:left; min-width: 55%; max-height:30%; overflow:auto;">
            <br />
            <b><span>You already had</span></b> <asp:GridView ID="foodintake" runat="server" Width="60%" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Food" HeaderText="Food" NullDisplayText="0" />
                    <asp:BoundField DataField="Qty" HeaderText="Qty" NullDisplayText="0" />
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
            <asp:Label Visible="false" runat="server" ID="fromDB"></asp:Label></div></div></asp:Content>