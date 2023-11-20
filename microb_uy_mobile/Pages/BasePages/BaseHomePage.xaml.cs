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
        // Ocultar completamente la barra de navegaci�n
        NavigationPage.SetHasNavigationBar(this, false);
    }
    public virtual async void OnPostContentTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PostDetailPage());
    }
    public virtual void OnReplyIconTapped(object sender, EventArgs e)
    {
        // L�gica para manejar la respuesta al post
        DisplayAlert("Info", "Responder al post", "OK");
    }

    public virtual void OnRetweetIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Info", "Retweet", "OK");
        // L�gica para manejar el retweet
    }

    public virtual void OnLikeIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Info", "Like", "OK");
        // L�gica para manejar el "Me gusta"
    }
    public virtual async void OnFeatherIconTapped(object sender, EventArgs e)
    {
        // Crear una nueva p�gina para el modal
        var newPostPage = new NewPostPage();

        // Mostrar la p�gina como un modal
        await Navigation.PushModalAsync(newPostPage);
    }
}