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

            // Validación básica: Comprueba si los campos no están vacíos
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                DisplayAlert("Error", "Por favor, completa todos los campos.", "Aceptar");
            }
            else
            {
                // En una implementación real, aquí registrarías al usuario en tu sistema.
                // Puedes llamar a un servicio de registro o realizar otras acciones según tus necesidades.

                // Después de un registro exitoso, puedes navegar a otra página, como la página de inicio.

                // Por ejemplo:
                // await Navigation.PushAsync(new HomePage());
            }
        }

        private void OnLoginLinkClicked(object sender, EventArgs e)
        {
            // Navegar a la página de inicio de sesión (LoginPage)
            Navigation.PushAsync(new LoginPage());
        }
    }
}
