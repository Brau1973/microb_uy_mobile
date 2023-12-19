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
            [Header("Authorization")] string authorization,
            [Query] int tenantid,
            [Query] int page = 1,
            [Query] int pageSize = 10,
            [Query] string searchText = "");

        [Get("/api/HashTag/{tenantid}/Integrados/{tenantIdTarjet}/Busqueda")]
        Task<BaseApiResponseDTO<HashTagDto>> GetHashtagsIntegrados(
            [Header("Authorization")] string authorization,
            [AliasAs("tenantid")] int tenantid,
            [AliasAs("tenantIdTarjet")] int tenantIdTarjet,
            [Query] string searchText = "",
            [Query] int page = 1,
            [Query] int pageSize = 10);

        // Obtiene una lista de posts asociados a un hashtag específico.
        [Get("/api/HashTag/hashtags/{nameHT}/{tenantid}/posts")]
        Task<IEnumerable<PostDto>> GetPosts(
            [Header("Authorization")] string authorization, 
            string nameHT,
            [Query] int tenantid);
    }

}
