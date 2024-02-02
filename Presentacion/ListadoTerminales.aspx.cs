using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using Logica;
using EntidadesCompartidas;


public partial class ListadoTerminales : System.Web.UI.Page
{
    // ================== PAGE LOAD ================== //
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";

            if (!IsPostBack)
            {
                List<Terminal> colTerminales = LogicaTerminales.ListarTerminales();
                Session["TodasLasTerminales"] = colTerminales;

                if (colTerminales.Count == 0)
                {
                    ddlOpciones.Enabled = false;
                    throw new Exception("No hay terminales disponibles");
                }
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    // ================== CARGAR GRILLA ================== //
    protected void ddlOpciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Terminal> colTerminales = (List<Terminal>)Session["TodasLasTerminales"];
            Session["TodasLasTerminales"] = colTerminales;

            gvTerminales.DataSource = null;
            gvTerminales.DataBind();

            if (ddlOpciones.SelectedIndex == 0)
            {
                throw new Exception("Seleccione una opción");
            }

            List<object> terminalesFiltradas = new List<object>();

            foreach (Terminal t in colTerminales)
            {
                if ((ddlOpciones.SelectedIndex == 1 && t is Internacional) ||
                    (ddlOpciones.SelectedIndex == 2 && t is Nacional))
                {
                    if (t is Nacional)
                    {
                        Nacional nacional = (Nacional)t;
                        terminalesFiltradas.Add(new
                        {
                            Codigo = nacional.Codigo,
                            Ciudad = nacional.Ciudad,
                            Taxi = nacional.Taxi ? "Tiene servicio de taxis" : "No tiene servicio de taxis"
                        });
                    }
                    else
                    {
                        Internacional internacional = (Internacional)t;
                        terminalesFiltradas.Add(new
                        {
                            Codigo = internacional.Codigo,
                            Ciudad = internacional.Ciudad,
                            pais = internacional.Pais
                        });
                    }
                }
                Session["TerminalesFiltradas"] = terminalesFiltradas;
            }

            gvTerminales.DataSource = terminalesFiltradas;

            // Ocultar o mostrar las columnas
            gvTerminales.Columns[2].Visible = (ddlOpciones.SelectedIndex == 1); // Muestra la columna "Pais"
            gvTerminales.Columns[3].Visible = (ddlOpciones.SelectedIndex == 2); // Muestra la columna "Taxi"

            gvTerminales.DataBind();

            if (gvTerminales.Rows.Count == 0)
            {
                lblError.ForeColor = Color.Blue;
                lblError.Text = "No hay terminales " + (ddlOpciones.SelectedIndex == 1 ? "Internacionales" : "Nacionales") + " para mostrar";
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    // ================== PAGINADO GRILLA ================== //
    protected void gvTerminales_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTerminales.PageIndex = e.NewPageIndex;
        gvTerminales.DataSource = (List<object>)Session["TerminalesFiltradas"];
        gvTerminales.DataBind();

        gvTerminales.SelectedIndex = -1;
    }
}