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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string Capacidad = "";
        string OBS = "";
        string Ubicacion = "";
        string Placa = "";
        int Chofer = 0;
        int Propietario = 0;
        int TitBanco = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Marca.AppendDataBoundItems = true;
                Color.AppendDataBoundItems = true;
                Banco.AppendDataBoundItems = true;
                Rastreo.AppendDataBoundItems = true;
                CargarComboMarca();
                CargarComboColor();
                CargarComboBanco();
                CargarComboRastreo();
                if (Request.QueryString["Id"] != null)
                {
                    Capacidad = txtCapacidad.Text;
                    OBS = txtOBS.Text;
                    Ubicacion = txtUbicacion.Text;
                    Placa = txtPlaca.Text;
                    int CamionId = Convert.ToInt32(Request.QueryString["Id"]);
                    //int NroCuenta=Convert.ToInt32(Request.QueryString["NroCuenta"]);
                    EntCamiones objCamion = new EntCamiones();
                    EntCuenta objCuenta = new EntCuenta();
                    objCamion = NegCamiones.BuscarCamiones(CamionId); //haber
                    //objCuenta = NegCamiones.BuscarCuenta(NroCuenta);
                    txtPlaca.Text = objCamion.Placa;//aqui el error del 13-09-17
                    txtEmplaque.Text = objCamion.Emplaque;
                    txtCapacidad.Text = objCamion.Capacidad;
                    txtOBS.Text = objCamion.OBS;
                    Cuenta.Text = "0";
                    Banco.SelectedIndex = 1;
                    Marca.Text = Convert.ToString(objCamion.Id_Marca);
                    Color.Text = Convert.ToString(objCamion.Id_Color);
                    txtUbicacion.Text = objCamion.Ubicacion;
                    TxtCiPropietario.Text = objCamion.IdPropietario;
                    TxtCiChofer.Text = objCamion.IdChofer;
                    TxtCittitularBanco.Text = objCamion.IdTitBanco;
                    string Tit = TxtCittitularBanco.Text;
                    SqlDataReader d = NegCamiones.BuscarTit(Tit);
                     d.Read();
                     if (d.HasRows == true)
                     {
                         if (d != null)
                         {
                             try
                             {
                                 Cuenta.Text = d["NroCuenta"].ToString();
                                 Banco.Text = d["Id_Banco"].ToString();
                             }
                             catch (Exception er)
                             {
                                 Cuenta.Text = "No se encontro la cuenta";
                             }
                         }
                     }
                    
                    Rastreo.Text = Convert.ToString(objCamion.Id_Rastreo);
                    EntUsuario us = (EntUsuario)Session["Usuario"];
                    EntBitacora bit = new EntBitacora();
                    bit.Usuario = us.Nombre + "" + us.Apellidos;
                    bit.Accion = "El usuario esta intentando modificar camiones";
                    bit.IdUsuario = us.Id_Usuario;
                    int bi = NegBitacora.GuardarBitacora(bit);

                }
                else
                {
                    EntUsuario us = (EntUsuario)Session["Usuario"];
                    EntBitacora bit = new EntBitacora();
                    bit.Usuario = us.Nombre + "" + us.Apellidos;
                    bit.Accion = "El usuario esta intentando crear Camiones";
                    bit.IdUsuario = us.Id_Usuario;
                    int bi = NegBitacora.GuardarBitacora(bit);
                }

                
             }

            
        }


        public void CargarComboMarca()
        {
            Marca.Items.Clear();
            Marca.Items.Add(new ListItem("--Selecciona una Marca--", ""));
            Marca.AppendDataBoundItems = true;
             ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                String sql = "Select Id_Marca, Descripcion from Marca";
                //cmd.Parameters.AddWithValue("@Id_Tipo_Prod1", cmbCategoria1.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                Marca.DataSource = dr; //cmd.ExecuteReader();    
                Marca.DataTextField = "Descripcion";
                Marca.DataValueField = "Id_Marca";
                Marca.DataBind();
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

        public void CargarComboColor()
        {
            Color.Items.Clear();
            Color.Items.Add(new ListItem("--Selecciona una Color--", ""));
            Color.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                String sql = "Select Id_Color, Descripcion from Color";
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                
                dr = cmd.ExecuteReader();
                Color.DataSource = dr;    
                Color.DataTextField = "Descripcion";
                Color.DataValueField = "Id_Color";
                Color.DataBind();
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

        public void CargarComboBanco()
        {
            Banco.Items.Clear();
            Banco.Items.Add(new ListItem("--Selecciona un Banco--", ""));
            Banco.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                String sql = "Select Id_Banco, Descripcion from Banco";
              
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                
                dr = cmd.ExecuteReader();
                Banco.DataSource = dr;  
                Banco.DataTextField = "Descripcion";
                Banco.DataValueField = "Id_Banco";
                Banco.DataBind();
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
       
        public void CargarComboRastreo()
        {
            Rastreo.Items.Clear();
            Rastreo.Items.Add(new ListItem("--Selecciona un Rastreo--", ""));
            Rastreo.AppendDataBoundItems = true;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            SqlCommand cmd = new SqlCommand();
            try
            {
                String sql = "Select Id_Rastreo, Descripcion from Rastreo";
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                Rastreo.DataSource = dr; 
                Rastreo.DataTextField = "Descripcion";
                Rastreo.DataValueField = "Id_Rastreo";
                Rastreo.DataBind();
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

       
        protected void BtnPropietario_Click(object sender, EventArgs e)
        {
            LblPropieatrio.Text = "*";
            if (TxtPropietario.Text != "")
            {
                SqlDataReader d = NegCamiones.BuscarPropietario(TxtPropietario.Text);
                d.Read();
                if (d.HasRows == true)
                {
                    if (d != null)
                    {
                        try
                        {
                            TxtCiPropietario.Text = d["CI"].ToString();
                        }
                        catch (Exception er)
                        {
                            LblPropieatrio.Text = "No se encontro registro del Propietario, Registrelo e intente nuevamente";
                            TxtPropietario.Text = "";
                        }
                        finally
                        {

                        }
                    }
                    else
                    {
                        LblPropieatrio.Text = "No se encontro registro del Propietario, Registrelo e intente nuevamente";
                        TxtPropietario.Text = "";
                    }
                }
                else
                {
                    LblPropieatrio.Text = "No se encontro registro del Propietario, Registrelo e intente nuevamente";
                    TxtPropietario.Text = "";
                }
            }
            else
            {
                LblPropieatrio.Text = "Debe introducir el CI del Propietario que desea buscar";
                TxtPropietario.Text = "";
            }

        }

        protected void BtnChofer_Click(object sender, EventArgs e)
        {
            LblMensajeChofer.Text = "*";
            if (TxtChofer.Text != "")
            {
                SqlDataReader d = NegCamiones.BuscarChofer(TxtChofer.Text);
                d.Read();
                if (d.HasRows == true)
                {
                    if (d != null)
                    {
                        try
                        {
                            TxtCiChofer.Text = d["CI"].ToString();
                        }
                        catch (Exception er)
                        {
                            LblMensajeChofer.Text = "No se encontro registro del Chofer, Registrelo e intente nuevamente";
                            TxtCiChofer.Text = "";
                        }
                        finally
                        {

                        }
                    }
                    else
                    {
                        LblMensajeChofer.Text = "No se encontro registro del Chofer, Registrelo e intente nuevamente";
                        TxtCiChofer.Text = "";
                    }
                }
                else
                {
                    LblMensajeChofer.Text = "No se encontro registro del Chofer, Registrelo e intente nuevamente";
                    TxtCiChofer.Text = "";
                }
            }
            else
            {
                LblMensajeChofer.Text = "Debe introducir el CI del Chofer que desea buscar";
                TxtCiChofer.Text = "";
            }
        }
        protected void BtnTitularBanco_Click(object sender, EventArgs e)
        {
            lblMensajeTitularBanco.Text = "*";
            if (txtDatosTitularBanco.Text != "")
            {
                SqlDataReader d = NegCamiones.BuscarTitular(txtDatosTitularBanco.Text);
                d.Read();
                if (d.HasRows == true)
                {
                    if (d != null)
                    {
                        try
                        {
                            TxtCittitularBanco.Text = d["CI"].ToString();
                        }
                        catch (Exception er)
                        {
                            lblMensajeTitularBanco.Text = "No se encontro registro del Propietario, Registrelo e intente nuevamente";
                            txtDatosTitularBanco.Text = "";
                        }
                        finally
                        {

                        }
                    }
                    else
                    {
                        lblMensajeTitularBanco.Text = "No se encontro registro del Propietario, Registrelo e intente nuevamente";
                        txtDatosTitularBanco.Text = "";
                    }
                }
                else
                {
                    lblMensajeTitularBanco.Text = "No se encontro registro del Propietario, Registrelo e intente nuevamente";
                    txtDatosTitularBanco.Text = "";
                }
            }
            else
            {
                lblMensajeTitularBanco.Text = "Debe introducir el CI del Propietario que desea buscar";
                txtDatosTitularBanco.Text = "";
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text != "" && txtEmplaque.Text != "")
            {
                EntCamiones objCamion = new EntCamiones();
                EntCuenta objCuen = new EntCuenta();
                
                objCamion.Placa = txtPlaca.Text;
                objCamion.Emplaque = txtEmplaque.Text;
                
                objCamion.Capacidad = txtCapacidad.Text;
                objCamion.OBS = txtOBS.Text;
                objCamion.Id_Marca = int.Parse(Marca.Text);
                objCamion.Id_Color = int.Parse(Color.Text);
                objCamion.IdPropietario = TxtCiPropietario.Text;
                objCamion.IdChofer = TxtCiChofer.Text;
                objCamion.IdTitBanco = TxtCittitularBanco.Text;
                objCamion.Id_Rastreo = int.Parse(Rastreo.Text);
                objCamion.Ubicacion = txtUbicacion.Text;

                objCuen.NroCuenta = long.Parse(Cuenta.Text);
                objCuen.Id_Banco = int.Parse(Banco.Text);

                if (Request.QueryString["Id"] == null) { 
                EntCamiones Ca = null;
                Ca = NegCamiones.Repetidos(objCamion.Placa);
                if (Ca != null)
                {
                    lblError.Text = "No se permiten datos repetidos";
                    lblError.Visible = true;
                    return;
                }
            }

                if (Request.QueryString["Id"] != null)
                {
                   
                    //ActualizaRegistros
                    objCamion.Id_Camion = Convert.ToInt32(Request.QueryString["Id"]);
                    if (NegCamiones.ActualizarCamiones(objCamion,objCuen) == 1)
                    {
                        
                        Response.Write("<script languaje =javascript>alert ('Registro de Entidad ACTUALIZADO satisfactoriamente');</script>");
                        
                        txtPlaca.Text = "";
                        txtEmplaque.Text = "";
                        txtCapacidad.Text = "";
                        txtOBS.Text = "";
                        Marca.Text = "";
                        Color.Text = "";
                        TxtCiPropietario.Text = "";
                        TxtCiChofer.Text = "";
                        TxtCittitularBanco.Text = "";
                        EntUsuario us = (EntUsuario)Session["Usuario"];
                        EntBitacora bit = new EntBitacora();
                        bit.Usuario = us.Nombre + "" + us.Apellidos;
                        bit.Accion = "El usuario a logrado modificar camiones";
                        bit.IdUsuario = us.Id_Usuario;
                        int bi = NegBitacora.GuardarBitacora(bit);
                        
                    }  
                    else
                    {
                        lblError.Text = "No se pudo ACTUALIZAR el Registro por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                  }

                    //}
                    else
                    {
                        if (NegCamiones.InsertarCamiones(objCamion,objCuen) == 1)
                        {
                            //Response.Redirect("frmPrincipal.aspx");
                            lblError.Text = "Registro de Entidad guardado satisfactoriamente";
                            lblError.Visible = true;
                            Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                            //Response.Redirect("frmRegistrarPropietarios.aspx");
                            txtPlaca.Text = "";
                            txtEmplaque.Text = "";
                            txtCapacidad.Text = "";
                            txtOBS.Text = "";
                            Marca.Text = "";
                            Color.Text = "";
                            TxtCiPropietario.Text = "";
                            TxtCiChofer.Text = "";
                            TxtCittitularBanco.Text = "";
                            Rastreo.Text = "";
                            EntUsuario us = (EntUsuario)Session["Usuario"];
                            EntBitacora bit = new EntBitacora();
                            bit.Usuario = us.Nombre + "" + us.Apellidos;
                            bit.Accion = "El usuario ha logrado crear camiones";
                            bit.IdUsuario = us.Id_Usuario;
                            int bi = NegBitacora.GuardarBitacora(bit);
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
        }
    }
