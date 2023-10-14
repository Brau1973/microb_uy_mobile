using Microsoft.Maui.Controls;

namespace microb_uy_mobile.Pages
{
    public partial class SignOutPage : ContentPage
    {
        public SignOutPage()
        {
            InitializeComponent();

            // Ocultar completamente la barra de navegación en la página de inicio
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void OnSignOutButtonClicked(object sender, EventArgs e)
        {
            // Aquí puedes agregar la lógica para cerrar la sesión del usuario
            // Esto podría incluir la eliminación de tokens de autenticación, restablecimiento de variables de sesión, etc.

            // Luego, puedes navegar de vuelta a la página de inicio o a la página de login, según tu flujo de la aplicación.
            await Navigation.PushAsync(new MainPage());
        }
    }
}
