using System;
using System.Collections.ObjectModel;
using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages;

namespace microb_uy_mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        public PostDetailPage()
        {
            InitializeComponent();

            LoadSamplePublicaciones();
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

        private void LoadSamplePublicaciones()
        {
            ObservableCollection<PostDTO> Posts = new ObservableCollection<PostDTO>();

            for (int i = 1; i <= 4; i++)
            {
                Posts.Add(new PostDTO
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
