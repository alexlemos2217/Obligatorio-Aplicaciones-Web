<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoTerminalInternacional.aspx.cs" Inherits="MantenimientoTerminalInternacional" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .style1
        {
            height: 21px;
            width: 39px;
        }
        .style2
        {
            width: 39px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <div align="center" 
        
        
        style="padding: 20px 0px 0px 0px; height: 930px; font-weight: bold; background-color: #FFFAFA;">
    
        &nbsp;Mantenimiento Terminales Internacionales<br />
        <br />
        <table align="center" style="width: 32%;">
            <tr>
                <td style="width: 94px; height: 21px">
                    Codigo:</td>
                <td class="style1">
                    <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox></td>
                <td style="width: 100px; height: 21px">
                    <asp:Button ID="btnBuscar" runat="server" Font-Bold="True" 
                        Text="Buscar" OnClick="btnBuscar_Click" style="margin-left: 0px" /></td>
            </tr>
            <tr>
                <td style="width: 94px">
                    Ciudad:</td>
                <td class="style2">
                    <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 94px">
                    País:</td>
                <td class="style2">
                    <asp:TextBox ID="txtPais" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAgregar" runat="server" Font-Bold="True" OnClick="btnAgregar_Click"
                        Text="Agregar" />
                    <asp:Button ID="btnModificar" runat="server" Font-Bold="True" 
                        Text="Modificar" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" Font-Bold="True" 
                        Text="Eliminar" OnClick="btnEliminar_Click" /></td>
                <td colspan="1">
                    <asp:Button ID="btnLimpiar" runat="server" Font-Bold="True" OnClick="btnLimpiar_Click"
                        Text="Limpiar" style="margin-left: 0px" />
                </td>
            </tr>
        </table>
    
        <br />
        <asp:Label ID="lblError" runat="server" Font-Bold="False"></asp:Label>
        &nbsp;<br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx" 
            Font-Bold="False" Font-Underline="False">Volver</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
