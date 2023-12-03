using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages.BasePages;
using microb_uy_mobile.Services.Interfaces;

namespace microb_uy_mobile.Pages;

public partial class HomePage : BaseHomePage
{
    public HomePage()
    {
        InitializeComponent();

        // Instancia el modelo de vista
        HomePageViewModel viewModel = new();

        // Asigna el modelo de vista como contexto de datos para la página
        this.BindingContext = viewModel;
    }

    public override async void OnPostItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is PostDTOOld selectedPost)
        {
            await Navigation.PushAsync(new PostDetailPage(selectedPost)); // Pasa el post seleccionado a la página de detalles
        }
        // Desmarca el elemento seleccionado
        ((CollectionView)sender).SelectedItem = null;
    }

    // Sobrescribe el evento OnReplyIconTapped
    public override async void OnReplyIconTapped(object sender, EventArgs e)
    {
        var image = (Image)sender;

        // Obtén el contexto (en este caso, el objeto vinculado al elemento del CollectionView)
        if (image.BindingContext is PostDTOOld selectedPost)
        {
            // Crear una nueva página para el modal
            var newReplyPage = new NewReplyPage(selectedPost);

            // Mostrar la página como un modal
            await Navigation.PushModalAsync(newReplyPage);
            //await Navigation.PushAsync(new BaseNewReplyPage(selectedPost));
        }
    }

    // Sobrescribe el evento OnRetweetIconTapped
    public override void OnRetweetIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Main", "Llamo a la api de mi instancia principal " + "Retweet", "OK");
        // Lógica para manejar el retweet
    }

    // Sobrescribe el evento OnLikeIconTapped
    public override void OnLikeIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Main", "Llamo a la api de mi instancia principal " + "Like", "OK");
        // Lógica para manejar el "Me gusta"
    }

    public override async void OnFeatherIconTapped(object sender, EventArgs e)
    {
        // Crear una nueva página para el modal
        var newPostPage = new NewPostPage();

        // Mostrar la página como un modal
        await Navigation.PushModalAsync(newPostPage);
    }
}