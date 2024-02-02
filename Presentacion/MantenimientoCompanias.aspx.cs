using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using System.Drawing;
using EntidadesCompartidas;


public partial class MantenimientoCompanias : System.Web.UI.Page
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

        txtNombre.Text = "";
        txtNombre.Enabled = true;
        txtDireccion.Text = "";
        txtDireccion.Enabled = false;
        txtTelefono.Text = "";
        txtTelefono.Enabled = false;
    }

    // ================== ACTIVAT BOTONES ================== //
    private void ActivoBotones(bool esAlta = true)
    {
        btnModificar.Enabled = !esAlta;
        btnEliminar.Enabled = !esAlta;
        btnAgregar.Enabled = esAlta;
        btnBuscar.Enabled = false;

        txtNombre.Enabled = false;
        txtDireccion.Enabled = true;
        txtTelefono.Enabled = true;
    }

    // ================== BOTÓN LIMPIAR ================== //
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioFormulario();
    }

    // ================== BOTÓN BUSCAR================== //
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text.Trim()))
            {
                throw new Exception("El nombre no puede estar vacío");
            }

            string nombre = txtNombre.Text.Trim();

            Compania comp = LogicaCompanias.Buscar(nombre);

            if (comp != null)
            {
                txtDireccion.Text = comp.Direccion;
                txtTelefono.Text = comp.Telefono;

                ActivoBotones(false);

                Session["UnaCompania"] = comp;
            }
            else
            {
                ActivoBotones();

                lblError.ForeColor = Color.Blue;
                lblError.Text = "No hay compañías registradas con ese nombre";

                Session["UnaCompania"] = null;
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
            string nombre = txtNombre.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            if (telefono == "00000000" || telefono == "000000000")
            {
                throw new Exception("El teléfono no puede ser cero");
            }

            Compania comp = new Compania(nombre, direccion, telefono);

            LogicaCompanias.Agregar(comp);

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
            Compania compania = (Compania)Session["UnaCompania"];

            compania.Direccion = txtDireccion.Text.Trim();
            compania.Telefono = txtTelefono.Text.Trim();


            if (compania.Telefono == "00000000" || compania.Telefono == "000000000")
            {
                throw new Exception("El teléfono no puede ser cero");
            }

            LogicaCompanias.Modificar(compania);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Modificación con éxito";

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
            Compania compania = (Compania)Session["UnaCompania"];

            LogicaCompanias.Eliminar(compania);

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