using microb_uy_mobile.DTOs;

namespace microb_uy_mobile.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();

        // Ocultar completamente la barra de navegación
        NavigationPage.SetHasNavigationBar(this, false);

        // Instancia el modelo de vista
        HomePageViewModel viewModel = new HomePageViewModel();

        // Asigna el modelo de vista como contexto de datos para la página
        this.BindingContext = viewModel;
    }

    private async void OnPostContentTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PostDetailPage());
    }


    private void OnRetweetIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Info", "Retweet", "OK");
        // Lógica para manejar el retweet
    }

    private void OnLikeIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Info", "Like", "OK");
        // Lógica para manejar el "Me gusta"
    }

    private async void OnFeatherIconTapped(object sender, EventArgs e)
    {
        // Crear una nueva página para el modal
        var newPostPage = new NewPostPage();

        // Mostrar la página como un modal
        await Navigation.PushModalAsync(newPostPage);
    }
    

}