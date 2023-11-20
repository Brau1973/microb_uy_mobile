namespace microb_uy_mobile.Pages.BasePages;

public partial class BaseSearchPostsPage : ContentPage
{
    public BaseSearchPostsPage()
	{
		InitializeComponent();

        // Instancia el modelo de vista
        HomePageViewModel viewModel = new();

        // Asigna el modelo de vista como contexto de datos para la página
        this.BindingContext = viewModel;
    }

    public string CloseKeyboardAndGetSearchText()
    {
        // Cerrar el teclado
        _searchBar.Unfocus();
        // Obtener el texto ingresado en el SearchBar
        string searchText = _searchBar.Text;
        return searchText;
    }
    public virtual void OnSearchButtonPressed(object sender, EventArgs e)
    {
        //SE COMPLETA EN CLASE HIJA
    }

    public virtual async void OnPostContentTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PostDetailPage());
    }
    public virtual void OnReplyIconTapped(object sender, EventArgs e)
    {
        // Lógica para manejar la respuesta al post
        DisplayAlert("Info", "Responder al post", "OK");
    }

    public virtual void OnRetweetIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Info", "Retweet", "OK");
        // Lógica para manejar el retweet
    }

    public virtual void OnLikeIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Info", "Like", "OK");
        // Lógica para manejar el "Me gusta"
    }
}