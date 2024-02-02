<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoCompanias.aspx.cs" Inherits="MantenimientoCompanias" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            height: 21px;
            width: 62px;
        }
        .style4
        {
            width: 62px;
        }
        .style8
        {
            height: 21px;
            width: 153px;
        }
        .style9
        {
            width: 153px;
        }
        .style10
        {
            height: 21px;
            width: 94px;
        }
        .style11
        {
            width: 94px;
        }
    </style>
</head>
<body style="height: 641px">
    <form id="form1" runat="server">
    <div align="center" 
        
        
        
        style="background-position: center center; padding: 20px 0px 0px 0px; height: 931px; font-weight: bold; background-color: #FFFAFA;">
    
        &nbsp;Mantenimiento Compañias<br />
        <br />
        <table align="center" style="width: 25%; height: 153px;">
            <tr>
                <td align="justify" class="style10">
                    Nombre:</td>
                <td class="style8">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                <td class="style3">
                    <asp:Button ID="btnBuscar" runat="server" Font-Bold="True" 
                        Text="Buscar" OnClick="btnBuscar_Click" style="margin-left: 0px" /></td>
            </tr>
            <tr>
                <td align="justify" class="style11">
                    Dirección:</td>
                <td class="style9">
                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox></td>
                <td class="style4">
                </td>
            </tr>
            <tr>
                <td align="justify" class="style11">
                    Teléfono:</td>
                <td class="style9">
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></td>
                <td class="style4">
                </td>
            </tr>
            <tr>
                <td class="style11"></td>
                <td class="style9"></td>
                <td class="style4">
                    <asp:Button ID="btnLimpiar" runat="server" Font-Bold="True" OnClick="btnLimpiar_Click"
                        Text="Limpiar" style="margin-left: 0px" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAgregar" runat="server" Font-Bold="True" OnClick="btnAgregar_Click"
                        Text="Agregar" />
                    <asp:Button ID="btnModificar" runat="server" Font-Bold="True" 
                        Text="Modificar" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" Font-Bold="True" 
                        Text="Eliminar" OnClick="btnEliminar_Click" /></td>
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
