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

            await Navigation.PushAsync(new LoginPage(Handler.MauiContext.Services.GetRequiredService<ISessionInfoService>(), selectedInstance));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.GetInstances();
        }

        private void LoadSampleInstances()
        {
            InstancesCollectionView.ItemsSource = new List<TenantDto>
            {
                new TenantDto(1, "Instancia 1", "https://example.com/instancia1", null, "#FF5733", "Registro 1", true),
                new TenantDto(2, "Instancia 2", "https://example.com/instancia2", null, "#3366FF", "Registro 2", true),
                new TenantDto(3, "Instancia 3", "https://example.com/instancia3", null, "#33FF33", "Registro 3", true),
                new TenantDto(4, "Instancia 4", "https://example.com/instancia4", null, "#FF5733", "Registro 1", false),
                new TenantDto(5, "Instancia 5", "https://example.com/instancia5", null, "#3366FF", "Registro 2", true),
                new TenantDto(6, "Instancia 6", "https://example.com/instancia6", null, "#33FF33", "Registro 3", false),
                new TenantDto(7, "Instancia 7", "https://example.com/instancia7", null, "#FF5733", "Registro 1", true),
                new TenantDto(8, "Instancia 8", "https://example.com/instancia8", null, "#3366FF", "Registro 2", false)
            };
        }
    }
}
