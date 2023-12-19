using microb_uy_mobile.DTOs;
using microb_uy_mobile.ViewModels.Integrations;

namespace microb_uy_mobile.Pages.Integrations;

public partial class IntegrationsHomePage : ContentPage
{
	public IntegrationsHomePage()
	{
		InitializeComponent();

        // Ocultar completamente la barra de navegación
        NavigationPage.SetHasNavigationBar(this, false);

        // Instancia el modelo de vista
        IntegrationsHomePageViewModel viewModel = new();

        // Asigna el modelo de vista como contexto de datos para la página
        this.BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Obtiene el ViewModel desde el BindingContext
        if (BindingContext is IntegrationsHomePageViewModel viewModel)
        {
            // Llama al método que necesitas del ViewModel
            await viewModel.GetPostList();
        }
    }

    public async void OnPostItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is PostDTOOld selectedPost)
        {
            await Navigation.PushAsync(new IntegrationsPostDetailPage(selectedPost)); // Pasa el post seleccionado a la página de detalles
        }
        // Desmarca el elemento seleccionado
        ((CollectionView)sender).SelectedItem = null;
    }

    private async void OnRefreshIconTapped(object sender, EventArgs e)
    {
        var viewModel = BindingContext as IntegrationsHomePageViewModel;
        if (viewModel != null)
        {
            viewModel.IsBusy = true; // Opcional, para mostrar el indicador de carga
            await viewModel.GetPostList();
            viewModel.IsBusy = false;
        }
    }
}