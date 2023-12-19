using microb_uy_mobile.DTOs;
using microb_uy_mobile.ViewModels;

namespace microb_uy_mobile.Pages.MainTenant.SearchPages;

public partial class SearchUsersPage : ContentPage
{
	public SearchUsersPage()
	{
		InitializeComponent();
        BindingContext = new SearchUsersViewModel();
    }

    private async void OnFrameUserTapped(object sender, EventArgs e)
    {
        if (sender is Frame tappedFrame)
        {
            if (tappedFrame.BindingContext is UserDto selectedUser)
            {
                await Navigation.PushAsync(new UserDetailPage(selectedUser));
            }
        }
    }
}