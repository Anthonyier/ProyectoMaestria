using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using CapaNegocios;
using System.IO;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace LogisticaBercam
{
    public partial class frmInicioSesion : System.Web.UI.Page
    {
        MailMessage msj = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        EntCorreos correos = new EntCorreos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Response.Redirect("frmPrincipal.aspx");
            }
        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            //lblError.Text = "";
            //lblNombreUser.Text = "";
            string usuario = us.Value;
            
            if (us.Value != "" && pass.Value != "") //(txtUsuario.Text != "" && txtContraseña.Text != "")
            {
                EntUsuario obj = NegUsuario.Login(us.Value, pass.Value);
                if (obj != null)
                {
                    Session["Usuario"] = obj;
                    //lblNombreUser.Text = obj.Nombres.ToString() + " " + obj.Apellidos.ToString();
                    //lblNombreUser.Visible = true;
                    Response.Redirect("frmPrincipal.aspx");
                }
                else
                {
                    Response.Write("<script languaje =javascript>alert ('Usuario o Contraseña invalidos');</script>");
                    //lblError.Text = "Usuario o Contraseña invalidos";
                    //lblError.Visible = true;
                }
            }
            else
            {
                Response.Write("<script languaje =javascript>alert ('Falta ingresar campos');</script>");
                //lblError.Text = "Falta ingresar campos";
                //lblError.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string usuario = us.Value;

            if (us.Value != "" && pass.Value != "") //si el usuario y contraseña no son vacios
            {
                EntUsuario obj = NegUsuario.Login(us.Value, pass.Value);
                if (obj != null)
                {
                    Session["Usuario"] = obj;
                    EntBitacora bit = new EntBitacora();
                    if (obj != null)
                    {
                        Session["Usuario"] = obj;
                        bit.Usuario = obj.Nombre + " " + obj.Apellidos;
                        bit.Accion = "El usuario se ha logeado";
                        bit.IdUsuario = obj.Id_Usuario;
                        int bi = NegBitacora.GuardarBitacora(bit);// Guardamos datos en la bitacora
                        

                        Response.Redirect("frmPrincipal.aspx");
                    }
                }
                else
                {
                    Response.Write("<script languaje =javascript>alert ('Usuario o Contraseña invalidos');</script>");
                    
                }
            }
            else
            {
                Response.Write("<script languaje =javascript>alert ('Falta ingresar campos');</script>");
                
            }
        }
        public void CorreoPersonaJoseLuis()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Nombre = "";
            string Ci = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagenes.ObtenerListaPersonaAndres();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Nombre = d["Persona"].ToString();
                        Vigencia = Convert.ToDateTime(d["Vigencia"].ToString());
                        Ci = d["CI"].ToString();
                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia-Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " con Nro CI: " + Ci + " de la Persona: " + Nombre + " se encuentra cerca y/o vencido de la fecha de vencimiento: " + Vigencia + ", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }
            }

            NegImagenes.EnviarMensajeAndres(Mensaje);
            d.Close();
        }
        public void CorreoPersonaAndresJefe()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Nombre = "";
            string Ci = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagenes.ObtenerListaPersonaAndres();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Nombre = d["Persona"].ToString();
                        Vigencia = Convert.ToDateTime(d["Vigencia"].ToString());
                        Ci = d["CI"].ToString();
                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia-Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " con Nro CI: " + Ci + " de la Persona: " + Nombre + " se encuentra cerca y/o vencido de la fecha de vencimiento: "+ Vigencia +", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }
            }

            NegImagenes.EnviarMensajeJefe(Mensaje);
            d.Close();
        }
        public void CorreoCamionesAndres()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamionesAndres2();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia - Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " de la Placa: " + Placa + "a cargo de Carla se encuentra cerca y/o Vencido de la fecha de vencimiento:" + Vigencia + ", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
            NegImagCert.EnviarMensajeAndreSanabria(Mensaje);
            d.Close();
        }
        public void CorreoCamionesJoseLuis()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamionesAndres();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = ( Vigencia-Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " de la Placa: " + Placa + " se encuentra cerca y/o vencido de la fecha de vencimiento: "+Vigencia+", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
            NegImagCert.EnviarMensajeAndreSanabria(Mensaje);
            d.Close();
        }
        public void CorreoCamionesCheckListAndres()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamionesCheckList();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia - Fini).Days;
                        if (DiffResult <= 0)
                        {
                            string Mensajes = "El " + TipoDoc + " de la Placa: " + Placa + " se encuentra cerca y/o vencido de la fecha de vencimiento: " + Vigencia + ", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
            NegImagCert.EnviarMensajeAndreSanabria(Mensaje);
            d.Close();
        }
        public void CorreoCamionesExtintoresAndres()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamionesExtintores();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia - Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " de la Placa: " + Placa + " se encuentra cerca y/o vencido de la fecha de vencimiento: " + Vigencia + ", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
            NegImagCert.EnviarMensajeAndreSanabria(Mensaje);
            d.Close();

        }
        public void CorreoCamionesAndresJefe()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamionesAndres();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia - Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " de la Placa: " + Placa + " se encuentra cerca y/o vencido de la fecha de vencimeinto: "+ Vigencia +", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
            NegImagCert.EnviarMensajeJefe(Mensaje);
            d.Close();
        }
        public void CorreoCamionExtintoresJefe()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamionesExtintores();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia - Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " de la Placa: " + Placa + " se encuentra cerca y/o vencido de la fecha de vencimeinto: " + Vigencia + ", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
            NegImagCert.EnviarMensajeJefe(Mensaje);
            d.Close();
        }
        public void CorreoCamionesCarla()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamionesCarla();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia - Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " de la Placa: " + Placa + "a cargo de Carla se encuentra cerca y/o Vencido de la fecha de vencimiento: " + Vigencia + ", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
           
            NegImagCert.EnviarMensajeCarla(Mensaje);
            NegImagCert.EnviarMensajeAndreSanabria(Mensaje);
            d.Close();
        }
        public void CorreoCamionesCarlaJefe()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamionesCarla();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = ( Vigencia-Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " de la Placa: " + Placa + "a cargo de Carla se encuentra cerca y/o Vencido de la fecha de vencimiento: "+ Vigencia +", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
            
            NegImagCert.EnviarMensajeJefe(Mensaje);
            d.Close();
        }

        private void CorreoSoat()
        {
            string Mensaje = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegSoat.BuscarListaSoat ();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["F_Venc"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia - Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El SOAT de la Placa: " + Placa + " esta por vencer, proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
            NegImagCert.EnviarMensaje(Mensaje);
            d.Close();
            
        }
        private void CorreoInspecionTec()
        {
            string Mensaje = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegInspeccTec.BuscarListaInspeccionTecnica();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["F_Venc"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia - Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "La Inspeccion Tecnica de la Placa: " + Placa + " esta por vencer, proceda a actualizar la misma.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
            NegImagCert.EnviarMensaje(Mensaje);
            d.Close();
           
        }
        public void CorreoCamiones()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamiones();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia-Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " de la Placa: " + Placa + " a cargo de nancy se encuentra cerca y/o vencido de la fecha de vencimiento: "+ Vigencia +", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
           
            NegImagCert.EnviarMensaje(Mensaje);
            d.Close();
        }
        public void CorreoCamionesNancyJefe()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamiones();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia-Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " de la Placa: " + Placa + " a cargo de nancy se encuentra cerca y/o vencido de la fecha de Vencimiento: " + Vigencia + ", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
   
            NegImagCert.EnviarMensajeJefe(Mensaje);
            d.Close();
        }
        private void CorreoSoatJefe()
        {
            string Mensaje = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegSoat.BuscarListaSoat();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["F_Venc"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia - Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El SOAT de la Placa: " + Placa + " a cargo de nancy esta por vencer.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
            NegImagCert.EnviarMensajeJefe(Mensaje);
            d.Close();

        }
        private void CorreoInspecionTecJefe()
        {
            string Mensaje = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegInspeccTec.BuscarListaInspeccionTecnica();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["F_Venc"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia - Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "La Inspeccion Tecnica de la Placa: " + Placa + " a cargo de nancy esta por vencer.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }
            NegImagCert.EnviarMensajeJefe (Mensaje);
            d.Close();

        }
        public void CorreoCamionesCheckListJefe()
        {

            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamionesCheckList();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());

                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia - Fini).Days;
                        if (DiffResult <= 0)
                        {
                            string Mensajes = "El " + TipoDoc + "  de la Placa: " + Placa + " a cargo de Andres/Luis se encuentra cerca y/o vencido de la fecha de Vencimiento: " + Vigencia + ", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }

            }

            NegImagCert.EnviarMensajeJefe(Mensaje);
            d.Close();
        }
        public void CorreoPersonas()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Nombre = "";
            string Ci = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagenes.ObtenerListaPersona();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Nombre = d["Persona"].ToString();
                        Vigencia = Convert.ToDateTime(d["Vigencia"].ToString());
                        Ci = d["CI"].ToString();
                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia-Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " con Nro CI: " + Ci + " de la Persona: " + Nombre + " se encuentra cerca y/o vencido de la fecha de Vencimiento: "+ Vigencia +", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }
            }

            NegImagenes.EnviarMensaje(Mensaje);
            d.Close();
        }
        public void CorreoPersonasNancyJefe()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Nombre = "";
            string Ci = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagenes.ObtenerListaPersona();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Nombre = d["Persona"].ToString();
                        Vigencia = Convert.ToDateTime(d["Vigencia"].ToString());
                        Ci = d["CI"].ToString();
                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia-Fini).Days;
                        if (DiffResult <= 30)
                        {
                            string Mensajes = "El " + TipoDoc + " con Nro CI: " + Ci + " de la Persona: " + Nombre + " se encuentra cerca y/o vencido de la fecha de Vencimiento: " + Vigencia + ", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception er)
                    {

                    }
                }
            }

            NegImagenes.EnviarMensajeJefe(Mensaje);
            d.Close();
        }
        public void CorreoCamionesCheckList()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamionesCheckList();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                         TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());
                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia - Fini).Days;
                        if (DiffResult <= 0)
                        {
                            string Mensajes = "El " + TipoDoc + "  de la Placa: " + Placa + " a cargo de Andres/Luis se encuentra cerca y/o vencido de la fecha de Vencimiento: " + Vigencia + ", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch(Exception e)
                    {

                    }
                }
            }
            NegImagenes.EnviarMensajeLuisHernan(Mensaje);
            d.Close();
        }
        public void CorreoCamionesCheckListNaty()
        {
            string Mensaje = "";
            string TipoDoc = "";
            string Placa = "";
            DateTime Vigencia = Convert.ToDateTime("01/01/2010");
            SqlDataReader d = NegImagCert.ObtenerListaCamionesCheckList();
            if (d.HasRows == true)
            {
                while (d.Read())
                {
                    try
                    {
                        TipoDoc = d["TipoDoc"].ToString();
                        Placa = d["Placa"].ToString();
                        Vigencia = Convert.ToDateTime(d["FeVenci"].ToString());
                        DateTime Fini = DateTime.Now;
                        int DiffResult = (Vigencia - Fini).Days;
                        if (DiffResult <= 0)
                        {
                            string Mensajes = "El " + TipoDoc + "  de la Placa: " + Placa + " a cargo de Andres/Luis se encuentra cerca y/o vencido de la fecha de Vencimiento: " + Vigencia + ", proceda a actualizar el mismo.\n";
                            Mensaje = Mensaje + Mensajes;
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            NegImagenes.EnviarMensajeNatyMichelle (Mensaje);
            NegImagenes.EnviarMensajeVillamontes(Mensaje);
            d.Close();
        }
        public void Enviar()
        {
            try{
            msj.From = new MailAddress(correos.From);
            msj.To.Add(new MailAddress(correos.Add));
            msj.Body = correos.Mensaje;
            msj.Subject =correos. Subject;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            string fr = correos.fr;
            string pass = correos.pass;
            smtp.Credentials = new NetworkCredential(fr, pass);
            smtp.EnableSsl = true;
            
            smtp.Send(msj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        public void BusquedaDocumentoCI()
        {
            EntPersona objPropietario = new EntPersona();
            
            objPropietario = NegPersona.BuscarTodasPersonas();
            SqlCommand cmd = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            cmd = new SqlCommand("Select * FROM Persona");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnx;
            cnx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    objPropietario.Cod_Ente= Convert.ToInt32( dr["Cod_Ente"].ToString());
                    EntPersona objPersImg = new EntPersona();
                    int CodigoEntidad = objPropietario.Cod_Ente;
                    objPersImg = NegPersona.BuscarPersonaVigenciaPR(CodigoEntidad, 1);
                    if (EstaVencido(objPersImg.DiasVigenciaCI) == true)
                    {
                        string mensaje = "El CI del transportista: " + " " + objPropietario.Nombres + " esta VENCIDO ";
                    }

                    objPersImg = NegPersona.BuscarPersonaVigenciaPR(CodigoEntidad,2);
                    if (EstaVencido(objPersImg.DiasVigenciaCI)==true)
                    {
                        string mensaje = "La licencia del transportista" + " " + objPropietario.Nombres + "esta VENCIDO";
                    }
                }
            }
            
        }

        public void BusquedaDocumentoLicencia()
        {
            EntPersona objPropietario = new EntPersona();

            objPropietario = NegPersona.BuscarTodasPersonas();
            EntPersona objPersImg = new EntPersona();
            int CodigoEntidad = Convert.ToInt32(objPropietario.Cod_Ente);
            objPersImg = NegPersona.BuscarPersonaVigenciaPR(CodigoEntidad, 2);
            if (EstaVencido(objPersImg.DiasVigenciaCI) == true)
            {
                string mensaje = "La licencia del transportista: " + " " + objPropietario.Nombres + " esta VENCIDO ";
            }
        }

        public bool EstaVencido(double dias)
        {
            if (dias < 0)
            {
                return true;
            }

            return false;
        }

        public bool EnviarCorreoLogin(string Mensaje)
        {
            //Thread thread;// = new Thread(;
            EntDatosEmpresa Em = NegUsuario.Empresa(3);
            try
            {
                msj.From = new MailAddress("transbercamcorreo@gmail.com");
                msj.To.Add(new MailAddress(Em.EmailEnvio));
                msj.Body = Mensaje;
                msj.Subject = "El Documento se ha Vencido";
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                string fr = "transbercamcorreo@gmail.com";
                //string pass = "transbercam12345";
                string pass = "kcqbzupdtnioterv";
                smtp.Credentials = new NetworkCredential(fr, pass);
                smtp.EnableSsl = true;
                //thread = new Thread(smtp.Send(msj));
                smtp.Send(msj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }


    }
}