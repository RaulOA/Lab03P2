using System;
using System.Web.UI;
using Lab03.Data;

namespace Lab03
{
    public partial class _CrearProvincia : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProvincia.Text))
            {
                ShowMessage("El nombre de la provincia es obligatorio.");
                return;
            }

            try
            {
                using (var context = new PV2024C2_Lab03Entities())
                {
                    string nombreProvincia = txtProvincia.Text.Trim();
                    DateTime fechaCreacion = DateTime.Now;

                    context.spCrearProvincia(nombreProvincia, fechaCreacion);
                }

                // Redirigir a la página de resultado después de crear la provincia
                Response.Redirect("~/Pages/ResultadoDeCrearProvincia.aspx");
            }
            catch (Exception ex)
            {
                ShowMessage("Ocurrió un error al crear la provincia. Por favor, intente nuevamente.");
                LogError(ex);
            }
        }


        private void ShowMessage(string message)
        {
            // Método para mostrar mensajes al usuario
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
        }

        private void LogError(Exception ex)
        {
            // Implementar lógica de registro de errores (puede ser en base de datos, archivo de log, etc.)
            // Ejemplo simple: Console.WriteLine(ex.ToString());
        }
    }
}

