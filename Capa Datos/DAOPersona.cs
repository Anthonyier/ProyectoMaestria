using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace CapaDatos
{
    public class DAOPersona
    {
        public static int GuardarPersona(EntPersona obj)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            int Id_Persona = 0;
            int Cod_Ente = 0;
            int IdTipoPersona = 0;
            int Id_ImagenCI = 0;
            int Id_ImagenLicencia = 0;
            int Id_ImagenFelcn = 0;
            int Id_ImagenRejap = 0;
            int Id_CuentaContable = 0;

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();
                cnx.Open();
                myTrans = cnx.BeginTransaction();
                string sql = "Insert into Entes (Id_Tipo) values (1);SELECT Scope_Identity();"; //mientras se guarde persona lo dejamos que guarde 1, luego parametrizamos para que guarde tipoente2
                cmd = new SqlCommand(sql, cnx);
                cmd.Transaction = myTrans;
                Cod_Ente = Convert.ToInt32(cmd.ExecuteScalar());
                sql = "";
              
                sql = "Insert into Persona (CI,Nombre,Apellidos,Direccion,Telefono,TelfReferencia,Email,Emision," +
             "Cod_Ente,Id_ImagenCI,Id_ImagenLicencia,Id_ImagenFelcn,Id_ImagenRejap,Id_CuentaContable)" +
             "values (@CI,@Nombre,@Apellidos,@Direccion,@Telefono,@TelfReferencia,@Email,@Emision,@Cod_Ente," +
             "@Id_ImagenCI,@Id_ImagenLicencia,@Id_ImagenFelcn,@Id_ImagenRejap,@Id_CuentaContable);SELECT Scope_Identity();";

                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@CI", obj.CI);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", obj.Apellidos);
                cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("@TelfReferencia", obj.TelfReferencia);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Emision", obj.Emision);
                cmd.Parameters.AddWithValue("@Cod_Ente", Cod_Ente);
                //cmd.Parameters.AddWithValue("@IdTipoPersona", obj.IdTipoPersona);
                cmd.Parameters.AddWithValue("@Id_ImagenCI",Id_ImagenCI);//obj.Id_ImagenCi);
                cmd.Parameters.AddWithValue("@Id_ImagenLicencia", Id_ImagenLicencia);//obj.Id_ImagenLicencia);
                cmd.Parameters.AddWithValue("@Id_ImagenFelcn", Id_ImagenFelcn);//obj.Id_ImagenFelcn);
                cmd.Parameters.AddWithValue("@Id_ImagenRejap", Id_ImagenRejap);//obj.Id_ImagenRejap);
                cmd.Parameters.AddWithValue("@Id_CuentaContable", obj.Id_CuentaContable);//Verificar bien que datos se van a guardar con el Plan de Cuentas actual Bercam mañana 16-08-17
                cmd.Transaction = myTrans;
                Id_Persona = Convert.ToInt32(cmd.ExecuteScalar());
                sql = "";

                
                if (obj.Id_TipoPersonaPRO == 1)
                {
                    cmd = new SqlCommand("Insert into Detalle_TipoEntidad (Cod_Ente, Id_TipoEntidad) values (@Cod_Ente, @Id_TipoEntidad) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", Cod_Ente);
                    cmd.Parameters.AddWithValue("@Id_TipoEntidad", 1); //quiere decir que es propietario
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                }
                if (obj.Id_TipoPersonaCho == 1)
                {
                    cmd = new SqlCommand("Insert into Detalle_TipoEntidad (Cod_Ente, Id_TipoEntidad) values (@Cod_Ente, @Id_TipoEntidad) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", Cod_Ente);
                    cmd.Parameters.AddWithValue("@Id_TipoEntidad", 2); //quiere decir que es chofer
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                }
                if (obj.Id_TipoPersonaTit == 1)
                {
                    cmd = new SqlCommand("Insert into Detalle_TipoEntidad (Cod_Ente, Id_TipoEntidad) values (@Cod_Ente, @Id_TipoEntidad) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", Cod_Ente);
                    cmd.Parameters.AddWithValue("@Id_TipoEntidad", 3); //quiere decir que es titular banco
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();

                }
                if (obj.Id_TipoPersonaUs == 1)
                {
                    cmd = new SqlCommand("Insert into Detalle_TipoEntidad (Cod_Ente, Id_TipoEntidad) values (@Cod_Ente, @Id_TipoEntidad) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", Cod_Ente);
                    cmd.Parameters.AddWithValue("@Id_TipoEntidad", 4); //quiere decir que es usuario
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                }
                if (obj.Id_TipoPersonaCL == 1)
                {
                    cmd = new SqlCommand("Insert into Detalle_TipoEntidad (Cod_Ente, Id_TipoEntidad) values (@Cod_Ente, @Id_TipoEntidad) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", Cod_Ente);
                    cmd.Parameters.AddWithValue("@Id_TipoEntidad", 5); //quiere decir que es cliente
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                }

                if (obj.Usuario != "")
                {
                    if (obj.Usuario != null)
                    { 
                    cmd = new SqlCommand("Insert into Usuario (Id_Persona, Usuario, Contraseña, Id_Sucursal, Id_Rol) values (@Id_Persona, @Usuario, @Contraseña, @Id_Sucursal, @Id_Rol) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Id_Persona", Id_Persona);
                    cmd.Parameters.AddWithValue("@Usuario", obj.Usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", obj.Contraseña);
                    cmd.Parameters.AddWithValue("@Id_Sucursal", 1);///mas adelante lo ocuparemos
                    cmd.Parameters.AddWithValue("@Id_Rol", obj.Id_Rol);
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                    }
                }

                myTrans.Commit();
            }

            catch(Exception e)
            {
                obj = null;
                myTrans.Rollback();
                return 0;
            }
            
            finally
            {     
                    cmd.Connection.Close();
            }
            return 1;
        }

        public static SqlDataReader BuscarPersona(string Per)
        {
            //EntCamiones obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("BuscarPersona", cnx);
                cmd.Parameters.AddWithValue("@Cliente", Per);
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
        public static EntPersona Repetidos(string ci)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            EntPersona rep = null;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("CIRepetidos", cnx);
                cmd.Parameters.AddWithValue("@CI", ci);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                rep = new EntPersona();
                dr.Read();
                rep.Id_Persona = Convert.ToInt32(dr["Id_Persona"].ToString());
                rep.CI = dr["CI"].ToString();

            }
            catch (Exception e)
            {
                rep = null;
            }
            finally
            {
                cnx.Close();
            }

            return rep;
        }

        public static void Habilitar(int id)
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

                string sql = "Update Persona set Estado=1 where Id_Persona=@Id_Persona";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Id_Persona", id);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();

                //hasta aqui
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
       
       
        public static int ElimianrPersona(int Id)
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

               string sql = "Update Persona set Estado=0 where Id_Persona=@Id_Persona";
               cmd = new SqlCommand(sql, cnx);
               cmd.Parameters.AddWithValue("@Id_Persona", Id);
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
       
        public static int ActualizarPersona(EntPersona obj)//string Nombres, string Apellidos, string CI, string Direccion, string Telefonos, string TelfReferencia, string Email, byte[] imgLicConducir, byte[] AntFelcn, byte[] AntRejap)
        {
            //EntPropietario objPropietario = null;
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;

            //int Id_Pers = 0;
            double CI_Propietario = 0;
            int Id_ImgLicenciaConducir = 0;
            int Id_ImgAntFELCN = 0;
            int Id_ImgAntPenalesRejap = 0;
            double CI_TitularBanco = 0;

            try
            {
                ClaseConexion Conexion = new ClaseConexion();
                SqlConnection cnx = Conexion.conectar();

                cnx.Open();
                myTrans = cnx.BeginTransaction();

                ////string sql = "Insert into Persona (CI, Tipo_Persona, Id_TipoPersonaPRO, Id_TipoPersonaCho, Id_TipoPersonaTit, Id_TipoPersonaUs, Nombres, Apellidos, Direccion, Telefonos, TelfReferencia, Email, VigenciaCI, VigenciaLicencia, VigenciaFelcn, VigenciaRejap) values(@CI, @Tipo_Persona, @Id_TipoPersonaPRO, @Id_TipoPersonaCho, @Id_TipoPersonaTit, @Id_TipoPersonaUs, @Nombres, @Apellidos, @Direccion, @Telefonos, @TelfReferencia, @Email, @VigenciaCI, @VigenciaLicencia, @VigenciaFelcn, @VigenciaRejap) ;SELECT  Scope_Identity(); ";

                string sql = "Update Persona set CI = @CI,Nombre = @Nombre, Apellidos = @Apellidos," +
                "Direccion = @Direccion, Telefono = @Telefono, TelfReferencia = @TelfReferencia," +
                "Email = @Email,Emision=@Emision where Id_Persona = @Id_Persona";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@CI", obj.CI);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", obj.Apellidos);
                cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("@TelfReferencia", obj.TelfReferencia);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Emision", obj.Emision);
                cmd.Parameters.AddWithValue("@Id_Persona", obj.Id_Persona);
                cmd.Transaction = myTrans;
                cmd.ExecuteNonQuery();
                
               //hasta aqui

                if (obj.Id_TipoPersonaPRO == 1)
                {
                    cmd = new SqlCommand("Insert into Detalle_TipoEntidad (Cod_Ente, Id_TipoEntidad) values (@Cod_Ente, @Id_TipoEntidad) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                    cmd.Parameters.AddWithValue("@Id_TipoEntidad", 1); //quiere decir que es propietario
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                }
                if (obj.Id_TipoPersonaCho == 1)
                {
                    cmd = new SqlCommand("Insert into Detalle_TipoEntidad (Cod_Ente, Id_TipoEntidad) values (@Cod_Ente, @Id_TipoEntidad) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                    cmd.Parameters.AddWithValue("@Id_TipoEntidad", 2); //quiere decir que es chofer
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                }
                if (obj.Id_TipoPersonaTit == 1)
                {
                    cmd = new SqlCommand("Insert into Detalle_TipoEntidad (Cod_Ente, Id_TipoEntidad) values (@Cod_Ente, @Id_TipoEntidad) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente",obj.Cod_Ente);
                    cmd.Parameters.AddWithValue("@Id_TipoEntidad", 3); //quiere decir que es titular banco
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                }
                if (obj.Id_TipoPersonaUs == 1)
                {
                    cmd = new SqlCommand("Insert into Detalle_TipoEntidad (Cod_Ente, Id_TipoEntidad) values (@Cod_Ente, @Id_TipoEntidad) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                    cmd.Parameters.AddWithValue("@Id_TipoEntidad", 4); //quiere decir que es usuario
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                }
                if (obj.Id_TipoPersonaCL == 1)
                {
                    cmd = new SqlCommand("Insert into Detalle_TipoEntidad (Cod_Ente, Id_TipoEntidad) values (@Cod_Ente, @Id_TipoEntidad) ;SELECT  Scope_Identity(); ", cnx);
                    cmd.Parameters.AddWithValue("@Cod_Ente", obj.Cod_Ente);
                    cmd.Parameters.AddWithValue("@Id_TipoEntidad", 5); //quiere decir que es cliente
                    cmd.Transaction = myTrans;
                    cmd.ExecuteNonQuery();
                }
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

      
        
        public static EntPersona ConsultaImagenes(int Id_img)
        {
            EntPersona obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ProcImagenes", cnx);
                cmd.Parameters.AddWithValue("@Id_Img", Id_img);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntPersona();
                dr.Read();

               
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
        //public static
        public static EntPersona ConsultaTodo(int Id_Persona)
        {
            EntPersona obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                
                cmd = new SqlCommand("ProcConsultaPersonas", cnx);
                cmd.Parameters.AddWithValue("@Id_Persona", Id_Persona);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntPersona();
                dr.Read();

                obj.Id_Persona = Convert.ToInt32(dr["Id_Persona"].ToString());
                
                obj.CI = dr["CI"].ToString();
                

                obj.Nombres = dr["Nombre"].ToString();
                obj.Apellidos = dr["Apellidos"].ToString();
                obj.Direccion = dr["Direccion"].ToString();
                obj.Telefono = dr["Telefono"].ToString();
                obj.TelfReferencia = dr["TelfReferencia"].ToString();
                obj.Email = dr["Email"].ToString();
                obj.Emision = dr["Emision"].ToString();
                obj.Estado = Convert.ToInt32(dr["Estado"].ToString());
                obj.Cod_Ente = Convert.ToInt32(dr["Cod_Ente"].ToString());
                obj.IdTipoPersona= Convert.ToInt32(dr["IdTipoPersona"].ToString());
                obj.Id_ImagenCi = Convert.ToInt32(dr["Id_ImagenCi"].ToString());
                obj.Id_ImagenLicencia = Convert.ToInt32(dr["Id_ImagenLicencia"].ToString());
                obj.Id_ImagenFelcn = Convert.ToInt32(dr["Id_ImagenFelcn"].ToString());
                obj.Id_ImagenRejap = Convert.ToInt32(dr["Id_ImagenRejap"].ToString());
                obj.Id_CuentaContable = Convert.ToInt32(dr["Id_CuentaContable"].ToString());

                
                
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
        public static EntPersona ConsultaVigenciaPR(int CodEnte, int TipoImg)
        {
            EntPersona obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            DAOPersona Per= new DAOPersona();
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            int num = Per.valor(CodEnte,TipoImg);
            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("ProcConsultaPersonasImagen", cnx);
                cmd.Parameters.AddWithValue("@Id", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntPersona();
                dr.Read();

                obj.DiasVigenciaCI = Convert.ToDouble(dr["DiasVigencia"].ToString());
                obj.VigenciaCI = Convert.ToDateTime(dr["FechaVigencia"].ToString());
                
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

        
        public int valor(int CodEnte, int TipoImg)
        {
            int obj = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            //double DiasVigenciaCI;
            try
            {

                cmd = new SqlCommand("ValorAlto", cnx);
                cmd.Parameters.AddWithValue("@Cod_Ente", CodEnte);
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

        public static double ConsultaVigencia(int CodEnte, int TipoImg)
        {
            EntPersona obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();

            double DiasVigenciaCI;
            try
            {
                
                cmd = new SqlCommand("ProcConsultaPersonasImagen", cnx);
                cmd.Parameters.AddWithValue("@Cod_Ente", CodEnte);
                cmd.Parameters.AddWithValue("@Tipo_Img", TipoImg);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntPersona();
                dr.Read();

                DiasVigenciaCI = Convert.ToDouble(dr["DiasVigencia"].ToString());
               

            }
            catch (Exception e)
            {
                //obj = null;
                DiasVigenciaCI = 0;
            }
            finally
            {
                cnx.Close();
                //cmd.Connection.Close();
            }
            return DiasVigenciaCI;//obj.DiasVigenciaCI;//obj;
        }

        public static EntPersona ConsultaPersonaTodo()
        {
            EntPersona obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("SELECT * FROM vi_listaPersonas", cnx);
                cmd.CommandType = CommandType.Text;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntPersona();
                dr.Read();
                obj.Nombres = dr["Nombre"].ToString();
                obj.Apellidos = dr["Apellidos"].ToString();
                obj.Direccion = dr["Direccion"].ToString();
                obj.Telefono = dr["Telefono"].ToString();
                obj.TelfReferencia = dr["TelfReferencia"].ToString();
                obj.Email = dr["Email"].ToString();
                obj.Estado = Convert.ToInt32(dr["Estado"].ToString());
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
        public static EntPersona ConsultaPersonaCI(string Ci)
        {
            EntPersona obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("SELECT * FROM vi_listaPersonas WHERE CI= @CI" , cnx);
                cmd.Parameters.AddWithValue("@CI", Ci);
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntPersona();
                dr.Read();

                obj.Id_Persona = Convert.ToInt32(dr["Id_Persona"].ToString());

                obj.CI = dr["CI"].ToString();


                obj.Nombres = dr["Nombre"].ToString();
                obj.Apellidos = dr["Apellidos"].ToString();
                

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

        public static EntPersona ConsultaTipoEntidad(int IdPersona)
        {
            EntPersona obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ProcConsultaTipoEntidad", cnx);
                cmd.Parameters.AddWithValue("@Id_Persona", IdPersona);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntPersona();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int tipopers = Convert.ToInt32(dr["Id_TipoPers"].ToString());
                        if (tipopers == 1)
                        {
                            obj.Id_TipoPersonaPRO = 1;
                        }
                        if(tipopers==2)
                        {
                            obj.Id_TipoPersonaCho = 1;
                        }
                        if(tipopers==3)
                        {
                            obj.Id_TipoPersonaTit = 1;
                        }
                        if(tipopers==4)
                        {
                            obj.Id_TipoPersonaUs = 1;
                        }
                        if (tipopers == 5)
                        {
                            obj.Id_TipoPersonaCL = 1;
                        }
                    }
                }
                else
                {

                }
                dr.Close();
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

        public static string EncontrarEmision(string Ci)
        {
            string Emi = "";
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                string sql = "select Emision from Persona where Ci=@Ci";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Ci", Ci);
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Emi = dr["Emision"].ToString();
                dr.Close();
            }
            catch (Exception ex)
            {
                dr = null;
                return "";
            }
            return Emi;
        }

        public static int EncontrarCodigoCiudad(string Emi)
        {
            int CodigoCiudad = 0;
            switch (Emi)
            {
                case "SCZ":
                    CodigoCiudad = 701;
                    break;
                case "LP":
                    CodigoCiudad = 201;
                    break;
                case "CH":
                    CodigoCiudad = 101;
                    break;
                case "OR":
                    CodigoCiudad = 401 ;
                    break;
                case "PT":
                    CodigoCiudad = 501;
                    break;
                case "TJ":
                    CodigoCiudad = 601;
                    break;
                case "BN":
                    CodigoCiudad = 801;
                    break;
                case "PD":
                    CodigoCiudad = 901;
                    break;
                case "CBBA":
                    CodigoCiudad=301;
                    break;
            }
            return CodigoCiudad;
        }

        public static bool VerificarCodEmision(string Emi)
        {
            bool VerEmision = false;
            switch (Emi)
            {
                case "SCZ":
                    VerEmision=true;
                    break;
                case "LP":
                    VerEmision=true;
                    break;
                case "CH":
                    VerEmision=true;
                    break;
                case "OR":
                    VerEmision=true;
                    break;
                case "PT":
                    VerEmision=true;
                    break;
                case "TJ":
                    VerEmision=true;
                    break;
                case "BN":
                    VerEmision=true;
                    break;
                case "PD":
                    VerEmision=true;
                    break;
                case "CBBA":
                    VerEmision=true ;
                    break;
            }
            return VerEmision;
        }
        public static string ExtDocumento(string Emi)
        {
            string ExtDoc = "";
            switch (Emi)
            {
                case "SCZ":
                    ExtDoc  = "SC";
                    break;
                case "LP":
                    ExtDoc = "LP";
                    break;
                case "CH":
                    ExtDoc = "CH";
                    break;
                case "OR":
                    ExtDoc = "OR";
                    break;
                case "PT":
                    ExtDoc = "PO";
                    break;
                case "TJ":
                    ExtDoc = "TJ";
                    break;
                case "BN":
                    ExtDoc = "BN";
                    break;
                case "PD":
                    ExtDoc = "PD";
                    break;
                case "CBBA":
                    ExtDoc = "CBBA";
                    break;
            }
            return ExtDoc;
        }
    }
}