using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoCCSS.Pages
{
    public partial class ExitoActualizar : System.Web.UI.Page
    {
        protected void lnkIrAMedicos_Click(object sender, EventArgs e)
        {
            // Redirigir a la página de Médicos
            Response.Redirect("Medicos.aspx");
        }
    }
}