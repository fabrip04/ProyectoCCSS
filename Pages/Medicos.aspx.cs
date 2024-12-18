using ProyectoCCSS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoCCSS.Pages
{
    public partial class Medico : System.Web.UI.Page
    {
        // Método que se ejecuta al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar los médicos cuando la página se carga por primera vez
                CargarMedicos();
            }
        }

        // Método para cargar los médicos en el GridView
        private void CargarMedicos()
        {
            try
            {
                using (var contexto = new CCSSDatosEntities())
                {
                    var medicos = contexto.PersonalMedico
                        .Select(m => new { m.ID_Medico, m.Nombre, m.Apellido, m.Especialidad })
                        .ToList();
                    GridViewMedicos.DataSource = medicos;
                    GridViewMedicos.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error en un log o mostrar un mensaje
                // por ejemplo, un Control de Error de ASP.NET.
                Console.WriteLine("Error al cargar médicos: " + ex.Message);
            }
        }

        // Método para agregar un nuevo médico
        protected void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            // Validaciones del lado del servidor para asegurarse que los campos no estén vacíos
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) ||
                string.IsNullOrEmpty(txtEspecialidad.Text) || string.IsNullOrEmpty(txtUsuario.Text) ||
                string.IsNullOrEmpty(txtContrasena.Text))
            {
                lblMensaje.Text = "Todos los campos son obligatorios."; // Mostrar mensaje de error
                lblMensaje.ForeColor = System.Drawing.Color.Red; // Cambiar color a rojo
                return; // Salir si algún campo está vacío
            }

            try
            {
                // Crear un nuevo objeto de PersonalMedico con los datos del formulario
                using (var contexto = new CCSSDatosEntities())
                {
                    var nuevoMedico = new PersonalMedico
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Especialidad = txtEspecialidad.Text,
                        Usuario = txtUsuario.Text,
                        Contraseña = txtContrasena.Text // Esto debería ser encriptado en un caso real
                    };

                    // Agregar el nuevo médico a la base de datos
                    contexto.PersonalMedico.Add(nuevoMedico);
                    contexto.SaveChanges();

                    // Recargar la lista de médicos después de agregar uno nuevo
                    CargarMedicos();

                    // Limpiar los campos después de agregar
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtEspecialidad.Text = "";
                    txtUsuario.Text = "";
                    txtContrasena.Text = "";

                    // Mostrar mensaje de éxito
                    lblMensaje.Text = "Médico agregado exitosamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green; // Cambiar color a verde
                }
            }
            catch (Exception ex)
            {
                // Manejar el error si ocurre al guardar el médico
                // Mostrar mensaje de error al usuario o registrar el error.
                lblMensaje.Text = "Error al agregar médico: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red; // Cambiar color a rojo
            }
        }



        // Método para manejar el comando de eliminación de médicos
        protected void GridViewMedicos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                // Obtener el índice de la fila seleccionada
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Verificar si el índice está dentro del rango
                if (rowIndex < 0 || rowIndex >= GridViewMedicos.Rows.Count)
                {
                    lblMensaje.Text = "Error: Índice fuera del rango.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Obtener el ID del médico de la fila seleccionada
                int idMedico = Convert.ToInt32(GridViewMedicos.DataKeys[rowIndex].Value);

                if (e.CommandName == "UpdateMedicos")
                {
                    // Redirigir a la página de edición de médico pasando el ID del médico
                    Response.Redirect("EditarMedico.aspx?id=" + idMedico);
                }
                else if (e.CommandName == "DeleteMedicos")
                {
                    // Lógica para eliminar el médico
                    using (var contexto = new CCSSDatosEntities())
                    {
                        var medico = contexto.PersonalMedico.FirstOrDefault(m => m.ID_Medico == idMedico);

                        if (medico != null)
                        {
                            contexto.PersonalMedico.Remove(medico);  // Eliminar el médico
                            contexto.SaveChanges();
                            lblMensaje.Text = "Médico eliminado correctamente.";
                            lblMensaje.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMensaje.Text = "Médico no encontrado.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                        }
                    }

                    // Recargar el GridView después de eliminar
                    CargarMedicos();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }







        protected void lnkIrAPacientes_Click(object sender, EventArgs e)
        {
            // Redirigir a la página Pacientes.aspx
            Response.Redirect("Pacientes.aspx");
        }
    }
}