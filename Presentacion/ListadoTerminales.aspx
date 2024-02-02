<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoTerminales.aspx.cs" Inherits="ListadoTerminales" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 615px">
    <form id="form2" runat="server">
    <div style="text-align: center; height: 930px; background-color: #FFFAFA;">
        <strong>
        <br />
        Listado de Terminales</strong><br />
        <br />
        <div align="center">
            <asp:DropDownList ID="ddlOpciones" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlOpciones_SelectedIndexChanged">
                <asp:ListItem Value="-------------------------">-----------------------------</asp:ListItem>
                <asp:ListItem>INTERNACIONALES</asp:ListItem>
                <asp:ListItem>NACIONALES</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <div align="center">
            <asp:GridView ID="gvTerminales" runat="server" BackColor="White" 
                BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="5" 
                GridLines="Horizontal" AutoGenerateColumns="False" AllowPaging="True" 
                onpageindexchanging="gvTerminales_PageIndexChanging" 
                onselectedindexchanged="ddlOpciones_SelectedIndexChanged" Width="600px">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="CÓDIGO" />
                    <asp:BoundField DataField="ciudad" HeaderText="CIUDAD" />
                    <asp:BoundField DataField="pais" HeaderText="PAIS" />
                    <asp:BoundField DataField="taxi" HeaderText="TAXI" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" 
                    BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" 
                    Width="250px" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" 
                    VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        </div>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="lnkBtnVolver" runat="server" PostBackUrl="~/Default.aspx" 
            Font-Underline="False">Volver</asp:LinkButton>
    </div>
    </form>
</body>
</html>
