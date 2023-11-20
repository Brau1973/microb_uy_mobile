using microb_uy_mobile.Pages.BasePages;

namespace microb_uy_mobile.Pages.Integrations.SearchPages;

public partial class IntegrationsSearchPostsPage : BaseSearchPostsPage
{
	public IntegrationsSearchPostsPage()
	{
		InitializeComponent();
        // Ocultar completamente la barra de navegaci�n
        NavigationPage.SetHasNavigationBar(this, false);
    }

    public override void OnSearchButtonPressed(object sender, EventArgs e)
    {
        string searchText = base.CloseKeyboardAndGetSearchText();
        DisplayAlert("Integrations instancia Search posts SearchBar", "Buscando " + searchText, "OK");

        // Aqu� puedes agregar la l�gica de b�squeda con el texto ingresado

        // Por ejemplo, podr�as actualizar la CollectionView con nuevos resultados de b�squeda
        // searchResultsCollectionView.ItemsSource = PerformSearch(searchText);
    }
    public override async void OnPostContentTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PostDetailPage());
    }
    public override void OnReplyIconTapped(object sender, EventArgs e)
    {
        // L�gica para manejar la respuesta al post
        DisplayAlert("Integrations instancia Search posts", "Responder al post", "OK");
    }

    public override void OnRetweetIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Integrations instancia Search posts", "Retweet", "OK");
        // L�gica para manejar el retweet
    }

    public override void OnLikeIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Integrations instancia Search posts", "Like", "OK");
        // L�gica para manejar el "Me gusta"
    }
}