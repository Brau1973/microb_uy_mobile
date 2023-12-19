using microb_uy_mobile.DTOs;
using Refit;

namespace microb_uy_mobile.Services
{
internal interface ILoginService
    {
        [Post("/api/iniciosesion/iniciar_sesion")]
        Task<LoginDto> InternalLogin(string email, int tenantid, string password);
    }
}
