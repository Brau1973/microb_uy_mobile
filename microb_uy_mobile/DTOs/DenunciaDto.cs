namespace microb_uy_mobile.DTOs
{
    public class DenunciaDto
    {
        public int Id { get; set; }
        public string TipoDenuncia { get; set; }
        public int Cantidad { get; set; }
        public DateTime UltimaFecha { get; set; } = DateTime.Now;
        public DateTime InicialFecha { get; set; } = DateTime.Now;
        public int Tenantid { get; set; }
        public PostDto Post { get; set; }

        public DenunciaDto() { }
    }
}
