using microb_uy_mobile.DTOs;

namespace microb_uy_mobile.Pages.BasePages;

public partial class BaseHomePage : ContentPage
{
    // Propiedad virtual para controlar la visibilidad de FeatherFrame
    public virtual bool IsFeatherFrameVisible
    {
        get => FeatherFrame.IsVisible;
        set => FeatherFrame.IsVisible = value;
    }
    public BaseHomePage()
	{
		InitializeComponent();
        // Ocultar completamente la barra de navegación
        NavigationPage.SetHasNavigationBar(this, false);
    }
    public async void OnPostItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is PostDTOOld selectedPost)
        {
            await Navigation.PushAsync(new PostDetailPage(selectedPost)); // Pasa el post seleccionado a la página de detalles
        }
        // Desmarca el elemento seleccionado
        ((CollectionView)sender).SelectedItem = null;
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
    public virtual async void OnFeatherIconTapped(object sender, EventArgs e)
    {
        // Crear una nueva página para el modal
        var newPostPage = new NewPostPage();

        // Mostrar la página como un modal
        await Navigation.PushModalAsync(newPostPage);
    }
}