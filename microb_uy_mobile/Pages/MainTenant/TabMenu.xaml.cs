namespace microb_uy_mobile.Pages;

public partial class TabMenu : TabbedPage
{
	public TabMenu()
	{
		InitializeComponent();
        // Ocultar completamente la barra de navegación en la página de inicio
        NavigationPage.SetHasNavigationBar(this, false);
    }
}