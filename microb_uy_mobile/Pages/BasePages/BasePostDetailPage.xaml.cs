using System.Collections.ObjectModel;
using microb_uy_mobile.DTOs;

namespace microb_uy_mobile.Pages.BasePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePostDetailPage : ContentPage
    {
        public PostDTOOld _mainPost;
        public BasePostDetailPage(PostDTOOld mainPost)
        {
            InitializeComponent();
            _mainPost = mainPost;

            LoadMainPostDetails();
            LoadPostResponses();
        }
        protected void LoadMainPostDetails()
        {
            // Cargar detalles del post principal desde _mainPost
            // Por ejemplo:
            UserProfileImage.Source = _mainPost.UserProfileImage;
            UserNameLabel.Text = _mainPost.UserName;
            PostContentLabel.Text = _mainPost.PostContent;
        }
        public virtual void OnReplyIconTapped(object sender, EventArgs e)
        {
            // Lógica para manejar la respuesta al post
            DisplayAlert("Base", "Responder al post", "OK");
        }
        public virtual async void OnRetweetIconTapped(object sender, EventArgs e)
        {
            // Maneja el evento cuando el icono de retweet es clicado
            // Realiza la acción correspondiente, como retwittear el post
            await DisplayAlert("Base", "Retweet", "OK");
        }

        public virtual async void OnLikeIconTapped(object sender, EventArgs e)
        {
            // Maneja el evento cuando el icono de "me gusta" es clicado
            // Realiza la acción correspondiente, como dar "me gusta" al post
            await DisplayAlert("Base", "Like", "OK");
        }

        protected void LoadPostResponses()
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
