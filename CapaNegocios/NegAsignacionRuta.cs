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
    public class NegAsignacionRuta
    {
        public static int InsertarAsignacion(EntRecepcion re)
        {
            return DOAAsignarRuta.GuardarRuta(re);
        }
        public static void ConfirmarViaje(int IdDetalle)
        {
            DOAAsignarRuta.ConfirmarViajeAnticipo(IdDetalle);
        }
        public static void NoDespachado(int IdDetalle)
        {
            DOAAsignarRuta.NoDespachado(IdDetalle);
        }
        public static bool CambioDeRuta(int IdDetalle_Recepcion, int IdRuta, int IdOrigen, int idDestino)
        {
            bool Resp = DOAAsignarRuta.CambioDeRuta(IdDetalle_Recepcion, IdRuta, IdOrigen, idDestino);
            return Resp;
        }
        public static void ModificarFecha(int IdDetalle, DateTime Fecha)
        {
            DOAAsignarRuta.ModificarFecha(IdDetalle, Fecha);
        }
        public static void ModificarFechaDescarga(int IdDetalle, DateTime FechaDescarga, int IdUsuario)
        {
            DOAAsignarRuta.ModificarDescarga(IdDetalle, FechaDescarga, IdUsuario);
        }
        public static void ConfirmarMic(string NoCrt,string NoMic,double VolumenMic,double PesoMic,int IdDetalle)
        {
            DOAAsignarRuta.ConfirmarMIC(NoCrt, NoMic, VolumenMic, PesoMic, IdDetalle);
        }
        public static void ConfirmarMic2(string NoCrt,string NoMic,double VolumenMic,double PesoMic,int IdDetalle,double VolumenCrt,double PesoCrt)
        {
            DOAAsignarRuta.ConfirmarMIC2(NoCrt, NoMic, VolumenMic, PesoMic, IdDetalle, VolumenCrt, PesoCrt);
        }
        public static int InsertarDetalle(EntDetalle_Recepcion der, int veces){
            return DOAAsignarRuta.GuardarDetalle(der,veces);
        }
        public static int ActualizarAsignacion(EntRecepcion re,EntDetalle_Recepcion der)
        {
            return DOAAsignarRuta.ActualizarAsignacion(re,der);
        }

        public static SqlDataReader BuscarChofer(string Placa)
        {
            SqlDataReader dr = DOAAsignarRuta.BuscarChofer(Placa);
            return dr;
        }

        public static SqlDataReader BuscarNit(string Client)
        {
            SqlDataReader dr = DOAAsignarRuta.BuscarNit(Client);
            return dr;
        }
        public static SqlDataReader BuscarPlaca(string Placa)
        {
            SqlDataReader dr = DOAAsignarRuta.BuscarPlaca(Placa);
            return dr;
        }
        //public static void GuardarAnticipo(String Placa, EntDetalle_Recepcion Detrec)
        //{
        //    GuardarAnticipo(Placa, Detrec);
        //}
        public static double EncontrarAnticipo(int IdDetalle) 
        {
            return DOAAsignarRuta.EncontrarAnticipo(IdDetalle);
        }
        public static DateTime EncontrarFechaAnticipo(int IdDetalle)
        {
            return DOAAsignarRuta.EncontraFechaAnticipo(IdDetalle);
        }
        public static int EncontrarIdCamion(int IdDetalle)
        {
            int IdCamion = 0;
            string Plac = DOAAsignarRuta.EncontrarPlacaViaje(IdDetalle);
            IdCamion = DOAAsignarRuta.EncontrarIdCamion(Plac);
            return IdCamion;
        }
        public static SqlDataReader BuscarRecepcion()
        {
            SqlDataReader dr = DOAAsignarRuta.BuscarRecepcion();
            return dr;
        }
        public static SqlDataReader BuscarCliente(string Cliente)
        {
            SqlDataReader dr = DOAAsignarRuta.BuscarCliente(Cliente);
            return dr;
        }
        public static SqlDataReader BuscarPendientes(string Placa)
        {
            SqlDataReader dr = DOAAsignarRuta.BuscarPendientes(Placa);
            return dr;
        }
        public static bool BuscarConfirmacion(string Placa, DateTime FechaCarga,int Ruta)
        {
            return DOAAsignarRuta.BuscarRepetidosConfirmacion(Placa, FechaCarga,Ruta);
        }
        public static bool BuscarConfirmacionDescarga(string Placa, DateTime FechaDescarga, int Ruta)
        {
            bool ConfirRep = DOAAsignarRuta.BuscarRepetidosConfirmacionDescarga(Placa, FechaDescarga, Ruta);
            return ConfirRep;
        }
        public static SqlDataReader BuscarProgramacion(string Placa,int ruta, DateTime FechaCarga)
        {
            SqlDataReader dr = DOAAsignarRuta.BuscarProgramacion(Placa,ruta ,FechaCarga);
            return dr;
        }
        public static int Deshabilitar(int id)
        {
            return DOAAsignarRuta.Deshabilitar(id);
        }
        public static SqlDataReader BuscarRuta(string Ruta)
        {
            SqlDataReader dr = DOAAsignarRuta.BuscarRuta(Ruta);
            return dr;
        }
        public static EntRecepcion ConsultaRecepcion(int id)
        {
            return DOAAsignarRuta.ConsultaRecepcion(id);
        }
        public static SqlDataReader BuscarMonto(string Monto)
        {
            SqlDataReader dr = DOAAsignarRuta.BuscarMonto(Monto);
            return dr;
        }

        public static int Maximo()
        {
            return DOAAsignarRuta.ValorMax();
        }

        public static int MaximoDetalle()
        {
            return DOAAsignarRuta.DetalleMax();
        }
        public static string BuscarPlacaConfirmar(int IdDetalle)
        {
            return DOAAsignarRuta.BuscarPlaca(IdDetalle);
        }
        public static DateTime BuscarFechaCargaConfirmar(int IdDetalle)
        {
            return DOAAsignarRuta.BuscarFechaCargaConfirmar(IdDetalle);
        }
        public static int BuscarRutaConfirmar(int IdDetalle)
        {
            return DOAAsignarRuta.BuscarRutaConfirmar(IdDetalle);
        }
        public static int InsertarPagoMasivoAntc()
        {
            return DOAAsignarRuta.InsertarPagoMasivoAntc();
        }
        public static void ActualizarProgramacionPago(int Id_Pmm, int IdDetalle)
        {
            DOAAsignarRuta.ActualizarProgramacionPago(Id_Pmm, IdDetalle);
        }
        public static int VerificarYaPagado(int IdDetalle)
        {
            return DOAAsignarRuta.VerificarYaPagado(IdDetalle);
        }
        public static double ObtenerVolumenCrt(string NroCrt)
        {
            return DOAAsignarRuta.ObtenerVolumenCrt(NroCrt);
        }
        public static double ObtenerPesoCrt(string NoCrt)
        {
            return DOAAsignarRuta.ObtenerPesoCrt(NoCrt);
        }
        public static void ActualizarPesoVolCrt(string NoCrt,double VolCrt,double PesoCrt)
        {
            DOAAsignarRuta.ActualizarVolPesoCrt(NoCrt, VolCrt, PesoCrt);
        }
        public static string EncontrarAbrevBanco(long NroCuenta)
        {
            return DOAAsignarRuta.EncontrarAbrevBanco(NroCuenta);
        }
        public static bool VerifBanco(string Abrev)
        {
            return DOAAsignarRuta.VerifBanco(Abrev);
        }
        public static int IdPagoMasivo(int IdDetalle)
        {
            return DOAAsignarRuta.EncontrarIdPagoMasiv(IdDetalle);
        }
        public static int IdDetalleCliente(int iddetalle)
        {
            return DOAAsignarRuta.EncontrarIdCliente(iddetalle);
        }
        public static int ObtenerDiaViaje(int IdDetalle)
        {
            return DOAAsignarRuta.ObtenerDiaViaje(IdDetalle);
        }
        public static int ObtenerMesViaje(int IdDetalle)
        {
            return DOAAsignarRuta.ObtenerMesViaje(IdDetalle);
        }
        public static int ObtenerAñoViaje(int IdDetalle)
        {
            return DOAAsignarRuta.ObtenerAñoViaje(IdDetalle);
        }
        public static int NEncontrarConfDescarga(int IdDetalle)
        {
            return DOAAsignarRuta.DEncontrarConfDescarga(IdDetalle);
        }
        public static void NAprobacionDeDescarga(int IdDetalle)
        {
            DOAAsignarRuta.DAprobacionDeDescarga(IdDetalle);
        }
    }
}