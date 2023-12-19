using microb_uy_mobile.DTOs;
using microb_uy_mobile.ViewModels;

namespace microb_uy_mobile.Pages.MainTenant;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();

        // Ocultar completamente la barra de navegación
        NavigationPage.SetHasNavigationBar(this, false);

        // Asigna el modelo de vista como contexto de datos para la página
        BindingContext = new HomePageViewModel();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Obtiene el ViewModel desde el BindingContext
        if (BindingContext is HomePageViewModel viewModel)
        {
            // Llama al método que necesitas del ViewModel
            await viewModel.GetPostList();
        }
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
            await Navigation.PushAsync(new PostDetailPage(selectedPost)); // Pasa el post seleccionado a la página de detalles
        }
        // Desmarca el elemento seleccionado
        ((CollectionView)sender).SelectedItem = null;
    }

    public async void OnReplyIconTapped(object sender, EventArgs e)
    {
        var image = (Image)sender;

        // Obtén el contexto (en este caso, el objeto vinculado al elemento del CollectionView)
        if (image.BindingContext is PostDto selectedPost)
        {
            // Crear una nueva página para el modal
            var newReplyPage = new NewReplyPage(selectedPost);

            // Mostrar la página como un modal
            await Navigation.PushModalAsync(newReplyPage);
            //await Navigation.PushAsync(new BaseNewReplyPage(selectedPost));
        }
    }
    public async void OnRetweetIconTapped(object sender, EventArgs e)
    {
        var image = (Image)sender;

        // Obtén el contexto (en este caso, el objeto vinculado al elemento del CollectionView)
        if (image.BindingContext is PostDto selectedPost)
        {
            // Crear una nueva página para el modal
            var newRepostPage = new NewRepostPage(selectedPost);

            // Mostrar la página como un modal
            await Navigation.PushModalAsync(newRepostPage);
            //await Navigation.PushAsync(new BaseNewReplyPage(selectedPost));
        }
    }

    public async void OnLikeIconTapped(object sender, EventArgs e)
    {
        if (sender is Image image && image.BindingContext is PostDto post)
        {
            var viewModel = BindingContext as HomePageViewModel;
            if (viewModel != null)
            {
                if (post.Likeado)
                {
                    await viewModel.RemoveLike(post);
                }
                else
                {
                    await viewModel.GiveLike(post);
                }

                // Refresca el post específico en la lista
                int index = viewModel.PostList.IndexOf(post);
                if (index != -1)
                {
                    viewModel.PostList[index] = post;
                }
            }
        }
    }

    public async void OnFeatherIconTapped(object sender, EventArgs e)
    {
        // Crear una nueva página para el modal
        var newPostPage = new NewPostPage();

        // Mostrar la página como un modal
        await Navigation.PushModalAsync(newPostPage);
    }
}