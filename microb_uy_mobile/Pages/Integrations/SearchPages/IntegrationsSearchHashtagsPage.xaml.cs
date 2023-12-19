using microb_uy_mobile.ViewModels.Integrations;

namespace microb_uy_mobile.Pages.Integrations.SearchPages;

public partial class IntegrationsSearchHashtagsPage : ContentPage
{
	public IntegrationsSearchHashtagsPage()
	{
		InitializeComponent();
        // Ocultar completamente la barra de navegaci�n
        NavigationPage.SetHasNavigationBar(this, false);

        BindingContext = new IntegrationsSearchHashtagsViewModel();
    }
}