using System.Collections.ObjectModel;
using microb_uy_mobile.DTOs;
using Microsoft.Maui.Controls;

namespace microb_uy_mobile
{
    public class HomePageViewModel : BindableObject
    {
        private ObservableCollection<PostDTO> posts;

        public ObservableCollection<PostDTO> Posts
        {
            get { return posts; }
            set
            {
                posts = value;
                OnPropertyChanged();
            }
        }

        public HomePageViewModel()
        {
            // Aquí, en lugar de datos hardcodeados, deberías realizar una llamada a tu servicio REST para obtener los posts.
            // Cuando el servicio esté disponible, reemplaza el código de prueba con datos reales.

            // Ejemplo de datos hardcodeados (reemplaza esto con la integración real):
            Posts = new ObservableCollection<PostDTO>();

            for (int i = 1; i <= 20; i++)
            {
                Posts.Add(new PostDTO
                {
                    UserProfileImage = "diego_forlan.jpg",
                    UserName = $"Usuario {i}",
                    PostContent = $"Este es el contenido del post {i}."
                });
            }

        }
    }
}
