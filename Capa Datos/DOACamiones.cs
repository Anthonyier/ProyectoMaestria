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
    public class DOACamiones
    {
        public static int GuadarCamiones(EntCamiones Cam,EntCuenta Cuen){

                   SqlCommand cmd = null;
                   SqlTransaction myTrans = null;
                   ClaseConexion Conexion = new ClaseConexion();
                   SqlConnection cnx = Conexion.conectar();
                   int Idcuenta = 0;
                   try
                   {
                       cnx.Open();
                       myTrans = cnx.BeginTransaction();
                      
                       string sql = "Insert Into Camiones(Placa,Emplaque,Capacidad,OBS,Ubicacion,Id_Marca,Id_Color,IdPropietario,IdChofer,IdTitBanco,Id_Rastreo)"+
                       "values (@Placa,@Emplaque,@Capacidad,@OBS,@Ubicacion,@IdMarca,@Color,@Propietario,@Chofer,@TitBanco,@Rastreo)"+
                       ";SELECT Scope_Identity();";
                       cmd = new SqlCommand(sql, cnx);
                       cmd.Parameters.AddWithValue("@Placa", Cam.Placa);
                       cmd.Parameters.AddWithValue("@Emplaque", Cam.Emplaque);
                       cmd.Parameters.AddWithValue("@Capacidad",Cam.Capacidad);
                       cmd.Parameters.AddWithValue("@OBS", Cam.OBS);
                       cmd.Parameters.AddWithValue("@Ubicacion",Cam.Ubicacion);
                       cmd.Parameters.AddWithValue("@IdMarca", Cam.Id_Marca);
                       cmd.Parameters.AddWithValue("@Color", Cam.Id_Color);
                       cmd.Parameters.AddWithValue("@Propietario", Cam.IdPropietario);
                       cmd.Parameters.AddWithValue("@Chofer", Cam.IdChofer);
                       cmd.Parameters.AddWithValue("@TitBanco", Cam. IdTitBanco);
                       cmd.Parameters.AddWithValue("@Rastreo", Cam.Id_Rastreo);
                       cmd.Transaction = myTrans;
                       cmd.ExecuteNonQuery();

                       if(DOACuenta.ConsultaCuenta(Cuen.NroCuenta )==null){
                       sql = "Insert Into Cuenta (NroCuenta,Id_Banco) values (@NroCuenta,@Id_Banco);SELECT Scope_Identity();";
                       cmd = new SqlCommand(sql, cnx);
                       cmd.Parameters.AddWithValue("@NroCuenta", Cuen.NroCuenta);
                       cmd.Parameters.AddWithValue("@Id_Banco",Cuen.Id_Banco);
                       cmd.Transaction = myTrans;
                       Idcuenta = Convert.ToInt32(cmd.ExecuteScalar());

                       EntPersona per = DOACamiones.IdTitular(Cam.IdTitBanco);
                       sql = "Insert Into TitularBanco(Id_Persona,Id_Cuenta) values (@IdPersona,@IdCuenta);SELECT Scope_Identity();";
                       cmd = new SqlCommand(sql, cnx);
                       cmd.Parameters.AddWithValue("@IdPersona", per.Id_Persona);
                       cmd.Parameters.AddWithValue("@IdCuenta", Idcuenta);
                       cmd.Transaction = myTrans;
                       cmd.ExecuteNonQuery();
                       }
                 
                   }
                   catch (Exception e)
                   {
                       myTrans.Rollback();

                   }
                   myTrans.Commit();
                   cnx.Close();
                   return 1;
        }

        public static bool DarSeguro(string Placa)
        {
            bool Valor = false;
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Camiones set Seguros=1 Where Placa=@Placa and Seguros=0";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Placa", Placa);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                Valor = true;
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                Valor = false;
                return Valor;
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
            return Valor;
        }

        public static bool QuitarSeguro(String Placa)
        {
            bool Valor = false;
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Camiones set Seguros=0 Where Placa=@Placa and Seguros=1";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Placa", Placa);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                Valor = true;
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                Valor = false;
                return Valor;
            }
            finally
            {
                myTrans.Commit();
                cmd.Connection.Close();
            }
            return Valor;
        }
        public static void Deshabilitar(string Placa)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Camiones set Est=1 Where Placa=@Placa";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Placa", Placa);
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

        public static void Habilitar(string Placa)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Camiones set Est=0 Where Placa=@Placa";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Placa", Placa);
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
        public static int ActualizarCamion(EntCamiones Camion,EntCuenta Cuenta)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Camiones set Placa=@Placa,Capacidad=@Capacidad,Id_Marca=@IdMarca,Id_Color=@IdColor,IdPropietario=@IdPropietario,IdChofer=@IdChofer,IdTitBanco=@IdTitBanco,OBS=@OBS,Ubicacion=@Ubicacion,Id_Rastreo=@Id_Rastreo Where Id_Camion=@Id_Camion";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Placa", Camion.Placa);
                cmd.Parameters.AddWithValue("@Capacidad", Camion.Capacidad);
                cmd.Parameters.AddWithValue("@OBS", Camion.OBS);
                cmd.Parameters.AddWithValue("@Ubicacion", Camion.Ubicacion);
                cmd.Parameters.AddWithValue("@IdMarca",Camion.Id_Marca);
                cmd.Parameters.AddWithValue("@IdColor",Camion.Id_Color);
                cmd.Parameters.AddWithValue("@IdPropietario", Camion.IdPropietario);
                cmd.Parameters.AddWithValue("@IdChofer", Camion.IdChofer);
                cmd.Parameters.AddWithValue("@IdTitBanco", Camion.IdTitBanco);
                cmd.Parameters.AddWithValue("@Id_Rastreo", Camion.Id_Rastreo);
                cmd.Parameters.AddWithValue("@Id_Camion", Camion.Id_Camion);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                SqlDataReader R= DOACuenta.BuscarTitCuenta(Camion.IdTitBanco);
                R.Read();
                if (R.HasRows == true)
                {
                    if (R!= null)
                    {
                        try
                        {
                            int Cuent =int.Parse( R["Id_Cuenta"].ToString());
                            sql = "Update Cuenta set NroCuenta=@NroCuenta,Id_Banco=@Id_Banco where Id_Cuenta=@Id_Cuenta";
                            cmd = new SqlCommand(sql, cnx);
                            cmd.Parameters.AddWithValue("@NroCuenta", Cuenta.NroCuenta);
                            cmd.Parameters.AddWithValue("@Id_Banco", Cuenta.Id_Banco);
                            cmd.Parameters.AddWithValue("@Id_Cuenta", Cuent);
                            cmd.Transaction = myTrans;
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception er)
                        {
                            
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                Camion = null;
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

        public static int actualizarChofer(EntCamiones Ca)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Update Camiones set IdChofer=@Chofer Where Placa=@Placa";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Chofer", Ca.IdChofer);
                cmd.Parameters.AddWithValue("@Placa", Ca.Placa);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Ca = null;
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

        public static int EstadoChofer(string Ci)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int Est = 0;
            try
            {

                cmd = new SqlCommand("EstadoChofer", cnx);
                cmd.Parameters.AddWithValue("@CI", Ci);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Est=Convert.ToInt32 (dr["Estado"].ToString());
            }
            catch(Exception e)
            {

            }
            finally
            {
                cnx.Close();
            }
            return Est;
        }

        public static EntCamiones Repetidos(string Placa)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            EntCamiones cam = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("PlacaRepetidos", cnx);
                cmd.Parameters.AddWithValue("@Placa", Placa);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                cam = new EntCamiones();
                dr.Read();
                cam.Id_Camion = Convert.ToInt32(dr["Id_Camion"].ToString());
                cam.Placa = dr["Placa"].ToString();

            }
            catch (Exception e)
            {
                cam = null;
            }
            finally
            {
                cnx.Close();
            }

            return cam;
        }
        public static EntCamiones ConsultaCamiones(int Id_Camiones)
        {
            EntCamiones obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ProcConsultaCamiones", cnx);
                cmd.Parameters.AddWithValue("@Id_Camion", Id_Camiones);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntCamiones();
                dr.Read();

                obj.Id_Camion = Convert.ToInt32(dr["Id_Camion"].ToString());

                obj.Placa = dr["Placa"].ToString();
                 obj.Emplaque = dr["Emplaque"].ToString();
                obj.Capacidad = dr["Capacidad"].ToString();
                obj.OBS = dr["OBS"].ToString();
                obj.Estado= Convert.ToInt32(dr["Estado"].ToString());
                obj.Fecha_Registro= Convert.ToDateTime(dr["Fecha_registro"].ToString());
                obj.Id_Marca = Convert.ToInt32(dr["Id_Marca"].ToString());
                obj.Ubicacion = dr["Ubicacion"].ToString();
                obj.Id_Color = Convert.ToInt32(dr["Id_Color"].ToString());
                obj.IdPropietario = dr["IdPropietario"].ToString();
                obj.IdChofer = dr["IdChofer"].ToString();
                obj.IdTitBanco = dr["IdTitBanco"].ToString();
                obj.Id_Soat = Convert.ToInt32(dr["Id_Soat"].ToString());
                obj.Id_InspeccionTecnica = Convert.ToInt32(dr["Id_InspeccionTecnica"].ToString());
                obj.Id_Rastreo = Convert.ToInt32(dr["Id_Rastreo"].ToString());

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

        public static int EliminarCamion(int Id)
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

                string sql = "Update Camiones set Est=1 where Id_Camion=@Id_Camion";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id_Camion", Id);
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
        public int valor(int Id, int TipoImg)
        {
            int obj = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("ProcAltoCamion", cnx);
                cmd.Parameters.AddWithValue("@Id_Camion", Id);
                cmd.Parameters.AddWithValue("@Tipo_Img", TipoImg);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                obj = Convert.ToInt32(dr["Resultado"].ToString());


            }
            catch (Exception e)
            {
                obj = 0;
                //obj.DiasVigenciaCI = 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return obj; //objDias
        }

        public int ValorSoat(int id)
        {
            int obj = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("ProcAltoSoat", cnx);
                cmd.Parameters.AddWithValue("@Id_Camion", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                obj = Convert.ToInt32(dr["Resultado"].ToString());


            }
            catch (Exception e)
            {
                obj = 0;
                //obj.DiasVigenciaCI = 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return obj; //objDias
        }

        public int ValorInsp(int id)
        {
            int obj = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("ProcAltaInspecc", cnx);
                cmd.Parameters.AddWithValue("@Id_Camion", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                obj = Convert.ToInt32(dr["Resultado"].ToString());


            }
            catch (Exception e)
            {
                obj = 0;
                //obj.DiasVigenciaCI = 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return obj; //objDias
        }

        public static EntDetalle_Certificados ConsultaVigenciaC(int CodEnte, int TipoImg)
        {
            EntDetalle_Certificados obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DOACamiones Ca = new DOACamiones();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Ca.valor(CodEnte, TipoImg);
            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("ProcCamiCert", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntDetalle_Certificados();
                dr.Read();

                obj.DiasVigencia = Convert.ToDouble(dr["DiasVigencia"].ToString());
                obj.Fecha_Vencimiento = Convert.ToDateTime(dr["FeVenci"].ToString());
                obj.Nombre = dr["NombreDoc"].ToString();

            }
            catch (Exception e)
            {
                obj = null;
                //obj.DiasVigenciaCI = 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return obj; //objDiasVigenciaCI;//obj.DiasVigenciaCI;//obj;
        }

        public static EntPersona IdTitular(string id)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            EntPersona per = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("IdTitular", cnx);
                cmd.Parameters.AddWithValue("@IdTitular", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                per = new EntPersona();
                dr.Read();
                per.Id_Persona = Convert.ToInt32(dr["Id_Persona"].ToString());

            }
            catch (Exception e)
            {
                per = null;
            }
            finally
            {
                cnx.Close();
            }

            return per;
        }

        public static SqlDataReader BuscarChofer(string CI_CH)
        {
            //EntCamiones obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarChofer", cnx);
                cmd.Parameters.AddWithValue("@Cliente", CI_CH);
                cmd.CommandType = CommandType.StoredProcedure;
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

        public static SqlDataReader Cantidad(int Est)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("CantidadCamiones",cnx);
                cmd.Parameters.AddWithValue("@IdEstado", Est);
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

        public static SqlDataReader Cant()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("CantiCami", cnx);
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
        public static SqlDataReader CantDesha()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("CantiDesCam", cnx);
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

        public static SqlDataReader BuscarCamion(String Ca)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarCamion", cnx);
                cmd.Parameters.AddWithValue("@Placa", Ca);
                cmd.CommandType = CommandType.StoredProcedure;
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

        public static SqlDataReader BuscarPropietario(String CI_P)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarPropietario", cnx);
                cmd.Parameters.AddWithValue("@Prop", CI_P);
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
        public static SqlDataReader BuscarTitularBanco(String CI_T)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarTitular", cnx);
                cmd.Parameters.AddWithValue("@Cliente", CI_T);
                cmd.CommandType = CommandType.StoredProcedure;
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

        public static SqlDataReader BuscarPlacaTitular(String Placa)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("EncontrarTitular", cnx);
                cmd.Parameters.AddWithValue("@Placa",Placa);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

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