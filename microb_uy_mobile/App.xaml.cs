using microb_uy_mobile.DTOs;

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
                {"LoggedUserEmail", ""},
                {"UserToken", ""},
                {"IntegratedTenant", new IntegracionDto()}
	        };

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}