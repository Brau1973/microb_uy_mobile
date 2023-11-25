namespace microb_uy_mobile.DTOs;

public class TematicaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public TematicaDto() { }
    public TematicaDto(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }
}
