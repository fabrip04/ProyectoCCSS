using ProyectoCCSS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoCCSS.Pages
{
    public partial class EditarMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idMedico = Convert.ToInt32(Request.QueryString["id"]);
                CargarMedico(idMedico);
            }
        }

        private void CargarMedico(int idMedico)
        {
            using (var contexto = new CCSSDatosEntities())
            {
                var medico = contexto.PersonalMedico.FirstOrDefault(m => m.ID_Medico == idMedico);
                if (medico != null)
                {
                    txtNombre.Text = medico.Nombre;
                    txtApellido.Text = medico.Apellido;
                    txtEspecialidad.Text = medico.Especialidad;
                    txtUsuario.Text = medico.Usuario;
                    txtContrasena.Text = medico.Contraseña;
                }
                else
                {
                    lblMensaje.Text = "Médico no encontrado.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        // Método para guardar los cambios del médico
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int idMedico = Convert.ToInt32(Request.QueryString["id"]);

            using (var contexto = new CCSSDatosEntities())
            {
                var medico = contexto.PersonalMedico.FirstOrDefault(m => m.ID_Medico == idMedico);

                if (medico != null)
                {
                    // Actualizar los datos del médico
                    medico.Nombre = txtNombre.Text;
                    medico.Apellido = txtApellido.Text;
                    medico.Especialidad = txtEspecialidad.Text;
                    medico.Usuario = txtUsuario.Text;
                    medico.Contraseña = txtContrasena.Text;

                    // Guardar los cambios en la base de datos
                    contexto.SaveChanges();

                    // Redirigir a una página de éxito
                    Response.Redirect("ExitoActualizar.aspx");
                }
                else
                {
                    lblMensaje.Text = "Médico no encontrado.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        // Método para cancelar la operación y redirigir a la página de médicos
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Medicos.aspx");
        }

        protected void lnkIrAMedicos_Click(object sender, EventArgs e)
        {
            // Redirigir a la página Medicos.aspx
            Response.Redirect("Medicos.aspx");
        }

    }
}
