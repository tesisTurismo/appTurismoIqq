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
    public class DetalleEntidadVModelo:BaseVModelo
    {
        private ApiServicio apiServicios;
        private bool isRefreshing;

   
        private ImageSource imageSource;
        private string nombreEntidad;
        private string descripcionEntidad;
        private string pagWebEntidad;
        private static DetalleEntidadVModelo instancia;
        private List<Entidad> entidadSeleccionada;
        public List<Entidad> EntidadSeleccionada
        {
            get { return this.entidadSeleccionada; }
            set { this.SetValue(ref this.entidadSeleccionada, value); }

        }
        public static DetalleEntidadVModelo GetInstancia()
        {

            return instancia;
        }
        public ImageSource ImageSource
        {
            get { return this.imageSource; }
            set { this.SetValue(ref this.imageSource, value); }
        }
        public Entidad Entidad
        {
            get;
            set;
        }
        public string NombreEntidad
        {
            get { return this.nombreEntidad; }
            set { this.SetValue(ref this.nombreEntidad, value); }
        }
        public string DescripcionEntidad
        {
            get { return this.descripcionEntidad; }
            set { this.SetValue(ref this.descripcionEntidad, value); }
        }
        public string PagWebEntidad
        {
            get { return this.pagWebEntidad; }
            set { this.SetValue(ref this.pagWebEntidad, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }

        }
        public DetalleEntidadVModelo(Entidad entidad)
        {
            instancia = this;
            this.Entidad = entidad;
            this.apiServicios = new ApiServicio();
            this.ImageSource = entidad.fotoApp;
            this.NombreEntidad = entidad.nombre;
            this.DescripcionEntidad = entidad.descripcion;
            this.PagWebEntidad = entidad.pagWeb;
            this.LoadEntidades();

        }

        private async void LoadEntidades()
        {
            try
            {
                this.IsRefreshing = true;
                // var mongoService = new ApiServicio();
                EntidadSeleccionada = (List<Entidad>) await apiServicios.listaEntidadesSeleccionada(Entidad.id);
                this.IsRefreshing = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("NO SE PUDO TOMAR LOS DATOSSSSSSS : " + e.Message);
            }

        }

        //comandos por ejecular al hacer click..
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadEntidades);
            }
        }
    }
}
