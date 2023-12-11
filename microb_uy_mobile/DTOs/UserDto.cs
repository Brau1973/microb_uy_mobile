namespace microb_uy_mobile.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string Ocupacion { get; set; }
        public string Ubicacion { get; set; }
        public string Biografia { get; set; }
        public string Nickname { get; set; }
        public string Rol { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int TenantId { get; set; }
        public string BannerImg { get; set; }
        public string PerfilImg { get; set; }
    }
}
