using microb_uy_mobile.DTOs;
using Refit;

internal interface IInstanciaService
{
    [Get("/api/tenants")]
    Task <DefaultResponseDTO> GetInstanciasAsync();
}