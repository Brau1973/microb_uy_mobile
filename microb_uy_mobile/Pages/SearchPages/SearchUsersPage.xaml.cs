using microb_uy_mobile.Pages.BasePages;

namespace microb_uy_mobile.Pages.SearchPages;

public partial class SearchUsersPage : BaseSearchUsersPage
{
	public SearchUsersPage()
	{
		InitializeComponent();
	}

    public override void OnSearchButtonPressed(object sender, EventArgs e)
    {
        string searchText = base.CloseKeyboardAndGetSearchText();
        DisplayAlert("MAIN instancia Search USERS SearchBar", "Buscando " + searchText, "OK");

        // Aquí puedes agregar la lógica de búsqueda con el texto ingresado

        // Por ejemplo, podrías actualizar la CollectionView con nuevos resultados de búsqueda
        // searchResultsCollectionView.ItemsSource = PerformSearch(searchText);
    }
}