namespace microb_uy_mobile.DTOs.Base
{
    public class BaseApiResponseDTO<T>
    {
        public string Mensaje { get; set; }
        public BaseResponseDTO<T> Response { get; set; }
    }
}
