using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocios
{
    public class NegUsuario
    {
        public static EntUsuario Login(string usuario, string password)
        {
            return DAOUsuario.Login(usuario, password);
        }

        public static EntDatosEmpresa Empresa(int Id)
        {
            return DAOUsuario.Empresa(Id);
        }
        public static int Usua(string Cliente)
        {
            return DAOUsuario.usua(Cliente);
        }

        public static int obtenerGenero(int IdPersona)
        {
            return DAOUsuario.Genero(IdPersona);
        }
    }
}
