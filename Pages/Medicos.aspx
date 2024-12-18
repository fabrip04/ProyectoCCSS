<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="ProyectoCCSS.Pages.Medico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <h2>Personal Médico</h2>

<!-- Formulario para agregar un nuevo médico -->
<div>
    <asp:Label ID="lblNombre" runat="server" Text="Nombre: " />
    <asp:TextBox ID="txtNombre" runat="server" Required="true" />
    <br /><br /> <!-- hola --> 
    
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

    <asp:Button ID="btnAgregarMedico" runat="server" Text="Agregar Médico" OnClick="btnAgregarMedico_Click" />
    <br />
</div>

<hr />

<!-- Mensaje de error o éxito -->
<asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

<!-- Tabla para mostrar los médicos registrados -->
<asp:GridView ID="GridViewMedicos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_Medico" OnRowCommand="GridViewMedicos_RowCommand">    <Columns>
        <asp:BoundField DataField="ID_Medico" HeaderText="ID Médico" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
        <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
        <asp:ButtonField ButtonType="Button" CommandName="DeleteMedicos" Text="Eliminar" />
    </Columns>
</asp:GridView>
<br />



<!-- Link para navegar a la página de Pacientes -->

<asp:LinkButton ID="lnkIrAPacientes" runat="server" Text="Ir a la página de Pacientes" 
    OnClick="lnkIrAPacientes_Click" CssClass="link-button" CausesValidation="false" />


</asp:Content>
