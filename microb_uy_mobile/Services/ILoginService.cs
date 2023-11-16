using microb_uy_mobile.DTOs;
using Refit;

namespace microb_uy_mobile.Services
{
internal interface ILoginService
    {
        [Get("/api/iniciosesion/iniciar_sesion")]
        Task<string> InternalLogin(string email, int instanciaid, string password);
    }
}
