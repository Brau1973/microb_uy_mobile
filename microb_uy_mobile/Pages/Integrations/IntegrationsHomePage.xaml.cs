using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages.BasePages;
using microb_uy_mobile.Services.Interfaces;
using microb_uy_mobile.ViewModels.Integrations;

namespace microb_uy_mobile.Pages.Integrations;

public partial class IntegrationsHomePage : BaseHomePage
{
	public IntegrationsHomePage()
	{
		InitializeComponent();

        // Ocultar FeatherFrame en IntegrationsHomePage
        IsFeatherFrameVisible = false;

        // Instancia el modelo de vista
        IntegrationsHomePageViewModel viewModel = new();

        // Asigna el modelo de vista como contexto de datos para la página
        this.BindingContext = viewModel;
    }

    // Sobrescribe la propiedad para ocultar el FeatherFrame
    public override bool IsFeatherFrameVisible
    {
        get => base.IsFeatherFrameVisible;
        set => base.IsFeatherFrameVisible = value;
    }

    // Sobrescribe el evento OnReplyIconTapped
    public override async void OnReplyIconTapped(object sender, EventArgs e)
    {
        // Lógica para manejar la respuesta al post
        await DisplayAlert("Integrations", "Chequear si esta habilitada la integracion entre usuarios para poder interactuar " +
            "Responder al post", "OK");

        ISessionInfoService _sessionInfoService = Handler.MauiContext.Services.GetRequiredService<ISessionInfoService>();
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

    // Sobrescribe el evento OnRetweetIconTapped
    public override void OnRetweetIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Integrations", "Chequear si esta habilitada la integracion entre usuarios para poder interactuar " + "Retweet", "OK");
        // Lógica para manejar el retweet
    }

    // Sobrescribe el evento OnLikeIconTapped
    public override void OnLikeIconTapped(object sender, EventArgs e)
    {
        DisplayAlert("Integrations", "Chequear si esta habilitada la integracion entre usuarios para poder interactuar " + "Like", "OK");
        // Lógica para manejar el "Me gusta"
    }

}