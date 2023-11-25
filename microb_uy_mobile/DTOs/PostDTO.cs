namespace microb_uy_mobile.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string MailAutor { get; set; }
        public DateTime Fecha { get; set; }
        public string Contenido { get; set; }
        public string TipoPost { get; set; }
        public List<HashTagDto> HashTags { get; set; } = new List<HashTagDto>();
        public int Likes { get; set; }
        public int CantRespuestas { get; set; }
        public int Tenantid { get; set; }

        // Constructor por defecto
        public PostDto()
        {
            // Puedes inicializar propiedades predeterminadas aquí si es necesario.
        }

        // Constructor con parámetros para facilitar la creación de instancias
        public PostDto(int id, string autor, string mailAutor, DateTime fecha, string contenido, string tipoPost, List<HashTagDto> hashTags, int likes, int cantRespuestas, int tenantid)
        {
            Id = id;
            Autor = autor;
            MailAutor = mailAutor;
            Fecha = fecha;
            Contenido = contenido;
            TipoPost = tipoPost;
            HashTags = hashTags;
            Likes = likes;
            CantRespuestas = cantRespuestas;
            Tenantid = tenantid;
        }
    }
}
