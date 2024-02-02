<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" 
        
        
        
        style="background-position: center center; height: 930px; width:1280; padding-top: 50px; font-weight: bold; background-color: #FFFAFA; vertical-align: middle; text-align: center;">
    
        PÁGINA PRINCIPAL<br />
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" 
            Font-Overline="False" Font-Underline="False" 
            PostBackUrl="~/MantenimientoCompanias.aspx">Mantenimiento de Compañias</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="False" 
            Font-Underline="False" PostBackUrl="~/MantenimientoTerminalNacional.aspx">Mantenimiento de las Terminales Nacionales</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="False" 
            Font-Underline="False" PostBackUrl="~/MantenimientoTerminalInternacional.aspx">Mantenimiento Terminales Internacionales</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="False" 
            Font-Underline="False" PostBackUrl="~/AgregarViaje.aspx">Agregar Viaje</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton5" runat="server" Font-Bold="False" 
            Font-Underline="False" PostBackUrl="~/ListadoTodasLasCompanias.aspx">Listar todas las Compañías</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton6" runat="server" Font-Bold="False" 
            Font-Underline="False" PostBackUrl="~/ListadoTerminales.aspx">Listar todas las Terminales</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton7" runat="server" Font-Bold="False" 
            Font-Underline="False" PostBackUrl="~/ListadoViajesTerminalMesAnio.aspx">Listar Viajes</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
