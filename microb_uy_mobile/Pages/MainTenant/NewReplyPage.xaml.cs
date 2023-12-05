using microb_uy_mobile.DTOs;
using System.Text.RegularExpressions;

namespace microb_uy_mobile.Pages.MainTenant;

public partial class NewReplyPage : ContentPage
{
    private readonly PostDTOOld _mainPost;
    protected string postContent { get; set; }
    protected List<string> hashtags { get; set; }
    public NewReplyPage(PostDTOOld mainPost)
    {
        InitializeComponent();

        _mainPost = mainPost;

        LoadMainPostDetails();
    }

    public async void OnPublishButtonClicked(object sender, EventArgs e)
    {
        // Obtener el contenido del post
        string replyContent = GetContentAndCloseEditor();

        if (replyContent != null)
        {
            // Obtener hashtags y contenido del post
            var result = ExtractHashtagsAndContent(replyContent);

            // Puedes realizar acciones con los hashtags, si lo deseas
            this.hashtags = result.Item1;
            this.postContent = result.Item2;
        }
        else
        {
            // Mostrar alerta si el contenido de respuesta es vacío
            await DisplayAlert("Main tenant", "Contenido de respuesta vacío", "OK");
        }
    }
    public void LoadMainPostDetails()
    {
        // Cargar detalles del post principal desde _mainPost
        // Por ejemplo:
        UserProfileImage.Source = _mainPost.UserProfileImage;
        UserNameLabel.Text = _mainPost.UserName;
        PostContentLabel.Text = _mainPost.PostContent;
    }

    public string GetContentAndCloseEditor()
    {
        string editorContent = PostEditor.Text;
        // Cerrar el teclado
        PostEditor.Unfocus();
        return editorContent;
    }

    public static Tuple<List<string>, string> ExtractHashtagsAndContent(string text)
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
    public async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        // Cerrar el teclado
        PostEditor.Unfocus();

        // Volver a la pantalla anterior
        await Navigation.PopModalAsync();
    }
}
