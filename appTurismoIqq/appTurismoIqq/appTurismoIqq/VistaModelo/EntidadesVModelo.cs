using appTurismoIqq.Modelo;
using appTurismoIqq.Servicios;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace appTurismoIqq.VistaModelo
{
    public class EntidadesVModelo : BaseVModelo
    {
        ApiServicio Entidades;
        bool rpta=false;
        public bool Rpta{
            get { return this.rpta; }
            set { this.SetValue(ref this.rpta, value); }
        }
        private List<Entidad> listaentidades;
        public List<Entidad> Listaentidades
        {
            get { return this.listaentidades; }
            set { this.SetValue(ref this.listaentidades,value); }

        }
        /*public ICommand RefreshCommand
        {
            get;
        }*/

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadEntidades);
            }
        }
        public string prueba { get; set; }
       

        public EntidadesVModelo()
        {
            Entidades = new ApiServicio();
            rpta = false;
            prueba = "holaaa";

            LoadEntidades();

            //RefreshCommand = new Command(async () => await ExecuteRefreshCommand());

        }
        /*
       async Task ExecuteRefreshCommand()
        {
            if (rpta)
                return;

            rpta = true;

            try
            {
                var mongoService = new ApiServicio();
                Listaentidades = await mongoService.listaEntidades();
            }
            finally
            {
                rpta = false;
            }
        }
       */
        private async void LoadEntidades()
        {
            try
            {
                var mongoService = new ApiServicio();
                Listaentidades = await mongoService.listaEntidades();
            }
            catch (Exception e)
            {
                Console.WriteLine("NO SE PUDO TOMAR LOS DATOSSSSSSS : " + e.Message);
            }
            
        }
        /*
        public async void mostrarentidades()
        {
            try
            {
               // Entidades.coleccionSeleccionada = "entidad";
                Listaentidades = await Entidades.Coleccion.Find(new BsonDocument()).ToListAsync();
                return ;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("No se pudo capturar los datos : "+e.Message);

            }
            return ;
        }
        */
        
    }
}
