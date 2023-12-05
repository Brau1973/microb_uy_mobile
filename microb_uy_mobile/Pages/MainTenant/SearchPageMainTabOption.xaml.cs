namespace microb_uy_mobile.Pages.MainTenant.SearchPages
{
    public partial class SearchPageMainTabOption : ContentPage
    {
        public SearchPageMainTabOption()
        {
            InitializeComponent();
            // Ocultar completamente la barra de navegación
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private async void OnButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchTabMenu());
        }
    }
}
