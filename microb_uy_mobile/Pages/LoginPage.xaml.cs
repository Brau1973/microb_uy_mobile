using Microsoft.Maui.Controls;

namespace microb_uy_mobile.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Aquí debes implementar la lógica de autenticación real.
            // Puedes realizar la autenticación contra un servicio o API.
            // Si la autenticación es exitosa, puedes navegar a la siguiente página.
            // Si la autenticación falla, muestra un mensaje de error.

            // Ejemplo de autenticación (simplificado):
            if (string.IsNullOrWhiteSpace(usernameEntry.Text) || string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await DisplayAlert("Error", "Nombre de usuario y contraseña son obligatorios", "OK");
            }
            else
            {
                // Autenticación exitosa
                // Aquí, navega a la página principal de la aplicación
                await Navigation.PushAsync(new TabMenu());
            }
        }

        private async void OnFacebookImageClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Info", "Facebook", "OK");
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
