using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Logica;
using EntidadesCompartidas;

public partial class ListadoTodasLasCompanias : System.Web.UI.Page
{
    // ================== PAGE LOAD ================== //
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        try
        {
            if (!IsPostBack)
            {
                List<Compania> colCompanias = LogicaCompanias.ListarCompanias();
                Session["TodasLasCompanias"] = colCompanias;

                if (colCompanias.Count > 0)
                {
                    gvCompanias.DataSource = colCompanias;
                    gvCompanias.DataBind();
                }
                else
                    throw new Exception("No hay compañías disponibles");
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    // ================== PAGINADO DE LA GRILLA ================== //
    protected void gvCompanias_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvCompanias.PageIndex = e.NewPageIndex;
            gvCompanias.DataSource = (List<Compania>)Session["TodasLasCompanias"];
            gvCompanias.DataBind();

            gvCompanias.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}