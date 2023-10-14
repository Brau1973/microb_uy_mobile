namespace microb_uy_mobile.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();

        // Ocultar completamente la barra de navegación en la página de inicio
        NavigationPage.SetHasNavigationBar(this, false);

        // Instancia el modelo de vista
        HomePageViewModel viewModel = new HomePageViewModel();

        // Asigna el modelo de vista como contexto de datos para la página
        this.BindingContext = viewModel;
    }

}