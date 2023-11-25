using microb_uy_mobile.DTOs;
using Refit;

// Interfaz que define las operaciones disponibles en el servicio de posts
internal interface IPostService
{
    // Obtiene una lista de posts para un tenant específico
    [Get("/api/Posts")]
    Task<IEnumerable<PostDto>> GetPosts([Query, AliasAs("tenantId")] int tenantId);

    // Obtiene un post por su Id y tenant específicos
    [Get("/api/Posts/{id}")]
    Task<PostDto> GetPost(int id, [Query, AliasAs("tenantId")] int tenantId);

    // Crea un nuevo post para un tenant específico
    [Post("/api/Posts")]
    Task<PostDto> PostPost([Body] PostDto postDto, [Query, AliasAs("tenantId")] int tenantId);

    // Elimina un post por su Id y tenant específicos
    [Delete("/api/Posts/{id}")]
    Task<bool> DeletePost(int id, [Query, AliasAs("tenantId")] int tenantId);

    // Crea un nuevo post de respuesta para un post específico y tenant
    [Post("/api/Posts/{PostId}/respuestas")]
    Task<PostDto> RespuestaPost(int PostId, [Body] PostDto postDto, [Query, AliasAs("tenantId")] int tenantId);

    // Obtiene una lista de respuestas para un post específico y tenant
    [Get("/api/Posts/{PostId}/respuestas")]
    Task<IEnumerable<PostDto>> GetRespuestaPost(int PostId, [Query, AliasAs("tenantId")] int tenantId);
}
