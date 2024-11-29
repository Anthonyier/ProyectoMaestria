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
    public class DOAAsignarRuta
    {
        public int recp;
        
        public static int GuardarRuta(EntRecepcion Recp)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            int Id_Recepcion=0;
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into Recepcion (Id_Recepcion,Id_RecepcionManual,Estado,OBS,Cod_Ente,VolumenTotalDespacho,TramoDesde,"+
                    "TramoHasta,FechaCarga,FechaDescarga,Cod_Prod) values"+
                    "(@Id_Recepcion,@Id_RecepcionManual,@Estado,@OBS,@Cod_Ente,@VolumenTotalDespacho,@TramoDesde,"+
                     "@TramoHasta,@FechaCarga,@FechaDescarga,@Cod_Pro);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                int Recep=Recp.Id_Recepcion+1;
                cmd.Parameters.AddWithValue("@Id_Recepcion",Recep);
                cmd.Parameters.AddWithValue("@Id_RecepcionManual", Recp.Id_RecepcionManual);
                cmd.Parameters.AddWithValue("@Estado", 1);
                cmd.Parameters.AddWithValue("@OBS", Recp.Obs);
                cmd.Parameters.AddWithValue("@Cod_Ente",Recp.Cod_Ente );
                cmd.Parameters.AddWithValue("@VolumenTotalDespacho", Recp.VolumenTotalDespacho);
                cmd.Parameters.AddWithValue("@TramoDesde", Recp.TramoDesde);
                cmd.Parameters.AddWithValue("@TramoHasta", Recp.TramoHasta);
                cmd.Parameters.AddWithValue("@FechaCarga", Recp.FechaCarga);
                cmd.Parameters.AddWithValue("@FechaDescarga", Recp.FechaDescarga);
                cmd.Parameters.AddWithValue("@Cod_Pro", Recp.Cod_Prod);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                Id_Recepcion = Recep;
               
            }
            catch (Exception e)
            {
                myTrans.Rollback();

            }
            myTrans.Commit();
            cnx.Close();
            return Id_Recepcion;
        }
        public static void PagoSinFactura(int IdDetalle)
        {
            SqlCommand cmd = null;
            //DateTime Fecha=DateTime.Today;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Detalle_Recepcion set SF1=1 where Id_Detalle=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", IdDetalle);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
        public static void EnvioConfirmado(int IdDetalle, DateTime Fecha)
        {
            SqlCommand cmd = null;
            //DateTime Fecha=DateTime.Today;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Detalle_Recepcion set Enviado=1,FechaAnticipo=@Fecha where Id_Detalle=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", IdDetalle);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
        public static bool CambioDeRuta(int IdDetalle_Recepcion, int IdRuta, int IdOrigen, int IdDestino)
        {
            bool res = false;
            SqlCommand cmd = null;
            //DateTime Fecha=DateTime.Today;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Detalle_Recepcion set Ruta=@Ruta,DetallePlantaOrigen=@Origen,DetallePlantaDestino=@Destino where Id_Detalle=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Origen", IdOrigen);
                cmd.Parameters.AddWithValue("@Destino", IdDestino);
                cmd.Parameters.AddWithValue("@Ruta", IdRuta);
                cmd.Parameters.AddWithValue("@Id", IdDetalle_Recepcion);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                res = true;
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                res = false;
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
            return res;
        }
        public static void ElimiarFechaAnticipo(int IdDetalle)
        {
            SqlCommand cmd = null;
            //DateTime Fecha=DateTime.Today;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Detalle_Recepcion set Enviado=0,FechaAnticipo=NUll,Confirmado=2 where Id_Detalle=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", IdDetalle);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
        public static void ModificarFecha(int IdDetalle , DateTime Fecha)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            DateTime FechaConfirmar = DateTime.Now;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Detalle_Recepcion set FechaCarga=@FechaCarga,FechaConfirmacion=@FechaConfirmacion where Id_Detalle=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@FechaCarga", Fecha);
                cmd.Parameters.AddWithValue("@FechaConfirmacion", FechaConfirmar);
                cmd.Parameters.AddWithValue("@Id", IdDetalle);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
        public static void ModificarDescarga(int idDetalle,DateTime Fecha,int IdUsuario)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = null;
            SqlConnection cnx = null;
            try
            {
                Conexion = new ClaseConexion();
                cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("ProcConfirmarFechaDescarga", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDetalle", idDetalle);
                cmd.Parameters.AddWithValue("@FechaDescarga", Fecha);
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
        public static void ConfirmarMIC(string NoCrt,string NoMic,double VolumenMic,double PesoMic,int IdDetalle)
        {
            SqlCommand cmd = null;
            SqlTransaction  myTrans= null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cnx.Open();
                myTrans=cnx.BeginTransaction();
                cmd = new SqlCommand("ProcActualizarValoresMic", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NoCrt", NoCrt);
                cmd.Parameters.AddWithValue("@NoMic",NoMic);
                cmd.Parameters.AddWithValue("@VolumenMic",VolumenMic);
                cmd.Parameters.AddWithValue("@PesoMic",PesoMic);
                cmd.Parameters.AddWithValue("@IdDetalleRecepcion",IdDetalle);
                cmd.Transaction=myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
        public static void ConfirmarMIC2(string NoCrt, string NoMic, double VolumenMic, double PesoMic, int IdDetalle,double VolumenCrt,double PesoCrt)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("ProcActualizarValoresMic2", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NoCrt", NoCrt);
                cmd.Parameters.AddWithValue("@NoMic", NoMic);
                cmd.Parameters.AddWithValue("@VolumenMic", VolumenMic);
                cmd.Parameters.AddWithValue("@PesoMic", PesoMic);
                cmd.Parameters.AddWithValue("@IdDetalleRecepcion", IdDetalle);
                cmd.Parameters.AddWithValue("@VolumenCRT", VolumenCrt);
                cmd.Parameters.AddWithValue("@PesoCRT", PesoCrt);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
        public static double ObtenerVolumenCrt(string NroCrt)
        {
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            double VolumenCrt = 0;
            try
            {
                cmd = new SqlCommand("select sum(VolumenMic) as TotalVolumenCrt from detalle_recepcion where NoCrt=@NroCrt",cnx);
                cmd.Parameters.AddWithValue("@NroCrt", NroCrt);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                VolumenCrt = Convert.ToDouble(dr["TotalVolumenCrt"].ToString());
                dr.Close();
            }
            catch (Exception ex)
            {
                dr = null;
                return 0;
            }
            return VolumenCrt;
        }
        public static double ObtenerPesoCrt(string NroCrt)
        {
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            double PesoCrt = 0;
            try
            {
                cmd = new SqlCommand("select sum(PesoMic) as TotalPesoMic from detalle_recepcion where NoCrt=@NroCrt", cnx);
                cmd.Parameters.AddWithValue("@NroCrt", NroCrt);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                PesoCrt = Convert.ToDouble(dr["TotalPesoMic"].ToString());
                dr.Close();
            }
            catch (Exception ex)
            {
                dr = null;
                return 0;
            }
            return PesoCrt;
        }
        public static void ActualizarVolPesoCrt(string NroCrt,double VolumenCrt,double PesoCrt)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("ProcActualizarValoresCrt", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VolumenCrt", VolumenCrt);
                cmd.Parameters.AddWithValue("@PesoCrt", PesoCrt);
                cmd.Parameters.AddWithValue("@NoCrt", NroCrt );
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
        public static void ConfirmarViajeAnticipo(int IdDetalle)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Detalle_Recepcion set Confirmado=0 where Id_Detalle=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", IdDetalle);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
        public static int ObtenerDiaViaje(int IdDetalle)
        {
            ClaseConexion con = new ClaseConexion();
            SqlConnection cnx = con.conectar();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int Iday = 0;
            try
            {
                cmd= new SqlCommand("select DAY(FechaCarga) as Dia from detalle_Recepcion where Id_detalle=@IdDetalle",cnx);
                cmd.Parameters.AddWithValue("@IdDetalle", IdDetalle);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Iday = Convert.ToInt32(dr["Dia"].ToString());
                dr.Close();
            }
            catch (Exception ex)
            {
                dr = null;
                Iday = 0;
            }
            finally
            {
                cnx.Close();
            }
            return Iday;
        }
        public static int ObtenerMesViaje(int IdDetalle)
        {
            ClaseConexion con = new ClaseConexion();
            SqlConnection cnx = con.conectar();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int IdMes = 0;
            try
            {
                cmd = new SqlCommand("select MONTH(FechaCarga) as Mes from detalle_Recepcion where Id_detalle=@IdDetalle", cnx);
                cmd.Parameters.AddWithValue("@IdDetalle", IdDetalle);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdMes = Convert.ToInt32(dr["Mes"].ToString());
                dr.Close();
            }
            catch (Exception ex)
            {
                dr = null;
                IdMes = 0;
            }
            finally
            {
                cnx.Close();
            }
            return IdMes;
        }

        public static int ObtenerAñoViaje(int IdDetalle)
        {
            ClaseConexion con = new ClaseConexion();
            SqlConnection cnx = con.conectar();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int IdAño = 0;
            try
            {
                cmd = new SqlCommand("select YEAR(FechaCarga) as Año from detalle_Recepcion where Id_detalle=@IdDetalle", cnx);
                cmd.Parameters.AddWithValue("@IdDetalle", IdDetalle);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdAño = Convert.ToInt32(dr["Año"].ToString());
                dr.Close();
            }
            catch (Exception ex)
            {
                dr = null;
                IdAño = 0;
            }
            finally
            {
                cnx.Close();
            }
            return IdAño;
        }
        public static void NoDespachado(int IdDetalle)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Detalle_Recepcion set Confirmado=2 where Id_Detalle=@Id";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id", IdDetalle);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                myTrans.Rollback();
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
        }
        public  static int GuardarDetalle(EntDetalle_Recepcion deret,int recep)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            cnx.Open();
            myTrans = cnx.BeginTransaction();
            try
            {
                string sql = "Insert into Detalle_Recepcion (Id_Detalle,Monto_Anticipo,FechaCarga,FechaDescarga,Vigencia,Placa_Camion,Id_Recepcion,Estado,Id_Chofer," +
                   "Compartimiento1,Compartimiento2,Compartimiento3,Compartimiento4,Compartimiento5,Compartimiento6,Compartimiento7,Precintos,Producto,Id_Ruta,VolumenRecepcion," +
                   "NombreTitular,DetallePlantaOrigen,DetallePlantaDestino,Id_Titular)" +
                   "values (@Id_Detalle,@Monto_Anticipo,@FechaCarga,@FechaDescarga,@Vigencia,@Placa_Camion,@Id_Recepcion,@Estado,@Id_Chofer," +
                   "@Compartimiento1,@Compartimiento2,@Compartimiento3,@Compartimiento4,@Compartimiento5,@Compartimiento6,@Compartimiento7,@Precintos,@Producto,@Id_Ruta,@VolumenRecepcion," +
                   "@NombreTitular,@DetallePlantaOrigen,@DetallePlantaDestino,@Id_Titular);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                int Det=deret.Id_Detalle+1;
                cmd.Parameters.AddWithValue("@Id_Detalle", Det);
                cmd.Parameters.AddWithValue("@Monto_Anticipo", deret.Monto_Anticipo);
                cmd.Parameters.AddWithValue("@FechaCarga", deret.FechaCarga);
                cmd.Parameters.AddWithValue("@FechaDescarga", deret.FechaDescarga);
                cmd.Parameters.AddWithValue("@Vigencia", deret.Vigencia);
                cmd.Parameters.AddWithValue("@Placa_Camion", deret.Placa_Camion);
                cmd.Parameters.AddWithValue("@Id_Recepcion", recep);
                cmd.Parameters.AddWithValue("@Estado", 1);
                cmd.Parameters.AddWithValue("@Id_Chofer", deret.Id_Chofer);
                cmd.Parameters.AddWithValue("@Compartimiento1", deret.Comportamiento1);
                cmd.Parameters.AddWithValue("@Compartimiento2", deret.Comportamiento2);
                cmd.Parameters.AddWithValue("@Compartimiento3", deret.Comportamiento3);
                cmd.Parameters.AddWithValue("@Compartimiento4", deret.Comportamiento4);
                cmd.Parameters.AddWithValue("@Compartimiento5", deret.Comportamiento5);
                cmd.Parameters.AddWithValue("@Compartimiento6", deret.Comportamiento6);
                cmd.Parameters.AddWithValue("@Compartimiento7", deret.Comportamiento7);
                cmd.Parameters.AddWithValue("@Precintos", deret.Precintos);
                cmd.Parameters.AddWithValue("@Producto", deret.Producto);
                cmd.Parameters.AddWithValue("@Id_Ruta", deret.Ruta);
                cmd.Parameters.AddWithValue("@VolumenRecepcion",deret.VolumenRecepcion);
                cmd.Parameters.AddWithValue("@NombreTitular", deret.NombreTitular);
                cmd.Parameters.AddWithValue("@DetallePlantaOrigen", deret.DetallePlantaOrigen);
                cmd.Parameters.AddWithValue("@DetallePlantaDestino", deret.DetallePlantaDestino);
                cmd.Parameters.AddWithValue("@Id_Titular", deret.Id_Titular);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                string sql2 = "update Camiones set Estado=4,Obs='El camion se encuntra viajando' where Placa=@Placa";
                cmd = new SqlCommand(sql2, cnx);
                cmd.Parameters.AddWithValue("@Placa",deret.Placa_Camion);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                string sql3 = "update Camiones set Ubicacion=@Ubicacion where Placa=@Placa";
                cmd = new SqlCommand(sql3, cnx);
                cmd.Parameters.AddWithValue("@Ubicacion",deret.Ubicacion);
                cmd.Parameters.AddWithValue("@Placa", deret.Placa_Camion);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

               
            }
            catch (Exception e)
            {
                myTrans.Rollback();

            }
            myTrans.Commit();
            cnx.Close();
            //GuardarAnticipo(deret, recep);
            return 1;
        }

        public static int ObtenerAño(string Año)
        {
            int Añ = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("Select Id From Año where Descripcion=@Año", cnx);
                cmd.Parameters.AddWithValue("@Año", Año);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Añ = Convert.ToInt32(dr["Id"].ToString());
            }
            catch (Exception e)
            {
                dr = null;
                return 0;
            }
            return Añ;
        }

        public static int IdDetalleRecp()
        {
            int Deta= 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("SELECT TOP 1 Id_Detalle FROM Detalle_Recepcion  ORDER BY Id_Detalle  DESC", cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Deta = Convert.ToInt32(dr["Id_Detalle"].ToString());
            }
            catch (Exception e)
            {
                dr = null;
                return 0;
            }
            return Deta;
        }

       
        public static double EncontrarAnticipo( int IdDetalle)
        {
            double Ant=0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select Monto_Anticipo from Detalle_Recepcion where Id_Detalle =@IdDetalle", cnx);
                cmd.Parameters.AddWithValue("@IdDetalle", IdDetalle);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Ant = Convert.ToDouble(dr["Monto_Anticipo"].ToString());
            }
            catch (Exception e)
            {
                dr = null;
                return 0;
            }
            return Ant;
        }

        public static DateTime EncontraFechaAnticipo(int IdDetalle)
        {
            DateTime Fec = Convert.ToDateTime("01/01/2020");
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select FechaAnticipo from Detalle_Recepcion where Id_Detalle =@IdDetalle", cnx);
                cmd.Parameters.AddWithValue("@IdDetalle", IdDetalle);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Fec = Convert.ToDateTime(dr["FechaAnticipo"].ToString());
            }
            catch (Exception e)
            {
                dr = null;
                return Fec;
            }
            return Fec;
        }
        public static string EncontrarPlacaViaje(int IdDetalle)
        {
           string Plac = "";
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select Placa_Camion from Detalle_Recepcion where Id_Detalle =@IdDetalle", cnx);
                cmd.Parameters.AddWithValue("@IdDetalle", IdDetalle );
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Plac = dr["Placa_Camion"].ToString();
            }
            catch (Exception e)
            {
                dr = null;
                return Plac;
            }
            return Plac;
        }
        public static int EncontrarIdCamion(string Placa)
        {
            int Cami = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("Select Id_Camion from Camiones where Placa=@Placa", cnx);
                cmd.Parameters.AddWithValue("@Placa", Placa);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Cami = Convert.ToInt32(dr["Id_Camion"].ToString());
            }
            catch (Exception e)
            {
                dr = null;
                return Cami;
            }
            return Cami;
        }

        public static String  BuscarPlaca(int IdDetalle)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            String Placa="";
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                String sql = "select Placa_Camion from Detalle_Recepcion where Id_Detalle=" + IdDetalle ;
                cmd = new SqlCommand(sql, cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Placa= Convert.ToString(dr["Placa_Camion"].ToString());
            }
            catch (Exception e)
            {
                Placa = "";
            }
            finally
            {
                cnx.Close();
            }

            return Placa;
        }

        public static DateTime BuscarFechaCargaConfirmar(int IdDetalle)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DateTime  fecha = Convert.ToDateTime("01/01/2001");
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                String sql = "select FechaCarga from Detalle_Recepcion where Id_Detalle=" + IdDetalle;
                cmd = new SqlCommand(sql, cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                fecha= Convert.ToDateTime(dr["FechaCarga"].ToString());
            }
            catch (Exception e)
            {
                fecha =Convert.ToDateTime("01/01/2001") ;
            }
            finally
            {
                cnx.Close();
            }

            return fecha;
        }

        public static int BuscarRutaConfirmar(int IdDetalle)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int Ruta = 0;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                String sql = "select Id_Ruta from Detalle_Recepcion where Id_Detalle=" + IdDetalle;
                cmd = new SqlCommand(sql, cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Ruta = Convert.ToInt32(dr["Id_Ruta"].ToString());
                dr.Close();
            }
            catch (Exception e)
            {
                Ruta  = 0;
            }
            finally
            {
                cnx.Close();
            }

            return Ruta;
        }
        public static SqlDataReader BuscarPendientes(string Placa)
        {
             SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select Max(Id_Detalle) as Maximo from Detalle_Recepcion where Placa_Camion=@Placa and Confirmado=1", cnx);
                cmd.Parameters.AddWithValue("@Placa", Placa);
                
                cnx.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception e)
            {
                dr = null;
                return dr;
            }
        }
        public static bool  BuscarRepetidosConfirmacion(string Placa,DateTime FechaCarga,int Ruta)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            bool repetido = false;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarRepetidosConfirmacion", cnx);
                cmd.Parameters.AddWithValue("@Placa", Placa);
                cmd.Parameters.AddWithValue("@FechaCarga", FechaCarga);
                cmd.Parameters.AddWithValue("@IdRuta", Ruta);
                
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    if (dr != null)
                    {
                        repetido = true;
                        return repetido;
                    }
                }
            }
            catch (Exception e)
            {
                dr = null;
                return repetido;
            }
            finally
            {
                dr.Close();
                cmd.Connection.Close();
            }
            return repetido;
        }
        public static bool BuscarRepetidosConfirmacionDescarga(string Placa, DateTime FechaDescarga, int Ruta)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn=null;
            SqlConnection cnx=null;
            bool Repetido = false;
            try
            {
                cn = new ClaseConexion();
                cnx = cn.conectar();
                cmd = new SqlCommand("BuscarRepetidosConfDescarga", cnx);
                cmd.Parameters.AddWithValue("@Placa", Placa);
                cmd.Parameters.AddWithValue("@FechaDescarga", FechaDescarga);
                cmd.Parameters.AddWithValue("@IdRuta", Ruta);

                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows == true)
                {
                    if (dr != null)
                    {
                        Repetido = true;
                        return Repetido;
                    }
                }
            }
            catch (Exception ex)
            {
                dr = null;
                return Repetido;
            }
            finally
            {
                dr.Close();
                cnx.Close();
            }
            return Repetido;
        }
        public static SqlDataReader BuscarProgramacion(string Placa,int Ruta,DateTime FechaCarga)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarRepetidosEnProgramacion", cnx);
                cmd.Parameters.AddWithValue("@Placa", Placa );
                cmd.Parameters.AddWithValue("@FechaCarga", FechaCarga);
                cmd.Parameters.AddWithValue("@IdRuta", Ruta);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception e)
            {
                dr = null;
                return dr;
            }
        }
        public static SqlDataReader BuscarChofer(string Placa)
        {
            //EntCamiones obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                //cmd = new SqlCommand("select * from  Camiones,Persona,Detalle_TipoEntidad where  Camiones.Placa=@Placa " +
                // "and Persona.CI=Camiones.IdChofer and Detalle_TipoEntidad.Id_TipoEntidad=2  and Persona.Cod_Ente=Detalle_TipoEntidad.Cod_Ente", cnx);
                cmd = new SqlCommand("select * from  View_Camiones where Placa = @Placa", cnx);
                cmd.Parameters.AddWithValue("@Placa", Placa);
                //cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                //obj = new EntCamiones();
                //dr.Read();

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

        public static int ValorMax()
        {
            int Mx = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("MaximaRecepcion", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Mx=Convert.ToInt32(dr["Maximo"].ToString());
            }
            catch (Exception e)
            {
                dr = null;
                return Mx;
            }
            return Mx;
        }

        public static int DetalleMax()
        {
            int Mx = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("MaximoDetalle", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Mx = Convert.ToInt32(dr["Maxim"].ToString());
            }
            catch (Exception e)
            {
                dr = null;
                return Mx;
            }
            return Mx;
        }

        public static SqlDataReader BuscarNit(string Client)
        {
            //EntCamiones obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select * from  vi_Cliente where Cliente = @Client", cnx);
                cmd.Parameters.AddWithValue("@Client", Client);
                //cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                //obj = new EntCamiones();
                //dr.Read();

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
        public static int Deshabilitar(int Id)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();

                cnx.Open();
                myTrans = cnx.BeginTransaction();

                ////string sql = "Insert into Persona (CI, Tipo_Persona, Id_TipoPersonaPRO, Id_TipoPersonaCho, Id_TipoPersonaTit, Id_TipoPersonaUs, Nombres, Apellidos, Direccion, Telefonos, TelfReferencia, Email, VigenciaCI, VigenciaLicencia, VigenciaFelcn, VigenciaRejap) values(@CI, @Tipo_Persona, @Id_TipoPersonaPRO, @Id_TipoPersonaCho, @Id_TipoPersonaTit, @Id_TipoPersonaUs, @Nombres, @Apellidos, @Direccion, @Telefonos, @TelfReferencia, @Email, @VigenciaCI, @VigenciaLicencia, @VigenciaFelcn, @VigenciaRejap) ;SELECT  Scope_Identity(); ";

                string sql = "Update Recepcion set Estado=0 where Id_Recepcion=@Id_Recepcion";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id_Recepcion", Id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                //hasta aqui
            }
            catch (Exception e)
            {

                myTrans.Rollback();
                return 0;

            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
            return 1;
        }
        public static EntRecepcion ConsultaRecepcion(int Id)
        {
            EntRecepcion obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarRecepcion", cnx);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntRecepcion();
                dr.Read();
                obj.Id_Recepcion = Convert.ToInt32(dr["Id_Recepcion"].ToString());
                obj.Id_RecepcionManual = dr["Id_RecepcionManual"].ToString();
                obj.Estado = Convert.ToInt32(dr["Estado"].ToString());
                obj.F_Reg = Convert.ToDateTime(dr["F_Reg"].ToString());
                obj.Obs = dr["OBS"].ToString();
                obj.Cod_Ente = Convert.ToInt32(dr["Cod_Ente"].ToString());
                
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return obj;
        }
        public static SqlDataReader BuscarCliente(string Cliente )
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select * from  Vi_ClienteEnte where Cod_Ente=@Cod_Ente", cnx);
                cmd.Parameters.AddWithValue("@Cod_Ente", Cliente);
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


        public static SqlDataReader BuscarPlaca(string Placa)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarPorPlaca", cnx);
                cmd.Parameters.AddWithValue("@Placa", Placa);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception e)
            {
                dr = null;
                return dr;
            }
        }

        public static SqlDataReader BuscarRecepcion()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx=cn.conectar();
                cmd = new SqlCommand("select MAX(Id_RecepcionManual) as valor from Recepcion",cnx);
                cnx.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception e)
            {
                dr = null;
                return dr;
            }
        }

        public static SqlDataReader BuscarRuta(string Ruta)
        {
            
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarRuta", cnx);
                cmd.Parameters.AddWithValue("@IdRuta", int.Parse(Ruta));
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

        public static SqlDataReader BuscarMonto(string monto)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select * from  Ruta where Id_Ruta=@Id_Ruta", cnx);
                cmd.Parameters.AddWithValue("@Id_Ruta", monto);

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

        public static int ActualizarAsignacion(EntRecepcion Recp, EntDetalle_Recepcion deret)
        {
            return 1;
        }

        public static int InsertarPagoMasivoAntc()
        {
            SqlCommand cmd = null;
            SqlConnection cnx = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            int IdPagoMasivo = 0;
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql="insert into Pago_MasivoAntLog (Activo) values(1);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Transaction = myTrans;
                IdPagoMasivo = Convert.ToInt32(cmd.ExecuteScalar());
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                return 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return IdPagoMasivo;
        }
        public static void ActualizarProgramacionPago(int Id_Pmm,int IdDetalle)
        {
            SqlCommand cmd = null;
            SqlConnection cnx = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            
            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "update detalle_recepcion set Id_Pmm=@Id_Pmm where Id_detalle=@IdDetalle";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id_Pmm", Id_Pmm);
                cmd.Parameters.AddWithValue("@IdDetalle", IdDetalle);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static int VerificarYaPagado(int IdDetalle)
        {
            int IdPago = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("select Id_Pmm from Detalle_Recepcion where Id_Detalle =@IdDetalle", cnx);
                cmd.Parameters.AddWithValue("@IdDetalle", IdDetalle);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdPago = Convert.ToInt32(dr["Id_Pmm"].ToString());
                dr.Close();
            }
            catch (Exception e)
            {
                dr = null;
                return 0;
            }
            return IdPago;
        }

        public static string EncontrarAbrevBanco(long NroCuenta)
        {
            string Abrevbanco = "";
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ProcEncAbrevBanco", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NroCuenta", NroCuenta);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Abrevbanco = dr["Abreviacion"].ToString();
                dr.Close();
                
            }
            catch (Exception ex)
            {
                dr = null;
                return "";
            }
            return Abrevbanco;
        }
        public static bool VerifBanco(string AbrevBanco)
        {
            bool VerBanco = false;
            switch (AbrevBanco)
            {
                case "BNB":
                    VerBanco = true;
                    break;
                case "BCB":
                    VerBanco = true;
                    break;
                case "BDB":
                    VerBanco = true;
                    break;
                case "BEC":
                    VerBanco = true;
                    break;
                case "BFO":
                    VerBanco = true;
                    break;
                case "BGA":
                    VerBanco = true;
                    break;
                case "BIE":
                    VerBanco = true;
                    break;
                case "BIS":
                    VerBanco = true;
                    break;
                case "BLA":
                    VerBanco = true;
                    break;
                case "BMS":
                    VerBanco = true;
                    break;
                case "BSO":
                    VerBanco = true;
                    break;
                case "BUN":
                    VerBanco = true;
                    break;
                case "BCP":
                    VerBanco = true;
                    break;
            }
            return VerBanco;
        }
        public static int EncontrarIdPagoMasiv(int IdDetalle)
        {
            int IdPagoMasivo = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                string sql = "Select Id_Pmm from Detalle_Recepcion where id_detalle=@IdDetalle";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@IdDetalle", IdDetalle);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdPagoMasivo = Convert.ToInt32(dr["Id_Pmm"].ToString());
                dr.Close();
            }
            catch (Exception ex)
            {
                dr = null;
                return 0;
            }
            return IdPagoMasivo;
        }
        public static int EncontrarIdCliente(int IdDetalle)
        {
            int IdCliente = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion Con = new ClaseConexion();
                SqlConnection cnx = Con.conectar();
                string sql = "select Id_Cliente from detalle_recepcion,ruta where detalle_recepcion.Id_ruta=ruta.id_ruta and Id_Detalle=@IdDetalle";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@IdDetalle", IdDetalle);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                IdCliente = Convert.ToInt32(dr["Id_Cliente"].ToString());
                dr.Close();
            }
            catch (Exception ex)
            {
                dr = null;
                return 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return IdCliente;
        }

        public static int DEncontrarConfDescarga(int IdDetalle)
        {
            int EstConfInternacionl = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion Con = new ClaseConexion();
                SqlConnection cnx = Con.conectar();
                string sql = "select EstConfViaInternacional from detalle_recepcion where Id_Detalle=@IdDetalle";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@IdDetalle",IdDetalle);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                EstConfInternacionl = Convert.ToInt32(dr["EstConfViaInternacional"].ToString());
                dr.Close();
                
            }
            catch (Exception ex)
            {
                dr = null;
                return 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return EstConfInternacionl;
        }
        public static void DAprobacionDeDescarga(int IdDetalle)
        {
            SqlCommand cmd = null;
            SqlConnection cnx = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();

            try
            {
                cnx = new SqlConnection();
                cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                cmd = new SqlCommand("ProcActualizacionConfDescarga ", cnx);
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.AddWithValue("@IdDetalle", IdDetalle);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                myTrans.Commit();
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}