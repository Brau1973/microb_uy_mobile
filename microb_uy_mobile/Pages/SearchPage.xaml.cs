using microb_uy_mobile.ViewModels;

namespace microb_uy_mobile.Pages;

public partial class SearchPage : ContentPage
{
    public SearchPage()
    {
        InitializeComponent();

        // Ocultar completamente la barra de navegaci�n en la p�gina de inicio
        NavigationPage.SetHasNavigationBar(this, false);

        // Instancia el ViewModel y as�gnalo como contexto de datos de la p�gina
        var viewModel = new SearchPageViewModel();
        BindingContext = viewModel;
    }
}