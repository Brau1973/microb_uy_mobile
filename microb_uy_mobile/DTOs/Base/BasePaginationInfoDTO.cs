namespace microb_uy_mobile.DTOs
{
    public class BasePaginationInfoDTO
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
    }
}
