using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages;
using microb_uy_mobile.ViewModels;

namespace microb_uy_mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();
            // Ocultar completamente la barra de navegación
            NavigationPage.SetHasNavigationBar(this, false);

            //LoadSampleInstances();

            ViewModel = new MainPageViewModel();

            BindingContext = ViewModel;
        }

        private async void OnCardTapped(object sender, EventArgs e)
        {
            // Obtener la InstanciaDTO seleccionada
            var selectedInstancia = ((Frame)sender).BindingContext as InstanceDTO;

            // Navegar a la página de inicio de sesión (LoginPage) o realizar otra acción
            // Ejemplo: await Navigation.PushAsync(new LoginPage(selectedInstancia));
            await Navigation.PushAsync(new LoginPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.GetInstances();
        }

        private void LoadSampleInstances()
        {
            InstancesCollectionView.ItemsSource = new List<InstanceDTO>
            {
                new InstanceDTO(1, "Instancia 1", "https://example.com/instancia1", "Tematica 1", "#FF5733", "Registro 1", true),
                new InstanceDTO(2, "Instancia 2", "https://example.com/instancia2", "Tematica 2", "#3366FF", "Registro 2", true),
                new InstanceDTO(3, "Instancia 3", "https://example.com/instancia3", "Tematica 3", "#33FF33", "Registro 3", true),
                new InstanceDTO(4, "Instancia 4", "https://example.com/instancia4", "Tematica 1", "#FF5733", "Registro 1", false),
                new InstanceDTO(5, "Instancia 5", "https://example.com/instancia5", "Tematica 2", "#3366FF", "Registro 2", true),
                new InstanceDTO(6, "Instancia 6", "https://example.com/instancia6", "Tematica 3", "#33FF33", "Registro 3", false),
                new InstanceDTO(7, "Instancia 7", "https://example.com/instancia7", "Tematica 1", "#FF5733", "Registro 1", true),
                new InstanceDTO(8, "Instancia 8", "https://example.com/instancia8", "Tematica 2", "#3366FF", "Registro 2", false)
            };
        }
    }
}
