using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using Lab03.Data;

namespace Lab03
{
    public partial class _ListaProvincias : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
            }
        }

        private void CargarProvincias()
        {
            using (var db = new PV2024C2_Lab03Entities())
            {
                // Ejecuta el procedimiento almacenado y convierte los resultados en una lista
                var provincias = db.Database.SqlQuery<spConsultarProvincias_Result>("spConsultarProvincias").ToList();

                // Enlaza el resultado al GridView
                GridViewProvincias.DataSource = provincias;
                GridViewProvincias.DataBind();
            }
        }

    }
}
