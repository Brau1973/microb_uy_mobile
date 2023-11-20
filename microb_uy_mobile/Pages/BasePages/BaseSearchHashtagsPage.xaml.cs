using microb_uy_mobile.DTOs;

namespace microb_uy_mobile.Pages.BasePages;

public partial class BaseSearchHashtagsPage : ContentPage
{
	public BaseSearchHashtagsPage()
	{
		InitializeComponent();
        LoadSampleHashtags();
    }

    public string CloseKeyboardAndGetSearchText()
    {
        // Cerrar el teclado
        _searchBar.Unfocus();
        // Obtener el texto ingresado en el SearchBar
        string searchText = _searchBar.Text;
        return searchText;
    }
    public virtual void OnSearchButtonPressed(object sender, EventArgs e)
    {
        //SE COMPLETA EN CLASE HIJA
    }
    // Función para cargar datos de ejemplo en la CollectionView de Hashtags
    private void LoadSampleHashtags()
    {
        SearchResultsHashtags.ItemsSource = new List<HashTagDTO>
            {
                new HashTagDTO { HashTagName = "Tech", HashTagDescription = "All about technology" },
                new HashTagDTO { HashTagName = "Travel", HashTagDescription = "Explore the world" },
                new HashTagDTO { HashTagName = "Foodie", HashTagDescription = "For food lovers" },
                new HashTagDTO { HashTagName = "Fashion", HashTagDescription = "Stay stylish" },
                new HashTagDTO { HashTagName = "Fitness", HashTagDescription = "Get fit" },
                new HashTagDTO { HashTagName = "Photography", HashTagDescription = "Capturing moments" },
                new HashTagDTO { HashTagName = "Nature", HashTagDescription = "Embrace the outdoors" },
                new HashTagDTO { HashTagName = "Art", HashTagDescription = "Creative expressions" },
                new HashTagDTO { HashTagName = "Music", HashTagDescription = "Sounds of joy" },
                new HashTagDTO { HashTagName = "Books", HashTagDescription = "Literary adventures" },
                new HashTagDTO { HashTagName = "Pets", HashTagDescription = "For pet enthusiasts" },
                new HashTagDTO { HashTagName = "Gaming", HashTagDescription = "Gamer's paradise" },
                new HashTagDTO { HashTagName = "Movies", HashTagDescription = "Cinematic experiences" },
                new HashTagDTO { HashTagName = "Sports", HashTagDescription = "Game on!" },
                new HashTagDTO { HashTagName = "Health", HashTagDescription = "Wellness matters" }
            };
    }
}