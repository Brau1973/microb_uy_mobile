using microb_uy_mobile.DTOs;
using Refit;
using System.Text.RegularExpressions;

namespace microb_uy_mobile.Pages.MainTenant;

public partial class NewRepostPage : ContentPage
{
    private readonly PostDto _mainPost;
    protected string repostContent { get; set; }
    protected List<string> hashtags { get; set; }
    public NewRepostPage(PostDto mainPost)
    {
        InitializeComponent();

        _mainPost = mainPost;

        this.BindingContext = _mainPost;

        //LoadMainPostDetails();
    }

    private async void OnPublishButtonClicked(object sender, EventArgs e)
    {
        // Cerrar el teclado
        RepostEditor.Unfocus();

        // Validación
        if (string.IsNullOrWhiteSpace(RepostTitleEntry.Text) || string.IsNullOrWhiteSpace(RepostEditor.Text))
        {
            await DisplayAlert("Error", "Por favor, ingresa un título y contenido para el post.", "OK");
        }
        else
        {
            await CreateNewPost();
            // Volver a la pantalla anterior
            await Navigation.PopModalAsync();
        }
    }

    public async Task CreateNewPost()
    {
        //Obtengo en item 1 el contenido del post sin hashtags y en item 2 los hashtags
        Tuple<string, List<CrearHashTag>> result = ExtractHashtagsAndContent(RepostEditor.Text);

        string baseApiUrl = (string)App.SessionInfo["BaseUrl"];
        string repostContent = result.Item1;
        List<CrearHashTag> hashTags = result.Item2;
        string repostTitle = RepostTitleEntry.Text;
        int tenantId = (int)App.SessionInfo["MainTenantId"];
        string loggedUserEmail = (string)App.SessionInfo["LoggedUserEmail"];
        DateTime currentDateTimeUtc = DateTime.UtcNow;
        string UserToken = (string)App.SessionInfo["UserToken"];

        try
        {
            // Crear una instancia de PostDto utilizando el constructor con parámetros
            var newResponse = new CrearPostDto
            {
                MailAutor = loggedUserEmail,
                Fecha = currentDateTimeUtc,
                Title = repostTitle,
                Contenido = repostContent,
                TipoPost = "REPOST",
                RepostId = _mainPost.Id,
                TenantidRepost = tenantId,
                HashTags = hashTags,
                Tenantid = tenantId
            };

            var api = RestService.For<IPostService>(baseApiUrl);
            var newPostResponse = await api.PostPost($"Bearer {UserToken}", newResponse, tenantId);

            if (newPostResponse != null)
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
            await DisplayAlert("Error", "Error al crear el nuevo post, intentelo mas tarde", "OK");
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private async void OnCancelButtonClicked(object sender, EventArgs e)
    {

        // Cerrar el teclado
        RepostEditor.Unfocus();

        // Volver a la pantalla anterior
        await Navigation.PopModalAsync();
    }

    public static Tuple<string, List<CrearHashTag>> ExtractHashtagsAndContent(string text)
    {
        List<CrearHashTag> hashtags = new List<CrearHashTag>();

        // Expresión regular para encontrar hashtags
        string hashtagPattern = @"#\w+";

        // Usar Regex para encontrar coincidencias
        MatchCollection hashtagMatches = Regex.Matches(text, hashtagPattern);

        // Extraer hashtags de las coincidencias y remover el símbolo '#'
        foreach (Match match in hashtagMatches)
        {
            string hashtagText = match.Value.Substring(1); // Eliminar el símbolo '#'
            if (!hashtags.Exists(tag => tag.NombreHT.Equals(hashtagText)))
            {
                hashtags.Add(new CrearHashTag { NombreHT = hashtagText });
            }
        }

        // Remover hashtags del texto original
        string repostContent = Regex.Replace(text, hashtagPattern, "").Trim();

        return Tuple.Create(repostContent, hashtags);
    }
}
