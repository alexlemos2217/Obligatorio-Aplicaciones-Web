<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoTodasLasCompanias.aspx.cs" Inherits="ListadoTodasLasCompanias" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 930px">
    <form id="form1" runat="server">
        <div align="center" 
            
            
            style="background-color: #FFFAFA; background-position: center center; height: 930px;">
            <br />
            <strong>Listado de Compañías</strong><br />
            <br />
            <asp:GridView ID="gvCompanias" runat="server" BackColor="White" 
                BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="5" 
                GridLines="Horizontal" AutoGenerateColumns="False" AllowPaging="True" 
                onpageindexchanging="gvCompanias_PageIndexChanging" Width="600px">
                <Columns>
                    <asp:BoundField DataField="nombre" HeaderText="NOMBRE" />
                    <asp:BoundField DataField="direccion" HeaderText="DIRECCIÓN" />
                    <asp:BoundField DataField="telefono" HeaderText="TELÉFONO" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" 
                    HorizontalAlign="Center" Width="150px" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" 
                    VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
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
