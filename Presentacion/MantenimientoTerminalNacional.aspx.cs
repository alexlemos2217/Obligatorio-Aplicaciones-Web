using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using System.Drawing;
using EntidadesCompartidas;

public partial class MantenimientoTerminalNacional : System.Web.UI.Page
{
    // ================== PAGE LOAD ================== //
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        if (!IsPostBack)
        {
            LimpioFormulario();
        }
    }

    // ================== LIMPIAR FORMULARIO ================== //
    private void LimpioFormulario()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnAgregar.Enabled = false;
        btnBuscar.Enabled = true;

        txtCodigo.Text = "";
        txtCodigo.Enabled = true;
        txtCiudad.Text = "";
        txtCiudad.Enabled = false;


        chkTaxi.Checked = false;
        chkTaxi.Enabled = false;
    }

    // ================== ACTIVAR BOTONES ================== //
    private void ActivoBotones(bool esAlta = true)
    {
        btnModificar.Enabled = !esAlta;
        btnEliminar.Enabled = !esAlta;
        btnAgregar.Enabled = esAlta;
        btnBuscar.Enabled = false;

        txtCodigo.Enabled = false;
        txtCiudad.Enabled = true;

        chkTaxi.Enabled = true;
    }

    // ================== BOTÓN LIMPIAR ================== //
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioFormulario();
    }

    // ================== BOTÓN BUSCAR ================== //
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text.Trim()))
            {
                throw new Exception("El código no puede estar vacío");
            }

            string codigo = txtCodigo.Text.Trim();

            Terminal ter = LogicaTerminales.Buscar(codigo);

            if (ter != null)
            {
                if (ter is Nacional)
                {
                    txtCiudad.Text = ter.Ciudad;
                    chkTaxi.Checked = ((Nacional)ter).Taxi;

                    ActivoBotones(false);

                    Session["UnaTerNacional"] = ter;
                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "La terminal no es Nacional";

                    Session["UnaTerNacional"] = null;
                }
            }
            else
            {
                ActivoBotones();

                lblError.ForeColor = Color.Blue;
                lblError.Text = "No hay terminales nacionales registradas con ese código";

                Session["UnaTerNacional"] = null;
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    // ================== BOTÓN AGREGAR ================== //
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();
            bool taxi = chkTaxi.Checked;

            Nacional nacional = new Nacional(codigo, ciudad, taxi);

            LogicaTerminales.Agregar(nacional);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Alta con éxito";

            LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
             lblError.Text = ex.Message;
        }
    }

    // ================== BOTÓN MODIFICAR ================== //
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Nacional nacional = (Nacional)Session["UnaTerNacional"];

            nacional.Ciudad = txtCiudad.Text.Trim();
            nacional.Taxi = chkTaxi.Checked;

            LogicaTerminales.Modificar(nacional);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Modificación exitosa";

            LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    // ================== BOTÓN ELIMINAR ================== //
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Nacional nacional = (Nacional)Session["UnaTerNacional"];

            LogicaTerminales.Eliminar(nacional);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Eliminación exitosa";

            LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}