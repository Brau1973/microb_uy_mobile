using microb_uy_mobile;
using Microsoft.Maui.Controls;

namespace microb_uy_mobile.Pages
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void OnSignUpClicked(object sender, EventArgs e)
        {
            // Obtener los valores de los campos de entrada
            string fullName = fullNameEntry.Text;
            string username = usernameEntry.Text;
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            // Validaci�n b�sica: Comprueba si los campos no est�n vac�os
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                DisplayAlert("Error", "Por favor, completa todos los campos.", "Aceptar");
            }
            else
            {
                // En una implementaci�n real, aqu� registrar�as al usuario en tu sistema.
                // Puedes llamar a un servicio de registro o realizar otras acciones seg�n tus necesidades.

                // Despu�s de un registro exitoso, puedes navegar a otra p�gina, como la p�gina de inicio.

                // Por ejemplo:
                // await Navigation.PushAsync(new HomePage());
            }
        }

        private void OnLoginLinkClicked(object sender, EventArgs e)
        {
            // Navegar a la p�gina de inicio de sesi�n (LoginPage)
            Navigation.PushAsync(new LoginPage());
        }
    }
}
