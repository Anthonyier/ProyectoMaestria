<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormCamiones.aspx.cs" Inherits="CapaPresentacion.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 101px;
        }
    </style>
    <script>
        function OpenWindow() {
            window.open('FrmRegistrodeEntidades');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            Registro de Camiones</h2>
        <br />
        <style>
            .upper-case
         {
    text-transform: uppercase
         }
        </style>
            <table>
                <tr>
                    <td style="text-align: right" class="auto-style1">Placa: </td>
                    <td><asp:TextBox ID="txtPlaca" runat="server" Width="300px" CssClass="upper-case"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:right" class="auto-style1">Emplaque:</td>
                    <td><asp:TextBox ID="txtEmplaque" runat="server" Width="300px" CssClass="upper-case"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td style="text-align: right" class="auto-style1">Capacidad: </td>
                    <td><asp:TextBox ID="txtCapacidad" runat="server" Width="300px" CssClass="upper-case"></asp:TextBox></td>
                </tr>      
               
                 <tr>
                    <td style="text-align: right" class="auto-style1">OBS: </td>
                    <td><asp:TextBox ID="txtOBS" runat="server" Width="300px" TextMode="MultiLine" CssClass="upper-case" ></asp:TextBox></td>
                </tr>

                <tr>
                    <td style="text-align:right" class="auto-style1">Ubicacion</td>
                    <td><asp:TextBox ID="txtUbicacion" runat="server" Width="300px" CssClass="upper-case"></asp:TextBox></td>
                </tr>
                
                 <tr>
                    <td style="text-align: right" class="auto-style1">Marca: </td>
                     <td><asp:DropDownList ID="Marca" AutoPostBack="true" runat="server">
                            </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="text-align:right" class="auto-style1">Color:</td>
                    <td><asp:DropDownList ID="Color" AutoPostBack="true" runat="server">
                            </asp:DropDownList></td>
                </tr>

                <tr>
                    <td style="text-align:right" class="auto-style1">C.I.Propietario</td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID ="Panel1" runat="server" >
                                    <asp:TextBox ID="TxtCiPropietario" runat="server" Width="100px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ReadOnly="true"></asp:TextBox>
                                    <asp:Button ID="BtnPropietario" runat="server" Text="Buscar Propietario" width="100px"   
                                        OnClick="BtnPropietario_Click" Font-Size="Smaller" />
                                    <input id="Button2" onclick="OpenWindow()" type="button" value="+"/>
                                </asp:Panel>
                                <tr>
                                   <td style="text-align:right"> </td>
                                   <td> <asp:Label ID="LblPropieatrio" runat="server" Text="*" ForeColor="DeepSkyBlue" Font-Size="Small">
                                    </asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align:right"> Datos Propietario</td>
                                   <td> <asp:TextBox ID="TxtPropietario" runat="server" Width="250px" > </asp:TextBox></td>
                                </tr>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    
                </tr>

                <tr>
                    <td style="text-align:right" class="auto-style1"> C.I.Chofer</td>
                   <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID ="Panel2" runat="server">
                                    <asp:TextBox ID="TxtCiChofer" runat="server" Width="100px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ReadOnly="true"></asp:TextBox>
                                     <asp:Button ID="BtnChofer" runat="server" Text="Buscar Chofer" width="100px"   
                                        OnClick="BtnChofer_Click" Font-Size="Smaller" />
                                      <input id="Button1" onclick="OpenWindow()" type="button" value="+"/>
                                </asp:Panel>
                                <tr>
                                   <td style="text-align:right"> </td>
                                   <td> <asp:Label ID="LblMensajeChofer" runat="server" Text="*" ForeColor="DeepSkyBlue" Font-Size="Small">
                                    </asp:Label></td>
                                   
                                </tr>
                                <tr>
                                    <td style="text-align:right"> Datos Chofer</td>
                                   <td> <asp:TextBox ID="TxtChofer" runat="server" Width="250px" > </asp:TextBox></td>
                                    
                                </tr>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    
                </tr>

                <tr>
                    <td style="text-align:right" class="auto-style1">C.I.TitBanco</td>
                    <td>
                        <asp:UpdatePanel ID="Update" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID ="PanelTitularBanco" runat="server" >
                                    <asp:TextBox ID="TxtCittitularBanco" runat="server" Width="100px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" ReadOnly="true"></asp:TextBox>
                                    <asp:Button ID="BtnTitularBanco" runat="server" Text="Buscar Titular banco" width="100px"   
                                        OnClick="BtnTitularBanco_Click" Font-Size="Smaller" />
                                    <input id="Button3" onclick="OpenWindow()" type="button" value="+"/>
                                </asp:Panel>
                                <tr>
                                   <td style="text-align:right"> </td>
                                   <td> <asp:Label ID="lblMensajeTitularBanco" runat="server" Text="*" ForeColor="DeepSkyBlue" Font-Size="Small">
                                    </asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align:right"> Datos Titular Banco</td>
                                   <td> <asp:TextBox ID="txtDatosTitularBanco" runat="server" Width="250px" > </asp:TextBox></td>
                                </tr>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    
                </tr>
                 <tr>
                    <td style="text-align:right" class="auto-style1">Cuenta:</td>
                    <td><asp:TextBox ID="Cuenta" runat="server" Width="300px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:right" class="auto-style1">Banco:</td>
                    <td><asp:DropDownList ID="Banco" AutoPostBack="true" runat="server">
                            </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="text-align:right" class="auto-style1">Rastreo</td>
                    <td><asp:DropDownList ID="Rastreo" AutoPostBack="true" runat="server">
                            </asp:DropDownList></td>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=SERVIDOR;Initial Catalog=Maestria1Modulo;Integrated Security=True" 
             ProviderName="<%$ ConnectionStrings:bercamConnectionString.ProviderName %>"></asp:SqlDataSource>
    </div>
</asp:Content>
