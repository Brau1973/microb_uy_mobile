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

        private string _bannerImg;
        public string BannerImg
        {
            get
            {
                // Retorna la imagen predeterminada si _perfilImg no está establecida
                return string.IsNullOrEmpty(_bannerImg) ? "diego_forlan.jpg" : _bannerImg;
            }
            set
            {
                _bannerImg = value;
            }
        }

        private string _perfilImg;
        public string PerfilImg
        {
            get
            {
                // Retorna la imagen predeterminada si _perfilImg no está establecida
                return string.IsNullOrEmpty(_perfilImg) ? "default_user.png" : _perfilImg;
            }
            set
            {
                _perfilImg = value;
            }
        }
    }
}
