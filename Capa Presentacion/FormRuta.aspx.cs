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
    public partial class FormRuta : System.Web.UI.Page
    {
        private int Or = 0;
        private int Des = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                //Response.AppendHeader("Refresh"; URL=http://FormRuta");

            {
                Cliente.AppendDataBoundItems = true;
                CargarCliente();
                //CargarProducto();

                //SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bercamConnectionString5"].ConnectionString;

                //SqlDataSource1.SelectCommand = "SELECT * FROM [Vi_ListaRuta]";



                //GridView1.DataSource = SqlDataSource1;

                //GridView1.DataBind();

                if (Request.QueryString["Id"] != null)
                {

                    int RutaId = Convert.ToInt32(Request.QueryString["Id"]);
                    EntRuta obj = new EntRuta();
                    obj = NegRuta.BuscarTodo(RutaId); //haber
                    TextRuta.Text = obj.Ruta;//aqui el error del 13-09-17
                    TextMonto.Text = Convert.ToString(obj.MontoAnticipo);
                    TextPrecio.Text = Convert.ToString(obj.PrecioTotal);
                    TextFletero.Text = Convert.ToString(obj.PrecioFlet);
                    txtIdOrigen.Text = Convert.ToString(obj.Origen);
                    TextOrigen.Text = Convert.ToString(obj.Origens);
                    TextUbicacion.Text = Convert.ToString(obj.Destinos);
                    txtIdDestino.Text = Convert.ToString(obj.Destino);
                    //SqlDataReader d = NegRuta.EncontrarCliente(obj.Id_Cliente);
                    //SqlDataReader r = NegRuta.BuscarProducto(obj.Id_Producto);
                    //d.Read();
                    //r.Read();
                    //Producto.Text = r["Descripcion"].ToString();
                    //Cliente.Text = d["CLIENTE"].ToString()

                }
            }
           
           
        }

        public void GridView1_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }
        protected void DtgListaRuta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarRuta")
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario va Modificar Rutas";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
               
                string sRutaId = e.CommandArgument.ToString();
                Response.Redirect("FormRuta.aspx?Id=" + sRutaId);
                
            }
            if (e.CommandName == "CarroGuia")
            {
                
            }
        }
        public void CargarCliente()
        {
            Cliente.Items.Clear();
            Cliente.Items.Add(new ListItem("--Selecciona Cliente--", ""));
            Cliente.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string sql = "SELECT * FROM Vi_Cliente";
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                Cliente.DataSource = dr; //cmd.ExecuteReader();    
                Cliente.DataTextField = "CLIENTE";
                Cliente.DataValueField = "Id_Persona";
                Cliente.DataBind();
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

            if (TextRuta.Text != "")
            {
                EntRuta ObjRuta= new EntRuta();
                ObjRuta.Ruta = TextRuta.Text;
                if (txtIdOrigen.Text != "")
                {
                    ObjRuta.Origen = Convert.ToInt32(txtIdOrigen.Text);
                }
                if (txtIdDestino.Text !="")
                {
                    ObjRuta.Destino = Convert.ToInt32(txtIdDestino.Text);
                }
                ObjRuta.MontoAnticipo = double.Parse(TextMonto.Text);
                ObjRuta.PrecioFlet = double.Parse(TextFletero.Text);
                ObjRuta.PrecioTotal = double.Parse(TextPrecio.Text);
                guardarPlantas();
                if(txtIdOrigen.Text=="")
                {
                    ObjRuta.Origen = Or;
                }
                if (txtIdDestino.Text == "")
                {
                    ObjRuta.Destino = Des;
                }
               
                if (Cliente.Text == "")
                {
                    ObjRuta.Id_Cliente = 0;
                }
                else
                {
                    ObjRuta.Id_Cliente = int.Parse(Cliente.Text);
                }
                if (Request.QueryString["Id"] != null)
                {
                   
                    //ActualizaRegistros
                    ObjRuta.Id_Ruta = Convert.ToInt32(Request.QueryString["Id"]);
                    if (NegRuta.ActualizarRuta(ObjRuta) == 1)
                    {
                        //Response.Redirect("frmPrincipal.aspx");
                        //lblError.Text = "Registro de Entidad ACTUALIZADO satisfactoriamente";
                        //lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Entidad ACTUALIZADO satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        TextRuta.Text = "";
                        TextPrecio.Text = "";
                        TextMonto.Text = "";
                        txtIdDestino.Text = "";
                        txtIdOrigen.Text = "";
                        TextOrigen.Text = "";
                        TextUbicacion.Text = "";
                        TextFletero.Text = "";
                    }
                    else
                    {
                        lblError.Text = "No se pudo ACTUALIZAR el Registro por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    //Insertar Ruta
                    if (ObjRuta.Id_Cliente != 0 && ObjRuta.Id_Cliente != 0 && NegRuta.InsertarRuta(ObjRuta) == 1)
                    {
                        //Response.Redirect("frmPrincipal.aspx");
                        lblError.Text = "Registro de Entidad guardado satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        TextRuta.Text = "";
                        TextMonto.Text = "";
                        TextPrecio.Text = "";
                        txtIdDestino.Text = "";
                        txtIdOrigen.Text = "";

                       
                        
                        

                    }
                    else
                    {
                        lblError.Text = "No se pudo Insertar el Registro por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;

                    }

                }

            }
            else
            {
                lblError.Text = "Faltan Ingresar campos Obligatorios";
                lblError.Visible = true;
            }
        }

        public void guardarPlantas()
        {
            if (txtIdOrigen.Text != null && txtIdOrigen.Text != String.Empty)
            {
                //no hace nada ya que ese item ya esta guardado en la Base de datos
            }
            else
            {
               Or= GuardarPlanta(TextOrigen.Text);
            }
            if (txtIdDestino.Text != null && txtIdDestino.Text != String.Empty)
            {
                //no hace nada ya que ese item ya esta guardado en la Base de datos
            }
            else
            {
                Des=GuardarPlanta(TextUbicacion.Text);
            }
        }
      
        protected void TextOrigen_TextChanged(object sender, EventArgs e)
        {
            string var;
            string idpl=string.Empty;//0;
            var = TextOrigen.Text;
            string queryString = "SELECT * FROM Planta where Descripcion = '" + var.ToString() + "'";

            using (SqlConnection connection = new SqlConnection(Properties.Resources.ConexionBercamPrin))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idpl = Convert.ToString(reader["Id"].ToString());
                           
                        }
                        int re;
                        
                        txtIdOrigen.Text= idpl.ToString();
                       
                    connection.Close();
                }
            }
            }
        }
            public int GuardarPlanta(string desc){
                SqlCommand cmd = null;
                SqlTransaction myTrans = null;
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                int res = 0;
                try
                {
                    cnx.Open();
                    myTrans = cnx.BeginTransaction();

                    string sql = "Insert into Planta (Descripcion) values" +
                        "(@Descripcion);SELECT Scope_Identity();";
                    cmd = new SqlCommand(sql, cnx);
                    cmd.Parameters.AddWithValue("@Descripcion", desc);
                    cmd.Transaction = myTrans;
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception e)
                {
                    myTrans.Rollback();

                }
                myTrans.Commit();
                cnx.Close();
                return res;
            }
        protected void TextUbicacion_TextChanged(object sender, EventArgs e)
        {
            string var;
            string idpl=string.Empty;//0;
            var = TextUbicacion.Text;
            string queryString = "SELECT * FROM Planta where Descripcion = '" + var.ToString() + "'";

            using (SqlConnection connection = new SqlConnection(Properties.Resources.ConexionBercamPrin))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idpl = Convert.ToString(reader["Id"].ToString());
                        }
                        int re;
                        //re = idpl;
                        txtIdDestino.Text= idpl.ToString();
                        //if (txtIdDestino.Text != null || txtIdDestino.Text != String.Empty) 
                        //{
                        //    //no hace nada ya que ese item ya esta guardado en la Base de datos
                        //}
                        //else
                        //{
                        //    GuardarPlanta(var);
                        //}
                    connection.Close();
                }
            }
         }
     }
   }
}