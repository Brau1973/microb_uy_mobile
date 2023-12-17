using microb_uy_mobile.DTOs;
using microb_uy_mobile.DTOs.Base;
using Refit;

// Interfaz que define las operaciones disponibles en el servicio de posts
internal interface IPostService
{
    //// Obtiene una lista de posts denunciados para un tenant específico
    //[Get("/api/posts/Denuncias")]
    //Task<IEnumerable<PostDto>> GetPostsD([Query, AliasAs("tenantId")] int tenantId);

    // Obtiene una lista paginada de posts para un tenant específico
    [Get("/api/Posts")]
    Task<BasePaginatedPosts<PostDto>> GetPaginatedPosts(int tenantId, int pageSize = 10, int? lastId = null, string searchText = "", int idUsuer = 0, int tenantUser = 0);

    //// Obtiene un post por su Id y tenant específicos
    //[Get("/api/Posts/{id}")]
    //Task<PostDto> GetPost(int id, [Query, AliasAs("tenantId")] int tenantId);

    // Crea un nuevo post para un tenant específico
    [Post("/api/Posts")]
    Task<PostDto> PostPost([Body] CrearPostDto postDto, [Query, AliasAs("tenantId")] int tenantId);

    //// Elimina un post por su Id y tenant específicos
    //[Delete("/api/Posts/{id}")]
    //Task<bool> DeletePost(int id, [Query, AliasAs("tenantId")] int tenantId);

    //// Crea un nuevo post de respuesta para un post específico y tenant
    //[Post("/api/Posts/{PostId}/respuestas")]
    //Task<PostDto> RespuestaPost(int PostId, [Body] CrearPostDto postDto, [Query, AliasAs("tenantId")] int tenantId);

    //// Obtiene una lista de respuestas para un post específico y tenant
    //[Get("/api/Posts/{PostId}/respuestas")]
    //Task<IEnumerable<PostDto>> GetRespuestaPost(int PostId, int tenantId, int pageSize = 10, int? lastId = null, string searchText = "", int idUser = 0, int tenantUser = 0);

    //// Obtiene una lista de posts a los que sigue un usuario específico y tenant
    //[Get("/api/posts/seguidos")]
    //Task<PaginatedList<PostDto>> GetPaginatedPostsSeguidos(int userid, int tenantId, int pageSize = 10, int? lastId = null, string searchText = "");

    // Añadir otros métodos según las definiciones en tu controlador...
}
