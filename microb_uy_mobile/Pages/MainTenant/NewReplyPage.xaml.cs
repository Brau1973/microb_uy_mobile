using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages.BasePages;

namespace microb_uy_mobile.Pages
{
    public partial class NewReplyPage : BaseNewReplyPage
    {
        public NewReplyPage(PostDTOOld mainPost) : base(mainPost)
        {
            InitializeComponent();
        }

        public override async void OnPublishButtonClicked(object sender, EventArgs e)
        {
            base.OnPublishButtonClicked(sender, e);
            if (postContent != null)
            {
                await DisplayAlert("Contenido", "Contenido: " + postContent, "Aceptar");

                string hashtagsMessage = string.Join(", ", hashtags);
                await DisplayAlert("Hashtags", "Hashtags: " + hashtagsMessage, "Aceptar");

                //LLAMAR A API DE RESPUESTAS ENVIANDO INFO DE MI PROPIO TENANT 
            }
            else
            {
                await DisplayAlert("Info", "Contenido de respuesta vacío", "OK");
            }
            
        }

        //public override async void OnCancelButtonClicked(object sender, EventArgs e)
        //{
        //    // Cerrar el teclado
        //    GetContentAndCloseEditor();

        //    // Volver a la pantalla anterior
        //    await Navigation.PopModalAsync();
        //}
    }
}
