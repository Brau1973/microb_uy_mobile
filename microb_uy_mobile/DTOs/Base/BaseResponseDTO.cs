using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microb_uy_mobile.DTOs
{
    public class BaseResponseDTO<T>
    {
        public BasePaginationInfoDTO Info { get; set; }
        public T[] Results { get; set; }
    }
}
