using System.Collections.ObjectModel;
using microb_uy_mobile.DTOs;

namespace microb_uy_mobile.ViewModels.Integrations
{
    public class IntegrationsMainPageViewModel : BaseViewModel
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

        public async Task GetIntegratedInstances()
        {
            Instances = new ObservableCollection<TenantDto>
                {
                new TenantDto(1, "Integrada 1", "URL1", null, "LIGHT", "Abierta", false),
                new TenantDto(2, "Integrada 2", "URL2", null, "LIGHT", "Abierta", false),
                new TenantDto(3, "Integrada 3", "URL3", null, "LIGHT", "Abierta", false),
                };
        }

    }
}
