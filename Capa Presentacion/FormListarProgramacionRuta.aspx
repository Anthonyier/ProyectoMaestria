<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormListarProgramacionRuta.aspx.cs" Inherits="CapaPresentacion.FormListarAsignacionRuta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="abrigo_formulario">
        <h2>Listas de Programacion de rutas</h2>
          <table>
            <tr>
                <td style="text-align:right" class="auto-style1">Mes</td>
                <td class="auto-style5"><asp:DropDownList ID="cmMes" runat="server" AutoPostBack="true"></asp:DropDownList></td>
                  <td style="text-align:right" class="auto-style1">Año</td>
                <td class="auto-style5"><asp:DropDownList ID="cmAño" runat="server" AutoPostBack="true" ></asp:DropDownList></td>
            </tr>
            </table> 
           <table>
            <tr>
            <td>

            </td>
            <td>
                 <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="DtgListaAsignacion_RowCommand">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                     <Columns>
                         <asp:TemplateField HeaderText="CLIENTE" SortExpression="CLIENTE">
                             <EditItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("CLIENTE") %>'></asp:Label>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("CLIENTE") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Id_Recepcion" SortExpression="Id_Recepcion">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id_Recepcion") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label2" runat="server" Text='<%# Bind("Id_Recepcion") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="F_Reg" SortExpression="F_Reg">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("F_Reg") %>'></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label3" runat="server" Text='<%# Bind("F_Reg") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Editar">
                             <ItemTemplate>
                                <asp:LinkButton ID="LinkAgregar" runat ="server" CausesValidation="false" CommandArgument='<%#Bind("Id_Recepcion") %>'
                                 CommandName="EditarRecepcion" >Editar</asp:LinkButton>
                            </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Anular">
                              <ItemTemplate>
                                <asp:LinkButton ID="LinkAnular" runat ="server" CausesValidation="false" CommandArgument='<%#Bind("Id_Recepcion") %>'
                                   CommandName="AnularRecepcion" OnClientClick="return confirm('Esta seguro que desea deshabilitar?');">Anular</asp:LinkButton>
                            </ItemTemplate>
                         </asp:TemplateField>
                       
                      
                     </Columns>
                     <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                     <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                     <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                     <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                     <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                     <SortedAscendingCellStyle BackColor="#F4F4FD" />
                     <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                     <SortedDescendingCellStyle BackColor="#D8D8F0" />
                     <SortedDescendingHeaderStyle BackColor="#3E3277" />
                     </asp:GridView>
                </td>
               </tr> 
            </table>
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bercamConnectionString3 %>" SelectCommand="ProcFechaAsignacionRuta" SelectCommandType="StoredProcedure">
               <SelectParameters>
                   <asp:ControlParameter ControlID="cmMes" DefaultValue="0" Name="IdMes" PropertyName="SelectedValue" Type="Int32" />
                   <asp:ControlParameter ControlID="cmAño" DefaultValue="0" Name="IdAño" PropertyName="SelectedValue" Type="String" />
               </SelectParameters>
      </asp:SqlDataSource>
      </div>

</asp:Content>


