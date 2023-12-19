using microb_uy_mobile.DTOs;
using microb_uy_mobile.Helpers;
using microb_uy_mobile.Services;
using microb_uy_mobile.Services.Interfaces;
using Newtonsoft.Json.Linq;
using Refit;

namespace microb_uy_mobile.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly string BaseApiUrl = (string)App.SessionInfo["BaseUrl"];
        private TenantDto SelectedInstance {  get; set; }

        public LoginPage(TenantDto selectedInstance)
        {
            InitializeComponent();

            this.SelectedInstance = selectedInstance;

            ShowLoadingIndicator(false);
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            ShowLoadingIndicator(true);

            string email = emailEntry.Text?.Trim();
            string password = passwordEntry.Text?.Trim();
            int tenantid = this.SelectedInstance.Id;
            var LoggedUserId = 0;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Por favor, ingresa tu email y contraseña.", "OK");
                ShowLoadingIndicator(false);
                return;
            }

            try
            {
                var api = RestService.For<ILoginService>(BaseApiUrl);
                var internalLoginResponse = await api.InternalLogin(email, tenantid, password);

                if (internalLoginResponse.Success == true)
                {
                    var userToken = internalLoginResponse.Token;

                    try
                    {
                        var apiUsuarios = RestService.For<IUsuariosService>(BaseApiUrl);
                        var getUsuarioMailResponse = await apiUsuarios.GetUsuarioMail(email, tenantid);
                        LoggedUserId = getUsuarioMailResponse.Id;
                    } 
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: " + ex.ToString());
                        await DisplayAlert("Login Error", "Error en Login, vuelve a intentarlo mas tarde", "OK");
                    }

                    //Guardo la informacion de la session
                    App.SessionInfo["UserToken"] = userToken;
                    App.SessionInfo["MainTenantId"] = tenantid;
                    App.SessionInfo["LoggedUserId"] = LoggedUserId;
                    App.SessionInfo["LoggedUserEmail"] = email;

                    //var decodedToken = JwtUtils.DecodeJwtToken(userToken);

                    await Navigation.PushAsync(new TabMenu());

                    ShowLoadingIndicator(false);
                }
                else
                {
                    await DisplayAlert("Login Error", "Usuario o contraseña invalidos", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                await DisplayAlert("Login Error", "Error en Login, vuelve a intentarlo mas tarde", "OK");
            }
            ShowLoadingIndicator(false);
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

        private void ShowLoadingIndicator(bool visible)
        {
            // Mostrar el indicador de carga o no
            loadingIndicator.IsRunning = visible;
            loadingIndicator.IsVisible = visible;
        }
    }
}
