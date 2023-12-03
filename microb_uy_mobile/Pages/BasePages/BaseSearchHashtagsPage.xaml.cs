using microb_uy_mobile.DTOs;
using microb_uy_mobile.ViewModels;
using System.Collections.ObjectModel;

namespace microb_uy_mobile.Pages.BasePages;

public partial class BaseSearchHashtagsPage : ContentPage
{
    public SearchHashtagsViewModel ViewModel { get; set; }
    //SI ANDA BIEN GENERAR CLASE CON ESTA INFO E INSTANCIAR ESTA CLASE XXX
    //(esta clase serviria para manejar todos los paginados)
    protected int _currentPage = 1;
    protected const int PageSize = 10;
    protected bool _isLoading = false; // Para evitar múltiples solicitudes simultáneas
    public BaseSearchHashtagsPage()
	{
		InitializeComponent();
        //LoadSampleHashtags();

        //ViewModel = new SearchHashtagsViewModel();

        //BindingContext = ViewModel;
    }
    //protected override async void OnAppearing()
    //{
    //    base.OnAppearing();
    //    //SearchResultsHashtags.EmptyView = "Busca Hashtags!";
    //    NoResults.Text = "Busca Hashtags!";
    //}

    public string CloseKeyboardAndGetSearchText()
    {
        // Cerrar el teclado
        _searchBar.Unfocus();
        // Obtener el texto ingresado en el SearchBar
        string searchText = _searchBar.Text;
        return searchText;
    }

    public virtual void OnSearchButtonClicked(object sender, EventArgs e)
    {
        //SE COMPLETA EN CLASE HIJA
    }

    public virtual async void LoadNewPage(object sender, EventArgs e)
    {
        // IMPLEMENTO EN HIJA
    }

    public void CheckCollectionViewIsEmpty()
    {
        if (SearchResultsHashtags.ItemsSource == null || !SearchResultsHashtags.ItemsSource.Cast<object>().Any())
        {
            // La CollectionView está vacía
            NoResults.IsVisible = true;
            NoResults.Text = "No hay resultados";
            SearchResultsHashtags.IsVisible = false;
        }
        else
        {
            // La CollectionView tiene elementos
            NoResults.IsVisible = false;
            SearchResultsHashtags.IsVisible = true;
        }
    }

    public void LoadHashTagsCollection(ObservableCollection<HashTagDto> hashtags)
    {
        _searchBar.Unfocus();
        // Agrega los nuevos hashtags a la colección existente o crea una nueva
        //var existingHashtags = SearchResultsHashtags.ItemsSource as ObservableCollection<HashTagDto> ?? new ObservableCollection<HashTagDto>();
        //existingHashtags.Concat(hashtags);

        SearchResultsHashtags.ItemsSource = hashtags;

        _currentPage++; // Incrementa la página para la próxima carga
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