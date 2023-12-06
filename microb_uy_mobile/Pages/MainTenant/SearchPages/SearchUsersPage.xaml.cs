using microb_uy_mobile.DTOs;

namespace microb_uy_mobile.Pages.MainTenant.SearchPages;

public partial class SearchUsersPage : ContentPage
{
	public SearchUsersPage()
	{
		InitializeComponent();
        LoadSampleUsuarios();
    }

    public async void OnUserSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is UserDto selectedUser)
        {
            await Navigation.PushAsync(new UserDetailPage(selectedUser));
        }
        // Desmarca el elemento seleccionado
        ((CollectionView)sender).SelectedItem = null;
    }

    private async void OnFrameTapped(object sender, EventArgs e)
    {
        if (sender is Frame tappedFrame)
        {
            if (tappedFrame.BindingContext is UserDto selectedUser)
            {
                await Navigation.PushAsync(new UserDetailPage(selectedUser));
            }
        }
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
                Id = 1,
                Nombre = "JohnDoe",
                Email = "john.doe@example.com",
                Biografia = "Software Engineer, Tech Enthusiast",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 2,
                Nombre = "JaneSmith",
                Email = "jane.smith@example.com",
                Biografia = "Designer and Creative Thinker",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 3,
                Nombre = "AlexJohnson",
                Email = "alex.johnson@example.com",
                Biografia = "Coffee Lover and Developer",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 4,
                Nombre = "EmilyDavis",
                Email = "emily.davis@example.com",
                Biografia = "Nature Explorer and Photographer",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 5,
                Nombre = "RobertWilson",
                Email = "robert.wilson@example.com",
                Biografia = "Gamer and Streamer",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 6,
                Nombre = "LindaMartin",
                Email = "linda.martin@example.com",
                Biografia = "Foodie and Traveler",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 7,
                Nombre = "MichaelBrown",
                Email = "michael.brown@example.com",
                Biografia = "Bookworm and History Buff",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 8,
                Nombre = "SarahLee",
                Email = "sarah.lee@example.com",
                Biografia = "Fitness Enthusiast and Nutritionist",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 9,
                Nombre = "ChrisHall",
                Email = "chris.hall@example.com",
                Biografia = "Musician and Songwriter",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 10,
                Nombre = "MeganWhite",
                Email = "megan.white@example.com",
                Biografia = "Art Lover and Painter",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 11,
                Nombre = "WilliamClark",
                Email = "william.clark@example.com",
                Biografia = "Pet Lover and Animal Rights Advocate",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 12,
                Nombre = "OliviaLewis",
                Email = "olivia.lewis@example.com",
                Biografia = "Movie Buff and Cinephile",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 13,
                Nombre = "DanielYoung",
                Email = "daniel.young@example.com",
                Biografia = "Hiker and Outdoor Enthusiast",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 14,
                Nombre = "AvaHarris",
                Email = "ava.harris@example.com",
                Biografia = "Fashionista and Stylist",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            },
            new UserDto
            {
                Id = 15,
                Nombre = "JamesTurner",
                Email = "james.turner@example.com",
                Biografia = "Tech Geek and Coding Ninja",
                PerfilImg = "diego_forlan.jpg",
                // Otros campos...
            }
        };
        foreach (var userDto in (List<UserDto>)SearchResultsUsuarios.ItemsSource)
        {
            userDto.BannerImg = "https://pbs.twimg.com/media/D-jnKUPU4AE3hVR.jpg";  // Reemplaza con tu valor común para BannerImg
            userDto.Rol = "Usuario Común";  // Reemplaza con tu valor común para Rol
            userDto.Ubicacion = "Ubicación Común";  // Reemplaza con tu valor común para Ubicacion
            userDto.Ocupacion = "Ocupación Común";  // Reemplaza con tu valor común para Ocupacion
            userDto.Nickname = "Nickname";
        }
    }
}