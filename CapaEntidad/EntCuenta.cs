using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaEntidad
{
    public class EntCuenta
    {
        public int Id_Cuenta { get; set; }
        public long NroCuenta {get;set;}
        public int Id_Banco { get; set; }
        public int Id_TipoCuenta { get; set; }
        
    }
}