using microb_uy_mobile.DTOs;
using System.Collections.ObjectModel;

namespace microb_uy_mobile.Pages.MainTenant;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class PostDetailPage : ContentPage
{
    public PostDto _mainPost;
    public PostDetailPage(PostDto mainPost)
    {
        InitializeComponent();
        _mainPost = mainPost;

        this.BindingContext = _mainPost;

        //LoadMainPostDetails();
        LoadPostResponses();
    }
    //private void LoadMainPostDetails()
    //{
    //    // Cargar detalles del post principal desde _mainPost
    //    // Por ejemplo:
    //    UserProfileImage.Source = _mainPost.UserProfileImage;
    //    UserNameLabel.Text = _mainPost.UserName;
    //    PostContentLabel.Text = _mainPost.PostContent;
    //}
    private void LoadPostResponses()
    {
        ObservableCollection<PostDto> Posts = new ObservableCollection<PostDto>();

        // Generar algunos posts normales
        for (int i = 1; i <= 5; i++)
        {
            Posts.Add(GenerarPostNormal($"Usuario{i}", $"Contenido del post {i}", $"Titulo del post{i}"));
        }
        CollectionViewRespuestas.ItemsSource = Posts;
    }
    public async void OnReplyIconTapped(object sender, EventArgs e)
    {
        var NewReplyPage = new NewReplyPage(_mainPost);

        // Mostrar la página como un modal
        await Navigation.PushModalAsync(NewReplyPage);
    }
    public async void OnRetweetIconTapped(object sender, EventArgs e)
    {
        // Maneja el evento cuando el icono de retweet es clicado
        // Realiza la acción correspondiente, como retwittear el post
        await DisplayAlert("MAIN TENANT", "Retweet", "OK");
    }

    public async void OnLikeIconTapped(object sender, EventArgs e)
    {
        // Maneja el evento cuando el icono de "me gusta" es clicado
        // Realiza la acción correspondiente, como dar "me gusta" al post
        await DisplayAlert("MAIN TENANT", "Like", "OK");
    }

    // Método para generar un post normal
    private PostDto GenerarPostNormal(string autor, string contenido, string titulo)
    {
        return new PostDto
        {
            AutorImg = "https://img.freepik.com/vector-premium/perfil-avatar-hombre-icono-redondo_24640-14044.jpg",
            Autor = autor,
            Title = titulo,
            Contenido = contenido,
            Fecha = DateTime.Now,
            TipoPost = "NORMAL",
            Likes = new Random().Next(1, 10), // Genera likes aleatorios para fines de prueba
            CantRespuestas = new Random().Next(0, 5) // Genera respuestas aleatorias para fines de prueba
        };
    }
}
