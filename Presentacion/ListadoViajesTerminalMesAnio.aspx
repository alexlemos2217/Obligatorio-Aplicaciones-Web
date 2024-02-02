<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoViajesTerminalMesAnio.aspx.cs" Inherits="ListadoViajesTerminalMesAnio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 747px">
    <form id="form1" runat="server">
    <div align="center" style="height: 930px; background-color: #FFFAFA;">
    
        <strong>
        <br />
        Listado Viajes<br />
        <br />
        Seleccione una Terminal<br />
        <asp:DropDownList ID="ddlTerminales" runat="server" AutoPostBack="True" 
            Width="160px">
            <asp:ListItem>--------------------------------</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblFecha" runat="server" Text="Ingrese una fecha"></asp:Label>
        <br />
        <asp:TextBox ID="txtFecha" runat="server" style="margin-top: 0px" Width="155px"></asp:TextBox>
        <br />
        </strong>
        <br />
        <asp:GridView ID="gvViajesTerminal" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
            CellPadding="4" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="CodigoViaje" HeaderText="CÓDIGO VIAJE" />
                <asp:BoundField DataField="FechaHoraSalida" HeaderText="SALIDA" />
                <asp:BoundField DataField="FechaHoraLlegada" HeaderText="LLEGADA" />
                <asp:BoundField DataField="MaxPasajeros" HeaderText="PASAJEROS" />
                <asp:BoundField DataField="PrecioBoleto" HeaderText="PRECIO" />
                <asp:BoundField DataField="Anden" HeaderText="ANDEN" />
                <asp:BoundField DataField="ViajeTerm.Codigo" HeaderText="TERMINAL" />
                <asp:BoundField DataField="ViajeComp.Nombre" HeaderText="COMPAÑÍA" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
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
        <br />
        <asp:Button ID="btnConsultar" runat="server" onclick="btnConsultar_Click" 
            Text="Consultar" />
        <br />
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
