using appTurismoIqq.Modelo;
using appTurismoIqq.Servicios;
using System;
using System.Collections.Generic;
using System.Text;

namespace appTurismoIqq.VistaModelo
{
    public class DetalleDireccionVModelo : BaseVModelo
    {
        private Direccion direccion;
        private string direccionLugar;
        private double latitud;
        private double longitud;
        private ApiServicio apiServicio;
        public Direccion Direccion
        {
            get { return this.direccion; }
            set { this.SetValue(ref this.direccion, value); }
        }
        public string DireccionLugar
        {
            get { return this.direccionLugar; }
            set { this.SetValue(ref this.direccionLugar, value); }
        }
        public double Latitud
        {
            get { return this.latitud; }
            set { this.SetValue(ref this.latitud, value); }
        }
        public double Longitud
        {
            get { return this.longitud; }
            set { this.SetValue(ref this.longitud, value); }
        }
        public DetalleDireccionVModelo(Direccion direccion)
        {
            this.Direccion = direccion;
            this.apiServicio = new ApiServicio();
            this.DireccionLugar = direccion.direccion;
            this.Latitud = latitud;
            this.Longitud = longitud;
        }
    }
}