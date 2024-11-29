using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntCamiones
    {
        public int Id_Camion { get; set; }
        public string Placa { get; set; }
        public string Emplaque { get; set; }
        public string Capacidad { get; set; }
        public DateTime CertEstanqueidad { get; set; }
        public DateTime CertIntegTornamesa { get; set; }
        public DateTime CertMantenMecanico { get; set; }
        public byte[] RUAT { get; set; }
        public string OBS { get; set; }
        public int Estado { get; set; }
        public int Est { get; set; }
        public string Ubicacion { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Id_Marca { get; set; }
        public int Id_Color { get; set; }
        public string IdPropietario { get; set; }
        public string IdChofer { get; set; }
        public string IdTitBanco { get; set; }
        public int Id_Soat { get; set; }
        public int Id_InspeccionTecnica { get; set; }
        public int Id_Rastreo { get; set; }
        public int Seguro { get; set; }
    }
}