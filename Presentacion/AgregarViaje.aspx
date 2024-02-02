<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgregarViaje.aspx.cs" Inherits="AgregarViaje" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 21px;
            width: 130px;
        }
        .style2
        {
            width: 130px;
        }
        .style3
        {
            height: 21px;
            width: 229px;
        }
        .style4
        {
            width: 229px;
        }
        .style5
        {
            width: 130px;
            height: 26px;
        }
        .style6
        {
            width: 229px;
            height: 26px;
        }
    </style>
</head>
<body style="height: 641px">
    <form id="form1" runat="server">
    <div align="center" 
        
        
        style="padding: 20px 0px 0px 0px; height: 930px; font-weight: bold; background-color: #FFFAFA;">
    
        Agregar Viaje<br />
        <br />
        <table align="center" style="width: 17%;">
            <tr>
                <td class="style1" align="justify">
                    Compañía:</td>
                <td class="style3">
                    <asp:DropDownList ID="ddlCompanias" runat="server" AutoPostBack="True" 
                        Height="25px" Width="160px">
                        <asp:ListItem Value="-------------------------">-------------------------------------</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="justify">
                    Terminal:</td>
                <td class="style4">
                    <asp:DropDownList ID="ddlTerminales" runat="server" Height="25px" Width="160px" 
                        AutoPostBack="True">
                        <asp:ListItem>-------------------------------------</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="justify">
                    Salida:</td>
                <td class="style4">
                    <asp:TextBox ID="txtSalida" runat="server" Width="155px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style5" align="justify">Llegada:</td>
                <td class="style6">
                    <asp:TextBox ID="txtLlegada" runat="server" Width="155px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style2" align="justify">Pasajeros:</td>
                <td class="style4">
                    <asp:TextBox ID="txtPasajeros" runat="server" Width="155px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style2" align="justify">Precio:</td>
                <td class="style4">
                    <asp:TextBox ID="txtPrecio" runat="server" Width="155px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style2" align="justify">Anden:</td>
                <td class="style4">
                    <asp:TextBox ID="txtAnden" runat="server" Width="155px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="style2" align="center"></td>
                <td class="style2" align="center">
                    <asp:Label ID="lblError" runat="server" Font-Bold="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnAgregar" runat="server" Font-Bold="True" OnClick="btnAgregar_Click"
                        Text="Agregar" />
                    </td>
            </tr>
        </table>
    
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx" 
            Font-Bold="False" Font-Underline="False">Volver</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
