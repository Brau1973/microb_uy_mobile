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

        public TenantDto(){}

        public TenantDto(int id, string nombre, string url, List<TematicaDto> tematicas,
            string paleta, string tipoRegistro, bool estado)
        {
            Id = id;
            Nombre = nombre;
            URL = url;
            Tematicas = tematicas;
            PaletaColor = paleta;
            TipoRegistro = tipoRegistro;
            Estado = estado;
        }
    }
}
