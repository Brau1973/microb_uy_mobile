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
            // Aquí puedes agregar la lógica para cerrar la sesión del usuario
            // Esto podría incluir la eliminación de tokens de autenticación, restablecimiento de variables de sesión, etc.

            // Luego, puedes navegar de vuelta a la página de inicio o a la página de login, según tu flujo de la aplicación.
            await Navigation.PushAsync(new TabMenu());
        }
    }
}
