using appTurismoIqq.Helpers;
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
    public class LoginVModelo : BaseVModelo
    {
        private ApiServicio apiServicio = new ApiServicio();
        private bool isRunning;
        private bool isEnabled;
        private bool isRefreshing;
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Recordar { get; set; }
        private List<Usuario> usuarios;
        public List<Usuario> Usuarios
        {
            get { return this.usuarios; }
            set { this.SetValue(ref this.usuarios, value); }

        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

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
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(IrRegistro);
            }
        }
        private async void IrRegistro()
        {
            VistaPrincipal.GetInstancia().Registros = new RegistroVModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
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
            try
            {
                this.IsRefreshing = true;
                Usuario u = await apiServicio.listaUsuario(this.Email, this.Password);
                this.IsRefreshing = false;
                if (u != null)
                {
                    VistaPrincipal.GetInstancia().Categorias = new CategoriasVModel();
                    await Application.Current.MainPage.Navigation.PushAsync(new CategoriasPage());
                }
                if (u == null)
                {
                    await Application.Current.MainPage.DisplayAlert(
                       "Error",
                       "Email y/o Contraseña Incorrectos ",
                       "Aceptar");
                }
                Settings.IsRemembered = this.Recordar;
            }
            catch (Exception e)
            {
                Console.WriteLine("HUBO UNA EXCEPTION EN INICIO DE SESIÓN: " + e.Message);
            }




        }

        /*
        private async void LoadUsers()
        {
            try
            {
                this.IsRefreshing = true;
                // var mongoService = new ApiServicio();
                Usuarios = (List<Usuario>)await apiServicio.listaUsuario(this.Email, this.Password);
                this.IsRefreshing = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("NO SE PUDO TOMAR LOS DATOSSSSSSS : " + e.Message);
            }

        }
        */


    }
}
