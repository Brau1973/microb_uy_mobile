using microb_uy_mobile.DTOs;
using MvvmHelpers;
using Refit;
using System.Collections.ObjectModel;

namespace microb_uy_mobile.Pages.MainTenant;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class PostDetailPage : ContentPage
{
    public PostDto _mainPost;

    private readonly string BaseApiUrl = (string)App.SessionInfo["BaseUrl"];
    private readonly int TenantId = (int)App.SessionInfo["MainTenantId"];
    private readonly int LoggedUserId = (int)App.SessionInfo["LoggedUserId"];

    public ObservableRangeCollection<PostDto> _responsesList = new ObservableRangeCollection<PostDto>();
    private int? _lastId;
    private int _pageSize = 10;
    private bool _hasMorePosts = true;
    private bool _isBusy = false;
    private bool _isLoading = false;
    private bool _isLabelVisible;
    private string _labelMsg;
    public PostDetailPage(PostDto mainPost)
    {
        InitializeComponent();
        _mainPost = mainPost;

        this.BindingContext = _mainPost;

        CollectionViewRespuestas.ItemsSource = _responsesList;

        LoadMainPostContent();
        LoadPostResponses();
    }

    private void LoadMainPostContent()
    {
        DataTemplate template;

        // Aquí determinas qué plantilla usar basado en el tipo de post
        if (_mainPost.TipoPost == "NORMAL")
        {
            template = (DataTemplate)this.Resources["NormalPostTemplate"];
        }
        else if (_mainPost.TipoPost == "REPOST")
        {
            template = (DataTemplate)this.Resources["RepostPostTemplate"];
        }
        else
        {
            // Manejar casos no esperados
            template = null;
        }

        if (template != null)
        {
            var content = template.CreateContent();
            if (content is View viewContent)
            {
                MainPostContentContainer.Content = viewContent;
            }
        }
    }

    private async void LoadPostResponses()
    {
        await GetResponsesList();
    }

    private async Task<List<PostDto>> DownloadResponsesAsync(int pageSize)
    {
        var api = RestService.For<IPostService>(BaseApiUrl);
        var getRespuestasPostResponse = await api.GetRespuestaPost(_mainPost.Id, TenantId, pageSize, _lastId, "", LoggedUserId, TenantId);

        if (getRespuestasPostResponse?.Results != null && getRespuestasPostResponse.Results.Any())
        {
            _lastId = getRespuestasPostResponse.Results.Last().Id;
            _hasMorePosts = getRespuestasPostResponse.Results.Count() == pageSize;
        }
        else
        {
            _hasMorePosts = false;
            return null;
        }

        return getRespuestasPostResponse?.Results.ToList() ?? new List<PostDto>();
    }
    public async Task GetResponsesList()
    {
        _lastId = null;
        _hasMorePosts = true;
        _isLoading = false;
        _responsesList.Clear();
        _isLoading = false;
        IsBusy = true;
        try
        {
            var results = await DownloadResponsesAsync(_pageSize);
            App.Current.Dispatcher.Dispatch(() =>
            {
                IsBusy = false;
                if (results != null && results.Count > 0)
                {
                    _isLabelVisible = false;
                    _responsesList.ReplaceRange(results);
                }
                else
                {
                    _isLabelVisible = true;
                    _labelMsg = "Aun no hay respuestas a este Post!";
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en GetResponsesList: {ex}");
        }
    }

    private async void LoadMoreData(object sender, EventArgs e)
    {
        if (_isLoading || !_hasMorePosts) return;

        _isLoading = true;
        try
        {
            await Task.Delay(500);
            var results = await DownloadResponsesAsync(_pageSize);
            _responsesList.AddRange(results);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en LoadMoreData: {ex}");
        }
        finally
        {
            _isLoading = false;
        }
    }


    private void LoadPostResponsesHardcodeado()
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
