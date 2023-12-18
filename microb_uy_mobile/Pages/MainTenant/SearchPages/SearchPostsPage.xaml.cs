using microb_uy_mobile.DTOs;
using microb_uy_mobile.ViewModels;

namespace microb_uy_mobile.Pages.MainTenant.SearchPages;

public partial class SearchPostsPage : ContentPage
{
	public SearchPostsPage()
	{
		InitializeComponent();

        // Instancia el modelo de vista
        SearchPostsPageViewModel viewModel = new();

        // Asigna el modelo de vista como contexto de datos para la página
        this.BindingContext = viewModel;
    }

    public void OnSearchButtonPressed(object sender, EventArgs e)
    {
        //string searchText = base.CloseKeyboardAndGetSearchText();
        //DisplayAlert("MAIN instancia Search posts SearchBar", "Buscando " + searchText, "OK");

        // Aquí puedes agregar la lógica de búsqueda con el texto ingresado

        // Por ejemplo, podrías actualizar la CollectionView con nuevos resultados de búsqueda
        // searchResultsCollectionView.ItemsSource = PerformSearch(searchText);
    }
    public async void OnPostItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is PostDto selectedPost)
        {
            //TODO Hacer Herencia para esta pagina, una para main tenant y otro para integrada
            await Navigation.PushAsync(new PostDetailPage(selectedPost)); // Pasa el post seleccionado a la página de detalles
        }
        // Desmarca el elemento seleccionado
        ((CollectionView)sender).SelectedItem = null;
    }
    public async void OnReplyIconTapped(object sender, EventArgs e)
    {
        //ISessionInfoService _sessionInfoService = Handler.MauiContext.Services.GetRequiredService<ISessionInfoService>();
        var image = (Image)sender;

        // Obtén el contexto (en este caso, el objeto vinculado al elemento del CollectionView)
        if (image.BindingContext is PostDto selectedPost)
        {
            // Crear una nueva página para el modal
            var newReplyPage = new NewReplyPage(selectedPost); //Clase hija de BaseNewReplyPage

            // Mostrar la página como un modal
            await Navigation.PushModalAsync(newReplyPage);
        }
    }

    public void OnRetweetIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("MAIN instancia Search posts", "Retweet", "OK");
        // Lógica para manejar el retweet
    }

    public void OnLikeIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("MAIN instancia Search posts", "Like", "OK");
        // Lógica para manejar el "Me gusta"
    }
}