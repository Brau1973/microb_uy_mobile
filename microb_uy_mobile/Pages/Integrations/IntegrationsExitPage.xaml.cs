using microb_uy_mobile.Services.Interfaces;
using Microsoft.Maui.Controls;

namespace microb_uy_mobile.Pages.Integrations
{
    public partial class IntegrationsExitPage : ContentPage
    {
        public IntegrationsExitPage()
        {
            InitializeComponent();

            // Ocultar completamente la barra de navegación
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void OnSignOutButtonClicked(object sender, EventArgs e)
        {
            //Reset datos session instancia integrada
            ISessionInfoService _sessionInfoService = Handler.MauiContext.Services.GetRequiredService<ISessionInfoService>();
            _sessionInfoService.IntegratedTenantId = 0;

            await Navigation.PushAsync(new TabMenu());
        }
    }
}
