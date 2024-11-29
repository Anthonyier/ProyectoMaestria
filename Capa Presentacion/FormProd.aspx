<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormProd.aspx.cs" Inherits="CapaPresentacion.FormProd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type ="text/css">
        .auto-style1{
            width:101px;
        }
        </style>
</asp:Content>
     
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
           
            Descripcion de producto</h2>
        <table>
            <tr>
                <td style="text-align:right" class="auto-style1">Descripcion</td>
                <td><asp:TextBox ID="TextProd" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                 <td>  <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="Smaller" 
                    OnClick="BtnGuardar_Click" BackColor="Aqua" Font-Bold="True" Font-Italic="False"/>
                   <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="Smaller" BackColor="Aqua" 
                        Font-Bold="True"/></td>
                <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
