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
            // Aqu� debes implementar la l�gica de autenticaci�n real.
            // Puedes realizar la autenticaci�n contra un servicio o API.
            // Si la autenticaci�n es exitosa, puedes navegar a la siguiente p�gina.
            // Si la autenticaci�n falla, muestra un mensaje de error.

            // Ejemplo de autenticaci�n (simplificado):
            if (string.IsNullOrWhiteSpace(usernameEntry.Text) || string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await DisplayAlert("Error", "Nombre de usuario y contrase�a son obligatorios", "OK");
            }
            else
            {
                // Autenticaci�n exitosa
                // Aqu�, navega a la p�gina principal de la aplicaci�n
                await Navigation.PushAsync(new TabMenu());
            }
        }

        private async void OnFacebookImageClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Info", "Facebook", "OK");
            // Manejar el evento Tapped de la imagen de Facebook
            // Navegar a la p�gina de autenticaci�n de Facebook
            //await Navigation.PushAsync(new FacebookAuthPage());
        }

        private async void OnGoogleImageClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Info", "Google", "OK");
            // Manejar el evento Tapped de la imagen de Google
            // Navegar a la p�gina de autenticaci�n de Google
            //await Navigation.PushAsync(new GoogleAuthPage());
        }

        //private void OnSignUpClicked(object sender, EventArgs e)
        //{
        //   // Navegar a la p�gina de registro (SignUpPage)
        //    Navigation.PushAsync(new SignUpPage());
        //}

    }
}
