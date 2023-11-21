using microb_uy_mobile.Pages.BasePages;
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

    // Sobrescribe el evento OnPostContentTapped
    public override async void OnPostContentTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PostDetailPage());
    }

    // Sobrescribe el evento OnReplyIconTapped
    public override void OnReplyIconTapped(object sender, EventArgs e)
    {
        // Lógica para manejar la respuesta al post
        DisplayAlert("Integrations", "Chequear si esta habilitada la integracion entre usuarios para poder interactuar " +
            "Responder al post", "OK");
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