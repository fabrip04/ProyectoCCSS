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
                lblMensaje.Text = "Error al cargar pacientes: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Método para agregar un nuevo paciente
        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                using (var contexto = new CCSSDatosEntities())
                {
                    contexto.InsertarPaciente(
                        txtNombre.Text.Trim(),
                        txtApellido.Text.Trim(),
                        DateTime.Parse(txtFechaNacimiento.Text),
                        txtDatosContacto.Text.Trim()
                    );

                    lblMensaje.Text = "Paciente agregado exitosamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;

                    // Limpiar campos del formulario
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtFechaNacimiento.Text = "";
                    txtDatosContacto.Text = "";

                    // Recargar la lista de pacientes
                    CargarPacientes();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar paciente: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Método para manejar el comando de eliminación en el GridView
        protected void GridViewPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeletePaciente")
            {
                try
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);

                    // Verifica si el índice está dentro del rango
                    if (rowIndex < 0 || rowIndex >= GridViewPacientes.Rows.Count)
                    {
                        lblMensaje.Text = "Error: Índice fuera del rango.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    int idPaciente = Convert.ToInt32(GridViewPacientes.DataKeys[rowIndex].Value);

                    using (var contexto = new CCSSDatosEntities())
                    {
                        var paciente = contexto.Pacientes.FirstOrDefault(p => p.ID_Paciente == idPaciente);

                        if (paciente != null)
                        {
                            contexto.Pacientes.Remove(paciente);
                            contexto.SaveChanges();

                            lblMensaje.Text = "Paciente eliminado correctamente.";
                            lblMensaje.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMensaje.Text = "Paciente no encontrado.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                        }
                    }

                    CargarPacientes();
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Ocurrió un error: " + ex.Message;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        // Método para cambiar de página
        protected void btnCambiarPagina_Click(object sender, EventArgs e)
        {
            Response.Redirect("Expedientes.aspx");
        }
    }
}
