using appTurismoIqq.VistaModelo;
using appTurismoIqq.Vistas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace appTurismoIqq
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var vPrincipal = VistaPrincipal.GetInstancia();
            vPrincipal.Categorias = new CategoriasVModel();
            this.MainPage = new NavigationPage(new CategoriasPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
