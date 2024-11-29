<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FrmRegistrodeEntidades.aspx.cs" Inherits="CapaPresentacion.FrmRegistrodeEntidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario">
        <h2 style="text-align:center" >
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <span class="auto-style1">REGISTRO DE PERSONAS</span></h2>
        <style>
            .upper-case
         {
    text-transform: uppercase
         }
            .auto-style1 {
                color: #FFFF00;
            }
            .auto-style2 {
                height: 26px;
            }
        </style>
            <table>
                <tr>

                    <td style="text-align: right">Nombres: </td>
                    <td><asp:TextBox ID="txtNombres" runat="server" Width="300px" CssClass="upper-case" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                    <td>  
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombres" 
                            Display="Dynamic" ErrorMessage="Porfavor Inserte el  nombre" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombres" Display="Dynamic" ErrorMessage="Por favor Inserte el  nombre" ForeColor="Red">Por favor Inserte el  nombre</asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td style="text-align: right">Apellidos: </td>
                    <td><asp:TextBox ID="txtApellidos" runat="server" Width="300px" CssClass="upper-case" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td style="text-align: right" class="auto-style2">C.I.: </td>
                    <td class="auto-style2"><asp:TextBox ID="txtCI" runat="server" Width="85px" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox> </td> 
                     <td class="auto-style2">
                         <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtCI" Display="Dynamic" 
                             ErrorMessage="Inserte bien el CI con numeros" ForeColor="Red" Operator="DataTypeCheck" 
                             Type="Integer">Inserte bien el CI con numeros</asp:CompareValidator>
                     </td>
                 </tr>
                  <tr>
                     <td style="text-align:right">Emision:</td>
                     <td class="auto-style2"><asp:TextBox ID="txtEmision" runat="server" Width="100px" CssClass="upper-case" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                 </tr>
             
                 <tr>
                    <td style="text-align: right">Dirección: </td>
                    <td><asp:TextBox ID="txtDireccion" runat="server" Width="300px" Height="60px" TextMode="MultiLine" CssClass="upper-case" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: right">Teléfono: </td>
                    <td><asp:TextBox ID="txtTelefono" runat="server" Width="300px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: right">Teléfono Referencia: </td>
                    <td><asp:TextBox ID="txtTelfReferencia" runat="server" Width="300px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td style="text-align: right">Email: </td>
                    <td><asp:TextBox ID="txtEmail" runat="server" Width="300px" BorderStyle="Solid" BorderWidth="1px" ></asp:TextBox> </td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" 
                            ErrorMessage="Email is required" SetFocusOnError ="True" ></asp:RequiredFieldValidator></td>
                     <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email"  Display="Dynamic"
                        ControlToValidate="txtEmail" SetFocusOnError="True"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                    </asp:RegularExpressionValidator>
                    </td>
                   
                </tr>          
                
                <tr>
                    <td style="text-align: right">
                        <h3 style="text-align: right">Tipo Entidad: </h3>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkPropietario" Text="Propietario" runat="server" Font-Underline="False" Height="5px" />
                    </td>
                </tr>
                <tr>
                    <td>

                        &nbsp;</td>
                      <td>
                          <asp:CheckBox ID="chkChofer" Text="Chofer" runat="server" />
                    </td>
                </tr>       
                <tr>
                    <td>

                    </td>
                      <td>
                          <asp:CheckBox ID="chkTitularBanco" Text="Titular Banco" runat="server" />
                    </td>
                    <td>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Por favor de check en uno de los checkbox"
                            OnServerValidate=" validarCheckbox_ServerValidate"></asp:CustomValidator> 
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                      <td>
                          <asp:CheckBox ID="chkCliente" Text="Cliente" runat="server" />
                    </td>
                </tr>
                
                <%--<asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional" >
                          <ContentTemplate>--%>
                <tr>
                    <td>

                    </td>
                    
                    <td>
                          <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional" >
                          <ContentTemplate>
                           <asp:CheckBox ID="chkUsuario" Text="Usuario" runat="server" AutoPostBack="true" OnCheckedChanged="chkUsuario_CheckedChanged" />
                              
                    </td>  
                </tr>  
                     
                <tr>
                    <td style="text-align: right">
                        <%--style="text-align: right">Vencimiento REJAP:--%>
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional" >
                          <ContentTemplate> 
                         <asp:Label ID="lblUsuario" runat="server" Text="USUARIO:" Visible="false" style="text-align: right"></asp:Label>      
                    </td>   
                    <td><asp:TextBox ID="txtUsuario" runat="server" Width="140px" Font-Size="Smaller" Visible="false" style="position: relative; top: 0px; left: 88px" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                         </ContentTemplate> 
                    </asp:UpdatePanel>
                    </td>
                    <hr />
                    <%--</ContentTemplate> 
                    </asp:UpdatePanel>--%>
                </tr>
                <tr>
                     <td style="text-align: right">
                          <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional" >
                          <ContentTemplate>  
                         <asp:Label ID="lblContraseña" runat="server" Text="CONTRASEÑA:" Visible="false"></asp:Label></td>
                    <td><asp:TextBox ID="txtContraseña" runat="server" Width="140px" Font-Size="Smaller" Visible="false" TextMode="Password" style="position: relative; top: 0px; left: 64px" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                         </ContentTemplate> 
                    </asp:UpdatePanel>
                    </td>
                    <hr />
                </tr>
                <tr>
                     <td style="text-align: right">
                          <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional" >
                          <ContentTemplate>  
                         <asp:Label ID="lblConfirmarContraseña" runat="server" Text="CONFIRMAR CONTRASEÑA:" Visible="false"></asp:Label></td>
                    <td><asp:TextBox ID="txtConfirmarContraseña" runat="server" Width="140px" Font-Size="Smaller" Visible="false" TextMode="Password" style="position: relative" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                        </ContentTemplate> 
                    </asp:UpdatePanel>
                    </td>
                    <hr />
                </tr>
                <tr>
                     <td style="text-align: right">
                         <asp:UpdatePanel ID="UpdatePanel13" runat="server" UpdateMode="Conditional" >
                          <ContentTemplate>
                         <asp:Label ID="lblRol" runat="server" Text="ROL:" Visible="false"></asp:Label></td>
                    <td><asp:DropDownList ID="cmbRol" runat="server" Width="140px" DataSourceID="SqlDataSource2" DataTextField="Descripcion" DataValueField="Id_rol" Visible="false" AutoPostBack="false" style="position: relative; top: 0px; left: 112px"></asp:DropDownList>
                        </ContentTemplate> 
                        </asp:UpdatePanel>
                     </td>
                    
                   <hr />
                </tr>
                               </ContentTemplate> 
                    </asp:UpdatePanel>
        </table>
           
        <br />
        <table>
                 <tr>
                    <td>
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" width="100px" Font-Size="X-Small" 
                        OnClick="BtnGuardar_Click" BackColor="Aqua" Font-Bold="True" Font-Italic="False"/> 
                        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" width="100px" Font-Size="X-Small" BackColor="Aqua" 
                        Font-Bold="True" OnClick="BtnCancelar_Click"/>  
                    </td>
                    <td><asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="Green" Font-Size="Medium"></asp:Label></td>
                 </tr>
        </table>  
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=SERVIDOR;Initial Catalog=Maestria1Modulo;Integrated Security=True" 
            SelectCommand="SELECT * FROM [Roles]" ProviderName="<%$ ConnectionStrings:bercamConnectionString.ProviderName %>"></asp:SqlDataSource>
    </div>
</asp:Content>
