namespace microb_uy_mobile.Pages;

public partial class TabMenu : TabbedPage
{
	public TabMenu()
	{
		InitializeComponent();
        // Ocultar completamente la barra de navegaci�n en la p�gina de inicio
        NavigationPage.SetHasNavigationBar(this, false);
    }
}