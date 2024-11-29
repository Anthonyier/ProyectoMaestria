using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using System.IO;

namespace CapaPresentacion
{
    public partial class FrmRegistrodeEntidades : System.Web.UI.Page
    {
        int Ciaux = 0;
        string Nom = "";
        string Ap = "";
        string Dir = "";
        string Telf = "";
        string TelRef = "";
        string mail = "";
        string Emision = "";
        int Cod = 0;
        bool Prop = false;
        bool Chof = false;
        bool Titban = false;
        bool Usua = false;
        bool Clien = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null) // Cargamos una persona ya existente
            {
                
                Nom = txtNombres.Text;
                Ap = txtApellidos.Text;
                Dir = txtDireccion.Text;
                Telf = txtTelefono.Text;
                TelRef = txtTelfReferencia.Text;
                mail = txtEmail.Text;
                Emision = txtEmision.Text;
                int PersonaId = Convert.ToInt32(Request.QueryString["Id"]);
                txtCI.Text = Convert.ToString(PersonaId);
                EntPersona objPropietario = new EntPersona();
                objPropietario = NegPersona.BuscarTodo(PersonaId); //BuscarPersona
                txtCI.Text = objPropietario.CI;
                txtEmision.Text = objPropietario.Emision; 
                txtNombres.Text = objPropietario.Nombres;
                txtApellidos.Text = objPropietario.Apellidos;
                txtDireccion.Text = objPropietario.Direccion;
                txtTelefono.Text = objPropietario.Telefono;
                txtTelfReferencia.Text = objPropietario.TelfReferencia;
                txtEmail.Text = objPropietario.Email;
                Cod = objPropietario.Cod_Ente;
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario esta intentando modificar persona ";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);
                objPropietario = NegPersona.BuscarTipoEntidad(PersonaId);

                MarcarCheckboxLoad(objPropietario);
            }
            else
            {
                EntUsuario us = (EntUsuario)Session["Usuario"];
                EntBitacora bit = new EntBitacora();
                bit.Usuario = us.Nombre + "" + us.Apellidos;
                bit.Accion = "El usuario esta intentando crear persona ";
                bit.IdUsuario = us.Id_Usuario;
                int bi = NegBitacora.GuardarBitacora(bit);

            }
            
        }

        public void MarcarCheckboxLoad(EntPersona objPropietario)
        {
            if (objPropietario.Id_TipoPersonaPRO == 1)
            {
                chkPropietario.Checked = true;
                Prop = true;
            }
            if (objPropietario.Id_TipoPersonaCho == 1)
            {
                chkChofer.Checked = true;
                Chof = true;
            }
            if (objPropietario.Id_TipoPersonaTit == 1)
            {
                chkTitularBanco.Checked = true;
                Titban = true;
            }
            if (objPropietario.Id_TipoPersonaUs == 1)
            {
                chkUsuario.Checked = true;
                Usua = true;
            }
            if (objPropietario.Id_TipoPersonaCL == 1)
            {
                chkCliente.Checked = true;
                Clien = true;
            }
        }

        protected void validarCheckbox_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (chkChofer.Checked)
            {

            }
        }


        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txtContraseña.Text) == Convert.ToString(txtConfirmarContraseña.Text))
            {
                //SIGUE SU CURSO
            }
            else
            {
                lblError.Text = "LAS CONTRASEÑAS NO COINCIDEN, VERIFIQUE E INTENTE NUEVAMENTE";
                lblError.Visible = true;
                return;
            }
           
            if (txtNombres.Text != "" && txtCI.Text != "")
                // si texto nombre y texto Ci no son vacios
            {
                EntPersona objPropietario = new EntPersona();
                
                try
                {
                    objPropietario.CI = txtCI.Text;
                }
                catch (Exception ex)
                {
                    lblError.Text = "El campo CI no tiene el formato correcto";
                    lblError.Visible = true;
                    return;
                }


                CheckearTipoPerosna(objPropietario);
                objPropietario.Nombres = txtNombres.Text;
                objPropietario.Apellidos = txtApellidos.Text;
                objPropietario.Direccion = txtDireccion.Text;
                objPropietario.Emision = txtEmision.Text;
                objPropietario.Telefono = txtTelefono.Text;
                objPropietario.TelfReferencia = txtTelfReferencia.Text;
                objPropietario.Email = txtEmail.Text;
                


              
                if (chkChofer.Checked == false && chkCliente.Checked == false && chkTitularBanco.Checked == false && chkPropietario.Checked == false && chkUsuario.Checked==false)
                {
                    lblError.Text = "Por favor de click en algun checkbox";
                    lblError.Visible = true;
                    return;
                }
                if (chkUsuario.Checked)
                {
                    objPropietario.Usuario = txtUsuario.Text;
                    objPropietario.Contraseña = txtContraseña.Text;
                }

                if (Request.QueryString["Id"] == null)
                {
                    EntPersona Per = null;
                    Per = NegPersona.Repetidos(objPropietario.CI);
                    if (Per != null)
                    {
                        lblError.Text = "No se permiten datos repetidos";
                        lblError.Visible = true;
                        return;
                    }

                }

                if (Request.QueryString["Id"] != null)
                {
                    objPropietario.Id_TipoPersonaCho = 0;
                    objPropietario.Id_TipoPersonaCL = 0;
                    objPropietario.Id_TipoPersonaPRO = 0;
                    objPropietario.Id_TipoPersonaTit = 0;
                    objPropietario.Id_TipoPersonaUs = 0;
                    
                    objPropietario.Nombres= Nom;
                     objPropietario.Apellidos= Ap;
                   objPropietario.Direccion = Dir;
                    objPropietario.Telefono = Telf;
                    objPropietario.Emision = Emision;
                    objPropietario.TelfReferencia =TelRef;
                    objPropietario.Email = mail;
                    objPropietario.Cod_Ente = Cod;

                    if (chkChofer.Checked && Chof==false)
                    {
                        objPropietario.Id_TipoPersonaCho = 1;
                    }

                    if(chkCliente.Checked && Clien==false){
                    objPropietario.Id_TipoPersonaCL = 1;
                    }

                    if (chkPropietario.Checked && Prop==false)
                    {
                        objPropietario.Id_TipoPersonaPRO = 1;
                    }

                    if(chkTitularBanco.Checked && Titban==false)
                    {
                        objPropietario.Id_TipoPersonaTit = 1;
                    }

                    if (chkUsuario.Checked && Usua==false)
                    {
                        objPropietario.Id_TipoPersonaUs = 1;
                    }
                    //ActualizaRegistros
                    objPropietario.Id_Persona = Convert.ToInt32(Request.QueryString["Id"]);
                    if (NegPersona.ActualizarPropietario(objPropietario) == 1)
                    {
                 
                        
                        lblError.Text = "Registro de Entidad ACTUALIZADO satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Entidad ACTUALIZADO satisfactoriamente');</script>");

                        LimpiarTextbox();

                        EntUsuario us = (EntUsuario)Session["Usuario"];
                        EntBitacora bit = new EntBitacora();
                        bit.Usuario = us.Nombre + "" + us.Apellidos;
                        bit.Accion = "El usuario a logrado actualizar la persona";
                        bit.IdUsuario = us.Id_Usuario;
                        int bi = NegBitacora.GuardarBitacora(bit);
                    }

                    //}
                    else
                    {
                        lblError.Text = "No se pudo ACTUALIZAR el Registro por algun motivo, Verifique e intente nuevamente";
                        lblError.Visible = true;

                    }
                }
                else
                {
                    if (NegPersona.InsertarPersona(objPropietario) == 1) // Insertamos La person
                    {
                       
                        lblError.Text = "Registro de Entidad guardado satisfactoriamente";
                        lblError.Visible = true;
                        Response.Write("<script languaje =javascript>alert ('Registro de Entidad guardado satisfactoriamente');</script>");
                        

                        LimpiarTextbox();

                        EntUsuario us = (EntUsuario)Session["Usuario"];
                        EntBitacora bit = new EntBitacora();
                        bit.Usuario = us.Nombre + "" + us.Apellidos;
                        bit.Accion = "El usuario a logrado crear la persona";
                        bit.IdUsuario = us.Id_Usuario;
                        int bi = NegBitacora.GuardarBitacora(bit);

                    }

                    //}
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
       
        //Limpiaremos TextBox
        public void LimpiarTextbox()
        {
            txtCI.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtEmision.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtTelfReferencia.Text = "";
            txtEmail.Text = "";
            //txtEstado.Text = "";
            chkUsuario.Checked = false;
            chkChofer.Checked = false;
            chkPropietario.Checked = false;
            chkTitularBanco.Checked = false;
            chkCliente.Checked = false;
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtConfirmarContraseña.Text = "";
        }
        //Nos encargamos de confirmar los Tipos de Persona
        public void CheckearTipoPerosna(EntPersona objPropietario)
        {
            objPropietario.Id_TipoPersonaPRO = 0;
            objPropietario.Id_TipoPersonaCho = 0;
            objPropietario.Id_TipoPersonaTit = 0;
            objPropietario.Id_TipoPersonaUs = 0;
            objPropietario.Id_TipoPersonaCL = 0;
            if (chkPropietario.Checked) 
            {
                objPropietario.Id_TipoPersonaPRO = 1;
                if (chkChofer.Checked)
                {
                    objPropietario.Id_TipoPersonaCho = 1;
                    if (chkTitularBanco.Checked)
                    {
                        objPropietario.Id_TipoPersonaTit = 1;
                        if (chkUsuario.Checked)
                        {
                            objPropietario.Id_TipoPersonaUs = 1;
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                        else
                        {
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }

                    }
                    else
                    {
                        if (chkUsuario.Checked)
                        {
                            objPropietario.Id_TipoPersonaUs = 1;
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                        else
                        {
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                    }
                }
                else
                {
                    if (chkTitularBanco.Checked)
                    {
                        objPropietario.Id_TipoPersonaTit = 1;
                        if (chkUsuario.Checked)
                        {
                            objPropietario.Id_TipoPersonaUs = 1;
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                        else
                        {
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                    }
                    else
                    {
                        if (chkUsuario.Checked)
                        {
                            objPropietario.Id_TipoPersonaUs = 1;
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                        else
                        {
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                    }
                }

            }
            else
            {
                if (chkChofer.Checked)
                {
                    objPropietario.Id_TipoPersonaCho = 1;
                    if (chkTitularBanco.Checked)
                    {
                        objPropietario.Id_TipoPersonaTit = 1;
                        if (chkUsuario.Checked)
                        {
                            objPropietario.Id_TipoPersonaUs = 1;
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                    }
                    else
                    {
                        if (chkUsuario.Checked)
                        {
                            objPropietario.Id_TipoPersonaUs = 1;
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                        else
                        {
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                    }
                }
                else
                {
                    if (chkTitularBanco.Checked)
                    {
                        objPropietario.Id_TipoPersonaTit = 1;
                        if (chkUsuario.Checked)
                        {
                            objPropietario.Id_TipoPersonaUs = 1;
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                        else
                        {
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                    }
                    else
                    {
                        if (chkUsuario.Checked)
                        {
                            objPropietario.Id_TipoPersonaUs = 1;
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                        else
                        {
                            if (chkCliente.Checked) //Insert 16-08-2017
                            {
                                objPropietario.Id_TipoPersonaCL = 1;
                            }//hasta aqui
                        }
                    }
                }
            }
        }

        protected void chkUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUsuario.Checked)
            {
                lblUsuario.Visible = true;
                lblContraseña.Visible = true;
                lblConfirmarContraseña.Visible = true;
                lblRol.Visible = true;
                txtUsuario.Visible = true;
                txtContraseña.Visible = true;
                txtConfirmarContraseña.Visible = true;
                cmbRol.Visible = true;
            }
            else
            {
                lblUsuario.Visible = false;
                lblContraseña.Visible = false;
                lblConfirmarContraseña.Visible = false;
                lblRol.Visible = false;
                txtUsuario.Visible = false;
                txtContraseña.Visible = false;
                txtConfirmarContraseña.Visible = false;
                cmbRol.Visible = false;
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            txtCI.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmision.Text = "";
            txtTelfReferencia.Text = "";
            txtEmail.Text = "";
            //txtEstado.Text = "";
            chkUsuario.Checked = false;
            chkChofer.Checked = false;
            chkPropietario.Checked = false;
            chkTitularBanco.Checked = false;
            chkCliente.Checked = false;
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtConfirmarContraseña.Text = "";

        }

        protected void chkCliente_CheckedChanged(object sender, EventArgs e)
        {

        }

       
    }
}