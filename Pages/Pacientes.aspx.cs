using ProyectoCCSS.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoCCSS.Pages
{
    public partial class Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPacientes(); // Cargar los pacientes en el GridView al cargar la página
            }
        }

        // Método para cargar los pacientes desde la base de datos
        private void CargarPacientes()
        {
            try
            {
                using (var contexto = new CCSSDatosEntities())
                {
                    var pacientes = contexto.Pacientes.ToList(); // Obtener los pacientes de la tabla
                    GridViewPacientes.DataSource = pacientes;
                    GridViewPacientes.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: Mostrar mensaje o registrar el error
                Console.WriteLine("Error al cargar pacientes: " + ex.Message);
            }
        }

        // Método para agregar un nuevo paciente
        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            // Validaciones del lado del servidor
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) ||
                string.IsNullOrEmpty(txtFechaNacimiento.Text) || string.IsNullOrEmpty(txtDatosContacto.Text))
            {
                // Mostrar mensaje de error (se podría usar un Label de Error en la interfaz)
                return;
            }

            // Validar que la fecha de nacimiento sea una fecha válida
            DateTime fechaNacimiento;
            if (!DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento))
            {
                // Mostrar mensaje de error por fecha inválida
                return;
            }

            try
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string datosContacto = txtDatosContacto.Text;

                // Insertar nuevo paciente utilizando el procedimiento almacenado
                string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("InsertarPaciente", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Apellido", apellido);
                        command.Parameters.AddWithValue("@Fecha_Nacimiento", fechaNacimiento);
                        command.Parameters.AddWithValue("@Datos_Contacto", datosContacto);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                // Limpiar campos después de agregar y recargar la lista de pacientes
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtFechaNacimiento.Text = "";
                txtDatosContacto.Text = "";
                CargarPacientes(); // Recargar la lista de pacientes después de agregar uno nuevo
            }
            catch (Exception ex)
            {
                // Manejo de errores: Mostrar mensaje o registrar el error
                Console.WriteLine("Error al agregar paciente: " + ex.Message);
            }
        }

        // Método para manejar los comandos de la GridView (Eliminar paciente)
        protected void GridViewPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idPaciente = Convert.ToInt32(e.CommandArgument);
                EliminarPaciente(idPaciente); // Eliminar paciente
                CargarPacientes(); // Recargar la lista después de eliminar
            }
        }

        // Método para eliminar un paciente
        private void EliminarPaciente(int idPaciente)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("EliminarPaciente", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Paciente", idPaciente);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores: Mostrar mensaje o registrar el error
                Console.WriteLine("Error al eliminar paciente: " + ex.Message);
            }
        }

        protected void btnCambiarPagina_Click(object sender, EventArgs e)
        {
            Response.Redirect("Expedientes.aspx");
        }
    }
}