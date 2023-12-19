using microb_uy_mobile.DTOs;
using microb_uy_mobile.DTOs.Base;
using Refit;

// Interfaz que define las operaciones disponibles en el servicio de posts
internal interface IPostService
{
    // Obtiene una lista paginada de posts para un tenant específico
    [Get("/api/Posts")]
    Task<BasePaginatedPosts<PostDto>> GetPaginatedPosts([Header("Authorization")] string authorization,int tenantId, int pageSize = 10, int? lastId = null, string searchText = "", int idUsuer = 0, int tenantUser = 0);

    // Crea un nuevo post para un tenant específico
    [Post("/api/Posts")]
    Task<PostDto> PostPost([Header("Authorization")] string authorization, [Body] CrearPostDto postDto,[Query, AliasAs("tenantId")] int tenantId);

    // Crea un nuevo post de respuesta para un post específico y tenant
    [Post("/api/Posts/{PostId}/respuestas")]
    Task<PostDto> RespuestaPost([Header("Authorization")] string authorization, int PostId, [Body] CrearPostDto postDto, [Query, AliasAs("tenantId")] int tenantId);

    // Obtiene una lista de respuestas para un post específico y tenant
    [Get("/api/Posts/{PostId}/respuestas")]
    Task<BasePaginatedPosts<PostDto>> GetRespuestaPost(int PostId, int tenantId, int pageSize = 10, int? lastId = null, string searchText = "", int idUser = 0, int tenantUser = 0);

    [Get("/api/Posts/{tenantId}/Integrados/{tenantIdTarjet}/Post")]
    Task<BasePaginatedPosts<PostDto>> GetPostsIntegrados(
        [AliasAs("tenantId")] int tenantId,
        [AliasAs("tenantIdTarjet")] int tenantIdTarjet,
        [Query] int pageSize = 10,
        [Query] int? lastId = null,
        [Query] int idUser = 0,
        [Query] int tenantUser = 0);

    [Get("/api/Posts/{tenantId}/Integrados/{tenantIdTarjet}/Post/Busqueda/{searchText}")]
    Task<BasePaginatedPosts<PostDto>> GetPostsBusquedaIntegrados(
        [AliasAs("tenantId")] int tenantId,
        [AliasAs("tenantIdTarjet")] int tenantIdTarjet,
        [AliasAs("searchText")] string searchText = "",
        [Query] int pageSize = 10,
        [Query] int? lastId = null,
        [Query] int idUser = 0,
        [Query] int tenantUser = 0);

    [Get("/api/Posts/{PostId}/respuestas/Integrados/{tenantIdTarjet}/respuestas")]
    Task<BasePaginatedPosts<PostDto>> GetRespuestasPostIntegrados(
        [AliasAs("PostId")] int PostId,
        [AliasAs("tenantId")] int tenantId,
        [AliasAs("tenantIdTarjet")] int tenantIdTarjet,
        [Query] int pageSize = 10,
        [Query] string searchText = "",
        [Query] int? lastPostId = null,
        [Query] int idUser = 0,
        [Query] int tenantuser = 0);

}
