using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaNegocios;
using CapaDatos;

namespace CapaNegocios
{
    public class Negproducto
    {
        public static int InsertarProducto(EntProducto prod)
        {
            return DOAProducto.GuardarProd(prod);
        }

        public static int ActualizarProducto(EntProducto prod)
        {
            return 1;
        }
    }
}