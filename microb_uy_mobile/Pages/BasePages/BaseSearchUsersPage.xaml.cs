using microb_uy_mobile.DTOs;

namespace microb_uy_mobile.Pages.BasePages;

public partial class BaseSearchUsersPage : ContentPage
{
	public BaseSearchUsersPage()
	{
		InitializeComponent();
        LoadSampleUsuarios();
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

    // Función para cargar datos de ejemplo en la CollectionView de Usuarios
    private void LoadSampleUsuarios()
    {
        SearchResultsUsuarios.ItemsSource = new List<UserDto>
        {
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "JohnDoe",
                UserBio = "Software Engineer, Tech Enthusiast"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "JaneSmith",
                UserBio = "Designer and Creative Thinker"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "AlexJohnson",
                UserBio = "Coffee Lover and Developer"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "EmilyDavis",
                UserBio = "Nature Explorer and Photographer"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "RobertWilson",
                UserBio = "Gamer and Streamer"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "LindaMartin",
                UserBio = "Foodie and Traveler"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "MichaelBrown",
                UserBio = "Bookworm and History Buff"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "SarahLee",
                UserBio = "Fitness Enthusiast and Nutritionist"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "ChrisHall",
                UserBio = "Musician and Songwriter"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "MeganWhite",
                UserBio = "Art Lover and Painter"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "WilliamClark",
                UserBio = "Pet Lover and Animal Rights Advocate"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "OliviaLewis",
                UserBio = "Movie Buff and Cinephile"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "DanielYoung",
                UserBio = "Hiker and Outdoor Enthusiast"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "AvaHarris",
                UserBio = "Fashionista and Stylist"
            },
            new UserDto
            {
                UserProfileImage = "diego_forlan.jpg",
                UserName = "JamesTurner",
                UserBio = "Tech Geek and Coding Ninja"
            }
        };
    }
}