using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntUsuario
    {
        public int Id_Usuario { get; set; }
        public double Id_Persona { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Id_TipoPersona { get; set; }
        public string Direccion { get; set; }
        public string Telefonos { get; set; }
        public string TelfReferencia { get; set; }
        public string Email { get; set; }
        public int Id_Rol { get; set; }
        public string Rol { get; set; }
        public string Sucursal { get; set; }
        public int Estado { get; set; }
    }
}