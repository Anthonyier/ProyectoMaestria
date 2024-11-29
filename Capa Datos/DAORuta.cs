using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DAORuta
    {
        public static int GuardarRuta(EntRuta Ruta)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into Ruta (Ruta,Origen,Destino,MontoAnticipo,PrecioFlet,PrecioTotal,Id_Cliente) values" +
                    "(@Ruta,@Origen,@Destino,@Monto,@PrecioFlet,@Precio,@IdCliente);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Ruta",Ruta.Ruta);
                cmd.Parameters.AddWithValue("@Origen", Ruta.Origen);
                cmd.Parameters.AddWithValue("@Destino",Ruta.Destino);
                cmd.Parameters.AddWithValue("@Monto",Ruta.MontoAnticipo);
                cmd.Parameters.AddWithValue("@PrecioFlet", Ruta.PrecioFlet);
                cmd.Parameters.AddWithValue("@Precio",Ruta.PrecioTotal);
                cmd.Parameters.AddWithValue("@IdCliente",Ruta.Id_Cliente);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                cnx.Close();

            }
            myTrans.Commit();
            cnx.Close();
            return 1;
        }

        public static bool RutaCorta(int Origen,int Destino, int IdCliente)
        {
            bool Corta = false;
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            //int Id_Pers = 0;

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();

                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Ruta set RutaCorta= 1 where Origen=@Origen and Destino=@Destino and Id_Cliente= @IdCliente";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                cmd.Parameters.AddWithValue("@Origen", Origen);
                cmd.Parameters.AddWithValue("@Destino", Destino);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                Corta = true;
                //hasta aqui
            }
            catch (Exception e)
            {

                myTrans.Rollback();
                cmd.Connection.Close();
                return false;

            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
            return Corta;
        }

        public static int Insertar(EntDetalleRuta Dr)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into Detalle_Ruta (IdRuta,IdProducto,MermaMaxima,MultaPorProducto) values (@IdRuta,@IdProducto,@MermaMaxima,@Multa);SELECT Scope_Identity();";  
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@IdRuta",Dr.IdRuta);
                cmd.Parameters.AddWithValue("@IdProducto", Dr.IdProducto);
                cmd.Parameters.AddWithValue("@MermaMaxima", Dr.MermaMaxima);
                cmd.Parameters.AddWithValue("@Multa", Dr.MultaProducto);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();

            }
            myTrans.Commit();
            cnx.Close();
            return 1;
        }

        public static bool CarroGuia(int IdRuta)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            //int Id_Pers = 0;

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();

                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Ruta set CamionGuia = 1 where Id_Ruta = @Id_Ruta";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id_Ruta",IdRuta);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                //hasta aqui
            }
            catch (Exception e)
            {
                
                myTrans.Rollback();
                return false;

            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
            return true;//obj;
        }
        public static int ActualizarRuta(EntRuta obj)//string Nombres, string Apellidos, string CI, string Direccion, string Telefonos, string TelfReferencia, string Email, byte[] imgLicConducir, byte[] AntFelcn, byte[] AntRejap)
        {
            //EntPropietario objPropietario = null;
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            //int Id_Pers = 0;
           
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();

                cnx.Open();
                myTrans = cnx.BeginTransaction();

                ////string sql = "Insert into Persona (CI, Tipo_Persona, Id_TipoPersonaPRO, Id_TipoPersonaCho, Id_TipoPersonaTit, Id_TipoPersonaUs, Nombres, Apellidos, Direccion, Telefonos, TelfReferencia, Email, VigenciaCI, VigenciaLicencia, VigenciaFelcn, VigenciaRejap) values(@CI, @Tipo_Persona, @Id_TipoPersonaPRO, @Id_TipoPersonaCho, @Id_TipoPersonaTit, @Id_TipoPersonaUs, @Nombres, @Apellidos, @Direccion, @Telefonos, @TelfReferencia, @Email, @VigenciaCI, @VigenciaLicencia, @VigenciaFelcn, @VigenciaRejap) ;SELECT  Scope_Identity(); ";

                string sql = "Update Ruta set Ruta = @Ruta,MontoAnticipo = @MontoAnticipo,PrecioFlet=@PrecioFlet,PrecioTotal = @PrecioTotal," +
                "Origen = @Origen ,Destino=@Destino where Id_Ruta = @Id_Ruta";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Ruta", obj.Ruta);
                cmd.Parameters.AddWithValue("@MontoAnticipo", obj.MontoAnticipo);
                cmd.Parameters.AddWithValue("@PrecioFlet", obj.PrecioFlet);
                cmd.Parameters.AddWithValue("@Origen", obj.Origen);
                cmd.Parameters.AddWithValue("@Destino",obj.Destino);
                cmd.Parameters.AddWithValue("@PrecioTotal", obj.PrecioTotal);
                cmd.Parameters.AddWithValue("@Id_Ruta", obj.Id_Ruta);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                //hasta aqui
            }
            catch (Exception e)
            {
                obj = null;
                myTrans.Rollback();
                return 0;

            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
            return 1;//obj;
        }

        public static int ActualizarMerma(EntDetalleRuta obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            //int Id_Pers = 0;

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();

                cnx.Open();
                myTrans = cnx.BeginTransaction();

                ////string sql = "Insert into Persona (CI, Tipo_Persona, Id_TipoPersonaPRO, Id_TipoPersonaCho, Id_TipoPersonaTit, Id_TipoPersonaUs, Nombres, Apellidos, Direccion, Telefonos, TelfReferencia, Email, VigenciaCI, VigenciaLicencia, VigenciaFelcn, VigenciaRejap) values(@CI, @Tipo_Persona, @Id_TipoPersonaPRO, @Id_TipoPersonaCho, @Id_TipoPersonaTit, @Id_TipoPersonaUs, @Nombres, @Apellidos, @Direccion, @Telefonos, @TelfReferencia, @Email, @VigenciaCI, @VigenciaLicencia, @VigenciaFelcn, @VigenciaRejap) ;SELECT  Scope_Identity(); ";

                string sql = "Update Detalle_Ruta set MultaPorProducto=@MultaPorProducto where Id = @Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@MultaPorProducto", obj.MultaProducto);
                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                //hasta aqui
            }
            catch (Exception e)
            {
                obj = null;
                myTrans.Rollback();
                return 0;

            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
            return 1;//obj;
        }
        public static EntRuta ConsultaTodo(int Id_Ruta)
        {
            EntRuta obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("BuscarRuta", cnx);
                cmd.Parameters.AddWithValue("@IdRuta", Id_Ruta);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntRuta();
                dr.Read();
                obj.Id_Ruta = Convert.ToInt32(dr["Id_Ruta"].ToString());
                obj.Ruta= dr["Ruta"] .ToString();
                obj.Origen = Convert.ToInt32(dr["Ori"].ToString());
                obj.Destino = Convert.ToInt32(dr["Des"].ToString());
                obj.Origens = dr["Origen"].ToString();
                obj.Destinos = dr["Destino"].ToString();
                obj.MontoAnticipo = Convert.ToDouble(dr["MontoAnticipo"].ToString());
                obj.PrecioFlet = Convert.ToDouble(dr["PrecioFlet"].ToString());
                obj.PrecioTotal = Convert.ToDouble(dr["PrecioTotal"].ToString());
                obj.Id_Cliente = Convert.ToInt32(dr["Id_Cliente"].ToString());
        
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return obj;
        }

        public static int BuscarRutaId(int id)
        {
            int IdRuta = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                string sql = "select id_ruta from detalle_recepcion where Id_Detalle=@Id";
                cmd = new SqlCommand(sql,cnx);
                cmd.Parameters.AddWithValue("@Id", id);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdRuta = Convert.ToInt32(dr["id_ruta"].ToString());
            }
            catch (Exception e)
            {
                IdRuta = 0;
            }
            finally
            {
                cnx.Close();
            }
            return IdRuta;
        }
        public static EntDetalleRuta BuscarDetalleRuta(int Id)
        {
            EntDetalleRuta obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("BuscarDetalleRuta", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntDetalleRuta();
                dr.Read();
                obj.Id= Convert.ToInt32(dr["Id"].ToString());
                obj.IdRuta = Convert.ToInt32(dr["IdRuta"].ToString());
                obj.IdProducto = Convert.ToInt32(dr["IdProducto"].ToString());
                obj.MermaMaxima = Convert.ToDouble(dr["MermaMaxima"].ToString());
                obj.MultaProducto= Convert.ToDouble(dr["MultaPorProducto"].ToString());
                
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return obj;
        }
        public static SqlDataReader BuscarCliente(int Cliente)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ProcBuscarCliente", cnx);
                cmd.Parameters.AddWithValue("@IdPersona", Cliente);
                cmd.CommandType = CommandType.StoredProcedure;

                cnx.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception e)
            {
                //obj = null;
                dr = null;
                return dr;
            }
            finally
            {

            }
        }

        public static SqlDataReader EncontrarCliente(int Cliente)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("EncontrarCliente", cnx);
                cmd.Parameters.AddWithValue("@Idcliente", Cliente);
                cmd.CommandType = CommandType.StoredProcedure;

                cnx.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception e)
            {
                //obj = null;
                dr = null;
                return dr;
            }
            finally
            {

            }
        }
        public static SqlDataReader BuscarProducto(int Producto)
        {

            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarProductos", cnx);
                cmd.Parameters.AddWithValue("@Producto", Producto);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();


                return dr;
            }
            catch (Exception e)
            {
                //obj = null;
                dr = null;
                return dr;
            }
            finally
            {

            }
        }

    }
}