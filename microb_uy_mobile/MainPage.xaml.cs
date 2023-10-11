using microb_uy_mobile;
using microb_uy_mobile.DTOs;
using microb_uy_mobile.Pages;
using System.Collections.ObjectModel;

namespace microb_uy_mobile;

public partial class MainPage : ContentPage
{
    public ObservableCollection<InstanciaDTO> Instancias { get; set; }

    public MainPage()
    {
        InitializeComponent();

        Instancias = new ObservableCollection<InstanciaDTO>
        {
            new InstanciaDTO("Futbol", "diego_forlan.jpg", "Futbol en general"),
            new InstanciaDTO("Politica", "diego_forlan.jpg", "Quien mato a nisman"),
            new InstanciaDTO("Tech", "diego_forlan.jpg", "Todo sobre tecnologia"),
            new InstanciaDTO("Bares", "diego_forlan.jpg", "Bares copados"),
            new InstanciaDTO("Trabajos", "diego_forlan.jpg", "Trabajos remotos"),
            new InstanciaDTO("Vacaciones", "diego_forlan.jpg", "Lugares para vacacionar")

    };

        BindingContext = this;
    }

    private async void OnFrameTapped(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new LoginPage());
        await Navigation.PushAsync(new TabMenu());
    }

}