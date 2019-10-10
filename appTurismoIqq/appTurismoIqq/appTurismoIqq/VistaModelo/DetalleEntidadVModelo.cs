using appTurismoIqq.Geolocalizacion;
using appTurismoIqq.Modelo;
using appTurismoIqq.Servicios;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace appTurismoIqq.VistaModelo
{
    public class DetalleEntidadVModelo:BaseVModelo
    {
        private static DetalleEntidadVModelo instancia;
        private ApiServicio apiServicios;
        private bool isRefreshing;
        

        private ImageSource imageSource;

        private double latitud;
        private double longitud;
        private int contador;
        private string nombreEntidad;
        private string descripcionEntidad;
        private string descripcionEntidadEng;
        private string pagWebEntidad;
        
        public List<Direccion> MiDireccion { get; set; }
        private List<Entidad> entidadSeleccionada;
        public List<Entidad> EntidadSeleccionada
        {
            get { return this.entidadSeleccionada; }
            set { this.SetValue(ref this.entidadSeleccionada, value); }

        }
        private List<DetalleDireccionItemVModel> direcciones;
        public List<DetalleDireccionItemVModel> Direcciones
        {
            get { return this.direcciones; }
            set { this.SetValue(ref this.direcciones, value); }

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
        public Direccion Direccion
        {
            get;
            set;
        }

       

        public string NombreEntidad
        {
            get { return this.nombreEntidad; }
            set { this.SetValue(ref this.nombreEntidad, value); }
        }

        public int Contador
        {
            get { return this.contador; }
            set { this.SetValue(ref this.contador, value); }
        }

        public string DescripcionEntidad
        {
            get { return this.descripcionEntidad; }
            set { this.SetValue(ref this.descripcionEntidad, value); }
        }

        public string DescripcionEntidadEng
        {
            get { return this.descripcionEntidad; }
            set { this.SetValue(ref this.descripcionEntidadEng, value); }
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

        public double latitud2;
        public double longitud2;
        public string calle1;

        
        public DetalleEntidadVModelo(Entidad entidad)
        {
            instancia = this;
            this.Entidad = entidad;
            this.apiServicios = new ApiServicio();
            this.ImageSource = entidad.fotoApp;
            this.NombreEntidad = entidad.nombre;
            this.DescripcionEntidad = entidad.descripcion;
            this.DescripcionEntidadEng = entidad.descripcionEng;
            this.PagWebEntidad = entidad.pagWeb;
            this.LoadDirecciones();
            this.EditarVistasEntidad();

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
        public void RefreshList()
        {

            var mylistaNVMDirecciones = this.MiDireccion.Select(p => new DetalleDireccionItemVModel
            {
                id = p.id,
                direccion = p.direccion,
                latitud = p.latitud,
                longitud = p.longitud,
                entidad = p.entidad
                

            });
            this.Direcciones = new List<DetalleDireccionItemVModel>(
                mylistaNVMDirecciones.OrderBy(p => p.direccion));
             

        }
        
        private async void LoadDirecciones()
        {
            try
            {
                this.IsRefreshing = true;
                // var mongoService = new ApiServicio();
                MiDireccion = (List<Direccion>)await apiServicios.ListaDirecciones(Entidad.nombre);
                
                RefreshList();
                this.IsRefreshing = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("NO SE PUDO TOMAR LOS DATOSSSSSSS : " + e.Message);
            }

        }

        private Entidad entidades( int vista)
        {
           
            return new Entidad
            {
                
                id = Entidad.id,
                foto = Entidad.foto,
                nombre = Entidad.nombre,
                pagWeb = Entidad.pagWeb,
                descripcion = Entidad.descripcion,
                descripcionEng = Entidad.descripcionEng,
                telefono = Entidad.telefono,
                categoria = Entidad.categoria,
                vistas = vista

            };
        }
        private async void EditarVistasEntidad()
        {
            try
            {
                //int vistasEntidades=vistasEntidades+1;
                Contador = Entidad.vistas + 1;

            Entidad entidadV=this.entidades(Contador);

                 await apiServicios.UpdateEntidad(entidadV);
            }
            catch (Exception e)
            {
                Console.WriteLine("NO SE PUDO TOMAR LA CANTIDAD DE VISTAS : " + e.Message);
            }
        }

        //comandos por ejecular al hacer click..
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadDirecciones);
            }
        }

        
        public ICommand EjecutarCantidadVistas
        {
            get
            {
                return new RelayCommand(EditarVistasEntidad);
            }
        }
        
        
      /*  public ICommand MapaCommand2
        {
            get
            {
                return new RelayCommand(IrMapa2);
            }
        }

        private async void IrMapa2()
        {
            //   VistaPrincipal.GetInstancia().DetalleSucursales = new DetalleSucursalVModelo(this);
            await Application.Current.MainPage.Navigation.PushAsync(new MapAppPage2(latitud2, longitud2, calle1));

        }*/

    }
}
