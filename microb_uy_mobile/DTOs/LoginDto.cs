using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microb_uy_mobile.DTOs
{
    public class LoginDto
    {
        public bool Success { get; set; }
        public string Accion { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
