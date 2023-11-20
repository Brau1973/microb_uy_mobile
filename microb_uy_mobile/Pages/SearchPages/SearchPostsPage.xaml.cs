using microb_uy_mobile.Pages.BasePages;

namespace microb_uy_mobile.Pages.SearchPages;

public partial class SearchPostsPage : BaseSearchPostsPage
{
	public SearchPostsPage()
	{
		InitializeComponent();
	}

    public override void OnSearchButtonPressed(object sender, EventArgs e)
    {
        string searchText = base.CloseKeyboardAndGetSearchText();
        DisplayAlert("MAIN instancia Search posts SearchBar", "Buscando " + searchText, "OK");

        // Aquí puedes agregar la lógica de búsqueda con el texto ingresado

        // Por ejemplo, podrías actualizar la CollectionView con nuevos resultados de búsqueda
        // searchResultsCollectionView.ItemsSource = PerformSearch(searchText);
    }
    public override async void OnPostContentTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PostDetailPage());
    }
    public override void OnReplyIconTapped(object sender, EventArgs e)
    {
        // Lógica para manejar la respuesta al post
        DisplayAlert("MAIN instancia Search posts", "Responder al post", "OK");
    }

    public override void OnRetweetIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("MAIN instancia Search posts", "Retweet", "OK");
        // Lógica para manejar el retweet
    }

    public override void OnLikeIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("MAIN instancia Search posts", "Like", "OK");
        // Lógica para manejar el "Me gusta"
    }
}