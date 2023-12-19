using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microb_uy_mobile.DTOs.Base
{
    public class BaseApiResponseNoPaginationInfo<T>
    {
        public string Mensaje { get; set; }
        public T Response { get; set; }
    }
}