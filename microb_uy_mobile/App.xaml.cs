namespace microb_uy_mobile
{
    public partial class App : Application
    {
        public static Dictionary<string, object> SessionInfo { get; private set; }
        public App()
        {
            InitializeComponent();

            SessionInfo = new Dictionary<string, object>
            {
                {"BaseUrl", "https://backoffice.web.microb-uy.lat"},
                {"MainTenantId", 0},
                {"LoggedUserId", 0},
                {"LoggedUserEmail", "usuario2@email.com"},
                {"UserToken", ""},
                {"IntegratedTenantId", 0}
	            // Agrega otras configuraciones según sea necesario
	        };

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}