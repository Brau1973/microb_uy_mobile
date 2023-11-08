namespace microb_uy_mobile.Pages.Integrations;

public partial class IntegrationsTabMenu : TabbedPage
{
	public IntegrationsTabMenu()
	{
		InitializeComponent();
        // Ocultar completamente la barra de navegación en la página de inicio
        NavigationPage.SetHasNavigationBar(this, false);
    }
}