namespace microb_uy_mobile.DTOs
{
    public class InstanciaDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string image { get; set; }
        public string url { get; set; }

        public InstanciaDTO(string nombre, string image, string url)
        {
            this.nombre = nombre;
            this.image = image;
            this.url = url;
        }
    }
}
