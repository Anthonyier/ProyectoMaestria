using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;


namespace CapaNegocios
{
    public class NegCamiones
    {
        public static int InsertarCamiones(EntCamiones cam,EntCuenta cuen)
        {
            return DOACamiones.GuadarCamiones(cam,cuen);
        }
        public static EntCamiones BuscarCamiones(int id_cam){
            return DOACamiones.ConsultaCamiones(id_cam);
        }

        public static EntDetalle_Certificados BuscarVigencia(int id,int tipo){
            return DOACamiones.ConsultaVigenciaC(id,tipo);
        }

        public static bool DarSeguro(string Placa)
        {
            return DOACamiones.DarSeguro(Placa);
        }
        public static bool QuitarSeguro(string Placa)
        {
            return DOACamiones.QuitarSeguro(Placa);
        }

        public static int EliminarCamion(int id)
        {
            return DOACamiones.EliminarCamion(id);
        }
        public static EntCamiones Repetidos(string Placa)
        {
            return DOACamiones.Repetidos(Placa);
        }
          public static EntCuenta BuscarCuenta(long NroCuen)
        {
            return DOACuenta.ConsultaCuenta(NroCuen);
        }
        public static SqlDataReader BuscarChofer(string Nombre)
        {
            SqlDataReader dr = DOACamiones.BuscarChofer(Nombre);
            return dr;
        }
        public static SqlDataReader Cantidad(int Est)
        {
            SqlDataReader dr = DOACamiones.Cantidad(Est);
            return dr;
        }

        public static SqlDataReader Cant()
        {
            SqlDataReader dr = DOACamiones.Cant();
            return dr;
        }
        public static SqlDataReader CantDesha()
        {
            SqlDataReader dr = DOACamiones.CantDesha();
            return dr;
        }

        public static SqlDataReader BuscarTit(string Ci)
        {
            SqlDataReader dr = DOACuenta.BuscarTitCuenta(Ci);
            return dr;
        }
        public static SqlDataReader BuscarCamion(string Nombre)
        {
            SqlDataReader dr = DOACamiones.BuscarCamion(Nombre);
            return dr;

        }
        public static SqlDataReader BuscarPropietario(string CI_P)
        {
            SqlDataReader dr = DOACamiones.BuscarPropietario(CI_P);
            return dr;
        }

        public static SqlDataReader BuscarTitular(string CI_P)
        {
            SqlDataReader dr = DOACamiones.BuscarTitularBanco(CI_P);
            return dr;
        }

        public static SqlDataReader BuscarPlacaTitular(string Placa)
        {
            SqlDataReader dr = DOACamiones.BuscarPlacaTitular(Placa);
            return dr;
        }
        public static int ActualizarCamiones(EntCamiones cam,EntCuenta Cuen)
        {
            return DOACamiones.ActualizarCamion(cam,Cuen);
        }

        public static int CambioEstado(int est, string id,string obs,int chofer)
        {
            return CambiarEstado.CambioEstado(est, id,obs,chofer);
        }

        public static void Deshabilitar(string Placa)
        {
            DOACamiones.Deshabilitar(Placa); 
        }

        public static int EstadoChofer(string Ci)
        {
            return DOACamiones.EstadoChofer(Ci);
        }
        public static void Habilitar(string Placa)
        {
            DOACamiones.Habilitar(Placa);
        }
        public static int ActualizarChofer(EntCamiones ca)
        {
            return DOACamiones.actualizarChofer(ca);
        }

      }
    }
