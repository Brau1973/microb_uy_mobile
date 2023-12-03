using microb_uy_mobile.ViewModels;

namespace microb_uy_mobile.Pages.MainTenant.SearchPages;

public partial class SearchHashtagsPage : ContentPage
{
    public SearchHashtagsPage()
    {
        InitializeComponent();
        BindingContext = new SearchHashtagsViewModel();
    }
}