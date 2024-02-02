using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using System.Drawing;
using EntidadesCompartidas;

public partial class MantenimientoTerminalInternacional : System.Web.UI.Page
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
        txtPais.Text = "";
        txtPais.Enabled = false;
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
        txtPais.Enabled = true;
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
                if (ter is Internacional)
                {
                    txtCiudad.Text = ter.Ciudad;
                    txtPais.Text = ((Internacional)ter).Pais;

                    ActivoBotones(false);

                    Session["UnaTerInternacional"] = ter;
                }
                else
                {
                    lblError.ForeColor = Color.Blue;
                    lblError.Text = "La terminal no es Internacional";

                    Session["UnaTerInternacional"] = null;
                }
            }
            else
            {
                ActivoBotones();

                lblError.ForeColor = Color.Blue;
                lblError.Text = "No hay terminales internacionales registradas con ese código";

                Session["UnaTerInternacional"] = null;
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
            string pais = txtPais.Text.Trim();

            Internacional internacional = new Internacional(codigo, ciudad, pais);

            LogicaTerminales.Agregar(internacional);

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
            Internacional internacional = (Internacional)Session["UnaTerInternacional"];

            internacional.Ciudad = txtCiudad.Text.Trim();
            internacional.Pais = txtPais.Text.Trim();

            LogicaTerminales.Modificar(internacional);

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
            Internacional internacional = (Internacional)Session["UnaTerInternacional"];

            LogicaTerminales.Eliminar(internacional);

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