using microb_uy_mobile.DTOs;
using microb_uy_mobile.DTOs.Base;
using Refit;

namespace microb_uy_mobile.Services.Interfaces
{
    public interface IHashTagService
    {
        // Obtiene una lista paginada de Hashtags pertenecientes a la instancia según los criterios de búsqueda.
        [Get("/api/HashTag")]
        Task<BaseApiResponseDTO<HashTagDto>> GetHashtags(
            [Query] int tenantid,
            [Query] int page = 1,
            [Query] int pageSize = 10,
            [Query] string searchText = "");

        // Obtiene una lista de posts asociados a un hashtag específico.
        [Get("/api/HashTag/hashtags/{nameHT}/{tenantid}/posts")]
        Task<IEnumerable<PostDto>> GetPosts(string nameHT, [Query] int tenantid);
    }

}
