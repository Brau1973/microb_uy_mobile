using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages.BasePages;

namespace microb_uy_mobile.Pages.MainTenant.SearchPages;

public partial class SearchUsersPage : ContentPage
{
	public SearchUsersPage()
	{
		InitializeComponent();
        LoadSampleUsuarios();
    }

    public void OnSearchButtonPressed(object sender, EventArgs e)
    {
        //string searchText = base.CloseKeyboardAndGetSearchText();
        //DisplayAlert("MAIN instancia Search USERS SearchBar", "Buscando " + searchText, "OK");

        // Aquí puedes agregar la lógica de búsqueda con el texto ingresado

        // Por ejemplo, podrías actualizar la CollectionView con nuevos resultados de búsqueda
        // searchResultsCollectionView.ItemsSource = PerformSearch(searchText);
    }
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