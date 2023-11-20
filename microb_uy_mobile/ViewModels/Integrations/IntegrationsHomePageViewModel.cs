using microb_uy_mobile.DTOs;
using System.Collections.ObjectModel;

namespace microb_uy_mobile.ViewModels.Integrations
{
    public class IntegrationsHomePageViewModel : BindableObject
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

        public IntegrationsHomePageViewModel()
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
                    UserName = $"Integracion Usuario {i}",
                    PostContent = $"Integracion Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. At urna condimentum mattis pellentesque id nibh tortor id aliquet. Nunc sed augue lacus viverra vitae congue. Nibh sit amet commodo nulla facilisi nullam vehicula. Dolor purus non enim praesent elementum facilisis. Sed turpis tincidunt id aliquet. Urna condimentum mattis pellentesque id nibh tortor id. {i}."
                });
            }

        }
    }
}
