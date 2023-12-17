namespace microb_uy_mobile.DTOs
{
    public class CrearPostDto
    {
        public string MailAutor { get; set; }
        public DateTime Fecha { get; set; }
        public string Title { get; set; }
        public string Contenido { get; set; }
        public string TipoPost { get; set; } = "NORMAL";
        public int RepostId { get; set; } = 0;
        public int TenantidRepost { get; set; }
        public List<CrearHashTag> HashTags { get; set; } = new List<CrearHashTag>();
        public int Tenantid { get; set; }

        public CrearPostDto()
        {
        }

    }
}
