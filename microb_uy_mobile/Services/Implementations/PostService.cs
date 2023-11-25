// Clase de implementación para la interfaz del servicio de posts
using microb_uy_mobile.DTOs;
using Refit;

internal class PostsService : IPostService
{
    private readonly IPostService _postservice;

    public PostsService(string apiUrl)
    {
        _postservice = RestService.For<IPostService>(apiUrl);
    }

    // Métodos públicos que llaman a las operaciones de la interfaz
    
    // Obtiene una lista de posts para un tenant específico
    public async Task<IEnumerable<PostDto>> GetPosts(int tenantId) => await _postservice.GetPosts(tenantId);

    // Obtiene un post por su Id y tenant específicos
    public async Task<PostDto> GetPost(int id, int tenantId) => await _postservice.GetPost(id, tenantId);
    
    // Crea un nuevo post para un tenant específico
    public async Task<PostDto> PostPost(PostDto postDto, int tenantId) => await _postservice.PostPost(postDto, tenantId);

    // Elimina un post por su Id y tenant específicos
    public async Task<bool> DeletePost(int id, int tenantId) => await _postservice.DeletePost(id, tenantId);

    // Crea un nuevo post de respuesta para un post específico y tenant
    public async Task<PostDto> RespuestaPost(int postId, PostDto postDto, int tenantId) =>
        await _postservice.RespuestaPost(postId, postDto, tenantId);

    // Obtiene una lista de respuestas para un post específico y tenant
    public async Task<IEnumerable<PostDto>> GetRespuestaPost(int postId, int tenantId) =>
        await _postservice.GetRespuestaPost(postId, tenantId);
}
