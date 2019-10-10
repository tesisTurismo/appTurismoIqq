using appTurismoIqq.Geolocalizacion;
using appTurismoIqq.Modelo;
using appTurismoIqq.Servicios;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace appTurismoIqq.VistaModelo
{
    public class DetalleDireccionVModel:BaseVModelo
    {
        private static DetalleDireccionVModel instancia;
        private ApiServicio apiServicios;
        private Direccion direccion;

        private int id;
        private string direcciones;
        private double latitud;
        private double longintud;

        public static DetalleDireccionVModel GetInstancia()
        {

            return instancia;
        }
        public Direccion Direccion
        {
            get { return this.direccion; }
            set { this.SetValue(ref this.direccion, value); }
        }
        public string Direcciones
        {
            get { return this.direcciones; }
            set { this.SetValue(ref this.direcciones, value); }
        }

        public double Latitud
        {
            get { return this.latitud; }
            set { this.SetValue(ref this.latitud, value); }
        }

        public double Longitud
        {
            get { return this.longintud; }
            set { this.SetValue(ref this.longintud, value); }
        }

        double latitud2;
        double longitud2;
        string calle1;
       
        public DetalleDireccionVModel(Direccion direccion)
        {
            instancia = this;
            this.Direccion = direccion;
            this.apiServicios = new ApiServicio();
            this.Direcciones = Direccion.direccion;
            this.Latitud = Direccion.latitud;
            this.Longitud = Direccion.longitud;
            latitud2 = Direccion.latitud;
            longitud2 = Direccion.longitud;
            calle1 = Direccion.direccion;
        }

        public ICommand IrMapa
        {
            get
            {
                return new RelayCommand(Mapa2);
            }
        }

        private async void Mapa2()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MapAppPage2(latitud2, longitud2, calle1));
        }
    }
}
