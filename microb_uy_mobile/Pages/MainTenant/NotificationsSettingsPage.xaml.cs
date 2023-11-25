using microb_uy_mobile.ViewModels;

namespace microb_uy_mobile.Pages
{
    public partial class NotificationsSettingsPage : ContentPage
    {
        public NotificationsSettingsPage()
        {
            InitializeComponent();

            // Ocultar completamente la barra de navegaci�n
            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new NotificationsSettingsViewModel();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var viewModel = (NotificationsSettingsViewModel)BindingContext;

            // Aqu� puedes guardar la configuraci�n de notificaciones en tu l�gica de usuario.
            // Puedes acceder a las propiedades del ViewModel, como viewModel.PushNotificationsEnabled, viewModel.EmailNotificationsEnabled, etc.
            // Realiza las acciones necesarias para guardar estas preferencias.

            // Muestra un mensaje de confirmaci�n
            await DisplayAlert("Configuraci�n Guardada", "Tu configuraci�n de notificaciones se ha guardado con �xito.", "Aceptar");

            // Luego, puedes navegar de vuelta a la p�gina anterior o realizar otras acciones seg�n tu flujo de la aplicaci�n.
        }
    }
}
