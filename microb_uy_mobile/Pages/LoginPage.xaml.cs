using microb_uy_mobile.DTOs;
using microb_uy_mobile.Services;
using Refit;

namespace microb_uy_mobile.Pages
{
    public partial class LoginPage : ContentPage
    {
        private InstanceDTO SelectedInstance {  get; set; }
        public LoginPage(InstanceDTO selectedInstance)
        {
            InitializeComponent();

            this.SelectedInstance = selectedInstance;

            loadingIndicator.IsRunning = false;
            loadingIndicator.IsVisible = false;
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Acceder a la propiedad Text de los Entry
            string email = emailEntry.Text;
            string password = passwordEntry.Text;
            try
            {
                var api = RestService.For<ILoginService>("http://10.0.2.2:5067");
                var userToken = await api.InternalLogin(email, this.SelectedInstance.Id, password);

                if (userToken != "")
                {
                    // Mostrar el indicador de carga
                    loadingIndicator.IsRunning = true;
                    loadingIndicator.IsVisible = true;

                    await Navigation.PushAsync(new TabMenu());
                }
                else
                {
                    await DisplayAlert("Login Error", "Login Error", "OK");
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
        // Manejar el evento Tapped de la imagen de Facebook
        // Navegar a la página de autenticación de Facebook
        //await Navigation.PushAsync(new FacebookAuthPage());
    }

        private async void OnGoogleImageClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Info", "Google", "OK");
            // Manejar el evento Tapped de la imagen de Google
            // Navegar a la página de autenticación de Google
            //await Navigation.PushAsync(new GoogleAuthPage());
        }

        //private void OnSignUpClicked(object sender, EventArgs e)
        //{
        //   // Navegar a la página de registro (SignUpPage)
        //    Navigation.PushAsync(new SignUpPage());
        //}

    }
}
