namespace microb_uy_mobile.DTOs
{
    public class TenantDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string URL { get; set; }
        public List<TematicaDto> Tematicas { get; set; }
        public string PaletaColor { get; set; }
        public string TipoRegistro { get; set; }
        public bool Estado { get; set; }
        public string BannerImg { get; set; }

        private string _perfilImg;
        public string PerfilImg
        {
            get
            {
                // Retorna la imagen predeterminada si _perfilImg no está establecida
                return string.IsNullOrEmpty(_perfilImg) ? "default_foro.jpg" : _perfilImg;
            }
            set
            {
                _perfilImg = value;
            }
        }
        public List<IntegracionWSDto> Integraccion { get; set; }
        public TenantDto(){}

        public TenantDto(int id, string nombre, string url, List<TematicaDto> tematicas,
            string paleta, string tipoRegistro, bool estado, string bannerImg, string perfilImg, List<IntegracionWSDto> integraciones)
        {
            Id = id;
            Nombre = nombre;
            URL = url;
            Tematicas = tematicas;
            PaletaColor = paleta;
            TipoRegistro = tipoRegistro;
            Estado = estado;
            BannerImg = bannerImg;
            PerfilImg = perfilImg;
            Integraccion = integraciones;
        }
    }
}
