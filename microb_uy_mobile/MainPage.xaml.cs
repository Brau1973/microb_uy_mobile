using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages;
using microb_uy_mobile.ViewModels;
using Refit;
using System.Net.Http;

namespace microb_uy_mobile
{
    public partial class MainPage : ContentPage
    {
        internal MainPageViewModel ViewModel { get; set; }
        public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:5001" : "https://localhost:44384";

        public MainPage()
        {
            InitializeComponent();
            // Ocultar completamente la barra de navegación
            NavigationPage.SetHasNavigationBar(this, false);

            ViewModel = new MainPageViewModel();
            //BindingContext = ViewModel;
            List<DefaultResponseDTO> BindingContext;
        }

        private async void OnCardTapped(object sender, EventArgs e)
        {
            // Obtener la InstanciaDTO seleccionada
            var selectedInstancia = ((Frame)sender).BindingContext as InstanciaDTO;

            //if (selectedInstancia != null)
            //{
                // Navegar a la página de inicio de sesión (LoginPage) o realizar otra acción
                // Ejemplo: await Navigation.PushAsync(new LoginPage(selectedInstancia));
                await Navigation.PushAsync(new LoginPage());
            //}
        }

        protected override async void OnAppearing()
        {

            try
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
                };

                string HTTP = "http://10.0.2.2:5067";
                string HTTPS = "https://10.0.2.2:7181";

                var httpclient = new HttpClient(handler)
                { 
                    BaseAddress = new Uri(HTTP) 
                };

            // Creamos un restservice que implemente la interfaz declarada
                var api = RestService.For<IInstanciaService>(httpclient);
                var instancias = await api.GetInstanciasAsync();
                Console.WriteLine("volvi de la api ");
                this.BindingContext = instancias;
                base.OnAppearing();
            }
            catch (Exception ex)
            {
                // Aquí manejas la excepción
                Console.WriteLine("Error al obtener los datos: " + ex.Message);
                // Puedes mostrar un mensaje de error al usuario si es necesario.
            }

        }
    }
}
