using System.Collections.ObjectModel;
using System.Threading.Tasks;
using microb_uy_mobile.DTOs;
using microb_uy_mobile.Helpers;
using Refit;
using System;

namespace microb_uy_mobile.ViewModels.Integrations
{
    public class IntegrationsMainPageViewModel : BaseViewModel
    {
        private readonly string BaseApiUrl = (string)App.SessionInfo["BaseUrl"];
        private readonly int TenantId = (int)App.SessionInfo["MainTenantId"];

        private ObservableCollection<IntegracionDto> instances;
        public ObservableCollection<IntegracionDto> Instances
        {
            get => instances;
            set => SetProperty(ref instances, value);
        }

        private bool isLabelVisible;
        public bool IsLabelVisible
        {
            get => isLabelVisible;
            set => SetProperty(ref isLabelVisible, value);
        }

        public IntegrationsMainPageViewModel()
        {
        }

        public async Task LoadIntegratedInstances()
        {
            try
            {
                var tenantDto = await DownloadIntegratedInstances();
                if (tenantDto.Integraccion.Count > 0)
                {
                    Instances = new ObservableCollection<IntegracionDto>(
                        IntegracionMapper.MapToIntegracionDtoList(tenantDto.Integraccion));
                    IsLabelVisible = false;
                }
                else
                {
                    Instances.Clear();
                    IsLabelVisible = true;
                }

            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente (por ejemplo, mostrar un mensaje al usuario)
                Console.WriteLine($"Error al descargar instancias integradas: {ex.Message}");
                IsLabelVisible = true;
            }
        }

        private async Task<TenantDto> DownloadIntegratedInstances()
        {
            try
            {
                var api = RestService.For<IInstanceService>(BaseApiUrl);
                var response = await api.GetTenantById(TenantId);
                if (response != null && response.Mensaje.Equals("Ok")){
                    return response.Response;
                }else
                    return null;
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente
                Console.WriteLine($"Error al realizar la solicitud API: {ex.Message}");
                return null;
            }
        }
    }
}
