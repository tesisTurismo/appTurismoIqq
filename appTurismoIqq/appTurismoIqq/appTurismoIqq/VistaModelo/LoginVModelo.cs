using appTurismoIqq.Servicios;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace appTurismoIqq.VistaModelo
{
    public class LoginVModelo: BaseVModelo
    {
        private ApiServicio apiServicio; 
        private bool isRunning;
        private bool isEnabled;
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Recordar { get; set; }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { this.SetValue(ref this.isRunning, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }

        public LoginVModelo()
        {
            this.IsEnabled = true;
            this.Recordar = true;
        }
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);

            }
        }

        private async void Login()
        {
            if (String.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar su email",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar su contraseña",
                    "Aceptar");
                return;
            }

        }


    }
}
