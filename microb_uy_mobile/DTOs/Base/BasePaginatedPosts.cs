using System;
using System.Collections.Generic;
namespace microb_uy_mobile.DTOs.Base
{
    public class BasePaginatedPosts<T>
    {
        public string NextPage { get; set; }
        public T[] Results { get; set; }
    }
}
