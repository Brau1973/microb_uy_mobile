using System.Collections.ObjectModel;
using microb_uy_mobile.DTOs;

namespace microb_uy_mobile.ViewModels.Integrations
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

        public async Task GetIntegratedInstances()
        {
            Instances = new ObservableCollection<InstanceDTO>
                {
                new InstanceDTO(1, "Integrada 1", "URL1", "Deporte", "LIGHT", "Abierta", false),
                new InstanceDTO(2, "Integrada 2", "URL2", "Militar", "LIGHT", "Abierta", false),
                new InstanceDTO(3, "Integrada 3", "URL3", "Política", "LIGHT", "Abierta", false),
                };
        }

    }
}
