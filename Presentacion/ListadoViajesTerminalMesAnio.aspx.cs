using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using EntidadesCompartidas;
using Logica;

public partial class ListadoViajesTerminalMesAnio : System.Web.UI.Page
{
    // ================== PAGE LOAD ================== //
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        try
        {
            if (!IsPostBack)
            {
                txtFecha.Attributes.Add("type", "month");

                CargarDropDownListTerminales();

            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    // ================== CARGAR DROP DOWN LIST TERMINALES ================== //
    private void CargarDropDownListTerminales()
    {
        List<Terminal> colTerminales = LogicaTerminales.ListarTerminales();

        foreach (Terminal terminal in colTerminales)
        {
            ddlTerminales.Items.Add(new ListItem(terminal.Codigo));
        }
    }

    // ================== BOTÓN CONSULTAR ================== //
    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            #region EXCEPCIONES

            if (ddlTerminales.SelectedIndex == 0)
            {
                gvViajesTerminal.DataSource = null;
                gvViajesTerminal.DataBind();
                throw new Exception("Seleccione una terminal");
            }
            else if (string.IsNullOrWhiteSpace(txtFecha.Text))
            {
                throw new Exception("Debe seleccionar la fecha");
            }

            #endregion

            string codigoTerminal = ddlTerminales.SelectedItem.Value;
            string fechaSeleccionada = txtFecha.Text;

            int mes = Convert.ToInt32(fechaSeleccionada.Split('-')[1]);
            int anio = Convert.ToInt32(fechaSeleccionada.Split('-')[0]);

            List<Viaje> colViajes = LogicaViajes.ListarViajesPorTerminalMesAnio(codigoTerminal, mes, anio);

            gvViajesTerminal.DataSource = colViajes;
            gvViajesTerminal.DataBind();

            if (colViajes.Count == 0)
            {
                throw new Exception("No se registraron viajes");
            }

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}