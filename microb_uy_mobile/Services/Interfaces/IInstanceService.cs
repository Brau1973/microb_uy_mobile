using microb_uy_mobile.DTOs;
using microb_uy_mobile.DTOs.Base;
using Refit;

internal interface IInstanceService
{
    [Get("/api/tenants")]
    Task <BaseApiResponseDTO<TenantDto>> GetInstancesAsync();

    [Get("/{id}")]
    Task<BaseApiResponseNoPaginationInfo<TenantDto>> GetTenantById(int id);
}