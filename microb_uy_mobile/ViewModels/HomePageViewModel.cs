using System.Collections.ObjectModel;
using microb_uy_mobile.DTOs;
using Microsoft.Maui.Controls;

namespace microb_uy_mobile
{
    public class HomePageViewModel : BindableObject
    {
        private ObservableCollection<PostDTOOld> posts;

        public ObservableCollection<PostDTOOld> Posts
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
            Posts = new ObservableCollection<PostDTOOld>();

            for (int i = 1; i <= 2; i++)
            {
                Posts.Add(new PostDTOOld
                {
                    UserProfileImage = "diego_forlan.jpg",
                    UserName = $"Usuario {i}",
                    PostContent = $"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. At urna condimentum mattis pellentesque id nibh tortor id aliquet. Nunc sed augue lacus viverra vitae congue. Nibh sit amet commodo nulla facilisi nullam vehicula. Dolor purus non enim praesent elementum facilisis. Sed turpis tincidunt id aliquet. Urna condimentum mattis pellentesque id nibh tortor id. {i}."
                });
            }
            for (int i = 1; i <= 1; i++)
            {
                Posts.Add(new PostDTOOld
                {
                    UserProfileImage = "diego_forlan.jpg",
                    UserName = $"Usuario {i}",
                    PostContent = $"Nunc sed augue lacus viverra vitae congue. Nibh sit amet commodo nulla facilisi nullam vehicula. Dolor purus non enim praesent elementum facilisis. Sed turpis tincidunt id aliquet. Urna condimentum mattis pellentesque id nibh tortor id. {i}."
                });
            }
            for (int i = 1; i <= 1; i++)
            {
                Posts.Add(new PostDTOOld
                {
                    UserProfileImage = "diego_forlan.jpg",
                    UserName = $"Usuario {i}",
                    PostContent = $"Dolor purus non enim praesent elementum facilisis. Sed turpis tincidunt id aliquet. Urna condimentum mattis pellentesque id nibh tortor id. {i}."
                });
            }
            for (int i = 1; i <= 7; i++)
            {
                Posts.Add(new PostDTOOld
                {
                    UserProfileImage = "diego_forlan.jpg",
                    UserName = $"Usuario {i}",
                    PostContent = $" Urna condimentum mattis pellentesque id nibh tortor id. {i}."
                });
            }
            for (int i = 1; i <= 8; i++)
            {
                Posts.Add(new PostDTOOld
                {
                    UserProfileImage = "diego_forlan.jpg",
                    UserName = $"Usuario {i}",
                    PostContent = $" hola nibh tortor id. {i}."
                });
            }

        }
    }
}
