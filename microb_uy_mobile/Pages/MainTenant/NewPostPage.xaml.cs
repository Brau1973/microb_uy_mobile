using microb_uy_mobile.DTOs;
using microb_uy_mobile.Services.Interfaces;
using System.Text.RegularExpressions;

namespace microb_uy_mobile.Pages
{
    public partial class NewPostPage : ContentPage
    {
        public NewPostPage()
        {
            InitializeComponent();
        }

        private async void OnPublishButtonClicked(object sender, EventArgs e)
        {
            // Cerrar el teclado
            PostEditor.Unfocus();

            //await DisplayAlert("Post", "Post: " + result.Item2, "Aceptar");

            await CreateNewPost();

            // Volver a la pantalla anterior
            await Navigation.PopModalAsync();
        }

        public async Task CreateNewPost()
        {
            //Obtengo en item 1 los hashtags y en item 2 el contenido del post sin hashtags
            Tuple<List<string>, string> result = ExtractHashtagsAndContent(PostEditor.Text);
            List<string> hashTags = result.Item1;
            string postContent = result.Item2;

            //Obtengo info del tenant logueado
            var sessionInfoService = Handler.MauiContext.Services.GetRequiredService<ISessionInfoService>();
            var tenantId = sessionInfoService.TenantId;

            // Reemplaza la URL con la dirección real de tu backend
            var apiUrl = "https://backoffice.web.microb-uy.lat";
            var postsService = new PostsService(apiUrl);

            try
            {
                // Crear una instancia de PostDto utilizando el constructor con parámetros
                var newPost = new PostDto
                {
                    Id = 1,
                    Autor = "Autor Ejemplo",
                    MailAutor = "autor@example.com",
                    Fecha = DateTime.Now,
                    Contenido = postContent,
                    TipoPost = "Normal",
                    HashTags = new List<HashTagDto> { new HashTagDto { NombreHT = "EjemploHT", TenantId = tenantId, Cantidad = 1 } },
                    Likes = 0,
                    CantRespuestas = 0,
                    Tenantid = 123
                };

                // Llama al servicio para crear el nuevo post.
                var createdPost = await postsService.PostPost(newPost, tenantId);

                // Verifica si la creación fue exitosa.
                if (createdPost != null)
                { 
                    await DisplayAlert("Éxito", "Post creado", "Aceptar");
                }
                else
                {
                    // La creación del post falló. Puedes manejar esto de acuerdo a tus necesidades.
                    await DisplayAlert("Error", "Error al crear el nuevo post", "OK");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores generales.
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {

            // Cerrar el teclado
            PostEditor.Unfocus();

            // Volver a la pantalla anterior
            await Navigation.PopModalAsync();
        }

        static Tuple<List<string>, string> ExtractHashtagsAndContent(string text)
        {
            List<string> hashtags = new List<string>();

            // Regular expression pattern to match hashtags
            string hashtagPattern = @"#\w+";

            // Use Regex to find matches
            MatchCollection hashtagMatches = Regex.Matches(text, hashtagPattern);

            // Extract hashtags from matches
            foreach (Match match in hashtagMatches)
            {
                hashtags.Add(match.Value);
            }

            // Remove hashtags from the original text
            string postContent = Regex.Replace(text, hashtagPattern, "").Trim();

            return Tuple.Create(hashtags, postContent);
        }
    }
}
