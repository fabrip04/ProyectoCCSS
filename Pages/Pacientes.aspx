<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="ProyectoCCSS.Pages.Pacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <h2>Lista de Pacientes</h2>

  <!-- Formulario para agregar un nuevo paciente -->
  <div>
      <asp:Label ID="lblNombre" runat="server" Text="Nombre: " />
      <asp:TextBox ID="txtNombre" runat="server" />
      <br /><br />
      
      <asp:Label ID="lblApellido" runat="server" Text="Apellido: " />
      <asp:TextBox ID="txtApellido" runat="server" />
      <br /><br />
      
      <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento: " />
      <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" />
      <br /><br />
      
      <asp:Label ID="lblDatosContacto" runat="server" Text="Datos de Contacto: " />
      <asp:TextBox ID="txtDatosContacto" runat="server" />
      <br /><br />
      
      <asp:Button ID="btnAgregarPaciente" runat="server" Text="Agregar Paciente" OnClick="btnAgregarPaciente_Click" />
  </div>

  <hr />

  <!-- Tabla para mostrar los pacientes registrados -->
  <asp:GridView ID="GridViewPacientes" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewPacientes_RowCommand">
      <Columns>
          <asp:BoundField DataField="ID_Paciente" HeaderText="ID Paciente" />
          <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
          <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
          <asp:BoundField DataField="Fecha_Nacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:yyyy-MM-dd}" />
          <asp:BoundField DataField="Datos_Contacto" HeaderText="Datos de Contacto" />
          <asp:TemplateField HeaderText="Acciones">
              <ItemTemplate>
                  <!-- Botón de eliminar -->
                  <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("ID_Paciente") %>' OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este paciente?');" />
              </ItemTemplate>
          </asp:TemplateField>
      </Columns>
  </asp:GridView>
  <br />
      <asp:Button ID="btnCambiarPagina" runat="server" Text="Ir a Pagina Expedientes" OnClick="btnCambiarPagina_Click" />

</asp:Content>
