using System;
using System.Web.UI;

namespace Lab03.Pages
{
    public partial class ResultadoDeCrearProvincia : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/ListaProvincias.aspx");
        }
    }
}
