namespace microb_uy_mobile.DTOs
{
    public class InstanceDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public string Tematica { get; set; }
        public string PaletaColor { get; set; }
        public string TipoRegistro { get; set; }
        public bool Estado { get; set; }

        public InstanceDTO(int id, string nombre, string url, string tematica, string paletaColor, string tipoRegistro, bool estado)
        {
            Id = id;
            Nombre = nombre;
            Url = url;
            Tematica = tematica;
            PaletaColor = paletaColor;
            TipoRegistro = tipoRegistro;
            Estado = estado;
        }
    }
}
