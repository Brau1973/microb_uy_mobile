using microb_uy_mobile.DTOs;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using MvvmHelpers;
using Refit;
using ObservableObject = Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject;

namespace microb_uy_mobile.ViewModels.Integrations
{
    public partial class IntegrationsHomePageViewModel : ObservableObject
    {
        private readonly string BaseApiUrl = (string)App.SessionInfo["BaseUrl"];
        private readonly int TenantId = (int)App.SessionInfo["MainTenantId"];
        private readonly int LoggedUserId = (int)App.SessionInfo["LoggedUserId"];
        private readonly IntegracionDto IntegratedTenant = (IntegracionDto)App.SessionInfo["IntegratedTenant"];

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

        public IntegrationsHomePageViewModel()
        {
            // Ejecutar la carga de posts en una tarea separada enseguida se renderiza el home
            Task.Run(async () => await GetPostList());
        }

        // -------------------------------- METODOS --------------------------------
        private async Task<List<PostDto>> DownloadPostsAsync(int pageSize)
        {
            if (IntegratedTenant.IntegracionPost == true)
            {
                var api = RestService.For<IPostService>(BaseApiUrl);
                var postResponse = await api.GetPostsIntegrados(TenantId, IntegratedTenant.TenantId, pageSize, _lastId, LoggedUserId, TenantId);

                if (postResponse?.Results != null && postResponse.Results.Any())
                {
                    _lastId = postResponse.Results.Last().Id;
                    _hasMorePosts = postResponse.Results.Count() == pageSize; // Corrección aquí
                }
                else
                {
                    _hasMorePosts = false;
                }

                return postResponse?.Results?.ToList() ?? new List<PostDto>();
            }
            else
            {
                return new List<PostDto>(); //Lista vacia
            }
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
                        if (IntegratedTenant.IntegracionPost == true)
                        {
                            //LA INTEGRACION ESTA ACTIVADA SOLO QUE NO HAY POSTS
                            LabelMsg = "Aun no hay Posts en esta Integracion!";
                        }
                        else
                        {
                            //INTEGRACION DESACTIVADA
                            LabelMsg = "Integracion desactivada.";
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Integracion GetPostList: {ex}");
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
                Console.WriteLine($"Error en Integracion LoadMoreData: {ex}");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}