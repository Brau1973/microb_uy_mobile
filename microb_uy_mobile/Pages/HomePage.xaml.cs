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
    // Sobrescribe el evento OnPostContentTapped
    public override async void OnPostContentTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PostDetailPage());
    }

    // Sobrescribe el evento OnReplyIconTapped
    public override void OnReplyIconTapped(object sender, EventArgs e)
    {
        ISessionInfoService _sessionInfoService = Handler.MauiContext.Services.GetRequiredService<ISessionInfoService>();
        // Lógica para manejar la respuesta al post
        DisplayAlert("Integrations", "Llamo a la api de mi instancia principal" +
            "Responder al post ", "OK");
    }

    // Sobrescribe el evento OnRetweetIconTapped
    public override void OnRetweetIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Integrations", "Llamo a la api de mi instancia principal " + "Retweet", "OK");
        // Lógica para manejar el retweet
    }

    // Sobrescribe el evento OnLikeIconTapped
    public override void OnLikeIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Integrations", "Llamo a la api de mi instancia principal " + "Like", "OK");
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