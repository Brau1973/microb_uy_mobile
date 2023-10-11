namespace microb_uy_mobile.DTOs
{
    public class InstanciaDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public InstanciaDTO(string name, string image, string description)
        {
            Name = name;
            Image = image;
            Description = description;
        }
    }
}
