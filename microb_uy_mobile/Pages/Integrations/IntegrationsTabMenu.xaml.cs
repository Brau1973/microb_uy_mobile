using microb_uy_mobile.DTOs;

namespace microb_uy_mobile.Pages.Integrations;

public partial class IntegrationsTabMenu : TabbedPage
{
	public IntegrationsTabMenu()
	{
		InitializeComponent();
        // Ocultar completamente la barra de navegaci�n en la p�gina de inicio
        NavigationPage.SetHasNavigationBar(this, false);

        IntegracionDto integratedTenant = (IntegracionDto)App.SessionInfo["IntegratedTenant"];

    }
}