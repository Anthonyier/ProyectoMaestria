using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntDetalle_Recepcion
    {
        public int Id_Detalle { get; set; }
        public double Monto_Anticipo { get; set; }
        public DateTime FechaCarga { get; set; }
        public DateTime FechaDescarga { get; set; }
        public DateTime Vigencia { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double Comportamiento1 { get; set; }
        public double Comportamiento2 { get; set; }
        public double Comportamiento3 { get; set; }
        public double Comportamiento4 { get; set; }
        public double Comportamiento5 { get; set; }
        public double Comportamiento6 { get; set; }
        public double Comportamiento7 { get; set; }
        public int Precintos { get; set; }
        public int Producto { get; set; }
        public int Estado { get; set; }
        public string  Id_Chofer { get; set; }
        public string Placa_Camion { get; set; }
        public int Id_Recepcion { get; set; }
        public int Ruta { get;set;}
        public double VolumenRecepcion { get; set; }
        public string Ubicacion { get; set; }
        public string NombreTitular { get; set; }
        public int DetallePlantaOrigen { get; set; }
        public int DetallePlantaDestino { get; set; }
        public string Id_Titular { get; set; }
        public string NoCrt { get; set; }
        public double VolumenCrt { get; set; }
        public double PesoCrt { get; set; }
        public string NoMic { get; set; }
        public double VolumenMic { get; set; }
        public double PesoMic { get; set; }
    }
}