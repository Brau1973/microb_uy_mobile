
namespace microb_uy_mobile.ViewModels
{
    public class NotificationsSettingsViewModel : BindableObject
    {
        private bool pushNotificationsEnabled;
        private bool emailNotificationsEnabled;
        private bool newFollowerNotificationsEnabled;
        private bool replyToPostNotificationsEnabled;

        public bool PushNotificationsEnabled
        {
            get { return pushNotificationsEnabled; }
            set
            {
                pushNotificationsEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool EmailNotificationsEnabled
        {
            get { return emailNotificationsEnabled; }
            set
            {
                emailNotificationsEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool NewFollowerNotificationsEnabled
        {
            get { return newFollowerNotificationsEnabled; }
            set
            {
                newFollowerNotificationsEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool ReplyToPostNotificationsEnabled
        {
            get { return replyToPostNotificationsEnabled; }
            set
            {
                replyToPostNotificationsEnabled = value;
                OnPropertyChanged();
            }
        }

        public NotificationsSettingsViewModel()
        {
            // Inicializar el estado de las notificaciones desde tu lógica de usuario
            PushNotificationsEnabled = true; // O cualquier valor predeterminado
            EmailNotificationsEnabled = true; // O cualquier valor predeterminado
            NewFollowerNotificationsEnabled = true; // O cualquier valor predeterminado
            ReplyToPostNotificationsEnabled = true; // O cualquier valor predeterminado
        }
    }

}
