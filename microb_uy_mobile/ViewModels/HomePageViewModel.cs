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
            Posts = new ObservableCollection<PostDTO>
            {
                new PostDTO
                {
                    UserProfileImage = "profile_image1.jpg",
                    UserName = "Usuario 1",
                    PostContent = "Este es el contenido del primer post."
                },
                new PostDTO
                {
                    UserProfileImage = "profile_image2.jpg",
                    UserName = "Usuario 2",
                    PostContent = "Este es el contenido del segundo post."
                },
                // Agrega más datos de prueba según sea necesario.
            };
        }
    }
}
