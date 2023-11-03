using System.Collections.ObjectModel;
using microb_uy_mobile.DTOs;
using Refit;

namespace microb_uy_mobile.Integrations.ViewModels
{
    public class IntegrationsMainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Response> instancias;

        public ObservableCollection<Response> Instancias
        {
            get { return instancias; }
            set
            {
                instancias = value;
                OnPropertyChanged();
            }
        }

        public async Task GetInstancias()
        {
            try
            {

                //InstanciasHardCode = new ObservableCollection<InstanciaDTO>
                //{
                //    new InstanciaDTO("Futbol", "diego_forlan.jpg", "Futbol en general y me paso de largo lalala"),
                //    new InstanciaDTO("Politica", "diego_forlan.jpg", "Quien mato a nisman"),
                //    new InstanciaDTO("Tech", "diego_forlan.jpg", "Todo sobre tecnologia"),
                //    new InstanciaDTO("Bares", "diego_forlan.jpg", "Bares copados"),
                //    new InstanciaDTO("Trabajos", "diego_forlan.jpg", "Trabajos remotos"),
                //    new InstanciaDTO("Vacaciones", "diego_forlan.jpg", "Lugares para vacacionar")
                //};

                var api = RestService.For<IInstanciaService>("http://10.0.2.2:5067");
                var instanciasResponse = await api.GetInstanciasAsync();

                if (instanciasResponse != null)
                {
                    Instancias = new ObservableCollection<Response>(instanciasResponse.Response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: "+ex.ToString());
                // Manejo de errores
            }
        }
    }
}
