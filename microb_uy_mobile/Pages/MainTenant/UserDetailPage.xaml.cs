using microb_uy_mobile.DTOs;

namespace microb_uy_mobile.Pages.MainTenant;

public partial class UserDetailPage : ContentPage
{
    private UserDto _userDto;
    public UserDetailPage(UserDto userDto)
	{
		InitializeComponent();
		_userDto = userDto;

		this.BindingContext = _userDto;
	}
    private async void OnFollowButtonClicked(object sender, EventArgs e)
    {
        // Aquí puedes implementar la lógica para seguir o dejar de seguir al usuario
        // Puedes utilizar servicios, cambiar propiedades, o realizar llamadas a la API, según tus necesidades.

        // Ejemplo: Cambiar el texto del botón después de seguir
        var button = sender as Button;
        if (button != null)
        {
            // Simular un cambio en el estado de seguir/dejar de seguir
            if (button.Text == "Seguir")
            {
                button.Text = "Dejar de seguir";
                // Aquí podrías realizar la lógica para seguir al usuario
            }
            else
            {
                button.Text = "Seguir";
                // Aquí podrías realizar la lógica para dejar de seguir al usuario
            }
        }
    }

}