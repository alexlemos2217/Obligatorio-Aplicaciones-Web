using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using EntidadesCompartidas;
using Logica;

public partial class AgregarViaje : System.Web.UI.Page
{
    // ================== PAGE LOAD ================== //
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        try
        {
            if (!IsPostBack)
            {
                txtSalida.Attributes.Add("type", "datetime-local");
                txtLlegada.Attributes.Add("type", "datetime-local");

                CargarDropDownListCompanias();

                CargarDropDownListTerminales();
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    // ================== LIMPIAR FORMULARIO ================== //
    private void LimpioFormulario()
    {
        txtSalida.Text = "";
        txtLlegada.Text = "";
        txtAnden.Text = "";
        txtPasajeros.Text = "";
        txtPrecio.Text = "";
    }

    // ================== CARGAR DROP DOWN LIST COMPAÑÍAS ================== //
    private void CargarDropDownListCompanias()
    {

        List<Compania> colCompanias = LogicaCompanias.ListarCompanias();

        foreach (Compania compania in colCompanias)
        {
            ddlCompanias.Items.Add(new ListItem(compania.Nombre));
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

    // ================== BOTON AGREGAR ================== //
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            #region EXCEPCIONES

            if (ddlCompanias.SelectedIndex == 0)
            {
                throw new Exception("Seleccione una compañía");
            }
            else if (ddlTerminales.SelectedIndex == 0)
            {
                throw new Exception("Seleccione una terminal");
            }
            else if (string.IsNullOrWhiteSpace(txtSalida.Text) || string.IsNullOrWhiteSpace(txtLlegada.Text))
            {
                throw new Exception("Seleccione una fecha");
            }
            else if (string.IsNullOrWhiteSpace(txtPasajeros.Text))
            {
                throw new Exception("Debe ingresar la cantidad de pasajeros");
            }
            else if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                throw new Exception("Debe ingresar el precio del boleto");
            }
            else if (string.IsNullOrWhiteSpace(txtAnden.Text))
            {
                throw new Exception("Debe ingresar el número de anden");
            }

            #endregion

            DateTime fechaSalida = Convert.ToDateTime(txtSalida.Text);
            DateTime fechaLlegada = Convert.ToDateTime(txtLlegada.Text);
            int pasajeros = Convert.ToInt32(txtPasajeros.Text);
            double precio = Convert.ToDouble(txtPrecio.Text);
            int anden = Convert.ToInt32(txtAnden.Text);

            string codigoTerminal = ddlTerminales.SelectedValue.ToUpper();
            string nombreCompania = ddlCompanias.SelectedValue.ToUpper();

            Terminal terminal = LogicaTerminales.Buscar(codigoTerminal);
            Compania compania = LogicaCompanias.Buscar(nombreCompania);


            Viaje viaje = new Viaje(0, fechaSalida, fechaLlegada, pasajeros, precio, anden, terminal, compania);

            int numeroViaje = LogicaViajes.Agregar(viaje);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Alta con éxito. Número de viaje: " + numeroViaje;

            LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}