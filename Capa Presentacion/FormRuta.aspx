<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormRuta.aspx.cs" Inherits="CapaPresentacion.FormRuta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type ="text/css">
        .auto-style1{
            width:101px;
        }

        </style>

    <style>
            .upper-case
         {
    text-transform: uppercase
         }
        </style>

    <script language="javascript" type="text/javascript">
        // Except only numbers and dot (.) for salary textbox
        function onlyDotsAndNumbers(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if (charCode == 44) {
                return true;
            }
            if (charCode == 46) {
                return true;
            }
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
</script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
     <div id="abrigo_formulario">
        <h2>
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
           
           Registro de Ruta</h2>
         <table>
             <tr>
                 <td style="text-align:right" class="auto-style1"> Ruta</td>
                  <td><asp:TextBox ID="TextRuta" runat="server" Width="300px" CssClass="upper-case" Style="text-transform: uppercase"></asp:TextBox></td>
             </tr>
             <tr>
                 <td style="text-align:right" class="auto-style1"> MontoAnticipo</td>
                 <td><asp:TextBox ID="TextMonto" runat="server" Width="300px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox></td>
             </tr>
             <tr>
                 <td style="text-align:right" class="auto-style1"> Precio</td>
                 <td><asp:TextBox ID="TextPrecio" runat="server" Width="300px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox></td>
         
             </tr>
             <tr>
                 <td style="text-align:right" class="auto-style1">PrecioFletero</td>
                 <td><asp:TextBox ID="TextFletero" runat="server" Width="300px" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox></td>
             </tr>
             <tr>
                 <td style="text-align:right" class="auto-style1">Origen</td>
                 <td><asp:TextBox ID="TextOrigen" runat="server" Width="200px" CssClass="upper-case" Style="text-transform: uppercase" OnTextChanged="TextOrigen_TextChanged" AutoPostBack="True" ></asp:TextBox><asp:TextBox ID="txtIdOrigen" runat="server" Width="30px" CssClass="upper-case" Style="text-transform: uppercase" OnTextChanged="TextOrigen_TextChanged" ></asp:TextBox></td>
             </tr>
             <tr>
                 <td style="text-align:right" class="auto-style1">Destino</td>
                 <td><asp:TextBox ID="TextUbicacion" runat="server" Width="200px" CssClass="upper-case" Style="text-transform: uppercase" AutoPostBack="True" OnTextChanged="TextUbicacion_TextChanged"></asp:TextBox><asp:TextBox ID="txtIdDestino" runat="server" Width="30px" CssClass="upper-case" Style="text-transform: uppercase" OnTextChanged="TextOrigen_TextChanged" ></asp:TextBox></td>
             </tr>
            
             <tr>
                <td style="text-align:right" class="auto-style1"> Cliente</td>
                <td><asp:DropDownList ID="Cliente" AutoPostBack="true"  runat="server" Width="195px" >
                    </asp:DropDownList></td>
            </tr>
         </table>
         <br />
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
          <br />
          <br />
         <table>
             <tr>
              <td>
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString5 %>" SelectCommand="SELECT [Id_Ruta], [MontoAnticipo], [Ruta], [PrecioTotal], [CI], [Nombre], [Apellidos], [Origen], [Destino], [PrecioFlet] FROM [Vi_Ruta] ORDER BY [Id_Ruta]"></asp:SqlDataSource>
                 <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" OnPageIndexChanging="GridView1_PageIndexChanging" BorderWidth="2px" CellPadding="3" AllowPaging="True" AutoGenerateColumns="False" CellSpacing="1" GridLines="None" OnRowCommand="DtgListaRuta_RowCommand" DataSourceID="SqlDataSource1" >
                     <Columns>
                         <asp:TemplateField HeaderText="Id_Ruta" SortExpression="Id_Ruta">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id_Ruta") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id_Ruta") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="MontoAnticipo" SortExpression="MontoAnticipo">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("MontoAnticipo") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label2" runat="server" Text='<%# Bind("MontoAnticipo") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Ruta" SortExpression="Ruta">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Ruta") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label3" runat="server" Text='<%# Bind("Ruta") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="PrecioTotal" SortExpression="PrecioTotal">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("PrecioTotal") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label4" runat="server" Text='<%# Bind("PrecioTotal") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="PrecioFlet" SortExpression="PrecioFlet">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("PrecioFlet") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label10" runat="server" Text='<%# Bind("PrecioFlet") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="CI/NIT" SortExpression="CI">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("CI") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label5" runat="server" Text='<%# Bind("CI") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label6" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Apellidos" SortExpression="Apellidos">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Apellidos") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label7" runat="server" Text='<%# Bind("Apellidos") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Origen" SortExpression="Origen">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Origen") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label8" runat="server" Text='<%# Bind("Origen") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Destino" SortExpression="Destino">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Destino") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label9" runat="server" Text='<%# Bind("Destino") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Edit">
                             <ItemTemplate>
                                <asp:LinkButton ID="LinkEditar" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id_Ruta") %>'
                                    CommandName="EditarRuta">Editar</asp:LinkButton>
                            </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Carro Guia">
                             <ItemTemplate>
                                <asp:LinkButton ID="LinkCarroGuia" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id_Ruta") %>'
                                    CommandName="CarroGuia" OnClientClick="return confirm('Esta seguro de Crear Carro Guia?');">Carro Guia</asp:LinkButton>
                            </ItemTemplate>
                         </asp:TemplateField>
                     </Columns>
                     <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                     <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                     <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                     <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                     <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#594B9C" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#33276A" />
                     </asp:GridView>
                     </td>
                 </tr>
         </table>

         <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString5 %>" SelectCommand="SELECT * FROM [Vi_ListaRuta]"></asp:SqlDataSource>--%>
    </div>
</asp:Content>
