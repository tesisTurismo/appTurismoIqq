using appTurismoIqq.Modelo;
using appTurismoIqq.Servicios;
using appTurismoIqq.Vistas;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace appTurismoIqq.VistaModelo
{
    public class DetalleDireccionItemVModel:Direccion
    {
        
        public ICommand DetalleDireccionMapa
        {
            get
            {
                return new RelayCommand(IrDetalleDirecciones);
            }
        }

        private async void IrDetalleDirecciones()
        {
            VistaPrincipal.GetInstancia().Direcciones = new DetalleDireccionVModel(this);

            await Application.Current.MainPage.Navigation.PushAsync(new DetalleDirecciones());
        }
    }
}
