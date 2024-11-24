using System;
using System.Collections.Generic;
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
            // Lista de nombres válidos de provincias sin tildes, en formato minúscula
            List<string> provinciasValidas = new List<string>
    {
        "san jose", "alajuela", "cartago", "heredia", "guanacaste", "puntarenas", "limon"
    };

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

            try
            {
                using (var context = new PV2024C2_Lab03Entities())
                {
                    DateTime fechaCreacion = DateTime.Now;

                    // Llamar al procedimiento almacenado para crear la provincia
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

