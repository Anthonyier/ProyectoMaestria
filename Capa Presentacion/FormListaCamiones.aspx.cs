using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class FormListaCamiones : System.Web.UI.Page
    {
        private static DataTable dtMarcas = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarMarcas();
                CargarCombo();
            }
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + "" + us.Apellidos;
            bit.Accion = "El usuario esta en la lista camiones ";
            bit.IdUsuario = us.Id_Usuario;
            int bi = NegBitacora.GuardarBitacora(bit);

           
        }
        public void CargarCombo()
        {
            cmEstado.Items.Clear();
            cmEstado.Items.Add(new ListItem("--Selecciona un ESTADO--", ""));
            cmEstado.AppendDataBoundItems = true;
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {

                //String sql = "Select Id_Ruta, Ruta, MontoAnticipo,Producto.Descripcion From Ruta,Producto where Ruta.Id_Producto=Producto.Id_Producto and Ruta.Id_Cliente=Persona.Id_Persona And Ruta.Id_Cliente";
                cmd = new SqlCommand("ProcBuscarEstado", cnx);
                //cmd.Parameters.AddWithValue("@IdPersona", IdPersona);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //cmd.Connection = cnx;
                SqlDataReader dr = null;
                cnx.Open();
                //cmd.Transaction = myTrans;
                dr = cmd.ExecuteReader();
                cmEstado.DataSource = dr; //cmd.ExecuteReader();    
                cmEstado.DataTextField = "Desccripcion";
                cmEstado.DataValueField = "Id";
                cmEstado.DataBind();
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
        public void CargarMarcas()
        {
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cmd = new SqlCommand("BuscarMarca", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = null;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                dtMarcas = new DataTable();
                dtMarcas.Load(dr);
                //dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnx.Close();// cmd.Connection.Close();
                cnx.Dispose();// cmd.Connection.Dispose();
            }
        }

        protected void DtgListaCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EntUsuario us = (EntUsuario)Session["Usuario"];
            EntBitacora bit = new EntBitacora();
            bit.Usuario = us.Nombre + "" + us.Apellidos;
            bit.IdUsuario = us.Id_Usuario;
            if (e.CommandName == "EditarCamion")
            {
                
                bit.Accion = "El usuario va editar un camion ";
                
                int bi = NegBitacora.GuardarBitacora(bit);
                
              

                    string CamionId = e.CommandArgument.ToString();
                    Response.Redirect("FormCamiones.aspx?Id=" + CamionId);
                
            }
            if (e.CommandName == "AgregarDocumentos")
            {
                

 
            }
            if (e.CommandName == "Anular")
            {

                {
                    string CamionId = e.CommandArgument.ToString();
                    NegCamiones.EliminarCamion(int.Parse(CamionId));
                    Response.Write("<script languaje =javascript>alert ('Deshabilitado satisfactoriamente');</script>");
                }
            }
        }
        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
             

        //        ((DropDownList)e.Row.FindControl("cmbMarca")).DataValueField = "Id_Marca";
        //        ((DropDownList)e.Row.FindControl("cmbMarca")).DataTextField = "Descripcion";
        //        ((DropDownList)e.Row.FindControl("cmbMarca")).DataSource = dtMarcas;
        //        ((DropDownList)e.Row.FindControl("cmbMarca")).DataBind();

        //    }
        }

        protected void GridViewCamiones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TxtBuscar.Text != "")
            {
                SqlDataReader d = NegCamiones.BuscarCamion(TxtBuscar.Text);
                d.Read();
                if (d.HasRows == true)
                {
                    if (d != null)
                    {
                        try
                        {
                            TxtBuscar.Text = d["Id_Camion"].ToString();
                            Response.Redirect("FormCamiones.aspx?Id=" + TxtBuscar.Text);
                        }
                        catch (Exception er)
                        {

                            TxtBuscar.Text = "No se encontro registro de la persona, Registrelo e intente nuevamente";
                        }
                        finally
                        {

                        }
                    }
                    else
                    {

                        TxtBuscar.Text = "No se encontro registro de la persona, Registrelo e intente nuevamente";
                    }
                }
                else
                {

                    TxtBuscar.Text = "No se encontro registro de la persona, Registrelo e intente nuevamente";
                }
            }
            else
            {

                TxtBuscar.Text = "No se encontro registro de la persona, Registrelo e intente nuevamente";
            }
        }

        protected void BtnBuscarPorEstado_Click(object sender, EventArgs e)
        {
           
            SqlDataReader c = NegCamiones.Cantidad (Convert.ToInt32(cmEstado.Text));
                c.Read();
                if (c.HasRows == true)
                {
                    lblCamionesDisp.Text = c["Cantidad"].ToString();//.ToString();
                }

                GridviewActi.Visible = false;
                GridViewCamiones.Visible = true;
                GridDesha.Visible = false;
        }

        protected void BtnBuscarActivo_Click(object sender, EventArgs e)
        {
            GridviewActi.Visible = true;
            GridViewCamiones.Visible = false;
            GridDesha.Visible = false;
            SqlDataReader c = NegCamiones.Cant();
            c.Read();
            if (c.HasRows == true)
            {
                lblCamionesDisp.Text = c["Cantidad"].ToString();//.ToString();
            }
        }

        protected void cmEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnBuscarDeshabilitados_Click(object sender, EventArgs e)
        {

            GridviewActi.Visible = false;
            GridViewCamiones.Visible = false;
            GridDesha.Visible = true;
            SqlDataReader c = NegCamiones.CantDesha();
            c.Read();
            if (c.HasRows == true)
            {
                lblCamionesDisp.Text = c["Cantidad"].ToString();//.ToString();
            }
        }
    }
}