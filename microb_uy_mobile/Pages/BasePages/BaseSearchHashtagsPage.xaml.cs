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
        SearchResultsHashtags.ItemsSource = new List<HashTagDTOOld>
            {
                new HashTagDTOOld { HashTagName = "Tech", HashTagDescription = "All about technology" },
                new HashTagDTOOld { HashTagName = "Travel", HashTagDescription = "Explore the world" },
                new HashTagDTOOld { HashTagName = "Foodie", HashTagDescription = "For food lovers" },
                new HashTagDTOOld { HashTagName = "Fashion", HashTagDescription = "Stay stylish" },
                new HashTagDTOOld { HashTagName = "Fitness", HashTagDescription = "Get fit" },
                new HashTagDTOOld { HashTagName = "Photography", HashTagDescription = "Capturing moments" },
                new HashTagDTOOld { HashTagName = "Nature", HashTagDescription = "Embrace the outdoors" },
                new HashTagDTOOld { HashTagName = "Art", HashTagDescription = "Creative expressions" },
                new HashTagDTOOld { HashTagName = "Music", HashTagDescription = "Sounds of joy" },
                new HashTagDTOOld { HashTagName = "Books", HashTagDescription = "Literary adventures" },
                new HashTagDTOOld { HashTagName = "Pets", HashTagDescription = "For pet enthusiasts" },
                new HashTagDTOOld { HashTagName = "Gaming", HashTagDescription = "Gamer's paradise" },
                new HashTagDTOOld { HashTagName = "Movies", HashTagDescription = "Cinematic experiences" },
                new HashTagDTOOld { HashTagName = "Sports", HashTagDescription = "Game on!" },
                new HashTagDTOOld { HashTagName = "Health", HashTagDescription = "Wellness matters" }
            };
    }
}