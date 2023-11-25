using microb_uy_mobile.ViewModels;

namespace microb_uy_mobile.Pages
{
    public partial class NotificationsSettingsPage : ContentPage
    {
        public NotificationsSettingsPage()
        {
            InitializeComponent();

            // Ocultar completamente la barra de navegación
            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new NotificationsSettingsViewModel();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var viewModel = (NotificationsSettingsViewModel)BindingContext;

            // Aquí puedes guardar la configuración de notificaciones en tu lógica de usuario.
            // Puedes acceder a las propiedades del ViewModel, como viewModel.PushNotificationsEnabled, viewModel.EmailNotificationsEnabled, etc.
            // Realiza las acciones necesarias para guardar estas preferencias.

            // Muestra un mensaje de confirmación
            await DisplayAlert("Configuración Guardada", "Tu configuración de notificaciones se ha guardado con éxito.", "Aceptar");

            // Luego, puedes navegar de vuelta a la página anterior o realizar otras acciones según tu flujo de la aplicación.
        }
    }
}
