using microb_uy_mobile.DTOs;
using microb_uy_mobile.ViewModels;

namespace microb_uy_mobile.Pages.MainTenant;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();

        // Ocultar completamente la barra de navegaci�n
        NavigationPage.SetHasNavigationBar(this, false);

        // Asigna el modelo de vista como contexto de datos para la p�gina
        BindingContext = new HomePageViewModel();
    }

    private async void OnRefreshIconTapped(object sender, EventArgs e)
    {
        var viewModel = BindingContext as HomePageViewModel;
        if (viewModel != null)
        {
            viewModel.IsBusy = true; // Opcional, para mostrar el indicador de carga
            await viewModel.GetPostList();
            viewModel.IsBusy = false;
        }
    }
    public async void OnPostItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is PostDto selectedPost)
        {
            await Navigation.PushAsync(new PostDetailPage(selectedPost)); // Pasa el post seleccionado a la p�gina de detalles
        }
        // Desmarca el elemento seleccionado
        ((CollectionView)sender).SelectedItem = null;
    }

    public async void OnReplyIconTapped(object sender, EventArgs e)
    {
        var image = (Image)sender;

        // Obt�n el contexto (en este caso, el objeto vinculado al elemento del CollectionView)
        if (image.BindingContext is PostDto selectedPost)
        {
            // Crear una nueva p�gina para el modal
            var newReplyPage = new NewReplyPage(selectedPost);

            // Mostrar la p�gina como un modal
            await Navigation.PushModalAsync(newReplyPage);
            //await Navigation.PushAsync(new BaseNewReplyPage(selectedPost));
        }
    }
    public void OnRetweetIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Main", "Llamo a la api de mi instancia principal " + "Retweet", "OK");
        // L�gica para manejar el retweet
    }

    public void OnLikeIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Main", "Llamo a la api de mi instancia principal " + "Like", "OK");
        // L�gica para manejar el "Me gusta"
    }

    public async void OnFeatherIconTapped(object sender, EventArgs e)
    {
        // Crear una nueva p�gina para el modal
        var newPostPage = new NewPostPage();

        // Mostrar la p�gina como un modal
        await Navigation.PushModalAsync(newPostPage);
    }
}