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
    public partial class FormProd : System.Web.UI.Page
    {
        string pro = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["Id"]!=null)
            {
                pro = TextProd.Text;
                int ProdId = Convert.ToInt32(Request.QueryString["Id"]);

            }

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TextProd.Text != "")
            {
                EntProducto ObjProd = new EntProducto();
                ObjProd.Descripcion = TextProd.Text;

                if (Request.QueryString["Id"] != null)
                {
                    //ActualizaRegistros
                    ObjProd.Id_Producto = Convert.ToInt32(Request.QueryString["Id"]);
                    if (Negproducto.ActualizarProducto(ObjProd) == 1)
                    {
                      
                        Response.Write("<script languaje =javascript>alert ('Registro de Entidad ACTUALIZADO satisfactoriamente');</script>");
                        //Response.Redirect("frmRegistrarPropietarios.aspx");
                        TextProd.Text = "";
                       
                    }
                    else
                    {
                        lblError.Text = "No se pudo ACTUALIZAR el Registro por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    if (Negproducto.InsertarProducto(ObjProd)== 1)//insertamos producto
                    {
                        
                        lblError.Text = "Registro de Entidad guardado satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                      
                        TextProd.Text = "";
                        

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