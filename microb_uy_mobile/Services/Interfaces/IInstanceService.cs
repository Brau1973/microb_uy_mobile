using microb_uy_mobile.DTOs;
using Refit;

internal interface IInstanceService
{
    [Get("/api/tenants")]
    Task <BaseResponseDTO<InstanceDTO>> GetInstancesAsync();
}