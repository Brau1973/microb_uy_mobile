using microb_uy_mobile.ViewModels;

namespace microb_uy_mobile.Pages;

public partial class SearchPage : ContentPage
{
    public SearchPage()
    {
        InitializeComponent();

        // Ocultar completamente la barra de navegación en la página de inicio
        NavigationPage.SetHasNavigationBar(this, false);

        // Instancia el ViewModel y asígnalo como contexto de datos de la página
        var viewModel = new SearchPageViewModel();
        BindingContext = viewModel;
    }
}