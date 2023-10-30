using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microb_uy_mobile.DTOs
{
    class DefaultReponseDTO
    {

        public class Rootobject
        {
            public string mensaje { get; set; }
            public Response[] response { get; set; }
        }

        public class Response
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public string url { get; set; }
            public string tematica { get; set; }
            public string paletaColor { get; set; }
            public string tipoRegistro { get; set; }
            public bool estado { get; set; }
        }

    }
}
