using System.Collections.ObjectModel;
using microb_uy_mobile.DTOs;

namespace microb_uy_mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        private readonly PostDTOOld _mainPost;
        public PostDetailPage(PostDTOOld mainPost)
        {
            InitializeComponent();
            _mainPost = mainPost;

            LoadMainPostDetails();
            LoadPostResponses();
        }

        private void LoadMainPostDetails()
        {
            // Cargar detalles del post principal desde _mainPost
            // Por ejemplo:
            UserProfileImage.Source = _mainPost.UserProfileImage;
            UserNameLabel.Text = _mainPost.UserName;
            PostContentLabel.Text = _mainPost.PostContent;
        }

        private async void OnRetweetIconTapped(object sender, EventArgs e)
        {
            // Maneja el evento cuando el icono de retweet es clicado
            // Realiza la acción correspondiente, como retwittear el post
            await DisplayAlert("Info", "Retweet", "OK");
        }

        private async void OnLikeIconTapped(object sender, EventArgs e)
        {
            // Maneja el evento cuando el icono de "me gusta" es clicado
            // Realiza la acción correspondiente, como dar "me gusta" al post
            await DisplayAlert("Info", "Like", "OK");
        }

        private void LoadPostResponses()
        {
            ObservableCollection<PostDTOOld> Posts = new ObservableCollection<PostDTOOld>();

            for (int i = 1; i <= 4; i++)
            {
                Posts.Add(new PostDTOOld
                {
                    UserProfileImage = "diego_forlan.jpg",
                    UserName = $"Usuario {i}",
                    PostContent = $"Respuesta {i} yurna condimentum mattis pellentesque id nibh tortor id."
                });
            }
            CollectionViewRespuestas.ItemsSource = Posts;
        }
    }
}
