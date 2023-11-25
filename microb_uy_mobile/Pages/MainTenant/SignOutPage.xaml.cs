using microb_uy_mobile.Services.Interfaces;
using Microsoft.Maui.Controls;

namespace microb_uy_mobile.Pages
{
    public partial class SignOutPage : ContentPage
    {
        public SignOutPage()
        {
            InitializeComponent();

            // Ocultar completamente la barra de navegaci�n
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void OnSignOutButtonClicked(object sender, EventArgs e)
        {
            ISessionInfoService _sessionInfoService = Handler.MauiContext.Services.GetRequiredService<ISessionInfoService>();
            //Reset datos de session
            _sessionInfoService.UserToken = null;
            _sessionInfoService.UserId = 0;
            _sessionInfoService.TenantId = 0;
            _sessionInfoService.IntegratedTenantId = 0;

            await Navigation.PushAsync(new MainPage());
        }
    }
}
