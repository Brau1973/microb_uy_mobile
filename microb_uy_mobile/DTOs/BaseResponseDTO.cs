using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microb_uy_mobile.DTOs
{
    internal class BaseResponseDTO<T>
    {
        public string Mensaje { get; set; }
        public T[] Response { get; set; }
        //Solo para adaptarme a la nueva respuesta de api/tenants y que no me falle al iniciar la app
        public int TotalPages { get; set; }
    }
}
