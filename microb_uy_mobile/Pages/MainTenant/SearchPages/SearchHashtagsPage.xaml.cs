using microb_uy_mobile.Pages.BasePages;

namespace microb_uy_mobile.Pages.SearchPages;

public partial class SearchHashtagsPage : BaseSearchHashtagsPage
{
	public SearchHashtagsPage()
	{
		InitializeComponent();
	}

    public override void OnSearchButtonPressed(object sender, EventArgs e)
    {
        string searchText = base.CloseKeyboardAndGetSearchText();
        DisplayAlert("MAIN instancia Search HASHTAGS SearchBar", "Buscando " + searchText, "OK");

        // Aquí puedes agregar la lógica de búsqueda con el texto ingresado

        // Por ejemplo, podrías actualizar la CollectionView con nuevos resultados de búsqueda
        // searchResultsCollectionView.ItemsSource = PerformSearch(searchText);
    }
}