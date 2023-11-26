using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages.BasePages;
using microb_uy_mobile.Services.Interfaces;

namespace microb_uy_mobile.Pages.Integrations
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntegrationsPostDetailPage : BasePostDetailPage
    {
        public IntegrationsPostDetailPage(PostDTOOld mainPost) : base(mainPost)
        {
            InitializeComponent();
            _mainPost = mainPost;

            LoadMainPostDetails();
            LoadPostResponses();
        }
        public override async void OnReplyIconTapped(object sender, EventArgs e)
        {
            ISessionInfoService _sessionInfoService = Handler.MauiContext.Services.GetRequiredService<ISessionInfoService>();

            var integrationsNewReplyPage = new IntegrationsNewReplyPage(_mainPost);

            // Mostrar la página como un modal
            await Navigation.PushModalAsync(integrationsNewReplyPage);
        }
        public override async void OnRetweetIconTapped(object sender, EventArgs e)
        {
            // Maneja el evento cuando el icono de retweet es clicado
            // Realiza la acción correspondiente, como retwittear el post
            await DisplayAlert("Integrations", "Retweet", "OK");
        }

        public override async void OnLikeIconTapped(object sender, EventArgs e)
        {
            // Maneja el evento cuando el icono de "me gusta" es clicado
            // Realiza la acción correspondiente, como dar "me gusta" al post
            await DisplayAlert("Integrations", "Like", "OK");
        }
    }
}
