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

        // Aqu� puedes agregar la l�gica de b�squeda con el texto ingresado

        // Por ejemplo, podr�as actualizar la CollectionView con nuevos resultados de b�squeda
        // searchResultsCollectionView.ItemsSource = PerformSearch(searchText);
    }
}