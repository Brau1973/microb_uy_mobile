using System.Collections.ObjectModel;
using microb_uy_mobile.DTOs;
using Refit;

namespace microb_uy_mobile.ViewModels
{
    public class MainPageViewModel : BaseViewModel
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
