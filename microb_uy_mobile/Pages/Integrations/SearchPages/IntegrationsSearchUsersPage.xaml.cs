using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages.MainTenant;
using microb_uy_mobile.ViewModels.Integrations;

namespace microb_uy_mobile.Pages.Integrations.SearchPages;

public partial class IntegrationsSearchUsersPage : ContentPage
{
	public IntegrationsSearchUsersPage()
	{
		InitializeComponent();
        // Ocultar completamente la barra de navegación
        NavigationPage.SetHasNavigationBar(this, false);

        BindingContext = new IntegrationsSearchUsersViewModel();
    }

    private async void OnFrameUserTapped(object sender, EventArgs e)
    {
        if (sender is Frame tappedFrame)
        {
            if (tappedFrame.BindingContext is UserDto selectedUser)
            {
                //TO DO: CAMBIAR ESTA PANTALLA PARA UNA PERSONALIZADA DE INTEGRATIONS?
                await Navigation.PushAsync(new UserDetailPage(selectedUser));
            }
        }
    }
}