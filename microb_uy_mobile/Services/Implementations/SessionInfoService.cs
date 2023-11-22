using microb_uy_mobile.Services.Interfaces;

namespace microb_uy_mobile.Services.Implementations
{
    public class SessionInfoService : ISessionInfoService
    {
        public int TenantId { get; set; }
        public int UserId { get; set; }
        public string UserToken { get; set; }
        public int IntegratedTenantId { get; set; }
    }
}
