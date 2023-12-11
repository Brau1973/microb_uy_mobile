using microb_uy_mobile.DTOs;
using microb_uy_mobile.DTOs.Base;
using Refit;

namespace microb_uy_mobile.Services.Interfaces
{
    public interface IUsuariosService
    {
        [Get("/api/usuarios")]
        Task<BaseApiResponseDTO<UserDto>> GetUsuarios(
            [Query] int tenantid,
            [Query] int page = 1,
            [Query] int pageSize = 10,
            [Query] string searchText = "");

        //[Get("/api/usuarios/getuserMail")]
        //Task<ActionResult<UsuarioDto>> GetUsuarioMail(
        //    [Query] string email,
        //    [Query] int tenantid);

        //[Delete("/api/usuarios/{id}")]
        //Task<ActionResult<bool>> DeleteUsuario([Path] int id);

        //[Put("/api/usuarios/{id}/{tenantId}")]
        //Task<ActionResult> EditUsuario([Path] int id, [Path] int tenantId, [Body] EditarPerfil tenantDto);

        //[Put("/api/usuarios/SeguirUsuario")]
        //Task<ActionResult<bool>> SeguirUsuario([Query] int idOrigen, [Query] int idDestino, [Query] int tenantOrigen, [Query] int tenantDestino);

        //[Put("/api/usuarios/DejarDeSeguirUsuario")]
        //Task<ActionResult<bool>> DejarDeSeguirUsuario([Query] int idOrigen, [Query] int idDestino, [Query] int tenantOrigen, [Query] int tenantDestino);

        //[Put("/api/usuarios/BloquearUsuario")]
        //Task<ActionResult<bool>> BloquearUsuario([Query] int idOrigen, [Query] int idDestino, [Query] int tenantOrigen, [Query] int tenantDestino);

        //[Put("/api/usuarios/DesbloquearUsuario")]
        //Task<ActionResult<bool>> DesbloquearUsuario([Query] int idOrigen, [Query] int idDestino, [Query] int tenantOrigen, [Query] int tenantDestino);

        //[Put("/api/usuarios/Banear")]
        //Task<ActionResult<bool>> BanUsuario([Query] int tenantOrigen, [Query] int idUsuer);

        //[Put("/api/usuarios/AprobarUser")]
        //Task<ActionResult<bool>> AprobarUsuario([Query] int tenantOrigen, [Query] int idUsuer);

        //[Get("/api/usuarios/{tenantid}")]
        //Task<ActionResult<PaginatedList<UsuarioDto>>> GetUsuariosPendientes(
        //    [Query] int tenantid,
        //    [Query] int page = 1,
        //    [Query] int pageSize = 10,
        //    [Query] string searchText = "");

        //[Get("/api/usuarios/seguidos/{userId}/{tenantid}")]
        //Task<ActionResult<PaginatedList<UsuarioDto>>> GetUsuariosSeguidos(
        //    [Path] int userId,
        //    [Path] int tenantid,
        //    [Query] int page = 1,
        //    [Query] int pageSize = 10,
        //    [Query] string searchText = "");

        //[Get("/api/usuarios/bloqueados/{userId}/{tenantid}")]
        //Task<ActionResult<PaginatedList<UsuarioDto>>> GetUsuariosBloqueados(
        //    [Path] int userId,
        //    [Path] int tenantid,
        //    [Query] int page = 1,
        //    [Query] int pageSize = 10,
        //    [Query] string searchText = "");

        //[Get("/api/usuarios/{tenantid}/integrados/{tenantIdTarjet}")]
        //Task<ActionResult<PaginatedList<UsuarioDto>>> GetUsuariosIntegrados(
        //    [Query] int tenantid,
        //    [Path] int tenantIdTarjet,
        //    [Query] int page = 1,
        //    [Query] int pageSize = 10,
        //    [Query] string searchText = "");

        //[Get("/api/usuarios/{tenantid}/integrados/{tenantIdTarjet}/Busqueda/{searchText}")]
        //Task<ActionResult<PaginatedList<UsuarioDto>>> GetUsuariosIntegradosB(
        //    [Query] int tenantid,
        //    [Path] int tenantIdTarjet,
        //    [Query] string searchText,
        //    [Query] int page = 1,
        //    [Query] int pageSize = 10);

        //[Get("/api/usuarios/seguidos/{userId}/{tenantid}/integrados/{tenantIdTarjet}")]
        //Task<ActionResult<PaginatedList<UsuarioDto>>> GetUsuariosSAsociados(
        //    [Path] int userId,
        //    [Path] int tenantid,
        //    [Path] int tenantIdTarjet,
        //    [Query] int page = 1,
        //    [Query] int pageSize = 10,
        //    [Query] string searchText = "");

        //[Get("/api/usuarios/bloqueados/{userId}/{tenantid}/integrados/{tenantIdTarjet}")]
        //Task<ActionResult<PaginatedList<UsuarioDto>>> GetUsuariosBAsociados(
        //    [Path] int userId,
        //    [Path] int tenantid,
        //    [Path] int tenantIdTarjet,
        //    [Query] int page = 1,
        //    [Query] int pageSize = 10,
        //    [Query] string searchText = "");
    }
}
