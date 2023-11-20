using microb_uy_mobile.Pages.BasePages;

namespace microb_uy_mobile.Pages.Integrations.SearchPages;

public partial class IntegrationsSearchHashtagsPage : BaseSearchHashtagsPage
{
	public IntegrationsSearchHashtagsPage()
	{
		InitializeComponent();
        // Ocultar completamente la barra de navegaci�n
        NavigationPage.SetHasNavigationBar(this, false);
    }

    public override void OnSearchButtonPressed(object sender, EventArgs e)
    {
        string searchText = base.CloseKeyboardAndGetSearchText();
        DisplayAlert("Integrations instancia Search HASHTAGS SearchBar", "Buscando " + searchText, "OK");

        // Aqu� puedes agregar la l�gica de b�squeda con el texto ingresado

        // Por ejemplo, podr�as actualizar la CollectionView con nuevos resultados de b�squeda
        // searchResultsCollectionView.ItemsSource = PerformSearch(searchText);
    }
}