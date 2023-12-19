namespace microb_uy_mobile.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Autor { get; set; }

        private string _autorImg;
        public string AutorImg
        {
            get
            {
                // Retorna la imagen predeterminada si _perfilImg no está establecida
                return string.IsNullOrEmpty(_autorImg) ? "default_user.png" : _autorImg;
            }
            set
            {
                _autorImg = value;
            }
        }
        public string MailAutor { get; set; }
        public DateTime Fecha { get; set; }
        public string Title { get; set; }
        public string Contenido { get; set; }
        public string TipoPost { get; set; }
        public PostDto Repost { get; set; }
        public List<HashTagDto> HashTags { get; set; } = new List<HashTagDto>();
        public List<DenunciaDto> Denuncias { get; set; } = new List<DenunciaDto>();
        public int Likes { get; set; }
        public int CantRespuestas { get; set; }
        public int Tenantid { get; set; }
        public bool Likeado { get; set; }

        public PostDto()
        {
        }

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
