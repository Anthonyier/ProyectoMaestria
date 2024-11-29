using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using CapaPresentacion;

namespace LogisticaBercam
{
    public partial class FormularioPrincipal : System.Web.UI.MasterPage
    {
        public string SuggestionListPersonas = "";
        public string ListClientes = "";
        public string ListClientes2 = "";
        public string ListClientes3 = "";
        public string Parametro = "";
        public string ListPlacas = "";
        public string ListPlacasHab = "";
        public string ListPlantas = "";
        public string ListRutas = "";
        public string ListCliDetRut = "";
        public string ListTitular = "";
        public string ListUsuario = "";
        public int IdPersona = 1;
        public void CargarPlantas()
        {
            string queryString = "SELECT * FROM Planta ORDER BY Descripcion";

            using (SqlConnection connection = new SqlConnection(CapaPresentacion.Properties.Resources.ConexionBercamPrin))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            if (string.IsNullOrEmpty(ListPlantas))
                            {
                                ListPlantas += "\"" + reader["Descripcion"].ToString() + "\"";
                            }
                            else
                            {
                                ListPlantas += ", \"" + reader["Descripcion"].ToString() + "\"";
                            }
                        }
                    }
                    connection.Close();
                }
            }
        }
        public void CargarClientesParam()//string Param1)
        {
            Parametro = Convert.ToString(Context.Request.QueryString["ClienteP"]);
            string queryString = "SELECT * FROM vi_Cliente where Cliente = " + "'" + Parametro + "'" + " ORDER BY Cliente";

            using (SqlConnection connection = new SqlConnection(CapaPresentacion.Properties.Resources.ConexionBercamPrin))
            {

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            if (string.IsNullOrEmpty(ListClientes2))
                            {
                                ListClientes2 += "\"" + reader["CI"].ToString() + "\"";
                            }
                            else
                            {
                                ListClientes2 += ", \"" + reader["CI"].ToString() + "\"";
                            }

                        }
                    }
                }

            }
        }
        public void CargarClientesF()//string Param1)
        {
            //Parametro = Convert.ToString(Context.Request.QueryString["ClienteP"]);
            string queryString = "SELECT * FROM vi_Cliente ORDER BY Cliente";

            using (SqlConnection connection = new SqlConnection(CapaPresentacion.Properties.Resources.ConexionBercamPrin))
            {

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            if (string.IsNullOrEmpty(ListClientes3))
                            {
                                ListClientes3 += "\"" + reader["CLIENTE"].ToString() + "\"";
                            }
                            else
                            {
                                ListClientes3 += ", \"" + reader["CLIENTE"].ToString() + "\"";
                            }

                        }
                    }
                }

            }
        }
        public void CargarClientesMain()
        {
            if (Request.QueryString["query"] != "")
            {
                if (Request.QueryString["identifier"] == "Cliente")
                {
                    DataSet ds = Autocomplete.GetProveedores(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["Descripcion"].ToString();
                            item.id = dr["Id"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel=" + item.id + "_" + dr["Descripcion"].ToString() + ">" + item.value + "</li>" + "\n");

                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
            }
        }
        public void CargarClientes()
        {
            string queryString = "SELECT * FROM vi_Cliente  ORDER BY Cliente";
            using (SqlConnection connection = new SqlConnection(CapaPresentacion.Properties.Resources.ConexionBercamPrin))
            {

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        
                        while (reader.Read())
                        {

                            if (string.IsNullOrEmpty(ListClientes))
                            {
                                ListClientes += "\"" + reader["CLIENTE"].ToString() + "\"";

                            }
                            else
                            {
                                ListClientes += ", \"" + reader["CLIENTE"].ToString() + "\"";
                                //ListClientes += ","\"" + reader["CLIENTE"].ToString() + "\"";
                            }

                        }
                    }
                }
            }
        }

        public void CargarRutas()
        {
            SqlCommand cmd = new SqlCommand();
            ClaseConexion Conexion = new ClaseConexion();
            SqlConnection cnx = Conexion.conectar();
            cmd = new SqlCommand("ProcEncCliente", cnx);
            cmd.Parameters.AddWithValue("@IdPersona", IdPersona);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = sql;
            //cmd.Connection = cnx;
            SqlDataReader reader = null;
            cnx.Open();
            //cmd.Transaction = myTrans;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                if (string.IsNullOrEmpty(ListRutas))
                {
                    ListRutas += "\"" + reader["Ruta"].ToString() + "\"";

                }
                else
                {
                    ListRutas += ", \"" + reader["Ruta"].ToString() + "\"";

                }

            }
            reader.Close();
        }
        public void CargarTitular()
        {
            string queryString = "SELECT * FROM View_Titular ORDER BY Cliente";
            using (SqlConnection connection = new SqlConnection(CapaPresentacion.Properties.Resources.ConexionBercamPrin))
            {

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {

                            if (string.IsNullOrEmpty(ListTitular))
                            {
                                ListTitular += "\"" + reader["CLIENTE"].ToString() + "\"";

                            }
                            else
                            {
                                ListTitular += ", \"" + reader["CLIENTE"].ToString() + "\"";
                                //ListClientes += ","\"" + reader["CLIENTE"].ToString() + "\"";
                            }

                        }
                    }
                }
            }
        }
        public void CargarPlacas()
        {
            string queryString = "SELECT * FROM View_Camiones ORDER BY Placa";
            using (SqlConnection connection = new SqlConnection(CapaPresentacion.Properties.Resources.ConexionBercamPrin))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (string.IsNullOrEmpty(ListPlacas))
                            {
                                ListPlacas += "\"" + reader["Placa"].ToString() + "\"";
                            }
                            else
                            {
                                ListPlacas += ", \"" + reader["Placa"].ToString() + "\"";
                            }
                        }
                    }
                }
            }
        }
        public void CargarUsuarios()
        {
            string queryString = "SELECT * FROM Vi_Usuario order by NombreUsuario";
            using (SqlConnection connection = new SqlConnection(CapaPresentacion.Properties.Resources.ConexionBercamPrin))
            {

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {

                            if (string.IsNullOrEmpty(ListUsuario))
                            {
                                ListUsuario += "\"" + reader["NombreUsuario"].ToString() + "\"";

                            }
                            else
                            {
                                ListUsuario += ", \"" + reader["NombreUsuario"].ToString() + "\"";
                                //ListClientes += ","\"" + reader["CLIENTE"].ToString() + "\"";
                            }

                        }
                    }
                }
            }
        }
        public void CargarPlacasHabilitadas()
        {
            string queryString = "SELECT * FROM View_Camiones where Est=0 ORDER BY Placa";
            using (SqlConnection connection = new SqlConnection(CapaPresentacion.Properties.Resources.ConexionBercamPrin))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (string.IsNullOrEmpty(ListPlacasHab))
                            {
                                ListPlacasHab += "\"" + reader["Placa"].ToString() + "\"";
                            }
                            else
                            {
                                ListPlacasHab += ", \"" + reader["Placa"].ToString() + "\"";
                            }
                        }
                    }
                }
            }
        }
        public void CargarCliDetRuta()
        {
            string queryString = "SELECT * FROM vi_Cliente  ORDER BY Cliente";
            using (SqlConnection connection = new SqlConnection(CapaPresentacion.Properties.Resources.ConexionBercamPrin))
            {

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {

                            if (string.IsNullOrEmpty(ListClientes))
                            {
                                ListCliDetRut += "\"" + reader["CLIENTE"].ToString() + "\"";

                            }
                            else
                            {
                                ListCliDetRut += ", \"" + reader["CLIENTE"].ToString() + "\"";
                                //ListClientes += ","\"" + reader["CLIENTE"].ToString() + "\"";
                            }

                        }
                    }
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            EntUsuario obj = (EntUsuario)Session["Usuario"];
            if (obj != null)
            {
                lblNombreUsuario.Text = obj.Nombre + " " + obj.Apellidos;
            }
            else
            {
                Response.Redirect("frmInicioSesion.aspx");
            }

            string queryString = "SELECT * FROM vi_listaPersonasCL  ORDER BY Cliente";

            using (SqlConnection connection = new SqlConnection(CapaPresentacion.Properties.Resources.ConexionBercamPrin))
            {

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            if (string.IsNullOrEmpty(SuggestionListPersonas))
                            {
                                SuggestionListPersonas += "\"" + reader["CLIENTE"].ToString() + "\"";
                            }
                            else
                            {
                                SuggestionListPersonas += ", \"" + reader["CLIENTE"].ToString() + "\"";
                            }

                        }
                    }
                }
            }
            CargarClientes();
            CargarClientesMain();
            CargarClientesParam();
            CargarClientesF();
            CargarCliDetRuta();
            CargarPlacas();
            CargarPlantas();
            CargarTitular();
            CargarPlacasHabilitadas();
            CargarUsuarios();
        }
        protected void LinkLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("Usuario");
            Response.Redirect("frmInicioSesion.aspx");
        }
    }
}