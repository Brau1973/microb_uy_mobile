using System.Collections.ObjectModel;
using microb_uy_mobile.DTOs;
using Refit;

namespace microb_uy_mobile.ViewModels
{
    public class IntegrationsMainPageViewModel : BaseViewModel
    {
        private ObservableCollection<InstanceDTO> instances;

        public ObservableCollection<InstanceDTO> Instances
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
                var api = RestService.For<IInstanceService>("http://10.0.2.2:5067");
                var instancesResponse = await api.GetInstancesAsync();

                if (instancesResponse != null)
                {
                    Instances = new ObservableCollection<InstanceDTO>(instancesResponse.Response);
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
