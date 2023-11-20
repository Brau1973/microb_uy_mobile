using microb_uy_mobile.Pages.BasePages;

namespace microb_uy_mobile.Pages.Integrations.SearchPages;

public partial class IntegrationsSearchHashtagsPage : BaseSearchHashtagsPage
{
	public IntegrationsSearchHashtagsPage()
	{
		InitializeComponent();
        // Ocultar completamente la barra de navegación
        NavigationPage.SetHasNavigationBar(this, false);
    }

    public override void OnSearchButtonPressed(object sender, EventArgs e)
    {
        string searchText = base.CloseKeyboardAndGetSearchText();
        DisplayAlert("Integrations instancia Search HASHTAGS SearchBar", "Buscando " + searchText, "OK");

        // Aquí puedes agregar la lógica de búsqueda con el texto ingresado

        // Por ejemplo, podrías actualizar la CollectionView con nuevos resultados de búsqueda
        // searchResultsCollectionView.ItemsSource = PerformSearch(searchText);
    }
}