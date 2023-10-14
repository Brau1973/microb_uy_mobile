using microb_uy_mobile.DTOs;
using System.Collections.ObjectModel;

namespace microb_uy_mobile.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        private ObservableCollection<InstanciaDTO> instancias;

        public ObservableCollection<InstanciaDTO> Instancias
        {
            get { return instancias; }
            set
            {
                instancias = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            Instancias = new ObservableCollection<InstanciaDTO>
            {
                new InstanciaDTO("Futbol", "diego_forlan.jpg", "Futbol en general y me paso de largo lalala"),
                new InstanciaDTO("Politica", "diego_forlan.jpg", "Quien mato a nisman"),
                new InstanciaDTO("Tech", "diego_forlan.jpg", "Todo sobre tecnologia"),
                new InstanciaDTO("Bares", "diego_forlan.jpg", "Bares copados"),
                new InstanciaDTO("Trabajos", "diego_forlan.jpg", "Trabajos remotos"),
                new InstanciaDTO("Vacaciones", "diego_forlan.jpg", "Lugares para vacacionar")
            };
        }
    }
}
