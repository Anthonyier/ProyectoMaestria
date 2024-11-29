<%@ Page Title="" Language="C#" MasterPageFile="~/FormularioPrincipal.Master" AutoEventWireup="true" CodeBehind="FormProgramacionRuta.aspx.cs" Inherits="CapaPresentacion.AsignacionRuta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type:"text/javascript">
        function OpenNewWindow() {
            window.open('FormEstCami.aspx', '_blank', 'location=no,resizable=no', true);
        }
    </script>
    <style type ="text/css">
        .auto-style1{
            width:101px;
        }
        .auto-style2 {
            width: 101px;
            height: 26px;
            font-size: medium;
        }
        .auto-style3 {
            height: 26px;
        }
        .auto-style4 {
            font-family: Arial;
            color: #003EFF;
            font-size: x-large;
        }
        .auto-style5 {
            width: 101px;
            font-size: medium;
        }
        .auto-style7 {
            font-size: xx-small;
        }
        .upper-case {
            font-size: xx-small;
        }
        </style>
    
    <script language="javascript" type="text/javascript">
        // Except only numbers and dot (.) for salary textbox
        function onlyDotsAndNumbers(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if (charCode == 44) {
                return true;
            }
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
</script>
    <script src="jquery-1.8.3.js" type="text/javascript"></script>
	<script type="text/javascript" src="jquery-ui-1.9.2.custom.min.js"></script>
	<link rel="stylesheet" type="text/css" href="jquery-ui.css" />
	<script type="text/javascript">
	    $(document).ready(function () {
	        var availableTags = [ <%= ListClientes %>];
	        //int NC = Convert.ToInt32(context.Request.QueryString["Codigo"]);
	        $('#ContentPlaceHolder1_TextCli').autocomplete({
	            source: availableTags
	        });
	        //var paramcl = document.getElementById("ContentPlaceHolder1_TextCli").value;
	        //var para = "FormularioPrincipal.Master?ClienteP=" + paramcl;
	    });
	</script>
    <script type="text/javascript">
        $(function () {
            //$(document).ready(function () {
            $('#ContentPlaceHolder1_extCli').autocomplete('Autocomplete.aspx', {
                autoCompleteClassName: 'Autocomplete',
                selectedClassName: 'sel',
                attrCallBack: 'rel',
                identifier: 'Cliente',
            }, fnClienteCallBack);
        });
        function fnClienteCallBack(par) {
            document.getElementById("ContentPlaceHolder1_txtNit").value = par[1];
        }
</script>

    <script type="text/javascript">
        $(document).ready(function () {
            var availableTags3 = [ <%= ListPlacas %>];

                   $('#ContentPlaceHolder1_TxtPlaca').autocomplete({
                       source: availableTags3
                   });
               });

	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;<br />
    <div id="abrigo_formulario">
        <h2 style="text-align:center" >
            <asp:ScriptManager ID="ScriptManager1" runat="server">

            </asp:ScriptManager>
           
            <span class="auto-style4">PROGRAMACION DE RUTAS</span></h2>
        <table> 
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1"> Cliente:</td>
               <td>
                   <asp:TextBox ID="TextCli" runat="server" Width="300px" OnTextChanged="TextCli_TextChanged" CssClass="auto-style7" ></asp:TextBox>
                                    
                                        <asp:Button ID="BtnBuscarNit" runat="server" Text="Buscar NIT" width="100px"   
                                            OnClick="BtnBuscarNit_Click" Font-Size="Smaller" />
                                    
                                    
               </td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1"> Cod_Ente:</td>
                <td>
                   <asp:TextBox ID="txtNit" runat="server" Width="100px" CssClass="auto-style7" ></asp:TextBox>
               </td>
                <%--<td><asp:DropDownList ID="Cliente" AutoPostBack="true" runat="server" OnSelectedIndexChanged="Cliente_SelectedIndexChanged">
                    </asp:DropDownList></td>--%>

            </tr>
             <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1"> Recepción:</td>
               <td>
                   <asp:TextBox ID="TextRecep" runat="server" Width="300px" CssClass="auto-style7"></asp:TextBox>
               </td>
            </tr>
            
            
            <tr>
              <td style="text-align:right;font-family:Calibri;" class="auto-style2"> RUTA:</td>
                <td class="auto-style3"><asp:DropDownList ID="Ruta" AutoPostBack="true" runat="server" OnSelectedIndexChanged="Ruta_SelectedIndexChanged" style="font-size: xx-small">
                    </asp:DropDownList></td>
            </tr>
             <tr>
              <td style="text-align:right;font-size:large;font-family:Calibri;" class="auto-style2"> Placa</td>
                <td class="auto-style3"><asp:DropDownList ID="Placa" AutoPostBack="true" runat="server" style="height: 22px">
                    </asp:DropDownList>
                    <asp:Button ID="ButtonPlacChof" runat="server" Text="Buscar Chofer" width="100px" Font-Size="Smaller" OnClick="ButtonPlacChof_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:large;font-family:Calibri;" class="auto-style1"> IDchofer</td>
               <td>
                   <asp:TextBox ID="TextBoxIdChofer" runat="server" Width="300px"></asp:TextBox>
               </td>
            </tr>
          
            <tr>
                <td style="text-align:right;font-size:large;font-family:Calibri;" class="auto-style1"> NombreChofer</td>
               <td>
                   <asp:TextBox ID="TextBoxNombreChofer" runat="server" Width="300px"></asp:TextBox>
               </td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:large;font-family:Calibri;" class="auto-style1">IdTitular</td>
                <td>
                    <asp:TextBox ID="TextIdTitular" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td style="text-align:right;font-size:large;font-family:Calibri;" class="auto-style1">Titular</td>
                <td>
                    <asp:TextBox ID="TextBoxNomTitular" runat="server" Width="300px" OnTextChanged="TextBoxNomTitular_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:large;font-family:Calibri"; class="auto-style1 ">Producto</td>
                <td>
                    <asp:DropDownList ID="Producto" AutoPostBack="true" runat="server" ></asp:DropDownList>
                </td>
            </tr>
            <tr> 
                <td style="text-align:right;Font-size:large;font-family:Calibri;"class="auto-style6">Compartimiento</td>
                 <td style="padding-right:10px;" class="auto-style8">
                   <asp:TextBox ID="TextBoxComp1" runat="server" Width="50px" ></asp:TextBox>
                      <asp:TextBox ID="TextBoxComp2" runat="server" Width="50px"></asp:TextBox>
                     <asp:TextBox ID="TextBoxComp3" runat="server" Width="50px" ></asp:TextBox>
                     <asp:TextBox ID="TextBoxComp4" runat="server" Width="50px" ></asp:TextBox>
                      <asp:TextBox ID="TextBoxComp5" runat="server" Width="50px"></asp:TextBox>
                     <asp:TextBox ID="TextBoxComp6" runat="server" Width="50px" ></asp:TextBox>
                     <asp:TextBox ID="TextBoxComp7" runat="server" Width="50px" ></asp:TextBox>
               </td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:large;font-family:Calibri;"class="auto-style1">Precintos</td>
                <td>
                    <asp:TextBox ID ="TexPrecintos" runat="server" Width="100px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:large;font-family:Calibri;"class="auto-style1">VolumenTotal</td>
                <td>
                <asp:TextBox ID="TextVolumenTotal" runat="server" Width="100px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td style="text-align:right;font-family:Calibri;" class="auto-style5"> Monto Anticipo:</td>
                <td><asp:TextBox ID="TextAnticipo" runat="server" Width="300px" CssClass="auto-style7" ReadOnly="true"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1">Ubicacion Origen:</td>
                 <td><asp:DropDownList ID="DdlOrigen" runat="server" Width="300px" CssClass="auto-style7"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;font-size:medium; font-family:Calibri;" class="auto-style1">Ubicacion Destino:</td>
                <td><asp:DropDownList ID="DdlUbicacion" runat="server" Width="300px" CssClass="auto-style7" OnSelectedIndexChanged="DdlUbicacion_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
             
            <tr>
                 <td style="text-align: right;font-size:medium; font-family:Calibri;">Fecha Carga: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <asp:TextBox ID="TextCarga" runat="server" Width="70px" Font-Size="Smaller" style="font-size: xx-small"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImageTextCarga" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" 
                                 OnClick="imgCalendarCarga_Click" Width="22px"  />
                        <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <td style="text-align: right"> </td>
                    <td>
                         <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>--%>
                            <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>--%>
                             <asp:Calendar ID="CalendarCarga" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" 
                                 Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" 
                                 OnSelectionChanged="Calendar_CargaOnSelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                             </ContentTemplate> 
                            </asp:UpdatePanel>

                    </td>
            </tr>
             <tr>
                 <td style="text-align: right;font-size:medium; font-family:Calibri;">Fecha Descarga: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <asp:TextBox ID="TextDescarga" runat="server" Width="70px" Font-Size="Smaller" style="font-size: xx-small"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImageDescarga" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png"  
                              OnClick="imgCalendarDesCarga_Click" Width="22px"  />
                        <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <td style="text-align: right"> </td>
                    <td>
                         <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>--%>
                            <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>--%>
                             <asp:Calendar ID="CalendarDescarga" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" 
                                 Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" 
                                 OnSelectionChanged="Calendar_DesCargaOnSelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                             </ContentTemplate> 
                            </asp:UpdatePanel>

                    </td>
            </tr>
           <tr>
                 <td style="text-align: right;font-size:medium; font-family:Calibri;">Vigencia: </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <asp:TextBox ID="TextVigencia" runat="server" Width="70px" Font-Size="Smaller" style="font-size: xx-small"></asp:TextBox>
                                
                            <asp:ImageButton ID="ImageVigencia" runat="server" Height="16px" ImageUrl="~/Bercam/descarga.png" 
                               OnClick="imgCalendarVigencia_Click" Width="22px"  />
                        <%--</ContentTemplate> 
                        </asp:UpdatePanel>--%>
                            
                    </td>
                    <td style="text-align: right"> </td>
                    <td>
                         <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>--%>
                            <%--<asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>--%>
                             <asp:Calendar ID="CalendarVigencia" runat="server" Visible ="False" BackColor="White" BorderColor="White" BorderWidth="1px" 
                                 Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" Width="350px" 
                                 OnSelectionChanged="Calendar_VigenciaOnSelectionChanged" SelectionMode="DayWeekMonth" NextPrevFormat="FullMonth">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                             </ContentTemplate> 
                            </asp:UpdatePanel>

                    </td>
            </tr>
            <tr>
                <td>

                </td>

                <td>

                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AllowPaging="True" ShowHeaderWhenEmpty="True" PageSize="20" >
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                        <EmptyDataTemplate>
                            <b> No Existen Registros !!!</b>
                        </EmptyDataTemplate>

                    </asp:GridView>
                   <asp:Button runat="server" ID="Agregar" Text="Agregar" OnClick="Agregar_Click" />
                    <asp:Button runat="server" ID="Modificar" Text="Modificar" OnClick="Modificar_Click" />
                     <asp:TextBox ID="txtFila" runat="server" Width="70px" Font-Size="Smaller" style="font-size: xx-small"></asp:TextBox>
                </td>
            </tr>

             <tr>
                    <td style="text-align: right;font-size:medium; font-family:Calibri;" class="auto-style1">OBS: </td>
                    <td><asp:TextBox ID="txtOBS" runat="server" Width="300px" TextMode="MultiLine" CssClass="upper-case" ></asp:TextBox></td>
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
