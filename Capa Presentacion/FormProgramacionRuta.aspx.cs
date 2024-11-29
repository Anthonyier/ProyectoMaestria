using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using System.IO;

namespace CapaPresentacion
{
    public partial class AsignacionRuta : System.Web.UI.Page
    {
        public string ListClientes = "";
        public string ListClientes2 = "";
        public string ListPlacas = "";
        System.Data.DataTable table;
        System.Data.DataRow row;
        System.Data.DataTable tabla;
        int IdPersona = 9;
        int IdRuta = 3;
        public string Parametro = "";
        public void CargarClientesMain()
        {
            if (Request.QueryString["query"] != "")
            {
                if (Request.QueryString["identifier"] == "Cliente")
                {
                    DataSet ds = Autocomplete.GetProveedores(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["Descripcion"].ToString();
                            item.id = dr["Id"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel=" + item.id + "_" + dr["Descripcion"].ToString() + ">" + item.value + "</li>" + "\n");

                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
            }
        }


        public void CargarClientesParam()
        {
            Parametro = Convert.ToString(Context.Request.QueryString["ClienteP"]);
            string queryString = "SELECT * FROM vi_Cliente where Cliente = " + "'" + Parametro + "'" + " ORDER BY Cliente";

            using (SqlConnection connection = new SqlConnection(Properties.Resources.ConexionBercamPrin))
            {

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            if (string.IsNullOrEmpty(ListClientes))
                            {
                                ListClientes += "\"" + reader["CI"].ToString() + "\"";
                            }
                            else
                            {
                                ListClientes += ", \"" + reader["CI"].ToString() + "\"";
                            }

                        }
                    }
                }

            }
        }

        public void CargarPlacas()
        {
            string queryString = "SELECT * FROM View_Camiones ORDER BY Placa";
            using (SqlConnection connection = new SqlConnection(Properties.Resources.ConexionBercamPrin)) //ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (string.IsNullOrEmpty(ListPlacas))
                            {
                                ListPlacas += "\"" + reader["Placa"].ToString() + "\"";
                            }
                            else
                            {
                                ListPlacas += ", \"" + reader["Placa"].ToString() + "\"";
                            }
                        }
                    }
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                Ruta.AppendDataBoundItems = true;
                CargarCombo();
                CargarAsignacion();
                tabla = new System.Data.DataTable();
                GridView1.DataSource = tabla;
                tabla.Columns.Add("Placa_Camion", typeof(System.String));
                tabla.Columns.Add("Id_Chofer", typeof(System.String));
                tabla.Columns.Add("Nombres", typeof(System.String));
                tabla.Columns.Add("Monto_Anticipo", typeof(System.String));
                tabla.Columns.Add("Compartimiento1", typeof(System.String));
                tabla.Columns.Add("Compartimiento2", typeof(System.String));
                tabla.Columns.Add("Compartimiento3", typeof(System.String));
                tabla.Columns.Add("Compartimiento4", typeof(System.String));
                tabla.Columns.Add("Compartimiento5", typeof(System.String));
                tabla.Columns.Add("Compartimiento6", typeof(System.String));
                tabla.Columns.Add("Compartimiento7", typeof(System.String));
                tabla.Columns.Add("Precintos", typeof(System.String));
                tabla.Columns.Add("Producto", typeof(System.String));
                tabla.Columns.Add("FechaCarga", typeof(System.String));
                tabla.Columns.Add("FechaDescarga", typeof(System.String));
                tabla.Columns.Add("Vigencia", typeof(System.String));
                tabla.Columns.Add("Ruta", typeof(System.String));
                tabla.Columns.Add("NombreTitular", typeof(System.String));
                tabla.Columns.Add("DetallePlantaOrigen", typeof(System.String));
                tabla.Columns.Add("DetallePlantaDestino", typeof(System.String));
                tabla.Columns.Add("Id_Titular", typeof(System.String));
                GridView1.DataBind();
                CargarClientesMain();
                CargarPlacas();
                //CargarClientesParam();
                string queryString = "SELECT * FROM vi_Cliente  ORDER BY Cliente";

                using (SqlConnection connection = new SqlConnection(Properties.Resources.ConexionBercamPrin)) //ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            if (string.IsNullOrEmpty(ListClientes))
                            {
                                ListClientes += "\"" + reader["CLIENTE"].ToString() + "\"";
                                //ListClientes += "\"" + reader["CLIENTE"].ToString() + "\"" + reader["CI"].ToString() + "\"";//"\"" + reader["CLIENTE"].ToString() + "\"";
                            }
                            else
                            {
                               ListClientes += ", \"" + reader["CLIENTE"].ToString() + "\"";
                                //ListClientes += ", \"" + reader["CLIENTE"].ToString() + "\"" + reader["CI"].ToString() + "\"";//"\"" + reader["CLIENTE"].ToString() + "\"";
                            }

                        }
                    }
                }

            }
            if (!Page.IsPostBack) 
            {
                table = new System.Data.DataTable();
                table.Columns.Add("Placa_Camion", typeof(System.String));
                table.Columns.Add("Id_Chofer", typeof(System.String));
                table.Columns.Add("Nombres", typeof(System.String));
                table.Columns.Add("Monto_Anticipo", typeof(System.String));
                table.Columns.Add("Compartimiento1", typeof(System.String));
                table.Columns.Add("Compartimiento2", typeof(System.String));
                table.Columns.Add("Compartimiento3", typeof(System.String));
                table.Columns.Add("Compartimiento4", typeof(System.String));
                table.Columns.Add("Compartimiento5", typeof(System.String));
                table.Columns.Add("Compartimiento6", typeof(System.String));
                table.Columns.Add("Compartimiento7", typeof(System.String));
                table.Columns.Add("Precintos", typeof(System.String));
                table.Columns.Add("Producto", typeof(System.String));
                table.Columns.Add("FechaCarga", typeof(System.String));
                table.Columns.Add("FechaDescarga", typeof(System.String));
                table.Columns.Add("Vigencia", typeof(System.String));
                table.Columns.Add("Ruta", typeof(System.String));
                table.Columns.Add("NombreTitular", typeof(System.String));
                table.Columns.Add("DetallePlantaOrigen", typeof(System.String));
                table.Columns.Add("DetallePlantaDestino", typeof(System.String));
                table.Columns.Add("Id_Titular", typeof(System.String));
                 Session.Add("Tabla", table);

            }
            if (Request.QueryString["Id"] != null)
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario esta intentando actualizar una programacion de ruta ";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
            }
            else
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario esta intentando programar una ruta ";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
            }
           

            }
        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {

        }
      
        
        protected void Calendar_CargaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarCarga.SelectedDate != null)
            {
                TextCarga.Text = CalendarCarga.SelectedDate.ToString("d");
                CalendarCarga.Visible = false;
            }

        }
        protected void Calendar_DesCargaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarDescarga.SelectedDate != null)
            {
                TextDescarga.Text = CalendarDescarga.SelectedDate.ToString("d");
                CalendarDescarga.Visible = false;
            }

        }
        protected void imgCalendarCarga_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarCarga.Visible)
            {
                CalendarCarga.Visible = false;
            }
            else
            {
                CalendarCarga.Visible = true;
            }
        }
        protected void imgCalendarDesCarga_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarDescarga.Visible)
            {
                CalendarDescarga.Visible = false;
            }
            else
            {
                CalendarDescarga.Visible = true;
            }
        }
        protected void Calendar_VigenciaOnSelectionChanged(object sender, EventArgs e)
        {
            if (CalendarVigencia.SelectedDate != null)
            {
                TextVigencia.Text = CalendarVigencia.SelectedDate.ToString("d");
                CalendarVigencia.Visible = false;
            }

        }
        protected void imgCalendarVigencia_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarVigencia.Visible)
            {
                CalendarVigencia.Visible = false;
            }
            else
            {
                CalendarVigencia.Visible = true;
            }
        }
       

        public void CargarAsignacion()
        {
            Placa.Items.Clear();
            Placa.Items.Add(new ListItem("--Selecciona una Placa--", ""));
            Placa.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();

            try
            {

                //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("ProcAsig", cnx);
                cmd.Parameters.AddWithValue("@IdCliente", IdPersona);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                Placa.DataSource = dr; //cmd.ExecuteReader();    
                Placa.DataTextField = "Placa";
                Placa.DataValueField = "Placa";
                Placa.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                Placa.Text = "No se encontro camion asignado";
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

        }

        public void CargarProducto()
        {
            Producto.Items.Clear();
            Producto.Items.Add(new ListItem("--Seleccione Un Producto--", ""));
            Producto.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cmd = new SqlCommand("BuscarProductos", cnx);
                cmd.Parameters.AddWithValue("@Producto", IdRuta);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                Producto.DataSource = dr; //cmd.ExecuteReader();    
                Producto.DataTextField = "Descripcion";
                Producto.DataValueField = "Id_Producto";
                Producto.DataBind();
                dr.Close();
            }
            catch (Exception e)
            {

            }
        }

        public int Origen()
        {
            SqlDataReader dr = NegAsignacionRuta.BuscarRuta(Ruta.Text);
            int Ori = 0;
            dr.Read();
            if (dr.HasRows == true)
            {
                if (dr != null)
                {
                    try
                    {
                        Ori = int.Parse(dr["Ori"].ToString());
                    }
                    catch (Exception e)
                    {
                        Ori = 0;
                    }
                }
            }
            return Ori;
        }

        public int Dest()
        {
            SqlDataReader dr = NegAsignacionRuta.BuscarRuta(Ruta.Text);
            int Des = 0;
            dr.Read();
            if (dr.HasRows == true)
            {
                if (dr != null)
                {
                    try
                    {
                        Des = int.Parse(dr["Des"].ToString());
                    }
                    catch (Exception e)
                    {
                        Des = 0;
                    }
                }
            }
            return Des;
        }

        public string Destino()
        {
            SqlDataReader dr = NegAsignacionRuta.BuscarRuta(Ruta.Text);
            string Des = "";
            dr.Read();
            if (dr.HasRows == true)
            {
                if (dr != null)
                {
                    try
                    {
                        Des = dr["Destino"].ToString();
                    }
                    catch (Exception e)
                    {
                        Des = "";
                    }
                }
            }
            return Des;
        }

        public void CargarDestino()
        {
            DdlUbicacion.Items.Clear();
            DdlUbicacion.Items.Add(new ListItem("--Seleccione una ubicacion--", ""));
            DdlUbicacion.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            int Desti = Dest();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {

                //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("BuscarPlanta", cnx);
                cmd.Parameters.AddWithValue("@Planta", Desti);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlUbicacion.DataSource = dr; //cmd.ExecuteReader();    
                DdlUbicacion.DataTextField = "Planta";
                DdlUbicacion.DataValueField = "Id";
                DdlUbicacion.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
        public void CargarOrigen()
        {
            DdlOrigen.Items.Clear();
            DdlOrigen.Items.Add(new ListItem("--Seleccione un Origen--", ""));
            DdlOrigen.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            int Or = Origen();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {

                //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("BuscarPlanta", cnx);
                cmd.Parameters.AddWithValue("@Planta", Or);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                DdlOrigen.DataSource = dr; //cmd.ExecuteReader();    
                DdlOrigen.DataTextField = "Planta";
                DdlOrigen.DataValueField = "Id";
                DdlOrigen.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
     

        public void CargarCombo()
        {
            Ruta.Items.Clear();
            Ruta.Items.Add(new ListItem("--Selecciona una RUTA--", ""));
            Ruta.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                
               //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("ProcBuscarCliente", cnx);
                cmd.Parameters.AddWithValue("@IdPersona", IdPersona);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                Ruta.DataSource = dr; //cmd.ExecuteReader();    
                Ruta.DataTextField = "Ruta";
                Ruta.DataValueField = "Id_Ruta";
                Ruta.DataBind();
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
            {
                if (EncontrarRepetidos() == false)
                {

                    EntDetalle_Recepcion ObjDe = new EntDetalle_Recepcion();
                    EntRecepcion ObjRe = new EntRecepcion();
                    SqlDataReader d = NegAsignacionRuta.BuscarChofer(Placa.Text);
                    d.Read();
                    try
                    {
                        ObjRe.Id_Recepcion = NegAsignacionRuta.Maximo();
                        ObjRe.Cod_Ente = int.Parse(txtNit.Text);//int.Parse(Cliente.Text);
                        ObjRe.Id_RecepcionManual = TextRecep.Text;
                        ObjRe.VolumenTotalDespacho = double.Parse(TextVolumenTotal.Text);
                        ObjRe.TramoDesde = int.Parse(DdlOrigen.Text);
                        ObjRe.TramoHasta = int.Parse(DdlUbicacion.Text);
                        ObjRe.FechaCarga = Convert.ToDateTime(TextCarga.Text);
                        try
                        {
                            ObjRe.FechaDescarga = Convert.ToDateTime(TextDescarga.Text);
                        }
                        catch (Exception ex)
                        {
                            ObjRe.FechaDescarga = Convert.ToDateTime(DateTime.Now.ToString());
                        }
                        ObjRe.Cod_Prod = int.Parse(Producto.Text);
                        ObjRe.Obs = txtOBS.Text;
                    }
                    catch (Exception ex)
                    {
                        return;
                    }

                    ObjDe.Monto_Anticipo = double.Parse(TextAnticipo.Text);
                    ObjDe.Placa_Camion = Placa.Text;
                    ObjDe.Id_Chofer = "0";
                    try
                    {
                        ObjDe.FechaCarga = Convert.ToDateTime(TextCarga.Text);
                        ObjDe.FechaDescarga = Convert.ToDateTime(TextDescarga.Text);
                        ObjDe.Vigencia = Convert.ToDateTime(TextVigencia.Text);
                    }
                    catch (Exception ex)
                    {
                        ObjDe.FechaCarga = Convert.ToDateTime(DateTime.Now.ToString());
                        ObjDe.FechaDescarga = Convert.ToDateTime(DateTime.Now.ToString());
                        ObjDe.Vigencia = Convert.ToDateTime(DateTime.Now.ToString());// string.Empty;

                    }

                    if (Request.QueryString["Id"] != null)
                    {
                        //ActualizaRegistros
                        ObjRe.Id_Recepcion = Convert.ToInt32(Request.QueryString["Id"]);
                        if (NegAsignacionRuta.ActualizarAsignacion(ObjRe, ObjDe) == 1)
                        {
                            //Response.Redirect("frmPrincipal.aspx");
                            //lblError.Text = "Registro de Entidad ACTUALIZADO satisfactoriamente";
                            //lblError.Visible = true;
                            Response.Write("<script languaje =javascript>alert ('Registro de Entidad ACTUALIZADO satisfactoriamente');</script>");
                            //Response.Redirect("frmRegistrarPropietarios.aspx");
                            //Cliente.Text = "";
                            TextRecep.Text = "";
                            Placa.Text = "";
                            Ruta.Text = "";
                            TextAnticipo.Text = "";
                            TextCarga.Text = "";
                            TextDescarga.Text = "";
                            TextVigencia.Text = "";



                        }
                        else
                        {
                            lblError.Text = "No se pudo ACTUALIZAR el Registro por algun motivo, Verifique e intente nuevamente";
                            lblError.Visible = true;
                        }
                    }
                    else
                    {
                        int Insertar = NegAsignacionRuta.InsertarAsignacion(ObjRe);
                        if (Insertar != 0)
                        {
                            foreach (GridViewRow row in GridView1.Rows)
                            {
                                double Volumen = 0;
                                EntDetalle_Recepcion red = new EntDetalle_Recepcion();
                                red.Id_Detalle = NegAsignacionRuta.MaximoDetalle();
                                red.Placa_Camion = row.Cells[0].Text;
                                red.Ubicacion = Destino();
                                red.Monto_Anticipo = double.Parse(row.Cells[3].Text);
                                red.Comportamiento1 = double.Parse(row.Cells[4].Text);
                                red.Comportamiento2 = double.Parse(row.Cells[5].Text);
                                red.Comportamiento3 = double.Parse(row.Cells[6].Text);
                                red.Comportamiento4 = double.Parse(row.Cells[7].Text);
                                red.Comportamiento5 = double.Parse(row.Cells[8].Text);
                                red.Comportamiento6 = double.Parse(row.Cells[9].Text);
                                red.Comportamiento7 = double.Parse(row.Cells[10].Text);
                                red.Precintos = int.Parse(row.Cells[11].Text);
                                red.Producto = int.Parse(row.Cells[12].Text);
                                red.Ruta = int.Parse(row.Cells[16].Text);
                                Volumen = red.Comportamiento1 + red.Comportamiento2 + red.Comportamiento3 + red.Comportamiento4 + red.Comportamiento5 + red.Comportamiento6 + red.Comportamiento7;
                                red.VolumenRecepcion = Volumen;
                                red.NombreTitular = HttpUtility.HtmlDecode(row.Cells[17].Text);
                                red.Id_Titular = row.Cells[20].Text;
                                red.DetallePlantaOrigen = int.Parse(row.Cells[18].Text);
                                red.DetallePlantaDestino = int.Parse(row.Cells[19].Text);
                                try
                                {
                                    red.FechaCarga = Convert.ToDateTime(row.Cells[13].Text);
                                }
                                catch (Exception er)
                                {
                                    red.FechaCarga = Convert.ToDateTime("01/01/01");
                                }
                                try
                                {
                                    red.FechaDescarga = Convert.ToDateTime(row.Cells[14].Text);

                                }
                                catch (Exception er)
                                {
                                    red.FechaDescarga = Convert.ToDateTime("01/01/01");
                                }

                                red.Id_Chofer = row.Cells[1].Text;

                                try
                                {
                                    red.Vigencia = Convert.ToDateTime(row.Cells[15].Text);

                                }
                                catch (Exception er)
                                {
                                    red.Vigencia = Convert.ToDateTime("01/01/01");
                                }
                                //red.Vigencia = Convert.ToDateTime(TextVigencia.Text);
                                SqlDataReader bd = NegAsignacionRuta.BuscarProgramacion(red.Placa_Camion, red.Ruta,red.FechaCarga);
                                bd.Read();
                                if (bd.HasRows == false)
                                {
                                    int v = NegAsignacionRuta.InsertarDetalle(red, Insertar);//red,Insertar);
                                }
                            }
                            //Response.Redirect("frmPrincipal.aspx");
                            lblError.Text = "Asignacion de RUTA registrada satisfactoriamente";
                            lblError.Visible = true;
                            Response.Write("<script languaje =javascript>alert ('Asignacion de RUTA registrada satisfactoriamente');</script>");
                            //Response.Redirect("frmRegistrarPropietarios.aspx");
                            //Cliente.Text = "";
                            TextRecep.Text = "";
                            Placa.Text = "";
                            TextBoxIdChofer.Text = "";
                            TextBoxNombreChofer.Text = "";
                            Ruta.Text = "";
                            //TextProd.Text = "";
                            TextAnticipo.Text = "";
                            TextCarga.Text = "";
                            TextDescarga.Text = "";
                            TextVigencia.Text = "";

                            DataTable dt = (DataTable)Session["dt"];
                            //dt.Clear();
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            Response.Redirect("FormProgramacionRuta.aspx");

                        }
                        else
                        {
                            lblError.Text = "No se pudo Insertar el Registro por algun motivo, Verifique e intente nuevamente,puede que algun documento este vencido";
                            lblError.Visible = true;

                        }

                    }
                }
        }

        protected void Cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            
        }

        protected void Ruta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ruta.Text != "")
            {
                IdRuta = int.Parse(Ruta.Text);
                CargarProducto();
                SqlDataReader d = NegAsignacionRuta.BuscarRuta(Ruta.Text);
                //SqlDataReader r = NegAsignacionRuta.BuscarMonto(Ruta.Text);
                d.Read();
                //r.Read();
                if (d.HasRows == true) //&& r.HasRows==true)
                {
                    if (d != null)// && r!= null)
                    {
                        try
                        {
                            //TextProd.Text = d["Descripcion"].ToString();
                            TextAnticipo.Text = d["MontoAnticipo"].ToString();
                            CargarOrigen();
                            CargarDestino();
                            
                        }
                        catch (Exception er)
                        {

                            //TextProd.Text = "";
                            TextAnticipo.Text = "";
                        }
                        finally
                        {

                        }
                    }
                    else
                    {
                        //TextProd.Text = "";
                    }
                }
                else
                {

                    //TextProd.Text = "";
                }
            }
            else
            {
                //TextProd.Text = "";
            }
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            double Vol = 0;
            string TitularAnticipo = TextIdTitular.Text;
            table = (System.Data.DataTable)(Session["Tabla"]);
            row = table.NewRow();
            row["Placa_Camion"] = Placa.Text;
            row["Id_Chofer"] = TextBoxIdChofer.Text;
            row["Nombres"] = TextBoxNombreChofer.Text;
            if (TitularAnticipo == "389115020" || TitularAnticipo=="6210978")
            {
                row["Monto_Anticipo"] = 0;
            }
            else
            {
                row["Monto_Anticipo"] = double.Parse(TextAnticipo.Text);
            }
            row["Ruta"] = int.Parse(Ruta.Text);
            row["NombreTitular"] = HttpUtility.HtmlDecode(TextBoxNomTitular.Text);
            row["Id_Titular"] = TextIdTitular.Text;
            row["DetallePlantaOrigen"] = int.Parse(DdlOrigen.Text);
            row["DetallePlantaDestino"] = int.Parse(DdlUbicacion.Text);
            if (TextBoxComp1.Text != "")
            {
                row["Compartimiento1"] = double.Parse(TextBoxComp1.Text);
            }
            else
            {
                row["Compartimiento1"] = 0;
            }
            if (TextBoxComp2.Text != "")
            {
                row["Compartimiento2"] = double.Parse(TextBoxComp2.Text);
            }
            else
            {
                row["Compartimiento2"] = 0;
            }
            if (TextBoxComp3.Text != "")
            {
                row["Compartimiento3"] = double.Parse(TextBoxComp3.Text);
            }
            else
            {
                row["Compartimiento3"] = 0;
            }
            if (TextBoxComp4.Text != "")
            {
                row["Compartimiento4"] = double.Parse(TextBoxComp4.Text);
            }
            else
            {
                row["Compartimiento4"] = 0;

            }
            if (TextBoxComp5.Text != "")
            {
                row["Compartimiento5"] = double.Parse(TextBoxComp5.Text);
            }
            else
            {
                row["Compartimiento5"] = 0;
            }
            if (TextBoxComp6.Text != "")
            {
                row["Compartimiento6"] = double.Parse(TextBoxComp6.Text);
            }
            else
            {
                row["Compartimiento6"] = 0;
            }
            if (TextBoxComp7.Text != "")
            {
                row["Compartimiento7"] = double.Parse(TextBoxComp7.Text);
            }
            else
            {
                row["Compartimiento7"] = 0;
            }
            row["Precintos"] = double.Parse(TexPrecintos.Text);
            row["Producto"] = int.Parse(Producto.Text);
            EntCamiones obj = new EntCamiones();
            SqlDataReader d = NegAsignacionRuta.BuscarPlaca(Placa.Text);
            d.Read();
            if (d.HasRows == true)
            {
                if (d != null)
                {
                    try
                    {
                        obj.Estado = int.Parse(d["Estado"].ToString());
                        if (obj.Estado != 2)
                        {
                            if (obj.Estado == 3)
                            {
                                lblError.Text = "El camion esta inactivo";
                                lblError.Visible = true;
                                return;
                            }
                            if (obj.Estado == 4)
                            {
                                lblError.Text = "El Camion esta De Viaje";
                                lblError.Visible = true;
                                return;
                            }
                            if(obj.Estado==5)
                            {
                                lblError.Text = "El Camion se encuentra en mantenimiento";
                                lblError.Visible = true;
                                return;
                            }
                        }

                        int ChEst = NegCamiones.EstadoChofer(TextBoxIdChofer.Text);
                        if (ChEst == 0)
                        {
                            lblError.Text = "El Chofer esta inhabilitado";
                            lblError.Visible = true;
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = "El camion no existe";
                        lblError.Visible = true;
                        return;
                    }
                }
            }
            try
            {
                row["FechaCarga"] = Convert.ToDateTime(TextCarga.Text);
            }catch (Exception er){
                row["FechaCarga"] = "";
            }
            try
            {
                row["FechaDescarga"] = Convert.ToDateTime(TextDescarga.Text);

            }
            catch (Exception er)
            {
                row["FechaDescarga"] = "";
            }
            try
            {
                row["Vigencia"] = Convert.ToDateTime(TextVigencia.Text);
            }
            catch (Exception er)
            {
                row["Vigencia"] = "";
            }
           
            SqlDataReader bd = NegAsignacionRuta.BuscarProgramacion(Placa.Text,Convert.ToInt32(Ruta.Text),Convert.ToDateTime(TextCarga.Text));
            bd.Read();
            if (bd.HasRows == true)
            {
                if(bd!=null)
                {
                    lblError.Text = "Esta Programacion ya ha sido metida";
                    lblError.Visible = true;
                    return;
                }
            }
            table.Rows.Add(row);
            GridView1.DataSource = table;
            GridView1.DataBind();
            Session.Add("Tabla", table);

            //TextCli.Text = "";
            //txtNit.Text = "";
            //TextRecep.Text = "";
            TextBoxNombreChofer.Text = "";
            TextBoxIdChofer.Text = "";
          

         }

        public bool EncontrarRepetidos()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                SqlDataReader bd = NegAsignacionRuta.BuscarProgramacion(Convert.ToString(row.Cells[0].Text), Convert.ToInt32(row.Cells[16].Text), Convert.ToDateTime(row.Cells[13].Text));
                bd.Read();
                if (bd.HasRows == true)
                {
                    if (bd != null)
                    {
                        return true; ;
                    }
                }
            }
            return false;
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
               table = (System.Data.DataTable)(Session["Tabla"]);
                int i=int.Parse(txtFila.Text)-1;
                DataRow dr= table.Rows[i];
                table.Rows.Remove(dr);
            GridView1.DataSource = table;
            GridView1.DataBind();
            
        }

        protected void TextCli_TextChanged(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {

            }
            SqlDataReader d = NegPersona.BuscarPersona(TextCli.Text);
            d.Read();
            if (d.HasRows == true)
            {
                if (d != null)
                {
                    try
                    {
                        IdPersona= int.Parse(d["Id_Persona"].ToString());
                        CargarCombo();
                        CargarAsignacion();
                    }
                    catch (Exception er)
                    {


                    }
                }
            }
        }


      
        protected void BtnBuscarNit_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                
                if (TextCli.Text != "")
                {
                    SqlDataReader d = NegAsignacionRuta.BuscarNit(TextCli.Text);
                    d.Read();
                    if (d.HasRows == true)
                    {
                        if (d != null)
                        {
                            try
                            {
                                txtNit.Text = d["Cod_Ente"].ToString();
                                //TxtChofer.Text = d["Nombre"].ToString() + " " + d["Apellidos"].ToString();
                                //TextId.Text = d["Id_Persona"].ToString();
                            }
                            catch (Exception er)
                            {
                                txtNit.Text = "No se encontro registro del Cliente, Registre e intente nuevamente";
                                //TxtChofer.Text = "";
                            }
                            finally
                            {

                            }
                        }
                        else
                        {
                            txtNit.Text = "No se encontro registro del Cliente, Registre e intente nuevamente";
                            //TxtChofer.Text = "";
                        }
                    }
                    else
                    {
                        txtNit.Text = "No se encontro registro del Cliente, Registre e intente nuevamente";
                        //TxtChofer.Text = "";
                    }
                }
                else
                {
                    txtNit.Text = "Debe introducir el CI del Chofer que desea buscar";
                    //TxtChofer.Text = "";
                }
            }
        }

        protected void ButtonPlacChof_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //LblChofer.Text = "*";
                if (Placa.Text != "")
                {
                    SqlDataReader d = NegAsignacionRuta.BuscarChofer(Placa.Text);
                    d.Read();
                    if (d.HasRows == true)
                    {
                        if (d != null)
                        {
                            try
                            {
                                TextBoxIdChofer.Text = d["IdChofer"].ToString();//d["Nombre"].ToString() + " " + d["Apellidos"].ToString();
                                TextBoxNombreChofer.Text = d["Chofer"].ToString();
                                TextBoxNomTitular.Text = d["titular"].ToString();
                                TextIdTitular.Text = d["IdTitBanco"].ToString();
                                lblError.Visible = false;
                            }
                            catch (Exception er)
                            {
                                
                                TextBoxNombreChofer.Text = "";
                            }
                            //finally
                            //{

                            //}
                        }
                        else
                        {
                            
                            TextBoxIdChofer.Text = "";
                            TextBoxNombreChofer.Text = "";
                            TextBoxNomTitular.Text = "";
                            TextIdTitular.Text = "";
                        }
                    }
                    else
                    {

                        TextBoxIdChofer.Text = "";
                        TextBoxNombreChofer.Text = "";
                        TextBoxNomTitular.Text = "";
                        TextIdTitular.Text = "";
                    }
                }
                else
                {

                    TextBoxIdChofer.Text = "";
                    TextBoxNombreChofer.Text = "";
                    TextBoxNomTitular.Text = "";
                    TextIdTitular.Text = "";
                }
            }
        }

        protected void DdlUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBoxNomTitular_TextChanged(object sender, EventArgs e)
        {

        }
       
    }
}