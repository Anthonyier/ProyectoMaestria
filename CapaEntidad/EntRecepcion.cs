using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntRecepcion
    {
        public int Id_Recepcion { get; set; }
        public string Id_RecepcionManual{get;set;}
        public int Estado { get; set; }
        public string Obs { get; set; }
        public DateTime F_Reg { get; set; }
        public int Cod_Ente { get; set; }
        public int Id_Ruta { get; set; }
        public int Id_Conciliacion { get; set; }
        public double VolumenTotalDespacho { get; set; }
        public int TramoDesde { get; set; }
        public int TramoHasta { get; set; }
        public DateTime FechaCarga { get; set; }
        public DateTime FechaDescarga { get; set; }
        public int Cod_Prod { get; set; }
    }
}