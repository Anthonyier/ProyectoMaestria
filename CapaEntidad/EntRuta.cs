using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntRuta
    {
        public int Id_Ruta { get; set; }
        public string Ruta { get; set; }
        public int Origen { get; set; }
        public int Destino { get; set; }
        public Double MontoAnticipo { get; set; }
        public Double PrecioTotal { get; set; }
        public Double PrecioFlet { get; set; }
        public int Id_Cliente { get; set; }
        


        public string Origens { get; set; }
        public string Destinos { get; set; }
    }
}