namespace microb_uy_mobile.Services.Interfaces
{
    public interface ISessionInfoService
    {
        int TenantId { get; set; }
        int UserId { get; set; }
        string UserToken { get; set; }
        int IntegratedTenantId { get; set; }
    }
}
