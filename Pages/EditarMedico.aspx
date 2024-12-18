<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarMedico.aspx.cs" Inherits="ProyectoCCSS.Pages.EditarMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h2>Editar Médico</h2>

  
    <div>
        <asp:Label ID="lblNombre" runat="server" Text="Nombre: " />
        <asp:TextBox ID="txtNombre" runat="server" Required="true" />
        <br /><br />
        
        <asp:Label ID="lblApellido" runat="server" Text="Apellido: " />
        <asp:TextBox ID="txtApellido" runat="server" Required="true" />
        <br /><br />
        
        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad: " />
        <asp:TextBox ID="txtEspecialidad" runat="server" Required="true" />
        <br /><br />
        
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario: " />
        <asp:TextBox ID="txtUsuario" runat="server" Required="true" />
        <br /><br />
        
        <asp:Label ID="lblContrasena" runat="server" Text="Contraseña: " />
        <asp:TextBox ID="txtContrasena" TextMode="Password" runat="server" Required="true" />
        <br /><br />
        
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" />
        
        <asp:LinkButton ID="lnkIrAPacientes" runat="server" Text="Ir a la página de Medicos" 
    OnClick="lnkIrAMedicos_Click" CssClass="link-button" CausesValidation="false" />

    </div>

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

</asp:Content>
