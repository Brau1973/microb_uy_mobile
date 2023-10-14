using Microsoft.Maui.Controls;

namespace microb_uy_mobile.Pages
{
    public partial class SignOutPage : ContentPage
    {
        public SignOutPage()
        {
            InitializeComponent();

            // Ocultar completamente la barra de navegaci�n en la p�gina de inicio
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void OnSignOutButtonClicked(object sender, EventArgs e)
        {
            // Aqu� puedes agregar la l�gica para cerrar la sesi�n del usuario
            // Esto podr�a incluir la eliminaci�n de tokens de autenticaci�n, restablecimiento de variables de sesi�n, etc.

            // Luego, puedes navegar de vuelta a la p�gina de inicio o a la p�gina de login, seg�n tu flujo de la aplicaci�n.
            await Navigation.PushAsync(new MainPage());
        }
    }
}
