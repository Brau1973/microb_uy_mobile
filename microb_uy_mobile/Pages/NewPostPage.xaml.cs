using microb_uy_mobile.Pages;
using System;
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

            //Obtengo en item 1 los hashtags y en item 2 el contenido del post sin hashtags
            Tuple<List<string>, string> result = ExtractHashtagsAndContent(PostEditor.Text);

            await DisplayAlert("Post", "Post: " + result.Item2, "Aceptar");

            // Mostrar una notificación
            await DisplayAlert("Éxito", "Post creado", "Aceptar");

            // Volver a la pantalla anterior
            await Navigation.PopModalAsync();
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
