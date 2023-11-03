using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microb_uy_mobile.DTOs
{
    public class DefaultResponseDTO
    {
        public string Mensaje { get; set; }
        public Response[] Response { get; set; }
    }

    public class Response
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public string Tematica { get; set; }
        public string PaletaColor { get; set; }
        public string TipoRegistro { get; set; }
        public bool Estado { get; set; }
    }
}
