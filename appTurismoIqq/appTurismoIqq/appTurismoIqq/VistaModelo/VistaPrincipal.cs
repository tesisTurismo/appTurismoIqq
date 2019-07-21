using System;
using System.Collections.Generic;
using System.Text;

namespace appTurismoIqq.VistaModelo
{
    public class VistaPrincipal
    {
        public EntidadesVModelo Entidades { get; set; }
        public VistaPrincipal()
        {
            this.Entidades = new EntidadesVModelo();
        }
        
    }
}
