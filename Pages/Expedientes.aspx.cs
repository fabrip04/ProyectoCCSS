using ProyectoCCSS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoCCSS.Pages
{
    public partial class Expedientes : System.Web.UI.Page
    {
        // Método para cargar los expedientes en el GridView
        private void CargarExpedientes()
        {
            using (var contexto = new CCSSDatosEntities())
            {
                var expedientes = from e in contexto.Expedientes
                                  join p in contexto.Pacientes on e.ID_Paciente equals p.ID_Paciente
                                  join m in contexto.PersonalMedico on e.ID_Medico equals m.ID_Medico
                                  select new
                                  {
                                      e.ID_Expediente,
                                      Paciente = p.Nombre + " " + p.Apellido,
                                      Medico = m.Nombre + " " + m.Apellido,
                                      e.Diagnostico,
                                      e.Tratamiento,
                                      e.Resultados_Pruebas,
                                      e.Fecha_Creacion,
                                      e.ID_Paciente,  // Añadir esta propiedad
                                      e.ID_Medico     // Añadir esta propiedad
                                  };

                // Asegúrate de que el GridView reciba estos campos
                GridViewExpedientes.DataSource = expedientes.ToList();
                GridViewExpedientes.DataBind();
            }
        }

        // Método para agregar un nuevo expediente
        protected void btnAgregarExpediente_Click(object sender, EventArgs e)
        {
            // Validar los campos antes de proceder con el registro
            if (string.IsNullOrEmpty(txtIDPaciente.Text) || string.IsNullOrEmpty(txtIDMedico.Text) ||
                string.IsNullOrEmpty(txtDiagnostico.Text) || string.IsNullOrEmpty(txtTratamiento.Text) ||
                string.IsNullOrEmpty(txtResultadosPruebas.Text) || string.IsNullOrEmpty(txtFechaCreacion.Text))
            {
                lblMensaje.Text = "Todos los campos son obligatorios."; // Mostrar mensaje de error
                lblMensaje.ForeColor = System.Drawing.Color.Red; // Puedes personalizar el color si lo deseas
                return; // Salir del método si los campos están vacíos
            }

            DateTime fechaCreacion;
            int idPaciente;
            int idMedico;

            // Intentar parsear los valores
            if (!DateTime.TryParse(txtFechaCreacion.Text, out fechaCreacion) ||
                !int.TryParse(txtIDPaciente.Text, out idPaciente) ||
                !int.TryParse(txtIDMedico.Text, out idMedico))
            {
                lblMensaje.Text = "Fecha de creación o IDs inválidos."; // Mensaje de error si no se puede convertir
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return; // Salir si hay errores con los valores ingresados
            }

            try
            {
                using (var contexto = new CCSSDatosEntities())
                {
                    // Agregar los datos directamente en la base de datos sin crear un objeto de Expediente explícito
                    contexto.Database.ExecuteSqlCommand(
                        "INSERT INTO Expedientes (ID_Paciente, ID_Medico, Diagnostico, Tratamiento, Resultados_Pruebas, Fecha_Creacion) " +
                        "VALUES ({0}, {1}, {2}, {3}, {4}, {5})",
                        idPaciente, idMedico, txtDiagnostico.Text, txtTratamiento.Text, txtResultadosPruebas.Text, fechaCreacion
                    );

                    // Guardar los cambios en la base de datos
                    contexto.SaveChanges();
                }

                // Actualizar la lista de expedientes en el GridView
                CargarExpedientes();

                // Limpiar los campos del formulario después de agregar
                txtIDPaciente.Text = string.Empty;
                txtIDMedico.Text = string.Empty;
                txtDiagnostico.Text = string.Empty;
                txtTratamiento.Text = string.Empty;
                txtResultadosPruebas.Text = string.Empty;
                txtFechaCreacion.Text = string.Empty;

                lblMensaje.Text = "Expediente agregado exitosamente."; // Mensaje de éxito
                lblMensaje.ForeColor = System.Drawing.Color.Green; // Cambiar color a verde
            }
            catch (Exception ex)
            {
                // Mostrar el error en la consola del servidor si ocurre un error
                Console.WriteLine("Error al agregar el expediente: " + ex.Message);
                lblMensaje.Text = "Hubo un error al agregar el expediente. Intente nuevamente."; // Mensaje de error
                lblMensaje.ForeColor = System.Drawing.Color.Red; // Cambiar color a rojo
            }
        }

        // Método que se ejecuta al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar los expedientes cuando la página se carga por primera vez
                CargarExpedientes();
            }
        }

        protected void btnCambiarPagina_Click(object sender, EventArgs e)
        {
            Response.Redirect("Medicos.aspx");
        }
    }
}