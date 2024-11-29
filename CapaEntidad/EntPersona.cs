using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntPersona
    {
        public int Id_Persona { get; set; }
        public string CI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TelfReferencia { get; set; }
        public string Email { get; set; }
        public string Emision { get; set; }
        public int Estado { get; set; }

        public int Cod_Ente { get; set; }
        public int IdTipoPersona { get; set; }
        public int Id_ImagenCi { get; set; }
        public int Id_ImagenLicencia { get; set; }
        public int Id_ImagenFelcn { get; set; }
        public int Id_ImagenRejap { get; set; }
        public int Id_CuentaContable { get; set; }

        public int Id_TipoPersonaPRO { get; set; }
        public int Id_TipoPersonaCho { get; set; }
        public int Id_TipoPersonaTit { get; set; }
        public int Id_TipoPersonaUs { get; set; }
        public int Id_TipoPersonaCL { get; set; }
        public DateTime VigenciaCI { get; set; }
        public DateTime VigenciaLicencia { get; set; }
        public DateTime VigenciaFelcn { get; set; }
        public DateTime VigenciaRejap { get; set; }
        public byte[] LicenciaConducir { get; set; }
        public byte[] AntFelcn { get; set; }
        public byte[] AntPenal { get; set; }
        public byte[] imgCI { get; set; }

        public double DiasVigenciaCI { get; set; }
        public double DiasVigenciaLicencia { get; set; }
        public double DiasVigenciaFelcn { get; set; }
        public double DiasVigenciaRejap { get; set; }





        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int Id_Rol { get; set; }

    }
}