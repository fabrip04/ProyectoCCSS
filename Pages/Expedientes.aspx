<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Expedientes.aspx.cs" Inherits="ProyectoCCSS.Pages.Expedientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

           <h2>Expedientes</h2>



    <!-- Formulario para agregar un nuevo expediente -->
    <asp:Label ID="lblIDPaciente" runat="server" Text="ID Paciente: " />
    <asp:TextBox ID="txtIDPaciente" runat="server" />
    <br /><br />

    <asp:Label ID="lblIDMedico" runat="server" Text="ID Médico: " />
    <asp:TextBox ID="txtIDMedico" runat="server" />
    <br /><br />

    <asp:Label ID="lblDiagnostico" runat="server" Text="Diagnóstico: " />
    <asp:TextBox ID="txtDiagnostico" runat="server" TextMode="MultiLine" Rows="3" Columns="30" Height="33px" Width="192px" />
    <br /><br />

    <asp:Label ID="lblTratamiento" runat="server" Text="Tratamiento: " />
    <asp:TextBox ID="txtTratamiento" runat="server" TextMode="MultiLine" Rows="3" Columns="30" Height="33px" Width="193px" />
    <br /><br />

    <asp:Label ID="lblResultadosPruebas" runat="server" Text="Resultados de Pruebas: " />
    <asp:TextBox ID="txtResultadosPruebas" runat="server" TextMode="MultiLine" Rows="3" Columns="30" Height="25px" Width="168px" />
    <br /><br />

    <asp:Label ID="lblFechaCreacion" runat="server" Text="Fecha de Creación: " />
    <asp:TextBox ID="txtFechaCreacion" runat="server" />
    <br /><br />

    <asp:Button ID="btnAgregarExpediente" runat="server" Text="Agregar Expediente" OnClick="btnAgregarExpediente_Click" />
    <br /><br />

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

    <!-- GridView para mostrar los expedientes registrados -->
    <!-- GridView para mostrar los expedientes registrados -->
    <asp:GridView ID="GridViewExpedientes" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="ID_Expediente" HeaderText="ID Expediente" />
        <asp:BoundField DataField="ID_Paciente" HeaderText="ID Paciente" />
        <asp:BoundField DataField="ID_Medico" HeaderText="ID Médico" />
        <asp:BoundField DataField="Diagnostico" HeaderText="Diagnóstico" />
        <asp:BoundField DataField="Tratamiento" HeaderText="Tratamiento" />
        <asp:BoundField DataField="Resultados_Pruebas" HeaderText="Resultados de Pruebas" />
        <asp:BoundField DataField="Fecha_Creacion" HeaderText="Fecha de Creación" />
        <asp:ButtonField ButtonType="Button" CommandName="DeleteExpediente" Text="Eliminar" />
    </Columns>
</asp:GridView>

    <br />
            <asp:Button ID="btnCambiarPagina" runat="server" Text="Ir a Pagina Medicos" OnClick="btnCambiarPagina_Click" />

</asp:Content>
