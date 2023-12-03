using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages.BasePages;
using microb_uy_mobile.Services.Interfaces;

namespace microb_uy_mobile.Pages.Integrations.SearchPages;

public partial class IntegrationsSearchPostsPage : BaseSearchPostsPage
{
	public IntegrationsSearchPostsPage()
	{
		InitializeComponent();
        // Ocultar completamente la barra de navegación
        NavigationPage.SetHasNavigationBar(this, false);
    }

    public override void OnSearchButtonPressed(object sender, EventArgs e)
    {
        string searchText = base.CloseKeyboardAndGetSearchText();
        DisplayAlert("Integrations instancia Search posts SearchBar", "Buscando " + searchText, "OK");

        // Aquí puedes agregar la lógica de búsqueda con el texto ingresado

        // Por ejemplo, podrías actualizar la CollectionView con nuevos resultados de búsqueda
        // searchResultsCollectionView.ItemsSource = PerformSearch(searchText);
    }
    public override async void OnPostItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is PostDTOOld selectedPost)
        {
            //TODO Hacer Herencia para esta pagina, una para main tenant y otro para integrada
            await Navigation.PushAsync(new PostDetailPage(selectedPost)); // Pasa el post seleccionado a la página de detalles
        }
        // Desmarca el elemento seleccionado
        ((CollectionView)sender).SelectedItem = null;
    }
    public override async void OnReplyIconTapped(object sender, EventArgs e)
    {
        var image = (Image)sender;

        // Obtén el contexto (en este caso, el objeto vinculado al elemento del CollectionView)
        if (image.BindingContext is PostDTOOld selectedPost)
        {
            // Crear una nueva página para el modal
            var newReplyPage = new NewReplyPage(selectedPost); //Clase hija de BaseNewReplyPage

            // Mostrar la página como un modal
            await Navigation.PushModalAsync(newReplyPage);
        }
    }

    public override void OnRetweetIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Integrations instancia Search posts", "Retweet", "OK");
        // Lógica para manejar el retweet
    }

    public override void OnLikeIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Integrations instancia Search posts", "Like", "OK");
        // Lógica para manejar el "Me gusta"
    }
}