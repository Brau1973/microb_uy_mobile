using microb_uy_mobile.DTOs;

namespace microb_uy_mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {

        private HomePageViewModel homePageViewModel;

        public SearchPage()
        {
            InitializeComponent();
            // Ocultar completamente la barra de navegación en la página de inicio

            HomePageViewModel homePageViewModel;

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void OnTabSelected(object sender, EventArgs e)
        {
            Button selectedButton = (Button)sender;

            // Reiniciar todos los botones para que no estén resaltados
            PostsButton.BackgroundColor = Color.FromArgb("D3D3D3"); // Grey
            HashtagsButton.BackgroundColor = Color.FromArgb("D3D3D3");
            UsuariosButton.BackgroundColor = Color.FromArgb("D3D3D3");

            PostsButton.TextColor = Color.FromArgb("80808080");
            HashtagsButton.TextColor = Color.FromArgb("80808080");
            UsuariosButton.TextColor = Color.FromArgb("80808080");

            // Resaltar el botón seleccionado
            selectedButton.BackgroundColor = Color.FromArgb("7928CA");
            selectedButton.TextColor = Color.FromArgb("FFFFFFFF"); // White

            // Oculta todas las CollectionView
            SearchResultsPosts.IsVisible = false;
            SearchResultsHashtags.IsVisible = false;
            SearchResultsUsuarios.IsVisible = false;

            // Obtiene el botón seleccionado
            var button = sender as Button;

            // Determina cuál CollectionView debe mostrarse según la pestaña seleccionada
            if (button.Text == "Posts")
            {
                SearchResultsPosts.IsVisible = true;
                LoadSamplePublicaciones(); // Carga datos de ejemplo para publicaciones
            }
            else if (button.Text == "Hashtags")
            {
                SearchResultsHashtags.IsVisible = true;
                LoadSampleHashtags(); // Carga datos de ejemplo para hashtags
            }
            else if (button.Text == "Usuarios")
            {
                SearchResultsUsuarios.IsVisible = true;
                LoadSampleUsuarios(); // Carga datos de ejemplo para usuarios
            }
        }

        // Función para cargar datos de ejemplo en la CollectionView de Publicaciones
        private void LoadSamplePublicaciones()
        {
            this.homePageViewModel = new HomePageViewModel();
            SearchResultsPosts.ItemsSource = homePageViewModel.Posts;

            //SearchResultsPosts.ItemsSource = new List<string>
            //{
            //    "Publicación 1",
            //    "Publicación 2",
            //    "Publicación 3",
            //    "Publicación 4",
            //};
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

        // -------------------------------------------------------copia rancia para linked in---------------------------------------------
        private async void OnPostContentTapped(object sender, EventArgs e)
        {
            // Obtén el post seleccionado (puedes utilizar el BindingContext o alguna otra lógica)
            //var selectedPost = ...; // Obtén el post seleccionado
            //await DisplayAlert("Info", "OnPostContentTapped", "OK");
            // Navega a la página de detalle del post y pasa el post seleccionado
            await Navigation.PushAsync(new PostDetailPage());
        }


        private void OnRetweetIconTapped(object sender, EventArgs e)
        {
            DisplayAlert("Info", "Retweet", "OK");
            // Lógica para manejar el retweet
        }

        private void OnLikeIconTapped(object sender, EventArgs e)
        {
            DisplayAlert("Info", "Like", "OK");
            // Lógica para manejar el "Me gusta"
        }
    }
}
