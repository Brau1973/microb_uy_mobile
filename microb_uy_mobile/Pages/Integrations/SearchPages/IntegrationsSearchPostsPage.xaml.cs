using microb_uy_mobile.DTOs;
using microb_uy_mobile.ViewModels.Integrations;

namespace microb_uy_mobile.Pages.Integrations.SearchPages;

public partial class IntegrationsSearchPostsPage : ContentPage
{
	public IntegrationsSearchPostsPage()
	{
		InitializeComponent();
        // Ocultar completamente la barra de navegaci�n
        NavigationPage.SetHasNavigationBar(this, false);

        // Instancia el modelo de vista
        IntegrationsSearchPostsPageViewModel viewModel = new();

        // Asigna el modelo de vista como contexto de datos para la p�gina
        this.BindingContext = viewModel;
    }

    public async void OnPostItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is PostDTOOld selectedPost)
        {
            await Navigation.PushAsync(new IntegrationsPostDetailPage(selectedPost)); // Pasa el post seleccionado a la p�gina de detalles
        }
        // Desmarca el elemento seleccionado
        ((CollectionView)sender).SelectedItem = null;
    }
}