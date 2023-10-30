using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages;
using microb_uy_mobile.ViewModels;
using Refit;

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
            List<DefaultReponseDTO> BindingContext;
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
            // Creamos un restservice que implemente la interfaz declarada
            var api = RestService.For<IInstanciaService>("https://10.0.2.2:5001");
            var instancias = await api.GetInstanciasAsync();
            this.BindingContext = instancias;
            base.OnAppearing();
        }
    }
}
