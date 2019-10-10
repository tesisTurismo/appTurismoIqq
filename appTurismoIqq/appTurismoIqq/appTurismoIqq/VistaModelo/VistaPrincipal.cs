using System;
using System.Collections.Generic;
using System.Text;

namespace appTurismoIqq.VistaModelo
{
    public class VistaPrincipal
    {
        public EntidadesVModelo Entidades { get; set; }
        public DetalleEntidadVModelo detalleEntidad { get; set; }
        public CategoriasVModel Categorias { get; set; }

        public LoginVModelo Login { get; set; }
        public RegistroVModel Registros { get; set; }
        public DetalleDireccionVModel Direcciones { get; set; }
        public VistaPrincipal()
        {
            //this.Entidades = new EntidadesVModelo();
            instancia = this;
        }

        private static VistaPrincipal instancia;

        public static VistaPrincipal GetInstancia()
        {
            if (instancia == null)
            {
                return new VistaPrincipal();
            }
            return instancia;
        }
    }
}
