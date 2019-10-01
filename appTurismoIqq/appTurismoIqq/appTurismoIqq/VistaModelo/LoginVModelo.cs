﻿using appTurismoIqq.Helpers;
using appTurismoIqq.Modelo;
using appTurismoIqq.Servicios;
using appTurismoIqq.Vistas;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace appTurismoIqq.VistaModelo
{
    public class LoginVModelo : BaseVModelo
    {
        private ApiServicio apiServicio = new ApiServicio();
        private bool isRunning;
        private bool isEnabled;
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Recordar { get; set; }
        private List<Usuario> usuarios;
        public List<Usuario> Usuarios
        {
            get { return this.usuarios; }
            set { this.SetValue(ref this.usuarios, value); }

        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { this.SetValue(ref this.isRunning, value); }
        }

        public LoginVModelo()
        {
            this.apiServicio = new ApiServicio();
            this.IsEnabled = true;
            this.Recordar = true;
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
            this.IsRunning = true;
            this.IsEnabled = false;

            try
            {
               

                Usuario u = await apiServicio.listaUsuario(this.Email, this.Password);
                
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

