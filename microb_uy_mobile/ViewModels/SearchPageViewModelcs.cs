using microb_uy_mobile.DTOs;
using System.Collections.ObjectModel;


namespace microb_uy_mobile.ViewModels
{
    public class SearchPageViewModel : BindableObject
    {
        private ObservableCollection<PostDTO> searchResults;

        public ObservableCollection<PostDTO> SearchResults
        {
            get { return searchResults; }
            set
            {
                searchResults = value;
                OnPropertyChanged();
            }
        }

        public SearchPageViewModel()
        {
            // Inicializa datos de ejemplo para la búsqueda
            SearchResults = new ObservableCollection<PostDTO>
            {
                new PostDTO
                {
                    UserProfileImage = "user1.jpg",
                    UserName = "Usuario1",
                    PostContent = "Resultado de busqueda 1."
                },
                new PostDTO
                {
                    UserProfileImage = "user2.jpg",
                    UserName = "Usuario2",
                    PostContent = "Resultado de busqueda 2."
                },
                // Agrega más posts de ejemplo según sea necesario.
            };
        }
    }
}
