using System.Collections.ObjectModel;
using microb_uy_mobile.DTOs;
using Refit;

namespace microb_uy_mobile.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<TenantDto> instances;

        public ObservableCollection<TenantDto> Instances
        {
            get { return instances; }
            set
            {
                instances = value;
                OnPropertyChanged();
            }
        }

        public async Task GetInstances()
        {
            try
            {
                var api = RestService.For<IInstanceService>("https://backoffice.web.microb-uy.lat"); //http://10.0.2.2:5067
                var instancesResponse = await api.GetInstancesAsync();

                if (instancesResponse != null)
                {
                    Instances = new ObservableCollection<TenantDto>(instancesResponse.Response.Results);
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
