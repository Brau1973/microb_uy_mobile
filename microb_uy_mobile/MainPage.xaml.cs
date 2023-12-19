using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages;
using microb_uy_mobile.Services.Interfaces;
using microb_uy_mobile.ViewModels;

namespace microb_uy_mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();
            // Ocultar completamente la barra de navegación
            NavigationPage.SetHasNavigationBar(this, false);

            //LoadSampleInstances();

            ViewModel = new MainPageViewModel();

            BindingContext = ViewModel;
        }

        private async void OnCardTapped(object sender, EventArgs e)
        {
            // Obtener la InstanciaDTO seleccionada
            var selectedInstance = ((Frame)sender).BindingContext as TenantDto;

            await Navigation.PushAsync(new LoginPage(selectedInstance));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.GetInstances();
        }
    }
}
