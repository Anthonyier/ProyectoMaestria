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
    public class NegRuta
    {
        public static int InsertarRuta(EntRuta Ruta)
        {
            return DAORuta.GuardarRuta(Ruta);
        }
        public static int InsertarDetalleRuta(EntDetalleRuta Det)
        {
            return DAORuta.Insertar(Det);
        }
        public static bool RutaCorta(int Origen, int Destino,int IdCliente)
        {
            return DAORuta.RutaCorta(Origen, Destino, IdCliente);
        }
        public static int ActualizarRuta(EntRuta Ruta)
        {
            return DAORuta.ActualizarRuta(Ruta);
        }
        public static EntRuta BuscarTodo(int Id_Ruta)
        {
            return DAORuta.ConsultaTodo(Id_Ruta);
        }
        public static bool CarroGuia(int IdRuta)
        {
            return DAORuta.CarroGuia(IdRuta);
        }
        public static EntDetalleRuta BuscarDetalleRuta(int Id)
        {
            return DAORuta.BuscarDetalleRuta(Id);
        }
        public static int BuscarIdRuta(int id)
        {
            int Ru = DAORuta.BuscarRutaId(id);
            return Ru;
        }
        public static SqlDataReader EncontrarCliente(int Cliente)
        {
            SqlDataReader dr = DAORuta.EncontrarCliente(Cliente);
            return dr;
        }
        public static SqlDataReader BuscarCliente(int Cliente)
        {
            SqlDataReader dr = DAORuta.BuscarCliente(Cliente);
            return dr;
        }
        public static SqlDataReader BuscarProducto(int Producto)
        {
            SqlDataReader dr = DAORuta.BuscarProducto(Producto);
            return dr;
        }
        public static int ActualizarMerma( EntDetalleRuta Obj)
        {
            return DAORuta.ActualizarMerma(Obj);
        }
    }
}