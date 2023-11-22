using microb_uy_mobile.DTOs;
using microb_uy_mobile.Services;
using microb_uy_mobile.Services.Interfaces;
using Refit;

namespace microb_uy_mobile.Pages
{
    public partial class LoginPage : ContentPage
    {
        private InstanceDTO SelectedInstance {  get; set; }

        private readonly ISessionInfoService _sessionInfoService;
        public LoginPage(ISessionInfoService sessionInfoService, InstanceDTO selectedInstance)
        {
            InitializeComponent();

            _sessionInfoService = sessionInfoService;
            this.SelectedInstance = selectedInstance;

            loadingIndicator.IsRunning = false;
            loadingIndicator.IsVisible = false;
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Acceder a la propiedad Text de los Entry
            string email = emailEntry.Text.Trim();
            string password = passwordEntry.Text.Trim();
            int tenantid = this.SelectedInstance.Id;
            try
            {
                var api = RestService.For<ILoginService>("https://backoffice.web.microb-uy.lat"); //http://10.0.2.2:5067
                var userToken = await api.InternalLogin(email, tenantid, password);

                if (userToken != "\"\"")
                {
                    // Mostrar el indicador de carga
                    loadingIndicator.IsRunning = true;
                    loadingIndicator.IsVisible = true;

                    //Guardo la informacion de la session
                    _sessionInfoService.UserToken = userToken;
                    _sessionInfoService.TenantId = tenantid;

                    await Navigation.PushAsync(new TabMenu());
                }
                else
                {
                    await DisplayAlert("Login Error", "Usuario o contraseña invalidos", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                // Manejo de errores
            }
        }

        private async void OnFacebookImageClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Info", "Facebook", "OK");
            await DisplayAlert("Instancia Seleccionada: ", $"Instancia Seleccionada: {SelectedInstance.Nombre}", "OK");
    }

        private async void OnGoogleImageClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Info", "Google", "OK");
        }
    }
}
