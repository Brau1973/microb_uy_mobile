using microb_uy_mobile.DTOs;
using microb_uy_mobile.Services.Interfaces;
using microb_uy_mobile.ViewModels.Integrations;

namespace microb_uy_mobile.Pages.Integrations
{
    public partial class IntegrationsMainPage : ContentPage
    {
        public IntegrationsMainPageViewModel ViewModel { get; set; }

        public IntegrationsMainPage()
        {
            InitializeComponent();

            //_sessionInfoService = Handler.MauiContext.Services.GetRequiredService<ISessionInfoService>();

            // Ocultar completamente la barra de navegación
            NavigationPage.SetHasNavigationBar(this, false);

            ViewModel = new IntegrationsMainPageViewModel();

            BindingContext = ViewModel;
        }

        private async void OnCardTapped(object sender, EventArgs e)
        {
            // Obtener la InstanciaDTO seleccionada
            var selectedInstancia = ((Frame)sender).BindingContext as TenantDto;

            // Setear info de la instancia integrada seleccionada
            ISessionInfoService _sessionInfoService = Handler.MauiContext.Services.GetRequiredService<ISessionInfoService>();
            _sessionInfoService.IntegratedTenantId = selectedInstancia.Id;

            await Navigation.PushAsync(new IntegrationsTabMenu());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.GetIntegratedInstances();
        }
    }
}
