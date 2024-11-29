using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaNegocios;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;

namespace CapaNegocios
{
    public class NegPersona
    {
        public static int InsertarPersona(EntPersona obj ){
            return DAOPersona.GuardarPersona(obj);//Nombres,Apellidos,CI,Direccion,Telefonos,TelfReferencia,Email,imgLicConducir,AntFelcn,AntRejap);
        }
        public static int ActualizarPropietario(EntPersona obj) {
            return DAOPersona.ActualizarPersona(obj);
        }
        public static EntPersona BuscarImagen(int Id_img)
        {
            return DAOPersona.ConsultaImagenes(Id_img);
        }
        public static EntPersona  BuscarTodo(int Id_Persona)
        {
            return DAOPersona.ConsultaTodo(Id_Persona);//.Login(usuario, password);
        }
        public static double BuscarPersonaVigencia(int Id_Persona, int Tipoimg)
        {
            return DAOPersona.ConsultaVigencia(Id_Persona, Tipoimg);//.Login(usuario, password);
        }
        public static EntPersona BuscarPersonaVigenciaPR(int Id_Persona, int Tipoimg)
        {
            return DAOPersona.ConsultaVigenciaPR(Id_Persona, Tipoimg);//.Login(usuario, password);
        }
        public static EntPersona BuscarTipoEntidad(int IdPersona){
            return DAOPersona.ConsultaTipoEntidad(IdPersona);
        }
        public static void Habilitar(int id)
        {
             DAOPersona.Habilitar(id);
        }
        
        public static EntPersona BuscarTodasPersonas()
        {
            return DAOPersona.ConsultaPersonaTodo();
        }

        public static EntPersona BuscarPersonaCI(string Ci)
        {

            return DAOPersona.ConsultaPersonaCI(Ci);
        }

        public static SqlDataReader BuscarPersona(string Nombre)
        {
            SqlDataReader dr = DAOPersona.BuscarPersona(Nombre);
            return dr;
        }
        public static EntPersona Repetidos(string ci)
        {
            return DAOPersona.Repetidos(ci);
        }
       
        public static int EliminarPersona(int id)
        {
            return DAOPersona.ElimianrPersona(id);
        }
        public static string EncontrarEmision(string Ci)
        {
            return DAOPersona.EncontrarEmision(Ci);
        }
        public static int EncontrarCodigoCiudad(string Emi)
        {
            return DAOPersona.EncontrarCodigoCiudad(Emi);
        }
        public static bool VerificarCodEmision(string Emi)
        {
            return DAOPersona.VerificarCodEmision(Emi);
        }
        public static string ExtDocumento(string Emi)
        {
            return DAOPersona.ExtDocumento(Emi); 
        }
    }

    
}