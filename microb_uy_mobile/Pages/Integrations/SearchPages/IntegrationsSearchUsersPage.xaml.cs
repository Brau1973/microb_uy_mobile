using microb_uy_mobile.Pages.BasePages;

namespace microb_uy_mobile.Pages.Integrations.SearchPages;

public partial class IntegrationsSearchUsersPage : BaseSearchUsersPage
{
	public IntegrationsSearchUsersPage()
	{
		InitializeComponent();
        // Ocultar completamente la barra de navegaci�n
        NavigationPage.SetHasNavigationBar(this, false);
    }

    public override void OnSearchButtonPressed(object sender, EventArgs e)
    {
        string searchText = base.CloseKeyboardAndGetSearchText();
        DisplayAlert("Integrations instancia Search USERS SearchBar", "Buscando " + searchText, "OK");

        // Aqu� puedes agregar la l�gica de b�squeda con el texto ingresado

        // Por ejemplo, podr�as actualizar la CollectionView con nuevos resultados de b�squeda
        // searchResultsCollectionView.ItemsSource = PerformSearch(searchText);
    }
}