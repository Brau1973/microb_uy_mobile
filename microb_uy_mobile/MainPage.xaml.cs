using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages;
using microb_uy_mobile.ViewModels;

namespace microb_uy_mobile
{
    public partial class MainPage : ContentPage
    {
        public IntegrationsMainPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();
            // Ocultar completamente la barra de navegación
            NavigationPage.SetHasNavigationBar(this, false);

            ViewModel = new IntegrationsMainPageViewModel();

            BindingContext = ViewModel;
        }

        private async void OnCardTapped(object sender, EventArgs e)
        {
            // Obtener la InstanciaDTO seleccionada
            var selectedInstancia = ((Frame)sender).BindingContext as InstanceDTO;

            // Navegar a la página de inicio de sesión (LoginPage) o realizar otra acción
            // Ejemplo: await Navigation.PushAsync(new LoginPage(selectedInstancia));
            await Navigation.PushAsync(new LoginPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.GetInstances();
        }
    }
}
