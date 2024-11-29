using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;



namespace CapaDatos
{
    public class DAOUsuario
    {
        //Esta Funcion nos permite logearnos
        public static EntUsuario Login(string usuario, string password)
        {
            EntUsuario obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
               
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("ProcUsuarios",cnx);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Contraseña", password);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntUsuario();
                dr.Read();
                
                obj.Id_Usuario = Convert.ToInt32(dr["Id_Usuario"].ToString());
                obj.Id_Persona = Convert.ToDouble(dr["Id_Persona"].ToString());//Convert.ToDouble(dr["CI_Usuario"].ToString());
                obj.Nombre = dr["Nombre"].ToString();
                obj.Apellidos = dr["Apellidos"].ToString();
                obj.Usuario = dr["Usuario"].ToString();
                obj.Contraseña = dr["Contraseña"].ToString();
                obj.Id_Rol = Convert.ToInt32(dr["Id_Rol"].ToString());
                obj.Sucursal = dr["Sucursal"].ToString();

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

        public static EntDatosEmpresa Empresa(int Id)
        {
            EntDatosEmpresa obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                ClaseConexion cn = new ClaseConexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("SELECT * FROM DatosEmpresa where IdEmpresa=3", cnx);
                cmd.CommandType = CommandType.Text;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntDatosEmpresa();
                dr.Read();
                obj.Nombre = dr["Nombre"].ToString();
                obj.RazonSocial = dr["RazonSocial"].ToString();
                obj.Nit = Convert.ToInt32(dr["Nit"].ToString());
                obj.Rubro = dr["Rubro"].ToString();
                obj.Telefono = Convert.ToInt32(dr["Telefono"].ToString()); 
                obj.Direccion = dr["Direccion"].ToString();
                obj.NombreContacto = dr["NombreContacto"].ToString();
                obj.Email = dr["Email"].ToString();
                obj.EmailEnvio = dr["EmailEnvio"].ToString();
                obj.PaginaWeb = dr["PaginaWeb"].ToString();
                obj.Facebook = dr["Facebook"].ToString();
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

        public static int Genero(int IdPersona)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int Gen = 0;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {
                cmd = new SqlCommand("Select IdGenero from usuario where Id_Persona=@IdPersona",cnx);
                cmd.Parameters.AddWithValue("@IdPersona",IdPersona);
                cmd.CommandType = CommandType.Text;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                Gen = Convert.ToInt32(dr["IdGenero"].ToString());
            }
            catch (Exception e)
            {
                return 0;
            }
            cnx.Close();
            return Gen;
        }
        public static int usua(string Cliente)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            int per = 0;
            ClaseConexion cn = new ClaseConexion();
            SqlConnection cnx = cn.conectar();
            try
            {

                cmd = new SqlCommand("IDUsuario", cnx);
                cmd.Parameters.AddWithValue("@Cliente", Cliente);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                per = Convert.ToInt32(dr["Id_Usuario"].ToString());

            }
            catch (Exception e)
            {
                per = 0;
            }
            finally
            {
                cnx.Close();
            }

            return per;
        }   
    }
}
