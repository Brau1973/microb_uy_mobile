using microb_uy_mobile.DTOs;
using microb_uy_mobile.DTOs.Base;
using Refit;

namespace microb_uy_mobile.Services.Interfaces
{
    public interface IUsuariosService
    {
        [Get("/api/usuarios")]
        Task<BaseApiResponseDTO<UserDto>> GetUsuarios(
            [Header("Authorization")] string authorization,
            [Query] int tenantid,
            [Query] int page = 1,
            [Query] int pageSize = 10,
            [Query] string searchText = "");

        [Put("/api/usuarios/SeguirUsuario")]
        Task<bool> SeguirUsuario([Query] int idOrigen, [Query] int idDestino, [Query] int tenantOrigen, [Query] int tenantDestino);

        [Put("/api/usuarios/DejarDeSeguirUsuario")]
        Task<bool> DejarDeSeguirUsuario([Query] int idOrigen, [Query] int idDestino, [Query] int tenantOrigen, [Query] int tenantDestino);

        [Get("/api/usuarios/{tenantid}/integrados/{tenantIdTarjet}")]
        Task<BaseApiResponseDTO<UserDto>> GetUsuariosIntegrados(
            [Header("Authorization")] string authorization,
            [AliasAs("tenantid")] int tenantid,
            [AliasAs("tenantIdTarjet")] int tenantIdTarjet,
            [Query] int page = 1,
            [Query] int pageSize = 10,
            [Query] string searchText = "");

        // Define el endpoint para obtener un usuario por email y tenantid
        [Get("/api/usuarios/getuserMail")]
        Task<UserDto> GetUsuarioMail([Query] string email, [Query] int tenantid);

        // Método para dar "like"
        [Put("/api/usuarios/likes")]
        Task<bool> Like(
            [Header("Authorization")] string authorization,
            [Query] int idUOrigen,
            [Query] int idPDestino,
            [Query] int tenantOrigen,
            [Query] int tenantPost);

        // Método para remover "like"
        [Put("/api/usuarios/removelike")]
        Task<bool> RemoveLike(
            [Header("Authorization")] string authorization,
            [Query] int idUOrigen,
            [Query] int idPDestino,
            [Query] int tenantOrigen,
            [Query] int tenantPost);
    }
}
