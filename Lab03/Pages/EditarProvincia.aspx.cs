using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Lab03.Data;

namespace Lab03
{
    public partial class EditarProvincia : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el ID de la provincia desde la URL
                string idProvinciaStr = Request.QueryString["id"];
                if (int.TryParse(idProvinciaStr, out int idProvincia))
                {
                    CargarProvincia(idProvincia);
                }
            }
        }

        //private void CargarProvincia(int idProvincia)
        //{
        //    using (var db = new PV2024C2_Lab03Entities())
        //    {
        //        // Usar el procedimiento almacenado para consultar la provincia
        //        var provincia = db.spConsultarProvinciaPorId(idProvincia).FirstOrDefault();
        //        if (provincia != null)
        //        {
        //            // Asignar valores a los controles
        //            txtID.Text = idProvincia.ToString();
        //            txtProvincia.Text = provincia.ToString();
        //        }
        //        else
        //        {
        //            // Si no se encuentra la provincia, redirige de vuelta a la lista
        //            Response.Redirect("ListaProvincias.aspx");
        //        }
        //    }
        //}

        private void CargarProvincia(int idProvincia)
        {
            using (var db = new PV2024C2_Lab03Entities())
            {
                // Usar el procedimiento almacenado para consultar la provincia
                var provincia = db.spConsultarProvinciaPorId(idProvincia).FirstOrDefault();
                if (provincia != null)
                {
                    // Asignar valores a los controles
                    txtID.Text = idProvincia.ToString();

                    // Asignar el nombre de la provincia al TextBox correspondiente
                    txtProvincia.Text = provincia.nombre; // Asegúrate de que "nombre" es la propiedad correcta
                }
                else
                {
                    // Si no se encuentra la provincia, redirige de vuelta a la lista
                    Response.Redirect("ListaProvincias.aspx");
                }
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Lista de nombres válidos de provincias sin tildes, en formato minúscula
            List<string> provinciasValidas = new List<string>
    {
        "san jose", "alajuela", "cartago", "heredia", "guanacaste", "puntarenas", "limon"
    };

            try
            {
                using (var db = new PV2024C2_Lab03Entities())
                {
                    // Validar el ID de la provincia
                    if (string.IsNullOrWhiteSpace(txtID.Text) || !int.TryParse(txtID.Text, out int idProvincia))
                    {
                        ShowMessage("El ID de la provincia no es válido.");
                        return;
                    }

                    // Limitar la longitud del nombre de la provincia a 50 caracteres
                    string nombreProvincia = txtProvincia.Text.Trim();

                    if (string.IsNullOrWhiteSpace(nombreProvincia))
                    {
                        ShowMessage("El nombre de la provincia es obligatorio.");
                        return;
                    }

                    // Validar la longitud máxima permitida
                    if (nombreProvincia.Length > 50)
                    {
                        ShowMessage("El nombre de la provincia no debe exceder los 50 caracteres.");
                        return;
                    }

                    // Convertir el nombre ingresado a minúsculas para comparar sin distinción de mayúsculas y minúsculas
                    string nombreProvinciaNormalizado = nombreProvincia.ToLower();

                    // Validar si el nombre ingresado está en la lista de provincias válidas
                    if (!provinciasValidas.Contains(nombreProvinciaNormalizado))
                    {
                        ShowMessage("El nombre de la provincia no es válido. Las provincias válidas son: San Jose, Alajuela, Cartago, Heredia, Guanacaste, Puntarenas, Limon.");
                        return;
                    }

                    // Llamar al procedimiento almacenado para editar la provincia
                    db.spEditarProvincia(idProvincia, nombreProvincia, "Activo");  // Estado predeterminado "Activo"

                    // Mostrar mensaje de éxito
                    ShowMessage("Provincia editada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                ShowMessage("Error al editar la provincia: " + ex.Message);
            }
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new PV2024C2_Lab03Entities())
                {
                    int idProvincia = int.Parse(txtID.Text);

                    // Llamar al procedimiento almacenado para eliminar la provincia
                    db.spEliminarProvincia(idProvincia);

                    // Mostrar mensaje de éxito
                    ShowMessage("Provincia eliminada exitosamente.");

                    // Redirige de vuelta a la lista de provincias tras eliminar
                    Response.Redirect("ListaProvincias.aspx");
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                ShowMessage("Error al eliminar la provincia: " + ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Simplemente redirige a la lista de provincias sin hacer cambios
            Response.Redirect("ListaProvincias.aspx");
        }

        private void ShowMessage(string message)
        {
            // Mostrar un alert en la página web
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
        }
    }
}
