<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExitoActualizar.aspx.cs" Inherits="ProyectoCCSS.Pages.ExitoActualizar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Actualización Exitosa</h2>
    <p>El médico ha sido actualizado correctamente.</p>
    <asp:LinkButton ID="lnkIrAMedicos" runat="server" Text="Volver a la lista de Médicos" OnClick="lnkIrAMedicos_Click" />

</asp:Content>
