using microb_uy_mobile.Pages;

namespace microb_uy_mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}