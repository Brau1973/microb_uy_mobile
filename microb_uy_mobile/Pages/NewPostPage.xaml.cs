using microb_uy_mobile.Pages;
using System;

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
            // Agregar aqu� la l�gica para publicar el post
            // ...

            // Cerrar el teclado
            PostEditor.Unfocus();

            // Mostrar una notificaci�n
            await DisplayAlert("�xito", "Post creado", "Aceptar");

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

    }
}
