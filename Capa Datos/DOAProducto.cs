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
    public class DOAProducto
    {
        public static int GuardarProd(EntProducto Prod)
        {
            SqlCommand cmd = null;
            SqlTransaction myTrans = null;
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            try
            {
                cnx.Open();
                myTrans = cnx.BeginTransaction();

                string sql = "Insert into Producto (Descripcion) values" +
                    "(@Descripcion);SELECT Scope_Identity();";
                cmd = new SqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@Descripcion", Prod.Descripcion);
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
    }
}