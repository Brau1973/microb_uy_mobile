﻿using microb_uy_mobile.DTOs;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using MvvmHelpers;
using Refit;
using ObservableObject = Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject;

namespace microb_uy_mobile.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly string BaseApiUrl = (string)App.SessionInfo["BaseUrl"];
        private readonly int TenantId = (int)App.SessionInfo["MainTenantId"];
        private readonly int LoggedUserId = (int)App.SessionInfo["LoggedUserId"];

        //-------------------------------- INFO PAGINADO --------------------------------
        //TODO ADAPTAR EL USO DE LASTID
        private int? _lastId;
        private int _pageSize = 10;
        private bool _hasMorePosts = true;

        public ObservableRangeCollection<PostDto> PostList { get; set; } = new ObservableRangeCollection<PostDto>();

        //-------------------------------- OBSERVABLES PARA COMPORTAMIENTO DE LA VISTA --------------------------------

        [ObservableProperty]
        private string _labelMsg;

        [ObservableProperty]
        private bool _isLabelVisible;

        [ObservableProperty]
        private bool _isBusy = false;

        [ObservableProperty]
        private bool _isLoading = false;

        public HomePageViewModel()
        {
            // Ejecutar la carga de posts en una tarea separada enseguida se renderiza el home
            Task.Run(async () => await GetPostList());
        }

        // -------------------------------- METODOS --------------------------------
        private async Task<List<PostDto>> DownloadPostsAsync(int pageSize)
        {
            var api = RestService.For<IPostService>(BaseApiUrl);
            var postResponse = await api.GetPaginatedPosts(TenantId, pageSize, _lastId, "", LoggedUserId, TenantId);

            if (postResponse?.Results != null && postResponse.Results.Any())
            {
                _lastId = postResponse.Results.Last().Id;
                _hasMorePosts = postResponse.Results.Count() == pageSize; // Corrección aquí
            }
            else
            {
                _hasMorePosts = false;
            }

            return postResponse?.Results.ToList() ?? new List<PostDto>();
        }

        [ICommand]
        public async Task GetPostList()
        {
            _lastId = null;
            _hasMorePosts = true;
            IsLoading = false;
            PostList.Clear();
            IsLoading = false; 
            IsBusy = true;
            try
            {
                var results = await DownloadPostsAsync(_pageSize);
                App.Current.Dispatcher.Dispatch(() =>
                {
                    IsBusy = false;
                    if (results.Count > 0)
                    {
                        IsLabelVisible = false;
                        PostList.ReplaceRange(results);
                    }
                    else
                    {
                        IsLabelVisible = true;
                        LabelMsg = "Aun no hay Posts en este foro!";
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetPostList: {ex}");
            }
        }

        [ICommand]
        public async Task LoadMoreData()
        {
            if (IsLoading || !_hasMorePosts) return;

            IsLoading = true;
            try
            {
                await Task.Delay(500);
                var results = await DownloadPostsAsync(_pageSize);
                PostList.AddRange(results);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en LoadMoreData: {ex}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        //public void LoadSampleData()
        //    {
        //        // Aquí, en lugar de datos hardcodeados, deberías realizar una llamada a tu servicio REST para obtener los posts.
        //        // Cuando el servicio esté disponible, reemplaza el código de prueba con datos reales.

        //        // Ejemplo de datos hardcodeados (reemplaza esto con la integración real):
        //        Posts = new ObservableCollection<PostDto>();

        //        // Generar algunos posts normales
        //        for (int i = 1; i <= 5; i++)
        //        {
        //            Posts.Add(GenerarPostNormal($"Usuario{i}", $"Contenido del post {i}", $"Titulo del post{i}"));
        //        }

        //        // Generar algunos reposts con información de repost referenciado
        //        for (int i = 1; i <= 3; i++)
        //        {
        //            PostDto postOriginal = GenerarPostNormal($"Usuario{i}", $"Contenido original del post {i}", $"Titulo original del post {i}");

        //            PostDto repost = new PostDto
        //            {
        //                AutorImg = "https://img.freepik.com/vector-premium/perfil-avatar-hombre-icono-redondo_24640-14044.jpg",
        //                Autor = $"Usuario{i + 10}", // Usuario diferente para el repost
        //                Title = $"Titulo de la cita {i}",
        //                Contenido = $"Este es una cita del post original {i}",
        //                Fecha = DateTime.Now.AddHours(-i),
        //                TipoPost = "REPOST",
        //                Repost = postOriginal,
        //                Likes = i * 3,
        //                CantRespuestas = i * 2
        //            };

        //            Posts.Add(repost);
        //        }
        //    }

        //    // Método para generar un post normal
        //    private PostDto GenerarPostNormal(string autor, string contenido, string titulo)
        //    {
        //        // Genera likes aleatorios para fines de prueba
        //        int likes = new Random().Next(1, 10);

        //        return new PostDto
        //        {
        //            AutorImg = "https://img.freepik.com/vector-premium/perfil-avatar-hombre-icono-redondo_24640-14044.jpg",
        //            Autor = autor,
        //            Title = titulo,
        //            Contenido = contenido,
        //            Fecha = DateTime.Now,
        //            TipoPost = "NORMAL",
        //            Likes = likes,
        //            CantRespuestas = new Random().Next(0, 5), // Genera respuestas aleatorias para fines de prueba
        //            Likeado = likes % 2 == 0 // 'true' si es par, 'false' si es impar
        //        };
        //    }
        //}

    }
}